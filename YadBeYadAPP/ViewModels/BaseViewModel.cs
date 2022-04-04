using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using YadBeYadApp.Services;

namespace YadBeYadApp.ViewModels
{
    class BaseViewModel : INotifyPropertyChanged
    {
        #region Properties

        protected YadBeYadAPIProxy YadProxy;
        protected App CurrentApp = (App)Application.Current;
        #endregion
        #region Events

        public event Action<Page> Push;

        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public BaseViewModel()
        {
           YadProxy = YadBeYadAPIProxy.CreateProxy();
        }
    }
}
