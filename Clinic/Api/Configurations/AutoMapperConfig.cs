using Manager.Mappings;

namespace Api.Configurations;

public static class AutoMapperConfig
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        //services.AddAutoMapper(typeof(NewClientMappingsProfile), typeof(UpdateClientMappingsProfile));
        services.AddAutoMapper(
            typeof(NewClientMappingsProfile),
            typeof(UpdateClientMappingsProfile),
            typeof(NewDoctorMappingsProfile),
            typeof(UsuarioMappingProfile));
    }

}
