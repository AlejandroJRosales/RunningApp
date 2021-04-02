using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RunningApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Totals : ContentPage
    {

        private void ResetListViewSources()
        {
            runLogListView.ItemsSource = DB.conn.Table<RunEntry>().ToList();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ResetListViewSources();
        }

        public Totals()
        {
            InitializeComponent();
            runLogListView.ItemsSource = DB.conn.Table<RunEntry>().ToList();
        }
    }
}