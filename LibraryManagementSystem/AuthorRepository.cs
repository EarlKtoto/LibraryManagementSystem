namespace LibraryManagementSystem;

public class AuthorRepository
{
    private string _connectionString;
    private LibraryDbContext _db;

    public AuthorRepository(string connectionString, LibraryDbContext db)
    {
        _connectionString = connectionString;
        _db = db;
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

    public Author GetAuthor(int id)
    {
        return _db.Author.Find(a => a.Id == id);
    }

    public List<Author> GetAuthors()
    {
        return _db.Author;
    }
}