using HR_desktop_app.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HR_desktop_app.Infrastructure.Commands
{
    internal class StaticCommandCloseApp : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
