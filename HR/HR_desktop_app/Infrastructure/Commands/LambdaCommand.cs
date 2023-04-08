using HR_desktop_app.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_desktop_app.Infrastructure.Commands
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecuted;


        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecuted = null!)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecuted = CanExecuted;
        }

        public override bool CanExecute(object parameter) => _CanExecuted?.Invoke(parameter!) ?? true;

        public override void Execute(object parameter) => _Execute(parameter!);
    }
}
