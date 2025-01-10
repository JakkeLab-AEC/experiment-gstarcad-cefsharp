using System;
using System.Web.Http;
using Microsoft.Owin.Hosting;

namespace WebViewTestingProject.Server
{
    public class ApiServer
    {
        private static ApiServer _instance;
        private IDisposable _webApp;

        private ApiServer()
        {
            
        }

        public static ApiServer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ApiServer();
                    return _instance;
                }
                
                return _instance;
            }
        }

        public void Start(string baseAddress = "http://localhost:5000/")
        {
            if (_webApp == null)
            {
                _webApp = WebApp.Start<StartUp>(baseAddress);
                Console.WriteLine($"API Server started at {baseAddress}");
            }
        }
        
        public void Stop()
        {
            _webApp?.Dispose();
            _webApp = null;
            Console.WriteLine("API Server stopped.");
        }
    }
}