using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using YadBeYadApp.Models;
using YadBeYadApp.Services;
using YadBeYadApp.Views;
using YadBeYadApp.ViewModels;
using YadBeYadApp.Services;

namespace YadBeYadApp.ViewModels
{
    class AttractionDetailViewModel : BaseViewModel
    {
        public AttractionDetailViewModel(Attraction chosenAttraction)
        {
            //insert values to properties
            this.currentAttraction = chosenAttraction;
            this.AttractionName = chosenAttraction.AttName;

            RevAndRate = new Command(ToRevAndRate);

            double rate = AvgRate();
            this.AttractionRate = string.Format("{0:0.0}", rate);

            if (rate >= 0 && rate <= 3)
            {
                this.RateBackgroundColor = Color.Red;
            }
            else if (rate <= 6)
            {
                this.RateBackgroundColor = Color.Orange;
            }
            else
            {
                this.RateBackgroundColor = Color.Lime;
            }

            isFavorite = false;
            currentFavorite = null;
            foreach (Favorite favorite in ((App)App.Current).CurrentUser.Favorites)
            {
                if (favorite.IsActive && favorite.AttractionId == chosenAttraction.AttractionId)
                {
                    this.HeartImageUrl = "filledHeartIcon.png";
                    isFavorite = true;
                    currentFavorite = favorite;
                }
            }

            if (!isFavorite)
            {
                this.HeartImageUrl = "emptyHeartIcon.png";
            }


            this.ReviewsToShow = new ObservableCollection<ReviewInList>();
            foreach (Review review in chosenAttraction.Reviews)
            {
                if (review.IsActive)
                {
                    this.ReviewsToShow.Add(new ReviewInList
                    {
                        UserName = review.User.UserName,
                        Comment = review.Comment,
                        Date = review.ReviewDate.ToString("dd/MM/yyyy")
                    });
                }
            }

            //commands
            HeartFillCommand = new Command(HeartFill);

        }

        private void ToRevAndRate()
        {
            Push?.Invoke(new RevAndRate(this.currentAttraction));
        }

        private async void HeartFill()
        {

            if (isFavorite && currentFavorite != null)
            {
                try
                {
                    bool isSuccess = await YadProxy.CancelFavorite(currentFavorite);
                    if (isSuccess)
                    {
                        ((App)App.Current).CurrentUser.Favorites.Remove(currentFavorite);
                        this.HeartImageUrl = "emptyHeartIcon.png";
                        isFavorite = false;
                        currentFavorite = null;
                        User u = await YadProxy.LoginAsync(((App)App.Current).CurrentUser.Email, ((App)App.Current).CurrentUser.Pass);
                        if (u != null)
                        {
                            ((App)App.Current).CurrentUser = u;
                        }
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Failed", "Something went wrong...", "ok");
                    }
                }
                catch (Exception e)
                {
                    await App.Current.MainPage.DisplayAlert("Failed", "Something went wrong...", "ok");
                }
            }
            else
            {
                currentFavorite = new Favorite
                {

                    User = ((App)App.Current).CurrentUser,
                    Attraction = currentAttraction,
                    IsActive = true
                };
                try
                {
                    Favorite isSuccess = await YadProxy.AddFavorite(currentFavorite);
                    if (isSuccess != null)
                    {
                        this.HeartImageUrl = "filledHeartIcon.png";
                        isFavorite = true;
                        currentFavorite = isSuccess;
                        User u = await YadProxy.LoginAsync(((App)App.Current).CurrentUser.Email, ((App)App.Current).CurrentUser.Pass);
                        if (u != null)
                        {
                            ((App)App.Current).CurrentUser = u;
                        }
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Failed", "Something went wrong...", "ok");
                    }
                }
                catch (Exception e)
                {
                    await App.Current.MainPage.DisplayAlert("Failed", "Something went wrong...", "ok");
                }
            }

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


        public async void RefreshPage()
        {
            YadBeYadAPIProxy proxy = YadBeYadAPIProxy.CreateProxy();
            List<Attraction> allAttractions = await proxy.GetAttractionsAsync();

            foreach (Attraction attraction in allAttractions)
            {
                if(this.currentAttraction.AttractionId == attraction.AttractionId)
                {
                    this.currentAttraction = attraction;
                }
            }

            double rate = AvgRate();
            this.AttractionRate = string.Format("{0:0.0}", rate);

            if (rate >= 0 && rate <= 3)
            {
                this.RateBackgroundColor = Color.Red;
            }
            else if (rate <= 6)
            {
                this.RateBackgroundColor = Color.Orange;
            }
            else
            {
                this.RateBackgroundColor = Color.Lime;
            }


            this.ReviewsToShow = new ObservableCollection<ReviewInList>();
            foreach (Review review in currentAttraction.Reviews)
            {
                if (review.IsActive)
                {
                    this.ReviewsToShow.Add(new ReviewInList
                    {
                        UserName = review.User.UserName,
                        Comment = review.Comment,
                        Date = review.ReviewDate.ToString("dd/MM/yyyy")
                    });
                }
            }
            OnPropertyChanged("ReviewsToShow");

        }




        #region Properties

        private bool isFavorite;
        private Favorite currentFavorite;

        private Attraction currentAttraction;

        private string attractionName;

        private string commentText;

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

        private Color rateBackgroundColor;

        public Color RateBackgroundColor
        {
            get => rateBackgroundColor;
            set
            {
                if (value != rateBackgroundColor)
                {
                    rateBackgroundColor = value;
                    OnPropertyChanged();
                }
            }
        }



        #endregion


        #region Commands

        public ICommand HeartFillCommand { get; set; }

        public ICommand CommentCommand { get; set; }

        public ICommand RateCommand { get; set; }

        public ICommand RevAndRate { get; set; }

        #endregion

        #region Events

        public event Action<Page> Push;

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

        private string comment;

        public string Comment
        {
            get => comment;
            set
            {
                if (value != comment)
                {
                    comment = value;
                    OnPropertyChanged();
                }
            }
        }

    }

}
