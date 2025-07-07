using bellosoft.Domain.Entities.Auth;

namespace bellosoft.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDto dto);
        Task RegisterAsync(RegisterDto dto);
    }
}
