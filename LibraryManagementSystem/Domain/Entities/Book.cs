using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem;

public class Book 
{
    [Key]
    public int Id { get; set; }
    [MaxLength(500)]
    public string Title { get; set; } = string.Empty;
    public int PublisherYear { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}