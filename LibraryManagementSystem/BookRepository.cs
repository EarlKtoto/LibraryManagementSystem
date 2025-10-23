namespace LibraryManagementSystem;

public class BookRepository
{
    private string _connectionString;
    private LibraryDbContext _db;
    
    public BookRepository(string connectionString, LibraryDbContext db)
    {
        _connectionString = connectionString;
        _db = db;
    }

    public void Create(Book book)
    {
        _db.Book.Add(book);
    }

    public void Update(Book book)
    {
        Book _book = _db.Book.Find(b =>  b.Id == book.Id);
        _book.Title = book.Title;
        _book.PublisherYear = book.PublisherYear;
        _book.AuthorId = book.AuthorId;
    }

    public void Delete(Book book)
    {
        _db.Book.Remove(book);
    }

    public Book GetBook(int id)
    {
        return _db.Book.Find(b => b.Id == id);
    }

    public List<Book> GetBooks()
    {
        return _db.Book;
    }
}