using LibraryManagementSystem.Resources;

namespace LibraryManagementSystem.Apllication.Validators;

public class AuthorValidator : IValidator<Author>
{
    public void Validate(Author author)
    {
        if (author.Id == null) throw new Exception(Messages.AuthorIdIsEmpty);
        if (string.IsNullOrEmpty(author.Name)) throw new Exception(Messages.AuthorNameIsEmpty);
        if (author.Name.Length > 100) throw new Exception(Messages.AuthorNameTooLong);
        if (author.DateOfBirth == null) throw new Exception(Messages.AuthorDateOfBirthIsEmpty);
        if (author.DateOfBirth >= DateOnly.FromDateTime(DateTime.Today)) throw new Exception(Messages.AuthorDateOfBirthInvalid);
    }
}