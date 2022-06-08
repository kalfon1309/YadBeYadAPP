using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YadBeYadApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YadBeYadApp.Models;

namespace YadBeYadApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RevAndRate : ContentPage
    {
        public RevAndRate(Attraction a)
        {
            InitializeComponent();
            this.BindingContext = new RevAndRateViewModel(a);
        }

      

    }
}