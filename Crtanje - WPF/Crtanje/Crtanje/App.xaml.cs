using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Crtanje
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SplashScreen splash = new SplashScreen(@"slike/SplashScreen_v3.png");
            splash.Show(false, true);
            splash.Close(new TimeSpan(0, 0, 2));
            System.Threading.Thread.Sleep(1000);
            base.OnStartup(e);
        }

    }
}
