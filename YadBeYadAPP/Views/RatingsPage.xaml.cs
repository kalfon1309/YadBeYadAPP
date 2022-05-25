using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YadBeYadApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YadBeYadApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RatingsPage : ContentPage
    {
        public RatingsPage()
        {
            InitializeComponent();
            RatingsPageViewModel r = new RatingsPageViewModel();
            this.BindingContext = r;
            r.Push += (p) => Navigation.PushAsync(p);
        }
    }
}