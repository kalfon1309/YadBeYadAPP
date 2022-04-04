using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YadBeYadApp.Models;
using YadBeYadApp.Services;
using YadBeYadApp.Views;

namespace YadBeYadApp
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
        public List<Attraction> attractions { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartPage());
        }

        protected override async void OnStart()
        {
            YadBeYadAPIProxy proxy = YadBeYadAPIProxy.CreateProxy();
            //await MainPage.Navigation.PushModalAsync(new LoadingPage());
            try
            {
                attractions = await proxy.GetAttractionsAsync();
                //MainPage.Navigation.PopModalAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(  "Boom");
            }

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
