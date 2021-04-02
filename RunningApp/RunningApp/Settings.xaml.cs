using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace RunningApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {

        protected override void OnAppearing()
        {
            genderEntry.Text = Preferences.Get("gender", "None");
            //dobPicker.Date = Preferences.Get("dob", "4/10/1998");
            unitsSwitch.IsToggled = true ? Preferences.Get("units", "Miles") == "Miles" : false;
        }

        private void CreditsClicked(object sender, EventArgs e)
        {
            try
            {
                Browser.OpenAsync("https://miamioh.edu/", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                DisplayAlert("Oops", "We couldn't complete your request, try again later", "OK");
            }
        }

        private void SubmitClicked(object sender, EventArgs e)
        {
            string units = unitsSwitch.IsToggled ? "Km" : "Miles";
            Preferences.Set("gender", genderEntry.Text);
            Preferences.Set("dob", dobPicker.ToString());
            Preferences.Set("units", units);

            // DB.conn.UpdateAll(units);
        }

        public Settings()
        {
            InitializeComponent();
        }
    }
}