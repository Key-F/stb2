using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Awesomium.Core;
using System.Threading;
using System.Globalization;
using Awesomium.Windows.Forms;


namespace stb
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

           // WebConfig webConfig = new WebConfig()
           // {
             //   ChildProcessPath = String.Format("{0}{1}CustomAwesomiumProcess.exe", My.Application.Info.DirectoryPath, Path.DirectorySeparatorChar),
               // HomeURL = new Uri("http://www.google.com"),
                // Let's gather some extra info for this sample.
             //   LogLevel = LogLevel.Verbose
          //  };
            //WebCore.Initialize(webConfig);
            Application.Run(new Form1());
            //Form1 b = new Form1();
            //b.button1.Enabled = true;

           // WebSession session = WebCore.CreateWebSession(
   // @"C:\STBSessionDataPath", WebPreferences.Default);
           // Form1.webControl1.LoadURL("http://ya.ru"); 
           // string cookies = webBrowser1.ExecuteJavascriptWithResult("document.cookie;");  
        }
    }
}
