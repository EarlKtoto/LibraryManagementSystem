namespace LibraryManagementSystem;

public class Book 
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int PublisherYear { get; set; }
    public int AuthorId { get; set; }
}