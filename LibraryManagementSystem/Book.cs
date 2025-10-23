namespace LibraryManagementSystem;

public class Book : IModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int PublisherYear { get; set; }
    public Author AuthorId { get; set; }
}