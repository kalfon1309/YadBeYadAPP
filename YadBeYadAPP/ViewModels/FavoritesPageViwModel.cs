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
     class FavoritesPageViwModel : BaseViewModel
    {

        public FavoritesPageViwModel()
        {
            Favorites = new ObservableCollection<Models.Favorite>();
            GetFavorites();




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


        #region Properties






        #endregion


        #region Commands


        #endregion

        public async void GetFavorites()
        {
            YadProxy = YadBeYadAPIProxy.CreateProxy();
            allFavorites = await YadProxy.GetFavoritesByUser(((App)App.Current).CurrentUser.UserId);
            foreach (Favorite f in allFavorites)
            {
                Favorites.Add(f);
            }
        }

        #region Events

        public event Action<Page> Push;

        #endregion





    }
}
