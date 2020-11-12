
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Support.Configuration.Swagger
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureSwaggerDocument(this IServiceCollection services)
        {

            //services.AddOpenApiDocument(configure =>
            //{
            //    configure.Title = Configuration.SwaggerConfiguration.Title;
            //    configure.Version = Configuration.SwaggerConfiguration.Version1;
            //    configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            //    {
            //        Type = OpenApiSecuritySchemeType.ApiKey,
            //        Name = "Authorization",
            //        In = OpenApiSecurityApiKeyLocation.Header,
            //        Description = "Type into the textbox: Bearer {your JWT token}."

            //    });

            //});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = Configuration.SwaggerConfiguration.Version1,
                    Title = Configuration.SwaggerConfiguration.Title,
                    Description = Configuration.SwaggerConfiguration.Description,
                    TermsOfService = new Uri(Configuration.SwaggerConfiguration.TermsOfService),
                    Contact = new OpenApiContact
                    {
                        Name = Configuration.SwaggerConfiguration.ContactName,
                        Email = Configuration.SwaggerConfiguration.ContactEmail,
                        Url = new Uri(Configuration.SwaggerConfiguration.ContactUrl)
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                var xmlFileDocumentationName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlFileDocumentationPath = Path.Combine(AppContext.BaseDirectory, xmlFileDocumentationName);
                c.IncludeXmlComments(xmlFileDocumentationPath);
            });

            return services;
        }
        public static IServiceCollection AddCustomCors(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            return services;
        }
    }
}
