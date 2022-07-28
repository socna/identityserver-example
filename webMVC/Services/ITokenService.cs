using IdentityModel.Client;
using System.Threading.Tasks;

namespace webMVC.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}