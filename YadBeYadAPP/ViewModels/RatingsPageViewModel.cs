using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using YadBeYadApp.Models;
using YadBeYadApp.Services;
using YadBeYadApp.Views;

namespace YadBeYadApp.ViewModels
{
    class RatingsPageViewModel : BaseViewModel
    {

        public RatingsPageViewModel()
        {
            Rates = new ObservableCollection<Rate>();
            GetRates();




        }

        //private async void GetAllAttractions()
        //{
        //    YadBeYadAPIProxy proxy = YadBeYadAPIProxy.CreateProxy();
        //    allReviews = await proxy.GetAttractionsAsync();
        //    Reviews = new ObservableCollection<Review>();
        //    foreach (Attraction attraction in allReviews)
        //    {
        //        Reviews.Add();
        //    }

        //}

        public ObservableCollection<Rate> Rates { get; set; }

        private List<Rate> allRates;


        #region Properties



        


        #endregion


        #region Commands


        #endregion

        public async void GetRates()
        {
            YadProxy = YadBeYadAPIProxy.CreateProxy();
            allRates = await YadProxy.GetRatesByUser(((App)App.Current).CurrentUser.UserId);
            foreach (Rate r in allRates)
            {
                Rates.Add(r);
            }
        }

        #region Events

        public event Action<Page> Push;

        #endregion




    }
}
