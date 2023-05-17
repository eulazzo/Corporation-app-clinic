using FluentValidation.AspNetCore;
using Manager.Validator;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Api.Configurations;

public static class FluentValidationConfig
{
    public static void AddFluentValidationConfiguration(this IServiceCollection services)
    {
        services.AddControllers()
            .AddNewtonsoftJson(x =>
            {
                x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                x.SerializerSettings.Converters.Add(new StringEnumConverter());
            })
            .AddJsonOptions(p => p.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
       .AddFluentValidation(p =>
        {
            p.RegisterValidatorsFromAssemblyContaining<NewClientValidator>();
            p.RegisterValidatorsFromAssemblyContaining<NewAddressValidator>();
            p.RegisterValidatorsFromAssemblyContaining<UpdateClientValidator>();
            p.RegisterValidatorsFromAssemblyContaining<NovoTelefoneValidator>();
            p.RegisterValidatorsFromAssemblyContaining<NovoMedicoValidator>();
            p.RegisterValidatorsFromAssemblyContaining<AlteraMedicoValidator>();
            p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
        });
    }
}
