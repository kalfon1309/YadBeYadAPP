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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            ProfileViewModel pVM = new ProfileViewModel();
            BindingContext = pVM;
            pVM.Push += (p) => Navigation.PushAsync(p);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((ProfileViewModel)this.BindingContext).RefreshPage();
        }
    }
}