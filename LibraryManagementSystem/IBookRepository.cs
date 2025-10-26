namespace LibraryManagementSystem;

public interface IBookRepository
{
    public void Create(Book book);
    public void Update(Book book);
    public void Delete(Book book);
    public Book GetById(int id);
    public List<Book> GetAll();
}