﻿using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvoidForgetting.SwaggerModel
{
    /// <summary>
    /// Swagger description
    /// </summary>
    public class ApplyTagDescriptions : IDocumentFilter
    {
        /// <summary>
        /// apply 方法
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new List<OpenApiTag>
            {
                new OpenApiTag{Name ="Login",Description="Login Doc"}
            };
        }
    }
}
