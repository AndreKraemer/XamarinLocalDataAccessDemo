using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinLocalDataAccessDemo.Pages;

namespace XamarinLocalDataAccessDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LocalDataButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ReadApplicationBaseDataDemoPage());
        }

        private void EditApplicationBaseDataButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditApplicationBaseDataDemoPage());
        }
    }
}
