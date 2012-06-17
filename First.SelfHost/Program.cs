using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace First.SelfHost
{

    public class HelloController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage
                       {
                           Content = new StringContent("Hello Web"),
                       };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8080");
            config.Routes.MapHttpRoute(
                "ApiDefault",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
                );

            var server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();
            Console.WriteLine("Server is opened");
            Console.ReadKey();
            server.CloseAsync().Wait();
        }
    }
}
