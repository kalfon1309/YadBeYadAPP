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
     class FavoritesPageViwModel : BaseViewModel
    {

        public FavoritesPageViwModel()
        {
            Favorites = new ObservableCollection<Models.Favorite>();
            GetFavorites();
            DeleteFavoriteCommand = new Command<Favorite>(DeleteFavorites);



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

        public ObservableCollection<Models.Favorite> Favorites { get; set; }

        private List<Favorite> allFavorites;

        public async void DeleteFavorites(Favorite f)
        {
            YadProxy = YadBeYadAPIProxy.CreateProxy();
            bool success = await YadProxy.DeleteFavorite(f);
            if (success)
            {
                GetFavorites();
            }
            else
            {
                CurrentApp.MainPage.DisplayAlert("Error", "Delete failed", "OK");
            }
        }

        #region Properties


        private Favorite currentFavorite;

        public Favorite CurrentFavorite
        {
            get => currentFavorite;
            set
            {
                if (value != currentFavorite)
                {
                    currentFavorite = value;
                    OnPropertyChanged();
                }
            }
        }



        #endregion


        #region Commands

        public ICommand DeleteFavoriteCommand { get; protected set; }
        #endregion

        public async void GetFavorites()
        {
            YadProxy = YadBeYadAPIProxy.CreateProxy();
            allFavorites = await YadProxy.GetFavoritesByUser(((App)App.Current).CurrentUser.UserId);
            if (allFavorites != null)
            {
                Favorites = new ObservableCollection<Favorite>(allFavorites);
                OnPropertyChanged("Favorites");
            }
        }

        #region Events

        public event Action<Page> Push;

        #endregion





    }
}

