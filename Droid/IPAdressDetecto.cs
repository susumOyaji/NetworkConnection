
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Net;
using Java.IO;
using Java.Net;
using Java.Lang;
using Android.Net.Wifi;
using System.Threading;

namespace NetworkConnection.Droid
{
    public class IPAdressDetecto
    {
        WifiManager wifi;

        /*コンストラクタ*/
        public int Sample_WifiConnection(Context context)
        {
            wifi = (WifiManager)context.getSystemService(Context.WIFI_SERVICE);
        }

        //IPアドレスの取得  
        int getIpAddress()
        {
            int ipAddress_int = wifi.getConnectionInfo().getIpAddress();
            if (ipAddress_int == 0)
            {
                ipAddress = null;
            }
            else
            {
                ipAddress = (ipAddress_int & 0xFF) + "." + (ipAddress_int >> 8 & 0xFF) + "." + (ipAddress_int >> 16 & 0xFF) + "." + (ipAddress_int >> 24 & 0xFF);
            }
            return ipAddress;
        }

        //ブロードキャストアドレスの取得    
        InetAddress getBroadcastAddress()
        {
            DhcpInfo dhcpInfo = wifi.getDhcpInfo();
            int broadcast = (dhcpInfo.ipAddress & dhcpInfo.netmask) | ~dhcpInfo.netmask;
            byte[] quads = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                quads[i] = (byte)((broadcast >> i * 8) & 0xFF);
            }
            try
            {
                return InetAddress.getByAddress(quads);
            }
            catch (IOException e)
            {
                e.PrintStackTrace();
                return null;
            }
        }
        //次に、ホストからTCP通信でIPアドレスが返されてくるので、受け取るための待ち受け状態を作っておきます。

        //ホストからTCPでIPアドレスが返ってきたときに受け取るメソッド  
        void receivedHostIp()
        {
            bool waiting = true;
            //Thread a = new Thread() { run() { int a = 0; } }.Start();

            new Thread()
            {
       // @Override
                void run()
                {
                    while (waiting)
                    {
                    try
                    {
                        if (serverSocket == null)
                        {
                            serverSocket = new ServerSocket(serverSocket);
                        }
                        socket = serverSocket.accept();
                        //↓③で使用  
                        inputDeviceNameAndIp(socket);
                        if (serverSocket != null)
                        {
                            serverSocket.close();
                            serverSocket = null;
                        }
                        if (socket != null)
                        {
                            socket.close();
                            socket = null;
                        }
                    }
                    catch (IOException e)
                    {
                        waiting = false;
                        e.PrintStackTrace();
                    }
                }
            }
        }.start();
    }
}


