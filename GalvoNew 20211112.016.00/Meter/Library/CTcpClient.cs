using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Meter.Library
{
    public class CTcpClient
    {
        //宣告網路資料流變數
       private NetworkStream myNetworkStream;
        //宣告 Tcp 用戶端物件
       private TcpClient myTcpClient;

       public CTcpClient()
       {
           // Console.WriteLine("輸入連接機名稱 : ");
           //取得主機名稱
           string hostName = "192.168.0.2";// Console.ReadLine();
           //Console.WriteLine("輸入連接通訊埠 : ");
           //取得連線 IP 位址
           int connectPort = int.Parse("36000");//Console.ReadLine());
           //建立 TcpClient 物件
           myTcpClient = new TcpClient();
           try
           {
               //測試連線至遠端主機
               myTcpClient.Connect(hostName, connectPort);
               //Console.WriteLine("連線成功 !!\n");
           }
           catch
           {
               //Console.WriteLine   ("主機 {0} 通訊埠 {1} 無法連接  !!", hostName, connectPort);
           }
       }

       //寫入資料
       void WriteData(ref string  CmdSent )
       {
           //String strTest = "this is a test string !!,123,456,789";
           //將字串轉 byte 陣列，使用 ASCII 編碼
           Byte[] myBytes = Encoding.ASCII.GetBytes(CmdSent);
           //Console.WriteLine("建立網路資料流 !!");
           //建立網路資料流
           myNetworkStream = myTcpClient.GetStream();
           //Console.WriteLine("將字串寫入資料流　!!");
           //將字串寫入資料流
           myNetworkStream.Write(myBytes, 0, myBytes.Length);
       }

       //讀取資料
       void ReadData(ref string RtnSts)
       {
           //Console.WriteLine("從網路資料流讀取資料 !!");
           //從網路資料流讀取資料
           int bufferSize = myTcpClient.ReceiveBufferSize;
           byte[] myBufferBytes = new byte[bufferSize];
           myNetworkStream.Read(myBufferBytes, 0, bufferSize);
           //取得資料並且解碼文字
           string recieveSts = Encoding.ASCII.GetString(myBufferBytes, 0, bufferSize);
           char delimiterChars = ',';
           string[] words = recieveSts.Split(delimiterChars);
           RtnSts = words[0];
           //Console.WriteLine(Encoding.ASCII.GetString(myBufferBytes, 0, bufferSize));
       }
    }
}
