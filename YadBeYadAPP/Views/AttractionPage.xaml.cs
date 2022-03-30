using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YadBeYadAPP.ViewModels;

namespace YadBeYadAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AttractionPage : ContentPage
    {
        public AttractionPage()
        {
            InitializeComponent();
            AttractionPageViewModel aPVM = new AttractionPageViewModel();
            BindingContext = aPVM;
            aPVM.Push += (p) => Navigation.PushAsync(p);
        }
    }
}