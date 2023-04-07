using HR_desktop_app.ViewModels.Base;
using System;

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

    }
}
