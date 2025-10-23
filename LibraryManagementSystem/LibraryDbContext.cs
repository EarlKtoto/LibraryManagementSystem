namespace LibraryManagementSystem;

public class LibraryDbContext
{
    public List<Author> Author {get;set;}
    public List<Book> Book {get;set;}

    public LibraryDbContext() 
    {
        Author = new List<Author>();
        Book = new List<Book>();
    }
}