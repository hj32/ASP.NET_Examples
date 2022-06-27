using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace ServiceLifetimeExample.Intrastructure
{
    public class EndpointInfo
    {


        /// <summary>
        /// Make the endpoints available to see.
        /// Navigate to /debug/routes to see a list of endpoints
        /// </summary>
        /// <param name="app">A IEndpointRoutBuilder e.g. WebApplication in the Startup.cs Configure Method</param>
        public void MapEndpoints(IEndpointRouteBuilder app) 
        {
            
            app.MapGet("/debug/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
            string.Join("\n", endpointSources.SelectMany(source => source.Endpoints))); 
        }


        public void MapEndpointsDetail(IEndpointRouteBuilder app) 
        {
            app.MapGet("/debug/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
            {
                var sb = new StringBuilder();
                var endpoints = endpointSources.SelectMany(es => es.Endpoints);
                foreach (var endpoint in endpoints)
                {
                    if (endpoint is RouteEndpoint routeEndpoint)
                    {
                        _ = routeEndpoint.RoutePattern.RawText;
                        _ = routeEndpoint.RoutePattern.PathSegments;
                        _ = routeEndpoint.RoutePattern.Parameters;
                        _ = routeEndpoint.RoutePattern.InboundPrecedence;
                        _ = routeEndpoint.RoutePattern.OutboundPrecedence;
                    }

                    var routeNameMetadata = endpoint.Metadata.OfType<Microsoft.AspNetCore.Routing.RouteNameMetadata>().FirstOrDefault();
                    _ = routeNameMetadata?.RouteName;

                    var httpMethodsMetadata = endpoint.Metadata.OfType<HttpMethodMetadata>().FirstOrDefault();
                    _ = httpMethodsMetadata?.HttpMethods; // [GET, POST, ...]

                    // There are many more metadata types available...
                }
            });
        }

        /// <summary>
        /// Try and list Razor pages
        /// </summary>
        /// <param name="app"></param>
        public static void getpages(IHost app) 
        {
            var provider = app.Services.GetRequiredService<IActionDescriptorCollectionProvider>();
            var pageEndpoints = provider.ActionDescriptors.Items.OfType<CompiledPageActionDescriptor>();
            string table = HTMLWrapper.ToHtmlTable(pageEndpoints);
            
               
      

           
            

            /*StringBuilder sb = new StringBuilder();
           foreach (CompiledPageActionDescriptor cpad in pageEndpoints) 
           {
              sb.Append( cpad.ModelTypeInfo);
              sb.Append(" | ");
              sb.Append(cpad.DisplayName);

           }*/

            int x;
            x = 0;

        }

        /// <summary>
        /// Get a console logger
        /// </summary>
        /// <returns></returns>
        public static ILogger GetConsoleLogger() 
        {

            using var loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder
                .SetMinimumLevel(LogLevel.Trace)
                .AddConsole());
            ILogger logger = loggerFactory.CreateLogger<Program>();

            return logger;
        }


        public static string DisplayCompiledPageActionDescriptor(IEnumerable <CompiledPageActionDescriptor> descriptors) 
        {

            return string.Empty;
        }
    }
}
