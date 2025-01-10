using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using CefSharp;
using CefSharp.SchemeHandler;
using CefSharp.Wpf;
using Gssoft.Gscad.Windows;
using Path = System.IO.Path;

namespace WebViewTestingProject.View.MainWebView
{
    public partial class WebViewControl : UserControl
    {

        public WebViewControl()
        {
            InitializeComponent();
            this.Loaded += InitBrowser;
        }
        
        ChromiumWebBrowser browser;

        public void InitBrowser(object sender, RoutedEventArgs e)
        {
            var dllPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var rootFolder = Path.Combine(dllPath, "View","WebControls", "Main");
            
            if (!Directory.Exists(rootFolder))
            {
                throw new DirectoryNotFoundException($"Root folder not found: {rootFolder}");
            }
            
            
            var settings = new CefSettings();
            settings.RegisterScheme(new CefCustomScheme
            {
                SchemeName = "localWebControl",
                DomainName = "cefsharp",
                SchemeHandlerFactory = new FolderSchemeHandlerFactory(
                    rootFolder: rootFolder,
                    hostName: "cefsharp",
                    defaultPage: "index.html"
                )
            });

            if (!Cef.IsInitialized.HasValue || Cef.IsInitialized == false)
            {
                Cef.Initialize(settings);
            }
            
            browser = new ChromiumWebBrowser("localWebControl://cefsharp");
            mainWebViewControl.Children.Add(browser);
        }

        public void Dispose()
        {
            Cef.Shutdown();
        }

        public void OnPaletteSetDestroy(object sender, PaletteSetStateEventArgs e)
        {
            Console.WriteLine(e.NewState);
            if (e.NewState == StateEventIndex.Hide)
            {
                //Dispose();
            }
        }
    }
}