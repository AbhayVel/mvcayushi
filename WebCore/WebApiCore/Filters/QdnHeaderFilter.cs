﻿using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Filters
{
    public class QdnHeaderFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            
            //if (operation.Parameters == null)
            //    operation.Parameters = new List<IParameter>();

            //operation.Parameters.Add(new NonBodyParameter
            //{
            //    Name = "MY-HEADER",
            //    In = "header",
            //    Type = "string",
            //    Required = true // set to false if this is optional
            //});
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name="token",
                In=  ParameterLocation.Header,                
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Accept",
                In = ParameterLocation.Header,
            });
        }
    }
}
