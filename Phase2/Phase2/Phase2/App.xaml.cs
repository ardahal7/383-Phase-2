using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Phase2
{
    public partial class App : Application
    {
        Label ResultsLabel;
        SearchBar SearchBar;

        public App()
        {
            InitializeComponent();

            //NaviagationPage will add a navigation bar at the bottom of the screen. This can be set to visible, low profile, or hidden.
            MainPage = new NavigationPage(new MainPage());

            //This will create the area that the results will appear
            ResultsLabel = new Label
            {
                Text = "Result will appear here.",
                VerticalOptions = LayoutOptions.FillAndExpand,
                FontSize = 25
            };


            //This will create the searchbar
            SearchBar = new SearchBar
            {
                Placeholder = "Please Search for a Username",
                SearchCommand = new Command(() => { ResultsLabel.Text = "Result: " + SearchBar.Text + " is what you asked for."; })

            };

            //Creates the layout
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Start,
                    Children = {
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "CMPS383 - Phase 2",
                        FontSize = 25
                    },
                    SearchBar,
                    new ScrollView
                    {
                        Content = ResultsLabel,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    }
                },
                    Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5)

                }

            };

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
