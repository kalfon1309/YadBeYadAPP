using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using YadBeYadApp.Models;

namespace YadBeYadApp.ViewModels
{
    class ReviewsPageViewModel : BaseViewModel
    {
        #region Properties
       
       
        public ObservableCollection<Review> AttractionReviews { get; set; }
        #endregion

        public ReviewsPageViewModel()
        {
            AttractionReviews = new ObservableCollection<Review>(CurrentApp.CurrentUser.Reviews);
        }
        #region Commands
        #endregion


        #region Events

        public event Action<Page> Push;

        #endregion
   



    }
}
