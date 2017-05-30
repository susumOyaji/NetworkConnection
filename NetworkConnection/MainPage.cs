using System;

using Xamarin.Forms;

namespace NetworkConnection
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            var networkConnection = DependencyService.Get<INetworkConnection > ();
            networkConnection.CheckNetworkConnection();
            var networkStatus = networkConnection.IsConnected ? "Connected" : "Not Connected";

            var speak = new Button
            {
                Text = "Click to check Network connectivity",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };


            speak.Clicked += (sender, e) =>
            {
                speak.Text = DependencyService.Get<INetworkConnection > ().IsConnected ? "You are Connected" : "You are Not Connected";
            };

            Content = speak;










            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

