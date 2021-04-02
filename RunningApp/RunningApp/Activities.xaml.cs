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
    public partial class Activities : ContentPage
    {
        private void AddClicked(object sender, EventArgs e)
        {
            try
            {
                RunEntry newRunEntry = new RunEntry
                {
                    RunDate = runDatePicker.Date,
                    Distance = Double.Parse(runDistanceEntry.Text),
                    RunTime = runTime.Text
                };
                DB.conn.Insert(newRunEntry);
                ResetListViewSources();
            } catch
            {
                DisplayAlert("Oops", "Your entry is invalid, please try again", "Ugh OK");
            }
        }

        private void UpdateClicked(object sender, EventArgs e)
        {
            RunEntry oldActivity = runLogListView.SelectedItem as RunEntry;
            if (oldActivity != null)
            {
                RunEntry newActivity = new RunEntry
                {
                    RunDate = runDatePicker.Date,
                    Distance = Double.Parse(runDistanceEntry.Text),
                    RunTime = runTime.Text
                };
                newActivity.Id = oldActivity.Id;
                DB.conn.Update(newActivity);
                ResetListViewSources();
            } else
            {
                DisplayAlert("Oops", "Looks like you didn't select anything. Please select something and try again.", "OK");
            }
        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            RunEntry activity = runLogListView.SelectedItem as RunEntry;
            if (activity != null)
            {
                int v = DB.conn.Delete(activity);
                if (v > 0)
                {
                    runLogListView.SelectedItem = null;
                    ResetListViewSources();
                }
            }
        }

        private void ResetListViewSources()
        {
            runLogListView.ItemsSource = DB.conn.Table<RunEntry>().ToList();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            runDistanceLabel.Text = "Distance in " + Preferences.Get("units", "Miles");
            ResetListViewSources();
        }

        public Activities()
        {
            InitializeComponent();
            runDatePicker.Date = DateTime.Now.Date;
            runLogListView.ItemsSource = DB.conn.Table<RunEntry>().ToList();
        }
    }
}