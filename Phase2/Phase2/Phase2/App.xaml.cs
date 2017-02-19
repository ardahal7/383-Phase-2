using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Phase2
{
    public partial class App : Application
    {
        //Label ResultsLabel;
        //SearchBar SearchBar;

        public App()
        {
            InitializeComponent();

            //NaviagationPage will add a navigation bar at the bottom of the screen. This can be set to visible, low profile, or hidden.
            MainPage = new NavigationPage(new MainPage());

 

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
