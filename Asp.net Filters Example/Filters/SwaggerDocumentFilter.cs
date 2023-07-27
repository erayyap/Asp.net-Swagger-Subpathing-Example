using Microsoft.Extensions.Primitives;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Asp.net_Filters_Example.Filters
{
    /// <summary>
    /// This filter shows the appropiate controllers based on the client query string.
    /// </summary>
    public class SwaggerDocumentFilter : IDocumentFilter
    {
        public HttpContext _httpContext => new HttpContextAccessor().HttpContext;

        /// <summary>
        /// Filter data contains which controllers should be shown depending on subpath.
        /// </summary>
        static Dictionary<string, StringValues> filterData = new Dictionary<string, StringValues>
        {
            {"clientX", new [] {
                "A/Method1", "B/Method2"
            } 
            }, 
            {"clientY", new [] {
                "A/Method1", "A/Method2", "B/Method1"
            }
            },
            {"clientZ", new [] {
                "A"
            }
            }
        };
     
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var clientName = _httpContext.Request.Query["client"].FirstOrDefault();
            if (clientName != null)
            {
                if (filterData.ContainsKey(clientName))
                {
                    var keys = swaggerDoc.Paths.Keys;
                    var controllersToRemove = keys.Where(b => filterData[clientName].Any(a => b.Substring(1).StartsWith(a)));
                    foreach (var swaggerPath in controllersToRemove)
                    {
                        swaggerDoc.Paths.Remove(swaggerPath);
                    }
                } else
                {
                    swaggerDoc.Paths.Clear();
                }
            }
        }
    }
}
