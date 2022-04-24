using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace YadBeYadApp.ViewModels
{
    class AttractionDetailViewModel:BaseViewModel
    {
        public AttractionDetailViewModel()
        {


        }

        private void ToProfilePage()
        {
            
        }

        private void ToDetailAttPage()
        {
            
        }







        #region Properties

        private string attractionName;

        public string AttractionName
        {
            get => attractionName;
            set
            {
                if (value != attractionName)
                {
                    attractionName = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<ReviewInList> ReviewsToShow { get; set; }


        private string attractionRate;

        public string AttractionRate
        {
            get => attractionRate;
            set
            {
                if (value != attractionRate)
                {
                    attractionRate = value;
                    OnPropertyChanged();
                }
            }
        }



        private string heartImageUrl;

        public string HeartImageUrl
        {
            get => heartImageUrl;
            set
            {
                if (value != heartImageUrl)
                {
                    heartImageUrl = value;
                    OnPropertyChanged();
                }
            }
        }


        #endregion


        #region Commands

        public ICommand HeartFillCommand { get; set; }

        public ICommand CommentCommand { get; set; }

        public ICommand RateCommand { get; set; }

        #endregion

        #region Events

        #endregion

    }

    class ReviewInList : BaseViewModel
    {

        private string userName;

        public string UserName
        {
            get => userName;
            set
            {
                if (value != userName)
                {
                    userName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string date;

        public string Date
        {
            get => date;
            set
            {
                if (value != date)
                {
                    date = value;
                    OnPropertyChanged();
                }
            }
        }

        private string text;

        public string Text
        {
            get => text;
            set
            {
                if (value != text)
                {
                    text = value;
                    OnPropertyChanged();
                }
            }
        }

    }

}
