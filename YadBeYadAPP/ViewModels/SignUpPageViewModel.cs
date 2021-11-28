using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
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
            FirstName = string.Empty;
            LastName = string.Empty;
            UserName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Age = default(int);
            status = string.Empty;
            FirstNameError = string.Empty;
            LastNameError = string.Empty;
            UserNameError = string.Empty;
            EmailError = string.Empty;
            AgeError = string.Empty;
            PasswordError = string.Empty;

            SignUpCommand = new Command(SignUp);

        }

        private async void SignUp()
        {
            YadBeYadAPIProxy proxy = YadBeYadAPIProxy.CreateProxy();
            try
            {
                FirstNameError = string.Empty;
                LastNameError = string.Empty;
                UserNameError = string.Empty;
                EmailError = string.Empty;
                AgeError = string.Empty;
                PasswordError = string.Empty;

                if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Email)
                    || string.IsNullOrEmpty(Password) || !ValidateEmail() || !ValidateName(FirstName) || !ValidateName(LastName) || Age == 0 )
                {
                    if (string.IsNullOrEmpty(FirstName))
                        FirstNameError = "Required Field";
                    else if (!ValidateName(FirstName))
                        FirstNameError = "First Name Not Valid";

                    if (string.IsNullOrEmpty(LastName))
                        LastNameError = "Required Field";
                    else if (!ValidateName(LastName))
                        LastNameError = "Last Name Not Valid";

                    if (string.IsNullOrEmpty(UserName))
                        UserNameError = "Required Field";

                    if (string.IsNullOrEmpty(Email))
                        EmailError = "Required Field";
                    else if (!ValidateEmail())
                        EmailError = "Email Not Valid";

                    if (Age == 0)
                        AgeError = "Required Field";
                  
                    if (string.IsNullOrEmpty(Password))
                        PasswordError = "Required Field";

                    return;
                }
                bool isUnique = await proxy.CheckUniqueness(Email, UserName);

                if (isUnique)
                {

                    User user = new User
                    {
                            Email = Email,
                            Pass = Password,
                            UserName = UserName,
                            Age = Age,
                            FirstName = FirstName,
                            LastName = LastName,
                            Rates = new List<Rate>(),
                            Reviews = new List<Review>()
                    };



                    bool b = await proxy.SignUpAsync(user);
                    Status = "Signing you up...";
                    if (b)
                        Status = "Sign Up Completed:)";
                    else
                        Status = "Something Went Wrong...";
                }
                else
                {
                    Status = "Email or/and User Name has/have already been used";
                }


            }
            catch (Exception)
            {
                Status = "Something Went Wrong...";
            }
        }

        public bool ValidateEmail() // a function that checks that the inserted email is in an email format
        {
            try
            {
                MailAddress TestEmail = new MailAddress(Email);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        public bool ValidateName(string name) //a function that checks that the inserted name has only letters
        {
            Regex rg = new Regex("^[A-Z][a-zA-Z/s]+$");
            return rg.IsMatch(name);
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
        }
            #endregion
      
        #region Commands

        public ICommand SignUpCommand { get; set; }

        #endregion

        #region Events


        #endregion

    }
}
