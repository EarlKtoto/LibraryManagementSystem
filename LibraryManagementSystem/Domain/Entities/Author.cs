using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem;

public class Author
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public ICollection<Book> Books { get; set; }
}