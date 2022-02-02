using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using YadBeYadApp.Models;

namespace YadBeYadAPP.ViewModels
{
    class ProfileViewModel:BaseViewModel
    {
        public ProfileViewModel()
        {
            User currentUser = ((App)App.Current).CurrentUser;
            if(currentUser != null)
            {
                this.FirstName = currentUser.FirstName;
                this.LastName = currentUser.LastName;
                this.UserName = currentUser.UserName;
                this.Email = currentUser.Email;
                this.Password = currentUser.Pass;
                this.Age = currentUser.Age;

                ToUpdatePageCommand = new Command(ToUpdatePage);

            }
            else
            {
                //Push?.Invoke(new startpage);
            }
        }

        private void ToUpdatePage()
        {
            //Push?.Invoke(new UpdatePage());
        }

        #region Properties

        private string email;

        public string Email
        {
            get => email;
            set
            {
                if (value != email)
                {
                    email = value;
                    OnPropertyChanged();
                }
            }
        }

        private string password;

        public string Password
        {
            get => password;
            set
            {
                if (value != password)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }

        private string firstName;

        public string FirstName
        {
            get => firstName;
            set
            {
                if (value != firstName)
                {
                    firstName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string lastName;

        public string LastName
        {
            get => lastName;
            set
            {
                if (value != lastName)
                {
                    lastName = value;
                    OnPropertyChanged();
                }
            }
        }
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
        private int age;

        public int Age
        {
            get => age;
            set
            {
                if (value != age)
                {
                    age = value;
                    OnPropertyChanged();
                }
            }
        }


        #endregion

        #region Commands

        public ICommand ToUpdatePageCommand { get; set; }

        #endregion

        #region Events

        public event Action<Page> Push;

        #endregion

        public void RefreshPage()
        {
            User currentUser = ((App)App.Current).CurrentUser; 
            if (currentUser != null)
            {
                this.FirstName = currentUser.FirstName;
                this.LastName = currentUser.LastName;
                this.UserName = currentUser.UserName;
                this.Email = currentUser.Email;
                this.Password = currentUser.Pass;
                this.Age = currentUser.Age;

                ToUpdatePageCommand = new Command(ToUpdatePage);

            }
        }

    }
}
