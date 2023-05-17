using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;

namespace Api.Configurations;

public static class SwaggerConfig
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title="Consultorio Legal",
                    Version="v1",
                    Description="API da aplicação Consultório Legal.",
                    Contact = new OpenApiContact
                    {
                        Name="Lázaro Vanderson",
                        Email = "lazarovanderson@.com",
                        Url = new Uri("https://github.com/eulazzo")
                    },
                    License= new OpenApiLicense
                    {
                        Name="OSD",
                        Url = new Uri("https://opensource.org/osd")
                    },

                    TermsOfService = new Uri("https://opensource.org/osd")
                });

            c.AddFluentValidationRulesScoped();
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Insira o token",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference= new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id ="Bearer"
                        }
                    },
                        Array.Empty<string>()
                    }
            });

            //Pegando via assembly o nome da aplicacao.xml e onde ele está(diretorio base) e concatenando com o nome.
            //Basicamente pegando caminho do xml para ser incluido no SWAGGER

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            c.IncludeXmlComments(xmlPath);

            xmlPath = Path.Combine(AppContext.BaseDirectory, "ClCoreShared.xml");
            c.IncludeXmlComments(xmlPath);


        });
    }

    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.RoutePrefix = string.Empty;
            c.SwaggerEndpoint("./swagger/v1/swagger.json", "CL V1");
        });
    }
}
