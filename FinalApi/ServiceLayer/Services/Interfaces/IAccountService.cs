using ServiceLayer.DTOs.AppUser;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IAccountService
    {
        Task Register(RegisterDto registerDto);
        Task<string> Login(LoginDto loginDto);
        Task ConfirmEmail(string userId, string token);
    }
}
