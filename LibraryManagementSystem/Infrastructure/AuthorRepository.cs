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
        author.Id = this.GetAll().Max(a => a.Id) + 1;
        _db.Authors.Add(author);
    }

    public void Update(Author author)
    {
        Author _author = _db.Authors.FirstOrDefault(a => a.Id == author.Id);
        _author.Name = author.Name;
        _author.DateOfBirth = author.DateOfBirth;
    }

    public void Delete(Author author)
    {
        _db.Authors.Remove(author);
    }

    public Author? GetById(int id)
    {
        return _db.Authors
            .FirstOrDefault(a => a.Id == id);
    }

    public List<Author> GetAll()
    {
        return _db.Authors.ToList();;
    }
}