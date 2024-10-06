using Clinic.WebApp.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Clinic.WebApp.Models.Service
{
    public static class ConfigureService
    {
        public static void AddApplicationService(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<ClinicContext>(opt => opt.UseSqlServer(config.GetConnectionString("ClinicConnection")));
            service.AddScoped<User>();
            service.AddScoped<LabColaborador>();
        }
    }
}
