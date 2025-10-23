namespace LibraryManagementSystem;

public interface IRepository
{
    public void Create(IModel model);
    public void Update(IModel model);
    public void Delete(IModel model);
    public IModel GetById(int id);
    public List<IModel> GetAll();
}