
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;
using Xamarin.Forms;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Net;
using Android.Util;
using Android.Net.Wifi;
using Android.App;
using NetworkConnection.Droid;



[assembly: Xamarin.Forms.Dependency(typeof(NetworkConnection_Droid))]
namespace NetworkConnection.Droid
{
    public class NetworkConnection_Droid : INetworkConnection
    {
        public NetworkConnection_Droid() { }

        public bool IsConnected { get; set; }
        public string CheckNetworkConnection()
        {
            //Getting the IP Address of the device fro Android.
            IPAddress[] addresses = Dns.GetHostAddresses(Dns.GetHostName());
            string ipAddress = string.Empty;
            if (addresses != null && addresses[0] != null)
            {
                ipAddress = addresses[0].ToString();
            }
            else
            {
                ipAddress = null;
            }



            WifiManager manager = (WifiManager)Android.App.Application.Context.GetSystemService(Service.WifiService);
            int ip = manager.ConnectionInfo.IpAddress;

            string ipaddress = Android.Text.Format.Formatter.FormatIpAddress(ip);


            return "system = "+ipAddress + "   Wifi = " + ipaddress;
        }

    }

}
