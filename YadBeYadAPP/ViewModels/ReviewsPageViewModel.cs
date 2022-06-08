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
    class ReviewsPageViewModel : BaseViewModel
    {

        public ReviewsPageViewModel()
        {
            Reviews = new ObservableCollection<Review>();
            GetReviews();
            DeleteRevCommand = new Command<Review>(DeleteReview);






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

        public ObservableCollection<Review> Reviews { get; set; }

        private List<Review> allReviews;


        #region Properties
        private Review currentReview;

        private string commentText;
        public ObservableCollection<Review> AttractionReviews { get; set; }


        public string CommentText
        {
            get => commentText;
            set
            {
                if (value != commentText)
                {
                    commentText = value;
                    OnPropertyChanged();
                }
            }
        }
        public Review CurrentReview
        {
            get => currentReview;
            set
            {
                if(value != currentReview)
                {
                    currentReview = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion


        #region Commands

        public ICommand DeleteRevCommand { get; protected set; }

        #endregion

        public async void DeleteReview(Review r)
        {
            YadProxy = YadBeYadAPIProxy.CreateProxy();
            bool success = await YadProxy.DeleteReview(r);
            if(success)
            {
                GetReviews();
            }
            else
            {
                CurrentApp.MainPage.DisplayAlert("Error", "Delete failed", "OK");
            }
        }
        public async void GetReviews()
        {
            YadProxy = YadBeYadAPIProxy.CreateProxy();
            allReviews = await YadProxy.GetReviewsByUser(((App)App.Current).CurrentUser.UserId);
            if (allReviews != null)
            {
                Reviews = new ObservableCollection<Review>(allReviews);
                OnPropertyChanged("Reviews");
            }
          

         
        }

        #region Events

        public event Action<Page> Push;

        #endregion
   
       
    }
}
