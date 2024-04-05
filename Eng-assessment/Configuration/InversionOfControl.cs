using Eng_assessment.Repositories;
using Eng_assessment.Repositories.Interface;
using Eng_assessment.Services;
using Eng_assessment.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Models.Entities.User;

namespace Eng_assessment.Configuration
{
    public class InversionOfControl
    {
        public static void ConfigureInjections(IServiceCollection services, string connectionString)
        {
            #region [Common]
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connectionString));
            #endregion

            #region AutoMapper

            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            #endregion

            #region [Repositories]

            #region User
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #endregion

            #region [Services]

            #region User
            services.AddScoped<IUserService, UserService>();
            #endregion

            #endregion
        }
    }
}
