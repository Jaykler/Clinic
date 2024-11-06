using Clinic.WebApp.Data.Context;
using Clinic.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic.WebApp.Data.Service
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
