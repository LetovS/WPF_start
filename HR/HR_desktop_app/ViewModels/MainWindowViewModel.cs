using HR_desktop_app.Infrastructure.Commands;
using HR_desktop_app.ViewModels.Base;
using System;
using System.Windows;
using System.Windows.Input;

namespace HR_desktop_app.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        /// <summary> Заголовок окна </summary>
        private string _Title = "Поле для проверки работы привязки";

        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        public ICommand CloseAppCommand { get; }
        private void OnCloseAppCommandExecuted(object o) => Application.Current.Shutdown();
        private bool CanExecuteCloseAppCommand(object o) => true;
        public MainWindowViewModel()
        {
            CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanExecuteCloseAppCommand);
        }
    }
}
