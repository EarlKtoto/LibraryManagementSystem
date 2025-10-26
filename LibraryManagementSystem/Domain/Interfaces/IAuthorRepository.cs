namespace LibraryManagementSystem;

public interface IAuthorRepository
{
    public void Create(Author author);
    public void Update(Author author);
    public void Delete(Author author);
    public Author? GetById(int id);
    public List<Author> GetAll();
}