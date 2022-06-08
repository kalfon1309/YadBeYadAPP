using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;
using YadBeYadApp.Models;
using YadBeYadApp.Services;
using YadBeYadApp.Views;

namespace YadBeYadApp.ViewModels
{
    class RevAndRateViewModel : BaseViewModel
    {
        public RevAndRateViewModel(Attraction chosenAttraction)
        {
            this.currentAttraction = chosenAttraction;
            this.CommentText = string.Empty;
            this.CommentRate = 5;

            AddCommentCommand = new Command(AddComment);
            AddRateCommand = new Command(AddRate);
        }

        private async void AddRate()
        {
            Rate newRate = new Rate
            {
                Attraction = this.currentAttraction,
                AttractionId = this.currentAttraction.AttractionId,
                User = ((App)App.Current).CurrentUser,
                UserId = ((App)App.Current).CurrentUser.UserId,
                Rates = CommentRate
            };

            try
            {
                bool b = await YadProxy.AddRate(newRate);
                if (b)
                {
                    await App.Current.MainPage.DisplayAlert("Success", "Rate Added", "ok");
                    User u = await YadProxy.LoginAsync(((App)App.Current).CurrentUser.Email, ((App)App.Current).CurrentUser.Pass);
                    ((App)App.Current).CurrentUser = u;
                    List<Attraction> attractions = await YadProxy.GetAttractionsAsync();
                    CurrentApp.attractions = attractions;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Failed", "Something Went Wrong...", "ok");
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Failed", "Something Went Wrong...", "ok");
            }

        }

        private async void AddComment()
        {
            if(string.IsNullOrEmpty(CommentText))
            {
                await App.Current.MainPage.DisplayAlert("Failed", "You must enter text in order to send your comment", "ok");
                return;
            }

            Review newReview = new Review
            {
                ReviewDate = DateTime.Today,
                Attraction = this.currentAttraction,
                AttractionId = this.currentAttraction.AttractionId,
                User = ((App)App.Current).CurrentUser,
                UserId = ((App)App.Current).CurrentUser.UserId,
                Comment = CommentText,
                IsActive = true
            };

            try
            {
                bool b = await YadProxy.AddReview(newReview);
                if (b)
                {
                    await App.Current.MainPage.DisplayAlert("Success", "Review Added", "ok");
                    User u = await YadProxy.LoginAsync(((App)App.Current).CurrentUser.Email, ((App)App.Current).CurrentUser.Pass);
                    ((App)App.Current).CurrentUser = u;
                    List<Attraction> attractions = await YadProxy.GetAttractionsAsync();
                    CurrentApp.attractions = attractions;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Failed", "Something Went Wrong...", "ok");
                }
            }
            catch(Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Failed", "Something Went Wrong...", "ok");
            }
            

        }



        #region Properties

        private Attraction currentAttraction;

        private string commentText;
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

        private int commentRate;
        public int CommentRate
        {
            get => commentRate;
            set
            {
                if (value != commentRate)
                {
                    commentRate = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Commands

        public ICommand AddCommentCommand { get; set; }
        public ICommand AddRateCommand { get; set; }

        #endregion

        #region Events


        #endregion






    }
}
