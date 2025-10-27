using LibraryManagementSystem.Apllication.Validators;
using LibraryManagementSystem.Resources;

namespace LibraryManagementSystem;

public class AuthorService
{
    private IAuthorRepository _authorRepository;
    private IValidator<Author> _authorValidator;

    public AuthorService(IAuthorRepository authorRepository, AuthorValidator authorValidator)
    {
        _authorRepository = authorRepository;
        _authorValidator = authorValidator;
    }

    public void AddNewAuthor(Author author)
    {
        _authorValidator.Validate(author);
        var existAuthor = _authorRepository.GetById(author.Id);
        if (existAuthor != null) throw new Exception(Messages.AuthorAlreadyExists);
        _authorRepository.Create(author);
    }

    public Author GetAuthorInformation(int id)
    {
        var existAuthor = _authorRepository.GetById(id);
        if (existAuthor == null) throw new Exception(Messages.AuthorNotFound);
        return _authorRepository.GetById(id);
    }
    
    public List<Author> GetAllAuthorsInformation()
    {
        return _authorRepository.GetAll();
    }

    public void UpdateAuthorInformation(Author author)
    {
        _authorValidator.Validate(author);
        var existAuthor = _authorRepository.GetById(author.Id);
        if (existAuthor == null) throw new Exception(Messages.AuthorNotFound);
        _authorRepository.Update(author);
    }

    public void DeleteAuthor(int id)
    {
        var existAuthor = _authorRepository.GetById(id);
        if (existAuthor == null) throw new Exception(Messages.AuthorNotFound);
        _authorRepository.Delete(_authorRepository.GetById(id));
    }
}