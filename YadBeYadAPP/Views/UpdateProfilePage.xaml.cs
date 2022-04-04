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
    public partial class UpdateProfilePage : ContentPage
    {
        public UpdateProfilePage()
        {
            InitializeComponent();
            UpdateProfileViewModel uPVM = new UpdateProfileViewModel();
            BindingContext = uPVM;
            uPVM.Push += (p) => Navigation.PushAsync(p);
        }
    }
}