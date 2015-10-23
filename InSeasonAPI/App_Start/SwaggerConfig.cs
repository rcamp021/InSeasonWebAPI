using System.Web.Http;
using WebActivatorEx;
using InSeasonAPI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace InSeasonAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration 
                .EnableSwagger(c =>
                    {
                        // By default, the service root url is inferred from the request used to access the docs.
                        // However, there may be situations (e.g. proxy and load-balanced environments) where this does not
                        // resolve correctly. You can workaround this by providing your own code to determine the root URL.
                        //
                        //c.RootUrl(req => GetRootUrlFromAppConfig());

                        c.Schemes(new[] { "http" });
                        c.SingleApiVersion("v1", "InSeasonAPI");

                        // Set this flag to omit descriptions for any actions decorated with the Obsolete attribute
                        c.IgnoreObsoleteActions();

                       


                        // If you annotate Controllers and API Types with
                        // Xml comments (http://msdn.microsoft.com/en-us/library/b2s063f7(v=vs.110).aspx), you can incorporate
                        // those comments into the generated docs and UI. You can enable this by providing the path to one or
                        // more Xml comment files.
                        //
                        c.IncludeXmlComments(GetXmlCommentsPath());

                        // Set this flag to omit schema property descriptions for any type properties decorated with the
                        // Obsolete attribute 
                        c.IgnoreObsoleteProperties();

                        })
                .EnableSwaggerUi(c => {});
        }
        private static string GetXmlCommentsPath()
        {
            return string.Format(@"{0}\bin\WebApiSwagger.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
