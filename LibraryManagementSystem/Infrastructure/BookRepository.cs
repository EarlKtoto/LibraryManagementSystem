namespace LibraryManagementSystem;

public class BookRepository : IBookRepository
{
    private LibraryDbContext _db;
    
    public BookRepository(LibraryDbContext context)
    {
        _db = context;
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

    public Book? GetById(int id)
    {
        return _db.Book.Find(b => b.Id == id);
    }

    public List<Book> GetAll()
    {
        return _db.Book;
    }
}