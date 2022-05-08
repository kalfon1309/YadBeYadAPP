using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using YadBeYadApp.Models;
using YadBeYadApp.Services;
using YadBeYadApp.Views;

namespace YadBeYadApp.ViewModels
{
    class AttractionPageViewModel : BaseViewModel
    {
        public AttractionPageViewModel()
        {
            Attractions = new ObservableCollection<Attraction>(CurrentApp.attractions);
            allAtttractions = CurrentApp.attractions;
            
            lastText = string.Empty;
            Text = string.Empty;
            ProfileCommand = new Command(ToProfilePage);
            AttractionCommand = new Command(ToDetailAttPage);
            ShowAllCommand = new Command(ShowAll);
            SearchCommand = new Command(Search);
        }

        private void Search()
        {
            List<Attraction> temp = new List<Attraction>();
            foreach (Attraction attraction in Attractions)
            {
                if(attraction.AttName.Contains(Text))
                {
                    temp.Add(attraction);
                }
            }
            Attractions = new ObservableCollection<Attraction>(temp);
            OnPropertyChanged("Attractions");
        }

        private void ToProfilePage()
        {
            Push?.Invoke(new ProfilePage());
        }

        private void ShowAll()
        {
            Attractions = new ObservableCollection<Attraction>(allAtttractions);
            OnPropertyChanged("Attractions");
        }
        private void ToDetailAttPage()
        {
            Push?.Invoke(new AttractionDetail());
        }

        private async void GetAllAttractions()
        {
            YadBeYadAPIProxy proxy = YadBeYadAPIProxy.CreateProxy();
            allAtttractions = await proxy.GetAttractionsAsync();
            Attractions = new ObservableCollection<Attraction>();
            foreach (Attraction attraction in allAtttractions)
            {
                Attractions.Add(attraction);
            }

        }


       


        #region Properties


        private string lastText;
        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                if (text != value)
                {
                    lastText = text;
                    text = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Attraction> Attractions { get; set; }

        private List<Attraction> allAtttractions;

     
        #endregion

        #region Commands

        public ICommand ProfileCommand { get; set; }

        public ICommand ShowAllCommand { get; set; }

        public ICommand AttractionCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        #endregion

        #region Events

        public event Action<Page> Push;

        #endregion


        private void ChangeList(string search)
        {
            if (text.Length == lastText.Length)
            {
                foreach (Attraction a in allAtttractions)
                {
                    allAtttractions.Remove(a);
                    Attractions.Add(a);
                }
            }
            if (text.Length > lastText.Length)
            {
                foreach (Attraction a in Attractions)
                {
                    if (!a.AttName.Contains(search))
                    {
                        Attractions.Remove(a);
                        allAtttractions.Add(a);
                    }
                }
            }
            else
            {
                foreach (Attraction a in allAtttractions)
                {
                    if (a.AttName.Contains(search))
                    {
                        allAtttractions.Remove(a);
                        Attractions.Add(a);
                    }
                }
            }
        }



    }
}
