
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
using System.Security;




//また、UDP通信とは別にTCP通信も待ち受け状態を作っておきます。
// これをしないと、④でゲストから通信しようとしても通信先のホストが見つからず、Exceptionが発生しますのでご注意ください。

namespace NetworkConnection.Droid
{

    //HostTCPHostWaitReceiv_Droid.cs
    public class HostTCPHostWaitReceiv
    {
        ServerSocket serverSocket;
        Socket connectedSocket;
        int tcpPort = 3333;//ホスト、ゲストで統一  

        //ゲストからの接続を待つ処理  
        void Connect()
        {
            //new Thread()
            //{
            //@Override
            void run()
            {
                try
                {
                    //ServerSocketを生成する
                    serverSocket = new ServerSocket(tcpPort);
                    //ゲストからの接続が完了するまで待って処理を進める 
                    connectedSocket = serverSocket.Accept();
                    //この後はconnectedSocketに対してInputStreamやOutputStreamを用いて入出力を行ったりするが、ここでは割愛      
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
            //}.start();
        }
    }
}

