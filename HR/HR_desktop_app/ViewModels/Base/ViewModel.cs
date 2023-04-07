using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HR_desktop_app.ViewModels.Base
{
    /// <summary>
    /// Базовая модель представления
    /// </summary>
    internal abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propname = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propname = null!)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propname);
            return true;
        }
    }
}
