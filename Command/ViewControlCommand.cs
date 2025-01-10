using System;
using Gssoft.Gscad.Runtime;
using Gssoft.Gscad.ApplicationServices;
using Gssoft.Gscad.Windows;
using WebViewTestingProject.View.MainWebView;

[assembly: CommandClass(typeof(WebViewTestingProject.Command.ViewControlCommand))]

namespace WebViewTestingProject.Command
{
    public class ViewControlCommand
    {
        [CommandMethod("ShowPalette")]
        public void ShowPalette()
        {
            PaletteSet myPaletteSet = new PaletteSet("RWCrawler", new Guid("61c9b5cd-b08e-48f2-89aa-17b387835d72"));
            myPaletteSet.Size = new System.Drawing.Size(200, 200);
            myPaletteSet.DockEnabled = (DockSides)((int)DockSides.Left + (int)DockSides.Right);


            var webView = new WebViewControl();
            myPaletteSet.StateChanged += webView.OnPaletteSetDestroy;
            
            myPaletteSet.AddVisual("MainWebView", webView);
            
            myPaletteSet.KeepFocus = true;
            myPaletteSet.Visible = true;
        }
    }
}