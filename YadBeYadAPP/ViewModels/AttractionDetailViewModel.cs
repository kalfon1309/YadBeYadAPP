using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using YadBeYadApp.Models;

namespace YadBeYadApp.ViewModels
{
    class AttractionDetailViewModel:BaseViewModel
    {
        public AttractionDetailViewModel(Attraction chosenAttraction)
        {
            //insert values to properties
            this.currentAttraction = chosenAttraction;
            this.AttractionName = chosenAttraction.AttName;
            this.AttractionRate = string.Format("{0:0.0}",AvgRate());

            bool isFavorite = false;
            foreach (Favorite favorite in ((App)App.Current).CurrentUser.Favorites)
            {
                if(favorite.IsActive && favorite.AttractionId == chosenAttraction.AttractionId)
                {
                    this.HeartImageUrl = "filledHeartIcon.png";
                    isFavorite = true;
                }
            }

            if(!isFavorite)
            {
                this.HeartImageUrl = "emptyHeartIcon.png";
            }

            this.ReviewsToShow = new ObservableCollection<ReviewInList>();
            foreach (Review review in chosenAttraction.Reviews)
            {
                if(review.IsActive)
                {
                    this.ReviewsToShow.Add(new ReviewInList
                    {
                        UserName = review.User.UserName,
                        Text = review.Comment,
                        Date = review.ReviewDate.ToString("dd/MM/yyyy")
                    });
                }
            }

            //commands
            HeartFillCommand = new Command(HeartFill);

        }

        private async void HeartFill()
        {
            
        }

        private void ToProfilePage()
        {
            
        }

        private void ToDetailAttPage()
        {
            
        }


        // method that canculates the avg rate
        private double AvgRate()
        {
            double sum = 0;
            double counter = 0;

            foreach (Rate rate in this.currentAttraction.Rates)
            {
                sum += rate.Rates;
                counter++;
            }

            if (counter == 0)
                return 0;

            double avg = sum / counter;
            return avg;
            
        }

      

        #region Properties

        private Attraction currentAttraction;

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
