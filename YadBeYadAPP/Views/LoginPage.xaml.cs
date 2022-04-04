using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YadBeYadApp.ViewModels;

namespace YadBeYadApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            LoginPageViewModel lVM = new LoginPageViewModel();
            BindingContext = lVM;
            lVM.Push += (p) => Navigation.PushAsync(p);

        }
    }
}