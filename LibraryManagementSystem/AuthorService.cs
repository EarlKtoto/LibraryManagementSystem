namespace LibraryManagementSystem;

public class AuthorService
{
    private IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public void AddNewAuthor(Author author)
    {
        try
        {
            var existAuthor = _authorRepository.GetById(author.Id);
            if (existAuthor != null) throw new Exception("Автор уже существует!");
            _authorRepository.Create(author);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
            return;
        }
    }

    public Author GetAuthorInformation(int id)
    {
        try
        {
            var existAuthor = _authorRepository.GetById(id);
            if (existAuthor == null) throw new Exception("Автор не найден!");
            return _authorRepository.GetById(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
            return null;
        }
    }
    
    public List<Author> GetAllAuthorsInformation()
    {
        try
        {
            return _authorRepository.GetAll();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
            return null;
        }
    }

    public void UpdateAuthorInformation(Author author)
    {
        try
        {
            var existAuthor = _authorRepository.GetById(author.Id);
            if (existAuthor == null) throw new Exception("Автор не найден!");
            _authorRepository.Update(author);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    public void DeleteAuthor(int id)
    {
        try
        {
            var existAuthor = _authorRepository.GetById(id);
            if (existAuthor == null) throw new Exception("Автор не найден!");
            _authorRepository.Delete(_authorRepository.GetById(id));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}