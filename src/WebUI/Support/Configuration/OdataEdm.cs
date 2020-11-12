using CleanArchitecture.Domain.Entities;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Support.Configuration
{
    public static class OdataEdm
    {

        public static IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);
            builder.EnableLowerCamelCase();
            builder.EntitySet<TodoBasic>("TodoBasic")
               .EntityType
               .Filter()
               .Count()
               .Expand(50)
               .OrderBy()
               .Page()
               .Select();

            return builder.GetEdmModel();
        }
    }
}

