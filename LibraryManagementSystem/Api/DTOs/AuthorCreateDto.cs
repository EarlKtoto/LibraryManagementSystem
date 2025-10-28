namespace LibraryManagementSystem.Api.DTOs;

public class AuthorCreateDto
{
    public string Name { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
}