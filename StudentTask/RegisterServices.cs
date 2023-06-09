using StudentTask.Data;
using StudentTask.Services;
using static StudentTask.RegisterServices;

namespace StudentTask
{
    public class RegisterServices
    {
        public static class RegisterServe
        {
            public static void RegisterServicess(IServiceCollection services)
            {
                Configure(services, DataRegister.GetTypes());
                Configure(services, RegisterServicesss.GetTypes());
            }
            public static void Configure(IServiceCollection services, Dictionary<Type, Type> types)
            {
                foreach (var type in types)
                {
                    services.AddScoped(type.Key, type.Value);

                }
                services.AddMvc().AddSessionStateTempDataProvider();
                services.AddSession();
            }
        }
    }
}
