
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
using Java.Net;
using Java.IO;
using System.Threading;
using Xamarin.Android;
using Xamarin.Forms;


/*    
③ホスト：ゲストから受信したIPアドレスに対してホスト端末のIPアドレスを送り返す。
①でIPアドレスを受け取ると
receiveUdpSocket.receive(packet);  
ここで止まっていた処理が再開します。
受信データ(IPアドレス)を文字列に変換して、 
IPアドレスを返すために用意したメソッドに受け取ったアドレスを引数に渡します。
returnIpAdress(address);   

処理はこんな感じです。
*/

namespace NetworkConnection.Droid
{

    public class ReturnIpaAdress
    {
        Socket returnSocket;

        //ブロードキャスト発信者(ゲスト)にIPアドレスと端末名を返す   
        void returnIpAdress(string address)
        {
            //new Thread() {
            void run()
            {
                try
                {
                    if (returnSocket != null)
                    {
                        returnSocket.Close();
                        returnSocket = null;
                    }
                    if (returnSocket == null)
                    {
                        returnSocket = new Socket(address, tcpPort);
                    }
                    //端末情報をゲストに送り返す  
                    outputDeviceNameAndIp(returnSocket, getDeviceName(), getIpAddress);
                }
                catch (UnknownHostException e)
                {
                    e.PrintStackTrace();
                }
                catch (java.net.ConnectException e)
                {
                    e.printStackTrace();
                    try
                    {
                        if (returnSocket != null)
                        {
                            returnSocket.Close();
                            returnSocket = null;
                        }
                    }
                    catch (IOException e1)
                    {
                        e.printStackTrace();
                    }
                 }
                 catch (IOException e)
                 {
                        e.PrintStackTrace();
                 }
             }
          //}.start();
       }
    }        

}
