using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MVVMFormsApp.Models;
using Xamarin.Forms;

namespace MVVMFormsApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public Command LaunchWebsiteCommand { get; }

        public Command SaveChangesCommand { get; }

        public MainViewModel()
        {
            LaunchWebsiteCommand = new Command(LaunchWebsite, ()=> !isBusy);
            SaveChangesCommand = new Command(async () => await SaveChanges(),()=> !isBusy );
        }

        Friend mmmm = new Friend();
        string name = "";
        string website = "";
        bool isBusy;
        bool bestFriend;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool BestFriend
        {
            get { return bestFriend; }
            set
            {
                bestFriend = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }
        public string Website
        {
            get { return website; }
            set
            {
                website = value;
                OnPropertyChanged();
               // OnPropertyChanged(nameof(Website));
            }
        }
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        void OnPropertyChanged([CallerMemberName] string anystring = "")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(anystring));
        }

        public string DisplayMessage
        {
            get { return $"Your new friend name is {name} and" + $"{(bestFriend ? " is" : " is not")} your best friend"; }
        }

        public void LaunchWebsite()
        {
            try
            {
                Device.OpenUri(new Uri(website));
            }
            catch
            {
              
            }
        }
        public async Task SaveChanges()
        {
            IsBusy = true;
            await Task.Delay(4000);
            IsBusy = false;
            await Application.Current.MainPage.DisplayAlert("Alert", "Info Saved!", "Ok");
        }
    }
}
