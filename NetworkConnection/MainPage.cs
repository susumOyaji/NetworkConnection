using System;

using Xamarin.Forms;

namespace NetworkConnection
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            var networkConnection = DependencyService.Get<INetworkConnection > ();
            string ip = networkConnection.CheckNetworkConnection();
            var networkStatus = networkConnection.IsConnected ? "Connected" : "Not Connected";

            var speak = new Button
            {
                Text = "Click to check"+ " Network connectivity IpAddress!",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };


            speak.Clicked += (sender, e) =>
            {
                speak.Text = ip;//DependencyService.Get<INetworkConnection > ().IsConnected ? "You are Connected" : "You are Not Connected";
            };

            Content = speak;

            

            //Content = new StackLayout
            //{
            //    Children = {speak,
            //        new Label { Text = "Hello ContentPage" }
            //    }
            //};
        }
    }
}

