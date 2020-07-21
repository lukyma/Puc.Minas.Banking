using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puc.Minas.Banking.WebApi.Config.Swagger
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfig(this SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = $"Puc.Minas.Banking",
                Version = "v1",
                Description = "Api de integração com o Puc Minas Banking."
            });
        }
    }
}
