using BlazorMap.Shared.Entities;
using BlazorMap.Shared.Helpers;

namespace BlazorMap.Client.Services.Auth
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Login(UserLogin request);
        
        Task<bool> IsUserAuthenticated();

        Task<ServiceResponse<int>> Register(UserRegister request);
    }
}
