namespace LibraryManagementSystem;

public class BookService
{
    private IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public void AddNewBook(Book book)
    {
        try
        {
            var existBook = _bookRepository.GetById(book.Id);
            if (existBook != null) throw new Exception("Книга уже существует!");
            _bookRepository.Create(book);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
            return;
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
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
            return null;
        }
    }
    
    public List<Book> GetAllBooksInformation()
    {
        try
        {
            return _bookRepository.GetAll();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
            return null;
        }
    }

    public void UpdateBookInformation(Book author)
    {
        try
        {
            var existBook = _bookRepository.GetById(author.Id);
            if (existBook == null) throw new Exception("Книга не найдена!");
            _bookRepository.Update(author);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
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
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}