namespace bellosoft.Domain.Entities.Errors
{
    public class BadRequestException(string message) : Exception(message) { }
}
