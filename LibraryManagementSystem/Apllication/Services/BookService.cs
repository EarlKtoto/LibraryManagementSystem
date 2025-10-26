namespace LibraryManagementSystem;

public class BookService
{
    private IBookRepository _bookRepository;
    private IAuthorRepository _authorRepository;

    public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
    }

    public void AddNewBook(Book book)
    {
        try
        {
            var existBook = _bookRepository.GetById(book.Id);
            if (existBook != null) throw new Exception("Книга уже существует!");
            if (_authorRepository.GetById(book.AuthorId) == null)
                throw new Exception("Автор для этой книги не найден");
            _bookRepository.Create(book);
        }
        catch 
        {
            throw;
        }
    }

    public Book GetBookInformation(int id)
    {
        try
        {
            var existBook = _bookRepository.GetById(id);
            if (existBook == null) throw new Exception("Книга не найдена!");
            return _bookRepository.GetById(id);
        }
        catch 
        {
            throw;
        }
    }
    
    public List<Book> GetAllBooksInformation()
    {
        try
        {
            return _bookRepository.GetAll();
        }
        catch 
        {
            throw;
        }
    }

    public void UpdateBookInformation(Book book)
    {
        try
        {
            var existBook = _bookRepository.GetById(book.Id);
            if (existBook == null) throw new Exception("Книга не найдена!");
            _bookRepository.Update(book);
        }
        catch 
        {
            throw;
        }
    }

    public void DeleteBook(int id)
    {
        try
        {
            var existBook = _bookRepository.GetById(id);
            if (existBook == null) throw new Exception("Книга не найдена!");
            _bookRepository.Delete(_bookRepository.GetById(id));
        }
        catch 
        {
            throw;
        }
    }
}