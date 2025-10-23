namespace LibraryManagementSystem;

public class Author : IModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
}