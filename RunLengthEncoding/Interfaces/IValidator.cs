namespace RunLengthEncoding.Interfaces
{
    public interface IValidator<T>
    {
        bool TryValidate(T model, out List<string> errors);
    }
}