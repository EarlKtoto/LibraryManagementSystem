namespace LibraryManagementSystem;

public class LibraryDbContext
{
    public LibraryDbContext()
    {
        Author = new List<Author>();
        Book = new List<Book>();
    }
    
    public List<Author> Author {get;set;} = new List<Author>();
    public List<Book> Book {get;set;} = new List<Book>();
}