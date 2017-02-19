using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Phase2
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Summoners> summoners = new ObservableCollection<Summoners>();

        Label ResultsLabel;
        SearchBar SearchBar;

        public MainPage()
        {
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
            //MainPage = new ContentPage
            //{
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Start,
            //        Children = {
            //        new Label {
            //            HorizontalTextAlignment = TextAlignment.Center,
            //            Text = "CMPS383 - Phase 2",
            //            FontSize = 25
            //        },
            //        SearchBar,
            //        new ScrollView
            //        {
            //            Content = ResultsLabel,
            //            VerticalOptions = LayoutOptions.FillAndExpand
            //        }
            //    },
            //        Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5)

            //    }

            //};
            Label header = new Label
            {
                Text = "ListView",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            // Define some data.
            summoners.Add(new Summoners { Name = "Aayush Dahal", Level= 40 });
            summoners.Add(new Summoners { Name = "Shiva Shrestha", Level = 50 });

            // Create the ListView.
            ListView listView = new ListView
            {
                // Source of data items.
                ItemsSource = summoners,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Name");

                    Label levelLabel = new Label();
                    levelLabel.SetBinding(Label.TextProperty, "Level");
                        

                    
                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                                {
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.Center,
                                        Spacing = 0,
                                        Children =
                                        {
                                           // SearchBar,
                                           // ResultsLabel,
                                            nameLabel,
                                            levelLabel
                                        }
                                        }
                                }
                        }
                    };
                })
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    SearchBar,
                    ResultsLabel,
                    header,
                    listView
                }
            };
        }
    }
}
        