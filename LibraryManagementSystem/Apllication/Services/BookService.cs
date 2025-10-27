using LibraryManagementSystem.Apllication.Validators;
using LibraryManagementSystem.Resources;

namespace LibraryManagementSystem;

public class BookService
{
    private IBookRepository _bookRepository;
    private IAuthorRepository _authorRepository;
    private IValidator<Book> _bookValidator;
    
    public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, BookValidator bookValidator)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _bookValidator = bookValidator;
    }

    public void AddNewBook(Book book)
    {
        _bookValidator.Validate(book);
        var existBook = _bookRepository.GetById(book.Id);
        if (existBook != null) throw new Exception(Messages.BookAlreadyExists);
        if (_authorRepository.GetById(book.AuthorId) == null)
            throw new Exception(Messages.AuthorForBookNotFound);
        _bookRepository.Create(book);
    }

    public Book GetBookInformation(int id)
    {
        var existBook = _bookRepository.GetById(id);
        if (existBook == null) throw new Exception(Messages.BookNotFound);
        return _bookRepository.GetById(id);
    }
    
    public List<Book> GetAllBooksInformation()
    {
        return _bookRepository.GetAll();
    }

    public void UpdateBookInformation(Book book)
    {
        _bookValidator.Validate(book);
        var existBook = _bookRepository.GetById(book.Id);
        if (existBook == null) throw new Exception(Messages.BookNotFound);
        _bookRepository.Update(book);
    }

    public void DeleteBook(int id)
    {
        var existBook = _bookRepository.GetById(id);
        if (existBook == null) throw new Exception(Messages.BookNotFound);
        _bookRepository.Delete(_bookRepository.GetById(id));
    }
}