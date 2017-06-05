
using Java.Net;
using Java.IO;
using Java.Lang.Reflect;
using System.Threading;
//using NetworkConnection.Droid;

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


/*
①ホスト：ゲストから発信されるブロードキャストを受信できる(受信待ち受け)状態にする。
ゲストからいくらブロードキャスト送信をしていても、ホスト側で受け取り態勢が整っていなければ受け取ることが出来ません。
まずはゲストが送信を開始する前に待ち受け状態にします。
*/

namespace NetworkConnection.Droid
{
    // HostWaitReceiv_Droid.cs
    public class HostWaitReceiv
    {
        DatagramSocket receiveUdpSocket;
        bool waiting;
        int udpPort = 9999;//ホスト、ゲストで統一  

        //ブロードキャスト受信用ソケットの生成   
        //ブロードキャスト受信待ち状態を作る  
        public void createReceiveUdpSocket()
        {
            waiting = true;



            //new Thread()
            //{
            void run()
            {
                string address = null;

                try
                {
                    //waiting = trueの間、ブロードキャストを受け取る
                    while (waiting)
                    {
                        //受信用ソケット
                        DatagramSocket receiveUdpSocket = new DatagramSocket(udpPort);
                        byte[] buf = new byte[256];
                        DatagramPacket packet = new DatagramPacket(buf, buf.Length);

                        //ゲスト端末からのブロードキャストを受け取る  
                        //受け取るまでは待ち状態になる   
                        receiveUdpSocket.Receive(packet);

                        //受信バイト数取得 
                        int length = packet.Length;//getlength()

                        //受け取ったパケットを文字列にする 
                        address = new String(buf, 0,length);

                        //↓③で使用  
                        returnIpAdress(address);
                        receiveUdpSocket.close();
                    }
                }
                catch (SocketException e)
                {
                    e.PrintStackTrace();
                }
                catch (IOException e)
                {
                    e.PrintStackTrace();
                }
            }
        }    // }.Start();
    }
}

 


