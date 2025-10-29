using LibraryManagementSystem.Api.DTOs;
using LibraryManagementSystem.Apllication.Validators;
using LibraryManagementSystem.Resources;

namespace LibraryManagementSystem;

public class AuthorService
{
    private IAuthorRepository _authorRepository;
    private IBookRepository _bookRepository;
    private AuthorValidator _authorValidator;

    public AuthorService(IAuthorRepository authorRepository,IBookRepository bookRepository, AuthorValidator authorValidator)
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

    public List<AuthorWithBookCountDto> GetAuthorsWithBookCount()
    {
        return _authorRepository.GetAll()
            .Select(a => new AuthorWithBookCountDto()
            {
                Id = a.Id,
                Name = a.Name,
                DateOfBirth = a.DateOfBirth,
                BookCount = a.Books.Count
            })
            .ToList();
    }

    public Author FindAuthorByName(string name)
    {
        return _authorRepository.GetAll()
            .Where(a => a.Name.ToLower().Contains(name.ToLower()))
            .FirstOrDefault();
    }
}