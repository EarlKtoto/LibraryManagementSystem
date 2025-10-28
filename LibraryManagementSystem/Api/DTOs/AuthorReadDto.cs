namespace LibraryManagementSystem.Api.DTOs;

public class AuthorReadDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
}