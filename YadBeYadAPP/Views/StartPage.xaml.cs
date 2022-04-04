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
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            StartPageViewModel sPVM = new StartPageViewModel();
            BindingContext = sPVM;
            sPVM.Push += (p) => Navigation.PushAsync(p);
        }
    }
}