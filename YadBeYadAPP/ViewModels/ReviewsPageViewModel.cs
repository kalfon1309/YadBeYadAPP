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
    class ReviewsPageViewModel : BaseViewModel
    {

        public ReviewsPageViewModel()
        {
            Reviews = new ObservableCollection<Review>();
            GetReviews();



       
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


        #endregion


        #region Commands


        #endregion

        public async void GetReviews()
        {
            YadProxy = YadBeYadAPIProxy.CreateProxy();
            allReviews = await YadProxy.GetReviewsByUser(((App)App.Current).CurrentUser.UserId);
            foreach(Review r in allReviews)
            {
                Reviews.Add(r);
            }
        }

        #region Events

        public event Action<Page> Push;

        #endregion
   



    }
}
