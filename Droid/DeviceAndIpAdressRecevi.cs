
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
④ゲスト：ホストから端末情報を受け取る
ゲストからTCP通信が行われると待ち状態になっていた処理が再開し、②で準備していたinputDeviceNameAndIp()まで処理が進みます。
socket = serverSocket.accept();    
//↓③で使用  
inputDeviceNameAndIp(socket);   
このメソッドはIPアドレスと端末名を取得して保持するために用意しています。
*/

namespace NetworkConnection.Droid
{
    //端末名とIPアドレスのセットを受け取る
    public class DeviceAndIpAdressRecevi
    {
        void inputDeviceNameAndIp(Socket socket)
        {
            try
            {
                BufferedReader bufferedReader = new BufferedReader(
                        new InputStreamReader(socket.getInputStream())
                );
                int infoCounter = 0;
                String remoteDeviceInfo;

                //ホスト端末情報(端末名とIPアドレス)を保持するためのクラスオブジェクト 
                //※このクラスは別途作成しているもの  
                SampleDevice hostDevice = new SampleDevice();
                while ((remoteDeviceInfo = bufferedReader.ReadLine()) != null && !remoteDeviceInfo.equals("outputFinish"))
                {
                    switch (infoCounter)
                    {
                        case 0:
                            //1行目、端末名の格納 
                            hostDevice.setDeviceName(remoteDeviceInfo);
                            infoCounter++;
                            break;
                        case 1:
                            //2行目、IPアドレスの取得    
                            hostDevice.setDeviceIpAddress(remoteDeviceInfo);
                            infoCounter++;
                            return;
                        default:
                            return;
                    }
                }
            }
            catch (IOException e)
            {
                e.PrintStackTrace();
            }
        }
    }
    //ゲストが端末情報を受け取るとき、本来はreturnしなくていいのですが、どうにも読み込みが完了してくれなかったので無理やり処理を完了させるためreturnさせています。もっとスマートなやり方があるはず…。

}
