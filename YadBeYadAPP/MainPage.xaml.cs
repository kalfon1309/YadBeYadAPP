using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YadBeYadApp.Services;

namespace YadBeYadAPP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            YadBeYadAPIProxy proxy = YadBeYadAPIProxy.CreateProxy();
            lbl_text.Text = await proxy.TestAsync();
        }
    }
}
