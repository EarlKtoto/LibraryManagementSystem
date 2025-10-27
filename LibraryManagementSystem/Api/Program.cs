using LibraryManagementSystem;
using LibraryManagementSystem.Apllication.Validators;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<LibraryDbContext>();

builder.Services.AddSingleton<IAuthorRepository, AuthorRepository>();
builder.Services.AddSingleton<IBookRepository, BookRepository>();

builder.Services.AddScoped<IValidator<Author>, AuthorValidator>();
builder.Services.AddScoped<IValidator<Book>, BookValidator>();

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
    return Results.Ok(authorService.GetAllAuthorsInformation());
});

app.MapGet("/authors/{id:int}", (int id, AuthorService authorService) =>
{
    try
    {
        var author = authorService.GetAuthorInformation(id);
        return Results.Ok(author);
    }
    catch (Exception ex)
    {
        return Results.NotFound(ex.Message);
    }
});

app.MapPost("/authors", (Author author, AuthorService authorService) =>
{
    try
    {
        authorService.AddNewAuthor(author);
        return Results.Ok("Автор успешно добавлен");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapPut("/authors/{id:int}", (int id, Author author, AuthorService authorService) =>
{
    try
    {
        author.Id = id;
        authorService.UpdateAuthorInformation(author);
        return Results.Ok("Автор обновлен");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapDelete("/authors/{id:int}", (int id, AuthorService authorService) =>
{
    try
    {
        authorService.DeleteAuthor(id);
        return Results.Ok("Автор удален");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapGet("/books", (BookService bookService) =>
{
    return Results.Ok(bookService.GetAllBooksInformation());
});

app.MapGet("/books/{id:int}", (int id, BookService bookService) =>
{
    try
    {
        var book = bookService.GetBookInformation(id);
        return Results.Ok(book);
    }
    catch (Exception ex)
    {
        return Results.NotFound(ex.Message);
    }
});

app.MapPost("/books", (Book book, BookService bookService) =>
{
    try
    {
        bookService.AddNewBook(book);
        return Results.Ok("Книга добавлена");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapPut("/books/{id:int}", (int id, Book book, BookService bookService) =>
{
    try
    {
        book.Id = id;
        bookService.UpdateBookInformation(book);
        return Results.Ok("Книга обновлена");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapDelete("/books/{id:int}", (int id, BookService bookService) =>
{
    try
    {
        bookService.DeleteBook(id);
        return Results.Ok("Книга удалена");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.Run();