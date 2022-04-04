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
    public partial class Activity : ContentPage
    {
        public Activity()
        {
            InitializeComponent();
            ActivityViewModel aVM = new ActivityViewModel();
            BindingContext = aVM;
            aVM.Push += (p) => Navigation.PushAsync(p);
        }
    }
}