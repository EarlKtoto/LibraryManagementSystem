namespace LibraryManagementSystem.Api.DTOs;

public class BookReadDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int PublisherYear { get; set; }
    public int AuthorId { get; set; }
}