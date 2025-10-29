using LibraryManagementSystem;
using LibraryManagementSystem.Api.DTOs;
using LibraryManagementSystem.Apllication.Validators;
using LibraryManagementSystem.Resources;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<LibraryDbContext>();

builder.Services.AddSingleton<IAuthorRepository, AuthorRepository>();
builder.Services.AddSingleton<IBookRepository, BookRepository>();

builder.Services.AddScoped<AuthorValidator>();
builder.Services.AddScoped<BookValidator>();

builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<BookService>();

var app = builder.Build();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;
        
        var error = context.Features.Get<IExceptionHandlerFeature>().Error;   
        
        context.Response.WriteAsJsonAsync(new {error = error.Message});
    });
});
    
app.MapGet("/authors", (AuthorService authorService) =>
{
    var authors = authorService.GetAllAuthorsInformation();
    var dtos = new List<AuthorReadDto>();

    foreach (var author in authors)
        dtos.Add(author.ToReadDto());

    return Results.Ok(dtos);
});

app.MapGet("/authors/{id:int}", (int id, AuthorService authorService) =>
{
    var author = authorService.GetAuthorInformation(id);
    return Results.Ok(author.ToReadDto());
});

app.MapPost("/authors", (AuthorCreateDto dto, AuthorService authorService) =>
{
    var author = dto.ToEntity();
    authorService.AddNewAuthor(author);
    return Results.Ok(Messages.AuthorAdded);
});

app.MapPut("/authors/{id:int}", (int id, AuthorCreateDto dto, AuthorService authorService) =>
{
    var author = dto.ToEntity(id);
    authorService.UpdateAuthorInformation(author);
    return Results.Ok(Messages.AuthorUpdated);
});

app.MapDelete("/authors/{id:int}", (int id, AuthorService authorService) =>
{
    authorService.DeleteAuthor(id);
    return Results.Ok(Messages.AuthorDeleted);
});

app.MapGet("/authors/withbookcount", (AuthorService authorService) =>
{
    var authors = authorService.GetAuthorsWithBookCount();
    return Results.Ok(authors);
});

app.MapGet("/authors/byname/{name}", (string name, AuthorService authorService) =>
{
    var author = authorService.FindAuthorByName(name);
    return Results.Ok(author.ToReadDto());
});

app.MapGet("/books", (BookService bookService) =>
{
    var books = bookService.GetAllBooksInformation();
    var dtos = new List<BookReadDto>();

    foreach (var book in books)
        dtos.Add(book.ToReadDto());

    return Results.Ok(dtos);
});

app.MapGet("/books/{id:int}", (int id, BookService bookService) =>
{
    var book = bookService.GetBookInformation(id);
    return Results.Ok(book.ToReadDto());
});

app.MapPost("/books", (BookCreateDto dto, BookService bookService) =>
{
    var book = dto.ToEntity();
    bookService.AddNewBook(book);
    return Results.Ok(Messages.BookAdded);
});

app.MapPut("/books/{id:int}", (int id, BookCreateDto dto, BookService bookService) =>
{
    var book = dto.ToEntity(id);
    bookService.UpdateBookInformation(book);
    return Results.Ok(Messages.BookUpdated);
});

app.MapDelete("/books/{id:int}", (int id, BookService bookService) =>
{
    bookService.DeleteBook(id);
    return Results.Ok(Messages.BookDeleted);
});

app.MapGet("/books/afteryear/{year:int}", (int year, BookService bookService) =>
{
    var books = bookService.GetBooksCreatedAfter(year);
    var dtos = new List<BookReadDto>();

    foreach (var book in books)
        dtos.Add(book.ToReadDto());
    
    return Results.Ok(dtos);
});

app.Run();