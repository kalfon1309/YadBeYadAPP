using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YadBeYadApp.ViewModels;
using YadBeYadApp.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YadBeYadApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AttractionDetail : ContentPage
    {
        public AttractionDetail(Attraction att)
        {
            InitializeComponent();
            AttractionDetailViewModel aDVM = new AttractionDetailViewModel(att);
            BindingContext = aDVM;
            aDVM.Push += (p) => Navigation.PushAsync(p);


            #region Properties

            #endregion


            #region Commands

            #endregion

            #region Events

            #endregion
        }
    }
}