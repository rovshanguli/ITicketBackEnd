using System.Collections.Generic;

namespace ServiceLayer.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(string name, List<string> roles);
    }
}
