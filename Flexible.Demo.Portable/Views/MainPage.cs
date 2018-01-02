using System;
using Xamarin.Flexible;
using Xamarin.Forms;

namespace Flexible.Demo
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            //Page itemsPage, aboutPage, flexiPage = null;

            //switch (Device.RuntimePlatform)
            //{
            //    case Device.iOS:
            //        itemsPage = new NavigationPage(new ItemsPage())
            //        {
            //            Title = "Browse"
            //        };

            //        aboutPage = new NavigationPage(new AboutPage())
            //        {
            //            Title = "About"
            //        };
            //        itemsPage.Icon = "tab_feed.png";
            //        aboutPage.Icon = "tab_about.png";
            //        break;
            //    default:
            //        itemsPage = new ItemsPage()
            //        {
            //            Title = "Browse"
            //        };

            //        aboutPage = new AboutPage()
            //        {
            //            Title = "About"
            //        };

                    StackLayout flexiContents = new StackLayout();

                    flexiContents.Children.Add(new FlexiPage { Content = new ContentPage { BackgroundColor = Color.BlueViolet, Content = new Label { Text = "Content 1" } } });
                    flexiContents.Children.Add(new FlexiPage { Content = new ContentPage { BackgroundColor = Color.BurlyWood, Content = new Label { Text = "Content 2" } } });
                    flexiContents.Children.Add(new FlexiPage { Content = new ContentPage { BackgroundColor = Color.Coral, Content = new Label { Text = "Content 3" } } });
                    flexiContents.Children.Add(new FlexiPage { Content = new ContentPage { BackgroundColor = Color.Crimson, Content = new Label { Text = "Content 4" } } });
                    flexiContents.Children.Add(new FlexiPage { Content = new ContentPage { BackgroundColor = Color.DarkGoldenrod, Content = new Label { Text = "Content 5" } } });

            Content = flexiContents;
                    //flexiPage = new ContentPage()
                    //{
                    //    Title = "Flexi Page",
                    //    BackgroundColor = Color.AliceBlue,
                    //    Content = flexiContents
                    //};

            //        break;
            //}

            //Children.Add(itemsPage);
            //Children.Add(aboutPage);
            //Children.Add(flexiPage);

            //Title = Children[0].Title;
        }

        //protected override void OnCurrentPageChanged()
        //{
        //    base.OnCurrentPageChanged();
        //    Title = CurrentPage?.Title ?? string.Empty;
        //}
    }
}
