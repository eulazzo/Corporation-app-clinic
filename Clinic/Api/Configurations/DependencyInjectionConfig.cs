using CL.Manager.Implementation;
using Data.Repository;
using Manager.Implementatios;
using Manager.Interfaces.Managers;
using Manager.Interfaces.Repositories;

namespace Api.Configurations;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IMedicoRepository, MedicoRepository>();
        services.AddScoped<IClienteManager, ClientManager>();
        services.AddScoped<IMedicoManager, MedicoManager>();
        services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IUsuarioManager, UsuarioManager>();

    }
}
