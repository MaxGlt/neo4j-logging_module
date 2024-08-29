using System;
using System.Net.Http;
using System.Text;
using System.Web;

namespace LoggingModule
{
    public class LoggingModule : IHttpModule
    {
        private readonly HttpClient client;

        LoggingModule()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5017"),
                Timeout = TimeSpan.FromSeconds(30)
            };
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
            context.EndRequest += OnEndRequest;
        }

        private void OnBeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            context.Items["RequestStartTime"] = DateTime.Now;
        }

        private async void OnEndRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;

            DateTime startTime = (DateTime)context.Items["RequestStartTime"];
            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;

            string url = context.Request.Url.ToString();
            string method = context.Request.HttpMethod;

            string fromApp = context.Request.Headers["X-From-App"] ?? "API";
            string toApp = context.Request.Headers["X-To-App"] ?? "API";

            var content = new StringContent($"{{ \"url\": \"{url}\", \"method\": \"{method}\", \"duration\": {duration.TotalMilliseconds}, \"fromApp\": \"{fromApp}\", \"toApp\": \"{toApp}\" }}", Encoding.UTF8, "application/json");

            await client.PostAsync("logging", content);
        }

        public void Dispose()
        {

        }

        public static void RegisterModule(IntPtr appContext)
        {
            
        }
    }
}
