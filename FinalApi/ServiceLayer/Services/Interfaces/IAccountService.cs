using ServiceLayer.DTOs.AppUser;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IAccountService
    {
        Task Regsiter(RegisterDto registerDto);
        Task<string> Login(LoginDto loginDto);

    }
}
