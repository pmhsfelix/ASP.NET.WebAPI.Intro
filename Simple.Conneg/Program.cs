using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.SelfHost;
using Common;

namespace Simple.Conneg
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8080");
            config.Routes.MapHttpRoute(
                "ApiDefault",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
                );

            config.Formatters.Add(new ImageFromTextFormatter());
            config.Formatters.Add(new WaveFromTextFormatter());

            var server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();
            Console.WriteLine("Server is opened");
            Console.ReadKey();
            server.CloseAsync().Wait();
        }
    }
}
