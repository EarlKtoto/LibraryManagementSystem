namespace LibraryManagementSystem;

public class AuthorRepository : IAuthorRepository
{
    private LibraryDbContext _db;

    public AuthorRepository(LibraryDbContext context)
    {
        _db = context;
    }

    public void Create(Author author)
    {
        _db.Author.Add(author);
    }

    public void Update(Author author)
    {
        Author _author = _db.Author.Find(a => a.Id == author.Id);
        _author.Name = author.Name;
        _author.DateOfBirth = author.DateOfBirth;
    }

    public void Delete(Author author)
    {
        _db.Author.Remove(author);
    }

    public Author? GetById(int id)
    {
        return _db.Author.Find(a => a.Id == id);
    }

    public List<Author> GetAll()
    {
        return _db.Author;
    }
}