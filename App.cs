using System;
using System.Windows;
using Gssoft.Gscad.Runtime;
using Gssoft.Gscad.Windows;
using WebViewTestingProject.Server;
using WebViewTestingProject.View.MainWebView;
using Exception = System.Exception;

namespace WebViewTestingProject
{
    public class App : IExtensionApplication
    {
        public void Initialize()
        {
            try
            {
                // API 서버 시작
                ApiServer.Instance.Start("http://localhost:5000/");
                Console.WriteLine("API Server is running.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting API Server: {ex.Message}");
            }
        }

        public void Terminate()
        {
            throw new System.NotImplementedException();
        }
    }
}