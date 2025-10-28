namespace LibraryManagementSystem.Api.DTOs;

public static class MappingExtensions
{
    public static AuthorReadDto ToReadDto(this Author author)
    {
        return new AuthorReadDto
        {
            Id = author.Id,
            Name = author.Name,
            DateOfBirth = author.DateOfBirth
        };
    }

    public static Author ToEntity(this AuthorCreateDto dto, int id = 0)
    {
        return new Author
        {
            Id = id,
            Name = dto.Name,
            DateOfBirth = dto.DateOfBirth
        };
    }

    public static BookReadDto ToReadDto(this Book book)
    {
        return new BookReadDto
        {
            Id = book.Id,
            Title = book.Title,
            PublisherYear = book.PublisherYear,
            AuthorId = book.AuthorId
        };
    }

    public static Book ToEntity(this BookCreateDto dto, int id = 0)
    {
        return new Book
        {
            Id = id,
            Title = dto.Title,
            PublisherYear = dto.PublisherYear,
            AuthorId = dto.AuthorId
        };
    }
}