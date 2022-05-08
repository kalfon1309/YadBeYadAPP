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
            AttractionReviews = new ObservableCollection<Review>(CurrentApp.CurrentUser.Reviews);




       
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


        public ObservableCollection<Review> AttractionReviews { get; set; }
        #endregion

     
        #region Commands


        #endregion


        #region Events

        public event Action<Page> Push;

        #endregion
   



    }
}
