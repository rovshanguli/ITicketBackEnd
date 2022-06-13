using System.Collections.Generic;

namespace ServiceLayer.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(string email,string name, List<string> roles);
    }
}
