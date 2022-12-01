using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmUiMvvM
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ViewModelBase(Action<object> OkAction)
        {
            this.OkCommand = new RelayCommand(p => CanOk(), OkAction);
        }

        public RelayCommand OkCommand { get; set; }

        private bool CanOk()
        {
            return true;
        }

    }
}
