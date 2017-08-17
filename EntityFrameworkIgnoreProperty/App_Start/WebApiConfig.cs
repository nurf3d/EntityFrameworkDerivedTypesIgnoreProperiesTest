using EntityFrameworkIgnoreProperty.Models;
using Microsoft.OData.Edm;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.OData;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace EntityFrameworkIgnoreProperty
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web-API-Konfiguration und -Dienste

            // Web-API-Routen
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.SetTimeZoneInfo(TimeZoneInfo.Utc);
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);

            config.MapODataServiceRoute(
                "odata",
                null,
                GetEDMModel(),
                //https://stackoverflow.com/questions/34912033/what-should-i-return-when-my-odata-v4-method-returns-singleresultt-and-nothing
                defaultHandler: HttpClientFactory.CreatePipeline(innerHandler: new HttpControllerDispatcher(config), handlers: new[] { new ODataNullValueMessageHandler() })
            );
        }

        public static IEdmModel GetEDMModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<Person>("People");
            builder.EntitySet<Event>("Events");
            return builder.GetEdmModel();
        }
    }
}