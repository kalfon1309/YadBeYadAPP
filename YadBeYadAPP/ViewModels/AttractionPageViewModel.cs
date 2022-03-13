using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using YadBeYadApp.Models;
using YadBeYadApp.Services;

namespace YadBeYadAPP.ViewModels
{
    class AttractionPageViewModel : BaseViewModel
    {
        public AttractionPageViewModel()
        {
            GetAllAttractions();
            attractions = new ObservableCollection<Attraction>();
            lastText = string.Empty;
            Text = string.Empty;
        }
        private async void GetAllAttractions()
        {
            YadBeYadAPIProxy proxy = YadBeYadAPIProxy.CreateProxy();
            allAtttractions = await proxy.GetAttractionsAsync();
        }
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
                if(text != value)
                {
                    lastText = text;
                    text = value;
                    OnPropertyChanged();
                }
            }
        }
        private ObservableCollection<Attraction> attractions;

        public ObservableCollection<Attraction> Attractions
        {
            get
            {
                return attractions;
            }
        }
        private List<Attraction> allAtttractions;
        private void ChangeList(string search)
        {
            if(text.Length == lastText.Length)
            {
                foreach(Attraction a in allAtttractions)
                {
                    allAtttractions.Remove(a);
                    Attractions.Add(a);
                }
            }
            if(text.Length > lastText.Length)
            {
                foreach(Attraction a in Attractions)
                {
                    if(!a.AttName.Contains(search))
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
