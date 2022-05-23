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

        public ReviewsPageViewModel(Review r)
        {
            AttractionReviews = new ObservableCollection<Review>(CurrentApp.CurrentUser.Reviews);
            this.commentText = r.Comment;



       
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

        private List<Attraction> allReviews;


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


        #region Events

        public event Action<Page> Push;

        #endregion
   



    }
}
