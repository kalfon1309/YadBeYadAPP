using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using YadBeYadApp.Views;

namespace YadBeYadApp.ViewModels
{
    class ActivityViewModel : BaseViewModel
    {
        public ActivityViewModel()
        {
            FavoritesCommand = new Command(ToFavoritesPage);

            ReviewsCommand = new Command(ToReviewsPage);

            RatingsCommand = new Command(ToRatingsPage);
        }

        private void ToFavoritesPage()
        {
            Push?.Invoke(new FavoritesPage());
        }

        private void ToReviewsPage()
        {
            Push?.Invoke(new ReviewsPage());
        }

        private void ToRatingsPage()
        {
            Push?.Invoke(new RatingsPage());
        }


        #region Properties

        #endregion

        #region Commands


        public ICommand FavoritesCommand { get; set; }

        public ICommand ReviewsCommand { get; set; }

        public ICommand RatingsCommand { get; set; }

        #endregion

        #region Events
        public event Action<Page> Push;
        #endregion



    }
}
