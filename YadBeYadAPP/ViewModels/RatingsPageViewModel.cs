using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
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
            DeleteRateCommand = new Command<Rate>(DeleteRate);
            ToAttractionDetailPageCommand = new Command<Rate>(ToAttractionDetailPage);


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
        private void ToAttractionDetailPage(Rate rate)
        {
            Attraction chosenAttraction = null;
            foreach (Attraction attraction in ((App)App.Current).attractions)
            {
                if (rate.AttractionId == attraction.AttractionId)
                    chosenAttraction = attraction;
            }

            if (chosenAttraction != null)
            {
                Push?.Invoke(new AttractionDetail(chosenAttraction));
            }
            else
            {
                Push?.Invoke(new AttractionDetail(rate.Attraction));
            }
        }



        public ObservableCollection<Rate> Rates { get; set; }

        private List<Rate> allRates;


        #region Properties

        private Rate currentRate;

        public Rate CurrentRate
        {
            get => currentRate;
            set
            {
                if (value != currentRate)
                {
                    currentRate = value;
                    OnPropertyChanged();
                }
            }
        }


        #endregion


        #region Commands
        public ICommand DeleteRateCommand { get; protected set; }
        public ICommand ToAttractionDetailPageCommand { get; set; }

        #endregion

        public async void DeleteRate(Rate r)
        {
            YadProxy = YadBeYadAPIProxy.CreateProxy();
            bool success = await YadProxy.DeleteRate(r);
            if (success)
            {
                GetRates();
            }
            else
            {
                CurrentApp.MainPage.DisplayAlert("Error", "Delete failed", "OK");
            }
        }


        public async void GetRates()
        {
            YadProxy = YadBeYadAPIProxy.CreateProxy();
            allRates = await YadProxy.GetRatesByUser(((App)App.Current).CurrentUser.UserId);
            if (allRates != null)
            {
                Rates = new ObservableCollection<Rate>(allRates);
                OnPropertyChanged("Rates");
            }
            
        }

        #region Events

        public event Action<Page> Push;

        #endregion




    }
}
