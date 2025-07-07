namespace bellosoft.Domain.Entities.Errors
{
    public class NotFoundException(string message) : Exception(message) { }
}
