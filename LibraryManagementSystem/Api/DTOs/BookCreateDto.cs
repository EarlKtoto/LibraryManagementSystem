namespace LibraryManagementSystem.Api.DTOs;

public class BookCreateDto
{
    public string Title { get; set; } = string.Empty;
    public int PublisherYear { get; set; }
    public int AuthorId { get; set; }
}