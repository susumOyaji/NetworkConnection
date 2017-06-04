
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
using System.Threading;

/*
②ゲスト：ホスト探索開始。ゲスト端末のIPアドレスを発信する。

ホストが待ち受け態勢を作ったところで、次はゲスト側からブロードキャスト送信を行います。ここでは送信回数を10回、５秒間隔で送るように制限しています。
ブロードキャスト送信を行うとき、Wi-Fi設定が有効で、かつ、ネットワークに接続されていないとExceptionが発生しますので、対策が必要です。
*/

namespace NetworkConnection.Droid
{
    public class SendGuestIPAdress_Droid
    {
        bool waiting;
        int udpPort = 9999;//ホスト、ゲストで統一  

        //同一Wi-fiに接続している全端末に対してブロードキャスト送信を行う 
        void sendBroadcast()
        {
            string myIpAddress = getIpAddress();
            waiting = true;

            Thread thread = new Thread() {
            //@Override
            void run()
            {
                int count = 0;
                //送信回数を10回に制限する  
                while (count < 10)
                {
                    try
                    {
                        DatagramSocket udpSocket = new DatagramSocket(udpPort);
                        udpSocket.setBroadcast(true);
                        DatagramPacket packet = new DatagramPacket(myIpAddress.getBytes(), myIpAddress.length(), getBroadcastAddress(), udpPort);
                        udpSocket.send(packet);
                        udpSocket.close();
                    }
                    catch (SocketException e)
                    {
                        e.PrintStackTrace();
                    }
                    catch (IOException e)
                    {
                        e.PrintStackTrace();
                    }
                    //5秒待って再送信を行う  
                    try
                    {
                        Thread.sleep(5000);
                        count++;
                    }
                    catch (InterruptedException e)
                    {
                        e.PrintStackTrace();
                    }
                }
            }
        }.start();
    }
}


