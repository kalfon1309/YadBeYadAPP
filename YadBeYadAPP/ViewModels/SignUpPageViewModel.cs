using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using YadBeYadApp.Models;
using YadBeYadApp.Services;
using YadBeYadAPP.Views;

namespace YadBeYadAPP.ViewModels
{

    class SignUpPageViewModel : BaseViewModel
    {
        public SignUpPageViewModel()
        {
            Email = string.Empty;
            Password = string.Empty;
            Status = string.Empty;
            //ToSignUpCommand = new Command(ToSignUp);
            //ToForgotPassCommand = new Command(ToForgotPass);
        }

        private async void SignUp()
        {
            YadBeYadAPIProxy proxy = YadBeYadAPIProxy.CreateProxy();
            try
            {
                User u = await proxy.LoginAsync(Email, Password);
                Status = "Loging you in....";
                if (u != null)
                {
                    ((App)App.Current).CurrentUser = u;
                    Push?.Invoke(new StartPage());
                }
            }
            catch (Exception)
            {
                Status = "Something went wrong...";
            }
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
        private string status;

        public string Status
        {
            get => status;
            set
            {
                if (value != status)
                {
                    status = value;
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

        private string userNameError;

        public string UserNameError
        {
            get => userNameError;
            set
            {
                if (value != userNameError)
                {
                    userNameError = value;
                    OnPropertyChanged();
                }
            }
        }
        private string ageError;

        public string AgeError
        {
            get => ageError;
            set
            {
                if (value != ageError)
                {
                    ageError = value;
                    OnPropertyChanged();
                }
            }
        }

        private string lastNameError;

        public string LastNameError
        {
            get => lastNameError;
            set
            {
                if (value != lastNameError)
                {
                    lastNameError = value;
                    OnPropertyChanged();
                }
            }
        }
        private string firstNameError;

        public string FirstNameError
        {
            get => firstNameError;
            set
            {
                if (value != firstNameError)
                {
                    firstNameError = value;
                    OnPropertyChanged();
                }
            }
        }
        private string emailError;

        public string EmailError
        {
            get => emailError;
            set
            {
                if (value != emailError)
                {
                    emailError = value;
                    OnPropertyChanged();
                }
            }
        }

        private string passwordError;

        public string PasswordError
        {
            get => passwordError;
            set
            {
                if (value != passwordError)
                {
                    passwordError = value;
                    OnPropertyChanged();
                }
            }
        }
        private string statusError;

        public string StatusError
        {
            get => statusError;
            set
            {
                if (value != statusError)
                {
                    statusError = value;
                    OnPropertyChanged();
                }
            }

            #endregion

            #region Commands

            #endregion

            #region Events

            #endregion
        }
    }
