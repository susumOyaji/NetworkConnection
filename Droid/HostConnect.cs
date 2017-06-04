
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


/*
⑤ゲスト：ホストのIPアドレスが判明して、TCP通信を開始する。
ゲスト端末でホストのIPアドレスを入手することが出来たので、あとはTCP通信を試みるだけです。
*/
namespace NetworkConnection.Droid
{   
    //IPアドレスが判明したホストに対して接続を行う 
    public class HostConnect
    {
        public void Connect(String remoteIpAddress)
        {
            bool waiting = false;

            new Thread()
            {
                override void run()
                {
                try
                {
                    if (socket == null)
                    {
                        socket = new Socket(remoteIpAddress, tcpPort);
                        //この後はホストに対してInputStreamやOutputStreamを用いて入出力を行ったりするが、ここでは割愛        
                    }
                }
                catch (UnknownHostException e)
                {
                    e.PrintStackTrace();
                }
                catch (ConnectException e)
                {
                    e.PrintStackTrace();
                }
                catch (IOException e)
                {
                    e.PrintStackTrace();
                }
            }
        }.start();
        }       
    }
}



/*
終わりに

いかがでしたでしょうか？ 
私がアスネット開発のMeetingForceに同一のWi-Fiに接続したホストとゲスト間でBluetoothと同様の通信を可能にするために苦戦した際の経験をもとに作成してみました。BufferdReader、BufferdWriterのサンプルが意外と出てこなかったり、UDP送受信をした後どうすればいい、というのが見つけられなかったり、いろいろ困ったので。UDP・TCP通信のサンプルをお探しの方に、ほんの少しでもお役にたてれば幸いです。

参考URL

MeetingForceって何？と思った方はこちらからどうぞ。

MeetingForce
*/
//http://meetingforce.net/

//Bluetoothを利用した複数端末の接続方法　～MeetingForce～

//http://asnet.hatenablog.com/entry/2015/07/07/131518


