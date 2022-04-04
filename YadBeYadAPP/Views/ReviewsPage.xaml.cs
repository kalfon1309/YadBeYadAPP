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
    public partial class ReviewsPage : ContentPage
    {
        public ReviewsPage()
        {
            InitializeComponent();
            ReviewsPageViewModel RPVM = new ReviewsPageViewModel();
            BindingContext = RPVM;
            RPVM.Push += (p) => Navigation.PushAsync(p);
        }
    }
}