namespace LibraryManagementSystem.Apllication.Validators;

public interface IValidator<T>
{
    void Validate(T entity);
}