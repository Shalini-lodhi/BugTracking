using BugTracking.ViewModels;

namespace BugTracking.Services
{
    public interface IAuthService
    {
        Task Register(UserCreateViewModel user);
        Task<JwtViewModel> Login(LoginViewModel loginViewModel);
    }
}
