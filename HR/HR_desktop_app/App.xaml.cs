using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HR_desktop_app
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsDeveloping { get; private set; } = true;

        protected override void OnStartup(StartupEventArgs e)
        {
            IsDeveloping = false;
            base.OnStartup(e);
        }
    }
}
