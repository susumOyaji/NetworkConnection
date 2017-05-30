﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Net;

using NetworkConnection.Droid;



[assembly: Dependency(typeof(NetworkConnection_Droid))]
namespace NetworkConnection.Droid
{
    public class NetworkConnection_Droid : INetworkConnection
    {
        public NetworkConnection_Droid() { }

        public bool IsConnected { get; set; }
            public void CheckNetworkConnection()
            {
                var connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
                var activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
                if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting)
                {
                    IsConnected = true;
                }
                else
                {
                    IsConnected = false;
                }
            }
    }

}