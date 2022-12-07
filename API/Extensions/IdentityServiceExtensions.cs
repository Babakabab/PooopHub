using Domain;
using Microsoft.AspNetCore.Identity;
using Persistance;

namespace API.Extensions;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddIdentityCore<AppUser>(opt =>
        {
            opt.Password.RequireUppercase = false;
        }).AddEntityFrameworkStores<DataContext>().AddSignInManager<SignInManager<AppUser>>();
        services.AddAuthentication();
        return services;
    }
}