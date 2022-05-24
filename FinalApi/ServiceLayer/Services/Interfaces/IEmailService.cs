using ServiceLayer.DTOs.AppUser;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IEmailService
    {
        Task Register(RegisterDto registerDto);
        Task ConfirmEmail(string userId, string token);
    }
}
