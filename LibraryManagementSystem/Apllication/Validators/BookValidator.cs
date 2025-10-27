using LibraryManagementSystem.Resources;

namespace LibraryManagementSystem.Apllication.Validators;

public class BookValidator : IValidator<Book>
{
    public void Validate(Book book)
    {
        if (book.Id == null) throw new Exception(Messages.BookIdIsEmpty);
        if (string.IsNullOrEmpty(book.Title)) throw new Exception(Messages.BookTitleIsEmpty);
        if (book.Title.Length > 500) throw new Exception(Messages.BookTitleTooLong);
        if (book.PublisherYear == null) throw new Exception(Messages.BookPublisherYearIsEmpty);
        if (book.PublisherYear > DateTime.Today.Year) throw new Exception(Messages.BookPublisherYearInvalid);
        if (book.AuthorId == null) throw new Exception(Messages.BookAuthorIsEmpty);
    }
}