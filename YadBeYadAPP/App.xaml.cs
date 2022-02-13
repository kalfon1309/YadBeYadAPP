using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YadBeYadApp.Models;
using YadBeYadAPP.Views;

namespace YadBeYadAPP
{
    public partial class App : Application
    {
        public static bool IsDevEnv
        {
            get
            {
                return true; //change this before release!
            }
        }

        public User CurrentUser { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FavoritesPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
