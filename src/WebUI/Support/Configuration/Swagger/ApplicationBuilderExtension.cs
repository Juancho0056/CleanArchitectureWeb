using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Support.Configuration.Swagger
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder ConfigureSwaggerUI(this IApplicationBuilder app)
        {
            //app.UseSwaggerUi3(settings =>
            //{

            //    settings.Path = "/api";
            //    settings.DocumentPath = "/api/specification.json";
            //});
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitecture Services v1");
            });
            return app;
        }

        public static IApplicationBuilder ConfigureCors(this IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
            return app;
        }
    }
}
