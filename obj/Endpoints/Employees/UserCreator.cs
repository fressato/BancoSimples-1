using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BancoSimples.Endpoints.Employees
{
    public class UserCreator
    {
        internal async Task<(IdentityResult identity, string userId)> Create(string email, string password, List<Claim> userClaims)
        {
            throw new NotImplementedException();
        }
    }
}