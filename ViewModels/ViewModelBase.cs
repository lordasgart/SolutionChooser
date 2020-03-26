using ReactiveUI;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SolutionChooser.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            this.RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
