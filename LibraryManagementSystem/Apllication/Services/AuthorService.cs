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
        catch 
        {
            throw;
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
        catch 
        {
            throw;
        }
    }
    
    public List<Author> GetAllAuthorsInformation()
    {
        try
        {
            return _authorRepository.GetAll();
        }
        catch 
        {
            throw;
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
        catch 
        {
            throw;
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
        catch 
        {
            throw;
        }
    }
}