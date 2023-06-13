using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using PseudoLaserSystem;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Meter.HeaderFile;
namespace Meter
{
    public partial class Form1 : Form
    {

        private double Move_Galvo_Move_Step;
        private CTrimEng m_TrimEng;
        private CMeter m_Meter;
        void Float2Array(float SrcValue, Byte[] DestAry)
        {
            float a = -135.678f;
            byte[] b = new byte[10];
            byte[] bBytes = BitConverter.GetBytes(a);
        }



        Socket[] SckSs;   // 一般而言 Server 端都會設計成可以多人同時連線. 
        int SckCIndex;    // 定義一個指標用來判斷現下有哪一個空的 Socket 可以分配給 Client 端連線;
        string LocalIP = "192.168.0.2"; // 其中 xxx.xxx.xxx.xxx 為本機IP
        int SPort = 6101;

        int RDataLen = 8196; // 這裡的RDataLen為要傳送資料的長度


        private bool m_TCPThread;
        public Form1()
        {
            InitializeComponent();
            //////////m_Meter = new CMeter();
            m_Meter = new CMeter(false);
            m_TrimEng = new CTrimEng(ref m_Meter);
            m_TCPThread = true;
            Listen();
        }



        // 聆聽
        private void Listen()
        {
            // 用 Resize 的方式動態增加 Socket 的數目

            Array.Resize(ref SckSs, 1);

            SckSs[0] = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            SckSs[0].Bind(new IPEndPoint(IPAddress.Parse(LocalIP), SPort));



            // 其中 LocalIP 和 SPort 分別為 string 和 int 型態, 前者為 Server 端的IP, 後者為S erver 端的Port

            SckSs[0].Listen(10); // 進行聆聽; Listen( )為允許 Client 同時連線的最大數

            SckSWaitAccept();   // 另外寫一個函數用來分配 Client 端的 Socket

        }
        // 等待Client連線

        private void SckSWaitAccept()
        {

            // 判斷目前是否有空的 Socket 可以提供給Client端連線

            bool FlagFinded = false;

            for (int i = 1; i < SckSs.Length; i++)
            {

                // SckSs[i] 若不為 null 表示已被實作過, 判斷是否有 Client 端連線

                if (SckSs[i] != null)
                {

                    // 如果目前第 i 個 Socket 若沒有人連線, 便可提供給下一個 Client 進行連線
                    if (SckSs[i].Connected == false)
                    {

                        SckCIndex = i;

                        FlagFinded = true;

                        break;

                    }

                }

            }

            // 如果 FlagFinded 為 false 表示目前並沒有多餘的 Socket 可供 Client 連線

            if (FlagFinded == false)
            {

                // 增加 Socket 的數目以供下一個 Client 端進行連線

                SckCIndex = SckSs.Length;

                Array.Resize(ref SckSs, SckCIndex + 1);

            }



            // 以下兩行為多執行緒的寫法, 因為接下來 Server 端的部份要使用 Accept() 讓 Cleint 進行連線;

            // 該執行緒有需要時再產生即可, 因此定義為區域性的 Thread. 命名為 SckSAcceptTd;

            // 在 new Thread( ) 裡為要多執行緒去執行的函數. 這裡命名為 SckSAcceptProc;

            Thread SckSAcceptTd = new Thread(SckSAcceptProc);
            SckSAcceptTd.Priority = ThreadPriority.Normal;

            // Of course this only affects the main thread rather than child threads.
            //SckSAcceptTd.Priority = ThreadPriority.Highest;
            SckSAcceptTd.Start();  // 開始執行 SckSAcceptTd 這個執行緒


            // 這裡要點出 SckSacceptTd 這個執行緒會在 Start( ) 之後開始執行 SckSAcceptProc 裡的程式碼, 同時主程式的執行緒也會繼續往下執行各做各的. 

            // 主程式不用等到 SckSAcceptProc 的程式碼執行完便會繼續往下執行.

        }


        // 接收來自Client的連線與Client傳來的資料

        private void SckSAcceptProc()
        {
            // 這裡加入 try 是因為 SckSs[0] 若被 Close 的話, SckSs[0].Accept() 會產生錯誤

            String strSend = "Error Id=0x0001";
            try
            {
                SckSs[SckCIndex] = SckSs[0].Accept();  // 等待Client 端連線
                // 為什麼 Accept 部份要用多執行緒, 因為 SckSs[0] 會停在這一行程式碼直到有 Client 端連上線, 並分配給 SckSs[SckCIndex] 給 Client 連線之後程式才會繼續往下, 若是將 Accept 寫在主執行緒裡, 在沒有Client連上來之前, 主程式將會被hand在這一行無法再做任何事了!!
                // 能來這表示有 Client 連上線. 記錄該 Client 對應的 SckCIndex
                int Scki = SckCIndex;
                // 再產生另一個執行緒等待下一個 Client 連線
                //SckSWaitAccept(); 先關掉多Client
                long IntAcceptData;
                byte[] clientData = new byte[RDataLen];  // 其中RDataLen為每次要接受來自 Client 傳來的資料長度


                string receiveCmd = "";
                string S;
                string[] words;
                char[] delimiterChars = { ',', '\r', '\n', '\0' };


                while (m_TCPThread)
                {

                    // 程式會被 hand 在此, 等待接收來自 Client 端傳來的資料
                    IntAcceptData = SckSs[Scki].Receive(clientData);

                    // 往下就自己寫接收到來自Client端的資料後要做什麼事唄~^^”

                    // 因為Client端傳ABCDE過來, 所以可以試著將Byte陣列轉成字串列印出來看看~

                    try
                    {
                        receiveCmd = Encoding.Default.GetString(clientData);
                        S = Encoding.Default.GetString(clientData);
                        words = receiveCmd.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                        switch (words[0])
                        {
                            case "InitialHw":
                                try
                                {

                                    bool rtn = m_TrimEng.InitialHw();
                                    if (rtn == true)
                                    { strSend = "InitialHw Ok,"; }
                                    else
                                    { strSend = "NG,0,"; }
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                }
                                break;

                            case "CloseHw":
                                try
                                {

                                    Application.Exit();
                                 //m_TrimEng.CloseHw();
                                    strSend = "CloseHw Ok,"; 
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                }
                                break;
                            case "JumpSpeed":
                                try
                                {
                                    m_TrimEng.JumpSpeed = Int32.Parse(words[1]);
                                }
                                catch(Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                }
                                break;
                            case "SpeedYNoWork":
                                try
                                {
                                    m_TrimEng.SpeedYNoWork = Int32.Parse(words[1]);
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                }
                                break;
                            case "JumpDelay":
                                try
                                {
                                    m_TrimEng.JumpDelay = Int32.Parse(words[1]);
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                }
                                break;

                            case "ResNoWorkOffset":
                                try
                                {
                                    m_TrimEng.ResNoWorkOffset = double.Parse(words[1]);
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                }
                                break;

                            case "CheckConnectToServer":
                                try
                                {
                                    strSend = "OK";
                                }
                                catch(Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                }
                                break;
                            case "TotalResistor":
                                try
                                {
                                    m_TrimEng.TotalResistor = Int32.Parse(words[1]);
                                    //將接收到的資料回傳給用戶端
                                    strSend = "TotalResistor Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "TotalResistor");
                                }
                                break;

                            case "ScaleFactorX":
                                try
                                {
                                    // m_TrimEng.ScaleFactorX = Double.Parse(words[1]);
                                    //將接收到的資料回傳給用戶端
                                    strSend = "ScaleFactorX Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "ScaleFactorX");
                                }
                                break;
                            case "ScaleFactorY":
                                try
                                {
                                    // m_TrimEng.ScaleFactorY = Double.Parse(words[1]);
                                    //將接收到的資料回傳給用戶端
                                    strSend = "ScaleFactorY Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "ScaleFactorY");
                                }
                                break;
                            case "CalculateResGalvoPos": //回傳 命令 起始索引值1開始 結束所引值1開始 XPos[0] YPos[0] XPos[1] YPos[1]
                                try
                                {
                                    m_TrimEng.CalculateResGalvoPos();
                                    strSend = "CalculateResGalvoPos Ok," + m_TrimEng.ResIdMark1.ToString() + "," + m_TrimEng.ResIdMark2.ToString() + ",";
                                    for (int aryIdx = (m_TrimEng.ResIdMark1 - 1); aryIdx < m_TrimEng.ResIdMark2; aryIdx++)
                                    {
                                        strSend = strSend + m_TrimEng.ResistorList.ElementAt(aryIdx).GalvoXPos.ToString() + "," + m_TrimEng.ResistorList.ElementAt(aryIdx).GalvoYPos.ToString() + ",";
                                    }
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    throw new System.ArgumentException(e.ToString(), "CalculateResGalvoPos");
                                }
                                break;

                            case "CalculateResColGalvoPos": //回傳 命令 起始索引值1開始 結束所引值1開始 XPos[0] YPos[0] XPos[1] YPos[1]
                                try
                                {
                                    m_TrimEng.CalculateResColGalvoPos();
                                    strSend = "CalculateResColGalvoPos Ok," + m_TrimEng.ResColIdMark1.ToString() + "," + m_TrimEng.ResColIdMark2.ToString() + ",";
                                    for (int aryIdx = (m_TrimEng.ResColIdMark1 - 1); aryIdx < m_TrimEng.ResColIdMark2; aryIdx++)
                                    {
                                        strSend = strSend + m_TrimEng.PanelList.ElementAt(aryIdx).GalvoColOffsetX.ToString("F10") + "," + m_TrimEng.PanelList.ElementAt(aryIdx).GalvoColOffsetY.ToString("F10") + ",";
                                    }
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "CalculateResColGalvoPos"); 
                                }
                                break;

                            case "CurrentResID":  // ReadOnly
                                try
                                {
                                    strSend = "CurrentResID Ok," + m_TrimEng.CurrentResID.ToString() + ",";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "CurrentResID");
                                }
                                break;
                            case "CutSetting":
                                try
                                {
                                    CCutParam[] cutData = new CCutParam[Int32.Parse(words[1])];
                                    for (int aryIdx = 0; aryIdx < cutData.Length; aryIdx++)
                                    {
                                        cutData[aryIdx] = new CCutParam();
                                        cutData[aryIdx].CutID = int.Parse(words[(17 * aryIdx) + 2]);
                                        cutData[aryIdx].Delay = Int32.Parse(words[(17 * aryIdx) + 3]);
                                        cutData[aryIdx].Direction = Int32.Parse(words[(17 * aryIdx) + 4]);
                                        cutData[aryIdx].PulseDensity = Int32.Parse(words[(17 * aryIdx) + 5]);
                                        cutData[aryIdx].QRate = double.Parse(words[(17 * aryIdx) + 6]);
                                        cutData[aryIdx].Repo = words[(17 * aryIdx) + 7];
                                        cutData[aryIdx].Speed = double.Parse(words[(17 * aryIdx) + 8]);
                                        cutData[aryIdx].Length = double.Parse(words[(17 * aryIdx) + 9]);
                                        cutData[aryIdx].StopPercentA = double.Parse(words[(17 * aryIdx) + 10]);
                                        cutData[aryIdx].StopPercentB = double.Parse(words[(17 * aryIdx) + 11]);
                                        cutData[aryIdx].StopPercentC = double.Parse(words[(17 * aryIdx) + 12]);
                                        cutData[aryIdx].StopPercentD = double.Parse(words[(17 * aryIdx) + 13]);
                                        cutData[aryIdx].StopPercentE = double.Parse(words[(17 * aryIdx) + 14]);
                                        cutData[aryIdx].StopPercentF = double.Parse(words[(17 * aryIdx) + 15]);
                                        cutData[aryIdx].StopPercentG = double.Parse(words[(17 * aryIdx) + 16]);
                                        cutData[aryIdx].XOffset = double.Parse(words[(17 * aryIdx) + 17]);
                                        cutData[aryIdx].YOffset = double.Parse(words[(17 * aryIdx) + 18]);
                                    }
                                    m_TrimEng.CutSetting(ref cutData);
                                    strSend = "CutSetting Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "CutSetting");
                                }
                                break;
                            case "GalvoAbsMove":
                                try
                                {
                                    m_TrimEng.GalvoAbsMove(double.Parse(words[1]), double.Parse(words[2]));
                                    //將接收到的資料回傳給用戶端
                                    strSend = "GalvoAbsMove Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "GalvoAbsMove");
                                }
                                break;
                            case "GalvoRelMove":
                                try
                                {
                                    double disMove = double.Parse(words[2]);
                                    bool dirMove = bool.Parse(words[1]);
                                    if (dirMove == true)
                                    {
                                        m_TrimEng.GalvoRelMove(disMove, 0);
                                    }
                                    else
                                    {
                                        m_TrimEng.GalvoRelMove(0, disMove);
                                    }
                                    //將接收到的資料回傳給用戶端
                                    strSend = "GalvoRelMove Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "GalvoRelMove");
                                }
                                break;
                            case "GetGalvoPosX":
                                try
                                {
                                    //將接收到的資料回傳給用戶端
                                    strSend = "GetGalvoPosX Ok," + m_TrimEng.GetGalvoPosX.ToString("F10") + ",";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "GetGalvoPosX");
                                }
                                break;
                            case "GetGalvoPosY":
                                try
                                {
                                    //將接收到的資料回傳給用戶端
                                    strSend = "GetGalvoPosY Ok," + m_TrimEng.GetGalvoPosY.ToString("F10") + ",";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "GetGalvoPosY");
                                }
                                break;
                            case "GetPower":
                                try
                                {
                                    //將接收到的資料回傳給用戶端
                                    strSend = "GetPower Ok," + m_TrimEng.LaserPower.ToString("F10") + ",";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "GetPower");
                                }
                                break;
                            case "GoToResistor":
                                try
                                {
                                    int resId = Int32.Parse(words[1]);
                                    m_TrimEng.GoToResistor(resId);
                                    //將接收到的資料回傳給用戶端
                                    strSend = "GoToResistor Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "GoToResistor");
                                }
                                break;

                            case "GuideLaserOff":
                                try
                                {
                                    m_TrimEng.GuideLaserOff();
                                    //將接收到的資料回傳給用戶端
                                    strSend = "GuideLaserOff Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "GuideLaserOff");
                                }
                                break;
                            case "GuideLaserOn":
                                try
                                {
                                    m_TrimEng.GuideLaserOn();
                                    //將接收到的資料回傳給用戶端
                                    strSend = "GuideLaserOn Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "GuideLaserOn");
                                }
                                break;
                            case "Mark1":
                                try
                                {
                                    m_TrimEng.Mark1();
                                    //將接收到的資料回傳給用戶端
                                    strSend = "Mark1 Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "Mark1");
                                }
                                break;
                            case "Mark2":
                                try
                                {
                                    m_TrimEng.Mark2();
                                    //將接收到的資料回傳給用戶端
                                    strSend = "Mark2 Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "Mark2");
                                }
                                break;
                            case "MarkCol1":
                                try
                                {
                                    m_TrimEng.MarkCol1();
                                    //將接收到的資料回傳給用戶端
                                    strSend = "MarkCol1 Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "MarkCol1");
                                }
                                break;
                            case "MarkCol2":
                                try
                                {
                                    m_TrimEng.MarkCol2();
                                    //將接收到的資料回傳給用戶端
                                    strSend = "MarkCol2 Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "MarkCol2");
                                }
                                break;
                            case "MeasureAll":
                                try
                                {
                                    m_TrimEng.MeasureAll();
                                    //將接收到的資料回傳給用戶端
                                    strSend = "MeasureAll Ok,";
                                    for (int aryIdx = 0; aryIdx < m_TrimEng.TotalResistor; aryIdx++)
                                    {
                                        strSend = strSend + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PreVal.ToString("F5") + "," + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PrePercent.ToString("F2") + "," + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PostVal.ToString("F5") + "," + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PostPercent.ToString("F2") + ",";
                                    }
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "MeasureAll");
                                }
                                break;

                            case "MeasureCold":
                                try
                                {
                                    m_TrimEng.MeasureCold();
                                    //將接收到的資料回傳給用戶端
                                    strSend = "MeasureCold Ok,";
                                    for (int aryIdx = 0; aryIdx < m_TrimEng.TotalResistor; aryIdx++)
                                    {
                                        strSend = strSend + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PreVal.ToString("F5") + "," + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PrePercent.ToString("F2") + "," + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PostVal.ToString("F5") + "," + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PostPercent.ToString("F2") + ",";
                                    }
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "MeasureCold");
                                }
                                break;
                            case "MeasureSetting":
                                try
                                {
                                    double[] measureSetting = new double[19];
                                    for (int aryIdx = 2; aryIdx < 21; aryIdx++)
                                    {
                                        measureSetting[aryIdx - 2] = double.Parse(words[aryIdx]);
                                    }
                                    m_TrimEng.MeasureSetting(ref measureSetting);
                                    //將接收到的資料回傳給用戶端
                                    strSend = "MeasureSetting Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "MeasureSetting");
                                }
                                break;
                            case "ProbeSetting":
                                try
                                {
                                    //CRes[] ProbeData = new CRes[Int32.Parse(words[1])];
                                    //for (int aryIdx = 0; aryIdx < ProbeData.Length; aryIdx++)
                                    //{
                                    //    ProbeData[aryIdx] = new CRes();
                                    //    ProbeData[aryIdx].HF = Int32.Parse(words[(4 * aryIdx) + 2]);
                                    //    ProbeData[aryIdx].HS = Int32.Parse(words[(4 * aryIdx) + 3]);
                                    //    ProbeData[aryIdx].LF = Int32.Parse(words[(4 * aryIdx) + 4]);
                                    //    ProbeData[aryIdx].LS = Int32.Parse(words[(4 * aryIdx) + 5]);
                                    //}
                                    //m_TrimEng.ProbeSetting(ref ProbeData);

                                    strSend = "ProbSetting Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "ProbeSetting");
                                }
                                break;
                            case "PulseLaser":
                                try
                                {
                                    m_TrimEng.PulseLaser();
                                    //將接收到的資料回傳給用戶端
                                    strSend = "PulseLaser Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "PulseLaser");
                                }
                                break;
                            case "TotalCutsGet":
                                try
                                {
                                    //將接收到的資料回傳給用戶端
                                    strSend = "TotalCuts Ok," + m_TrimEng.TotalCuts.ToString() + ",";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "TotalCutsGet");
                                }
                                break;
                            case "TotalCutsSet":
                                try
                                {
                                    m_TrimEng.TotalCuts = Int32.Parse(words[1]);
                                    //將接收到的資料回傳給用戶端
                                    strSend = "TotalCuts Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "TotalCutsSet");
                                }
                                break;

                            case "CurrentColIdSet":
                                try
                                {
                                    m_TrimEng.CurrentColId = Int32.Parse(words[1]);
                                    //將接收到的資料回傳給用戶端
                                    strSend = "CurrentColId Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "TotalCutsSet");
                                }
                                break;

                            case "TotalResistorGet":
                                try
                                {
                                    //將接收到的資料回傳給用戶端
                                    strSend = "TotalResistor Ok," + m_TrimEng.TotalResistor.ToString() + ",";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "TotalResistorGet");
                                }
                                break;
                            case "TotalResistorSet":
                                try
                                {
                                    m_TrimEng.TotalResistor = Int32.Parse(words[1]);
                                    //將接收到的資料回傳給用戶端
                                    strSend = "TotalResistor Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "TotalResistorSet");
                                }
                                break;



                            case "TotalColGet":
                                try
                                {
                                    //將接收到的資料回傳給用戶端
                                    strSend = "TotalColGet Ok," + m_TrimEng.TotalCol.ToString() + ",";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "TotalColGet");
                                }
                                break;
                            case "TotalColSet":
                                try
                                {
                                    m_TrimEng.TotalCol = Int32.Parse(words[1]);
                                    //將接收到的資料回傳給用戶端
                                    strSend = "TotalCol Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "TotalColSet");
                                }
                                break;

                            case "TrimAll":
                                try
                                {
                                    m_TrimEng.CurrentColId = Int32.Parse(words[1]);
                                    m_TrimEng.TrimAll();
                                    //將接收到的資料回傳給用戶端
                                    strSend = "TrimAll Ok,";
                                    //for (int aryIdx = 0; aryIdx < m_TrimEng.TotalResistor; aryIdx++)
                                    //{
                                    //    strSend = strSend + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PreVal.ToString("F10") + "," + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PrePercent.ToString("F10") + "," + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PostVal.ToString("F10") + "," + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PostPercent.ToString("F10") + ",";
                                    //}
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "TrimAll");

                                }
                                break;
                            case "GetTrimData":
                                try
                                {
                                    strSend = "GetTrimData Ok,";
                                    for (int aryIdx = 0; aryIdx < m_TrimEng.TotalResistor; aryIdx++)
                                    {
                                        strSend = strSend + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PreVal.ToString("F4") + "," + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PrePercent.ToString("F3") + "," + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PostVal.ToString("F4") + "," + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PostPercent.ToString("F3") + ",";
                                    }
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "GetTrimData");
                                }
                                break;
                            case "TrimOne":
                                try
                                {
                                    m_TrimEng.CurrentColId = Int32.Parse(words[1]);
                                    m_TrimEng.TrimOne();
                                    //將接收到的資料回傳給用戶端
                                    strSend = "TrimOne Ok,";
                                    // strSend = strSend + m_TrimEng.TrimmedDataList.ElementAt(m_TrimEng.CurrentResID - 1).PreVal.ToString("F10") + "," + m_TrimEng.TrimmedDataList.ElementAt(m_TrimEng.CurrentResID - 1).PrePercent.ToString("F10") + "," + m_TrimEng.TrimmedDataList.ElementAt(m_TrimEng.CurrentResID - 1).PostVal.ToString("F10") + "," + m_TrimEng.TrimmedDataList.ElementAt(m_TrimEng.CurrentResID - 1).PostPercent.ToString("F10") + ",";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "TrimOne");
                                }

                                break;
                            case "TurnLaserOff":
                                try
                                {
                                    m_TrimEng.TurnLaserOff();
                                    //將接收到的資料回傳給用戶端
                                    strSend = "TurnLaserOff Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "TurnLaserOff");
                                }

                                break;
                            case "TurnLaserOn":
                                try
                                {
                                    m_TrimEng.TurnLaserOn();
                                    //將接收到的資料回傳給用戶端
                                    strSend = "TurnLaserOn Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "TurnLaserOn");
                                }

                                break;

                            case "LaserEmissionOFF":
                                try
                                {
                                    m_TrimEng.LaserEmissionOFF();
                                    //將接收到的資料回傳給用戶端
                                    strSend = "LaserEmissionOFF Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "TurnLaserOff");
                                }

                                break;
                            case "LaserEmissionON":
                                try
                                {
                                    m_TrimEng.LaserEmissionON();
                                    //將接收到的資料回傳給用戶端
                                    strSend = "LaserEmissionON Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "TurnLaserOn");
                                }

                                break;
                            case "UpdatePower":
                                try
                                {
                                    m_TrimEng.LaserPower = double.Parse(words[1]);
                                    m_TrimEng.LaserPower = double.Parse(words[1]);
                                    m_TrimEng.LaserPower = double.Parse(words[1]);
                                    m_TrimEng.LaserPower = double.Parse(words[1]);
                                    //將接收到的資料回傳給用戶端
                                    strSend = "UpdatePower Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "UpdatePower");
                                }

                                break;

                            case "UpdatePRR":
                                try
                                {
                                    m_TrimEng.LaserPRR = double.Parse(words[1]);

                                    //將接收到的資料回傳給用戶端
                                    strSend = "UpdatePRR Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "UpdatePower");
                                }

                                break;
                            case "UpdatePulseWidth":
                                try
                                {
                                    switch (int.Parse(words[1]))
                                    {
                                        case 0:
                                            m_TrimEng.LaserPulseWidth = 50;
                                            break;
                                        case 1:
                                            m_TrimEng.LaserPulseWidth = 100;
                                            break;
                                        case 2:
                                            m_TrimEng.LaserPulseWidth = 200;
                                            break;
                                    }
                                    //將接收到的資料回傳給用戶端
                                    strSend = "UpdatePulseWidth Ok,";
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "UpdatePower");
                                }
                                break;

                            case "MeasureBias":
                                try
                                {
                                    for (int aryIdx = 0; aryIdx < Int32.Parse(words[1]); aryIdx++)
                                    {
                                        m_TrimEng.ResistorList.ElementAt(aryIdx).MeasureBias = double.Parse(words[aryIdx + 2]);
                                    }
                                    //將接收到的資料回傳給用戶端
                                    strSend = "MeasureBias Ok,";
                                }
                                catch (Exception e)
                                {

                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "UpdateResPos");
                                }
                                break;

                            case "UpdateResPos":
                                try
                                {
                                    //將接收到的資料回傳給用戶端
                                    strSend = "UpdateResPos Ok,";
                                    for (int aryIdx = 0; aryIdx < Int32.Parse(words[1]); aryIdx++)
                                    {
                                        m_TrimEng.ResistorList.ElementAt(aryIdx).GalvoXPos = double.Parse(words[(2 * aryIdx) + 2]);
                                        m_TrimEng.ResistorList.ElementAt(aryIdx).GalvoYPos = double.Parse(words[(2 * aryIdx) + 3]);
                                    }
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "UpdateResPos");
                                }
                                break;

                            case "UpdateResOffset":
                                try
                                {
                                    //將接收到的資料回傳給用戶端
                                    strSend = "UpdateResOffset Ok,";
                                    for (int aryIdx = 0; aryIdx < Int32.Parse(words[1]); aryIdx++)
                                    {
                                        m_TrimEng.PanelList.ElementAt(aryIdx).GalvoColOffsetX = double.Parse(words[(2 * aryIdx) + 2]);
                                        m_TrimEng.PanelList.ElementAt(aryIdx).GalvoColOffsetY = double.Parse(words[(2 * aryIdx) + 3]);
                                    }
                                }
                                catch (Exception e)
                                {
                                    strSend = "NG,0," + e.ToString();
                                    //throw new System.ArgumentException(e.ToString(), "UpdateResOffset");
                                }

                                break;
                            default:
                                strSend = "NG,0, Command not found!";
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        try
                        {
                            m_TrimEng.TurnLaserOff();
                        }
                        catch { }
                        //throw new System.ArgumentException(e.ToString(), "DecoderErr");
                        strSend = "NG,0," + e.ToString();
                    }
                    SckSSend(strSend);
                }
            }
            catch (Exception e)
            {
                // 這裡若出錯主要是來自 SckSs[Scki] 出問題, 可能是自己 Close, 也可能是 Client 斷線, 自己加判斷吧~
                try
                {
                    m_TrimEng.TurnLaserOff();
                }
                catch { }
                if (m_TCPThread != false)
                {
                    SckSWaitAccept();
                }
                // throw new System.ArgumentException(e.ToString(), "DecoderErr");
            }
        }



        // Server 傳送資料給所有Client
        private void SckSSend(string SendS)
        {
            for (int Scki = 1; Scki < SckSs.Length; Scki++)
            {
                if (null != SckSs[Scki] && SckSs[Scki].Connected == true)
                {
                    try
                    {
                        // SendS 在這裡為 string 型態, 為 Server 要傳給 Client 的字串
                        SckSs[Scki].Send(Encoding.ASCII.GetBytes(SendS));

                    }
                    catch (Exception e)
                    {
                        // 這裡出錯, 主要是出在 SckSs[Scki] 出問題
                        throw new Exception(e.Message);
                    }
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //int nextPos = 2003;
            //double speed = (double)25 / 1000000;
            //int arySize = (int)(Math.Abs(0 - 2003) / speed);
            //int remainder = (int)(Math.Abs(0 - 2003) % speed);
            //double[] PosAry = new double[arySize];
            //for (int ayrIdx = 0; ayrIdx < arySize; ayrIdx++)
            //{
            //    PosAry[ayrIdx] = ayrIdx * speed + 0;
            //}

            for (int ayrIdx = 0; ayrIdx < 120; ayrIdx++)
            {
                comboBox2.Items.Add((ayrIdx + 1));
            }
            comboBox2.SelectedIndex = 0;

            //////////m_Meter.SetRes(8550, 7200 , 9000);
            //////////UInt32 a = 9000;
            //////////byte[] b = new byte[10];
            //////////byte[] bBytes = BitConverter.GetBytes(a);
            //////////string aa;
            //////////aa = bBytes[0].ToString();
            //////////for (int i = 0; i < bBytes.Length;++i )
            //////////{
            //////////b[i + 5] = bBytes[i];
            //////////}

            //////////UInt32 sValue = BitConverter.ToUInt32(b, 5);




            //zedGraphControl1.GraphPane.Title  = "標題測試";
            // zedGraphControl1.GraphPane.XAxis.Title = "X軸";
            //  zedGraphControl1.GraphPane.YAxis.Title= "Y軸";

            dgvResultList1.BorderStyle = BorderStyle.None;
            dgvResultList1.ColumnCount = 3;
            dgvResultList1.Columns[0].Name = "No";
            dgvResultList1.Columns[1].Name = "RVal";
            dgvResultList1.Columns[2].Name = "RPer";
            dgvResultList1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvResultList1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvResultList1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvResultList1.Columns[0].Width = 40;
            dgvResultList1.Columns[1].Width = 95;
            dgvResultList1.Columns[2].Width = 95;
            dgvResultList1.Columns[0].Frozen = true;
            dgvResultList1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvResultList1.Rows.Clear();
            dgvResultList1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgvResultList2.BorderStyle = BorderStyle.None;
            dgvResultList2.ColumnCount = 3;
            dgvResultList2.Columns[0].Name = "No";
            dgvResultList2.Columns[1].Name = "RVal";
            dgvResultList2.Columns[2].Name = "RPer";
            dgvResultList2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvResultList2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvResultList2.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvResultList2.Columns[0].Width = 40;
            dgvResultList2.Columns[1].Width = 95;
            dgvResultList2.Columns[2].Width = 95;
            dgvResultList2.Columns[0].Frozen = true;
            dgvResultList2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvResultList2.Rows.Clear();
            dgvResultList2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            for (int aryIdx = 1; aryIdx < 58; aryIdx++)
            {
                if (aryIdx <= 12)
                {
                    dgvResultList1.Rows.Add((new object[] { "A-" + aryIdx.ToString(), "", "" }));
                }
                else if (aryIdx <= 24)
                {
                    dgvResultList1.Rows.Add((new object[] { "B-" + (aryIdx - 12).ToString(), "", "" }));
                }
                else if (aryIdx <= 36)
                {
                    dgvResultList1.Rows.Add((new object[] { "C-" + (aryIdx - 24).ToString(), "", "" }));
                }
                else if (aryIdx <= 48)
                {
                    dgvResultList1.Rows.Add((new object[] { "D-" + (aryIdx - 36).ToString(), "", "" }));
                }
                else if (aryIdx <= 60)
                {
                    dgvResultList1.Rows.Add((new object[] { "E-" + (aryIdx - 48).ToString(), "", "" }));
                }
                dgvResultList1.Rows[aryIdx - 1].Height = 16;
            }
            dgvResultList1.RowsDefaultCellStyle.Font = new Font("新細明體", 11);
            dgvResultList1.AlternatingRowsDefaultCellStyle.Font = new Font("新細明體", 11);


            for (int aryIdx = 58; aryIdx <= 114; aryIdx++)
            {
                if (aryIdx <= 60)
                {
                    dgvResultList2.Rows.Add((new object[] { "E-" + (aryIdx - 48).ToString(), "", "" }));
                }
                else if (aryIdx <= 72)
                {
                    dgvResultList2.Rows.Add((new object[] { "F-" + (aryIdx - 60).ToString(), "", "" }));
                }
                else if (aryIdx <= 84)
                {
                    dgvResultList2.Rows.Add((new object[] { "G-" + (aryIdx - 72).ToString(), "", "" }));
                }
                else if (aryIdx <= 96)
                {
                    dgvResultList2.Rows.Add((new object[] { "H-" + (aryIdx - 84).ToString(), "", "" }));
                }
                else if (aryIdx <= 108)
                {
                    dgvResultList2.Rows.Add((new object[] { "I-" + (aryIdx - 96).ToString(), "", "" }));
                }
                else
                {
                    dgvResultList2.Rows.Add((new object[] { "J-" + (aryIdx - 108).ToString(), "", "" }));
                }
                dgvResultList2.Rows[aryIdx - 58].Height = 16;
            }
            dgvResultList2.RowsDefaultCellStyle.Font = new Font("新細明體", 11);
            dgvResultList2.AlternatingRowsDefaultCellStyle.Font = new Font("新細明體", 11);




            //dgvResultList1.Rows.Clear()
            //For aryIdx As Integer = 1 To 57 Step 1

            //    With m_param.Product
            // If aryIdx <= 12
            //   dgvResultList1.Rows.Add((New Object() { "A" & aryIdx.ToString().PadLeft(CInt("0")), "", ""}))
            // elseIf aryIdx <= 24
            //        dgvResultList1.Rows.Add((New Object() { "B" & aryIdx.ToString().PadLeft(CInt("0")), "", ""}))
            //end if
            //
            //
            //        dgvResultList1.Rows.Item(aryIdx - 1).Height = 16
            //    End With
            //Next aryIdx
            //dgvResultList2.Rows.Clear()
            //For aryIdx As Integer = 58 To 114 Step 1
            //    With m_param.Product
            //        dgvResultList2.Rows.Add((New Object() { "R" & aryIdx, "", ""}))
            //    End With
            //    dgvResultList2.Rows.Item(aryIdx - 58).Height = 16
            //Next aryIdx
        }

        private double CalcuCoefficientOfVariation(double[] Ary)
        {
            double meanValue = 0;
            for (int aryIdx = 0; aryIdx < Ary.Length; aryIdx++)
            {
                meanValue = meanValue + Ary[aryIdx] / Ary.Length;
            }

            double std = 0;
            for (int aryIdx = 0; aryIdx < Ary.Length; aryIdx++)
            {
                std = std + (Ary[aryIdx] - meanValue) * (Ary[aryIdx] - meanValue) / Ary.Length;
            }
            std = Math.Sqrt(std);
            double coeV = 0;
            coeV = std / meanValue * 100;
            return coeV;
        }

        //Simple Moving Average
        private double CalcuSMA(double OldSMA, double[] OldData, double[] NewData, int DataLength)
        {
            double newSMA = 0;
            for (int aryIdx = 0; aryIdx < OldData.Length; aryIdx++)
            {
                newSMA = OldSMA + ((NewData[aryIdx] - OldData[aryIdx]) / DataLength);
            }
            return newSMA;
        }
        //Weighted Moving Average
        private double CalcuWMA(double OldSMA, double[] OldData, double[] NewData, int DataLength)
        {
            double newSMA = 0;
            for (int aryIdx = 0; aryIdx < OldData.Length; aryIdx++)
            {
                newSMA = OldSMA + ((NewData[aryIdx] - OldData[aryIdx]) / DataLength);
            }
            return newSMA;
        }
        //Exponential Moving Average
        private double CalcuEMA(double OldSMA, double[] OldData, double[] NewData, int DataLength)
        {
            double newSMA = 0;
            for (int aryIdx = 0; aryIdx < OldData.Length; aryIdx++)
            {
                newSMA = OldSMA + ((NewData[aryIdx] - OldData[aryIdx]) / DataLength);
            }
            return newSMA;
        }
        //double moving average
        private double CalcuDSMA(double OldSMA, double[] OldData, double[] NewData, int DataLength)
        {
            double newSMA = 0;
            for (int aryIdx = 0; aryIdx < OldData.Length; aryIdx++)
            {
                newSMA = OldSMA + ((NewData[aryIdx] - OldData[aryIdx]) / DataLength);
            }
            return newSMA;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            button11.Visible = false;



            /* Procedure of ContGatedPulseGen Testing */
            // printf("\n Begin of ContGatedPulseGen for GPTC#0\n");
            // printf(" Connect the Trigger Signal to GPTC0_GATE\n");
            // printf(" and External Clock to GPTC0_SRC \n");
            ////////////short err;
            ////////////err = D2KDASK.D2K_GCTR_Reset(0, 0);
            ////////////// 2 means 200ns
            ////////////err = D2KDASK.D2K_GCTR_Setup((ushort)0, (ushort)0, (ushort)D2KDASK.SingleTrigContPulseGen, (byte)D2KDASK.GPTC_CLKSRC_INT | (byte)D2KDASK.GPTC_GATESRC_INT, (byte)D2KDASK.GPTC_OUTPUT_LACTIVE, 20, 20);
            ////////////// err = D2KDASK.D2K_GCTR_Control(card, 0, GPTC_IntUpDnCTR, 0);
            ////////////err = D2KDASK.D2K_GCTR_Control(0, 0, D2KDASK.GPTC_IntENABLE, 1);
            ////////////err = D2KDASK.D2K_GCTR_Control(0, 0, D2KDASK.GPTC_IntGATE, 0);
            ////////////err = D2KDASK.D2K_GCTR_Control(0, 0, D2KDASK.GPTC_IntGATE, 1);
            ////////////err = D2KDASK.D2K_GCTR_Control(0, 0, D2KDASK.GPTC_IntGATE, 0);
            ////////////printf(" Continuous pulses are generated at GPTC0_OUT and press any key to EXIT \n");
            ////////////getch();
            //////////err = D2KDASK.D2K_GCTR_Control(0, 0, D2KDASK.GPTC_IntENABLE, 0);




            //m_Meter.SelectRelayMap(m_Meter.m_ProbeMap[59]);//59
            //System.Threading.Thread.Sleep(1);
            CHighResolutionTimeStamps timeStamps = new CHighResolutionTimeStamps();

            //zedGraphControl1.GraphPane.Title = "60 Test";

            //////////m_Meter.SelectRelayMap(2, 2, 3, 3);
            //////////timeStamps.DelayMicroSec(350);
            //////////m_Meter.SelectRelayMap(5, 5, 4, 4);
            //////////timeStamps.DelayMicroSec(350);

            //   //m_Meter.SelectRelayMap(12 ,12, 50, 50);
            //m_Meter.SelectRelayMap(2, 2, 115, 115);
            //   //m_Meter.SelectRelayMap(37, 37, 75, 75);
            //   //m_Meter.SelectRelayMap(0, 0, 38, 38);
            //   timeStamps.DelayMicroSec(350);
            //繼電器延遲時間
            //m_Timer.DelayMicroSec(res.FT_Dly);

            //m_Meter.SelectRelayMap(m_Meter.m_ProbeMap[0]);//60

            zedGraphControl1.IsShowPointValues = true;
            //zedGraphControl1.GraphPane.Title = "20 Ohms Test";
            int AvgNum = 0;




            // m_Meter.SetRes(200, 200, 200);
            //  m_Meter.SetRes2(200);




            CRes res = m_TrimEng.ResistorList.ElementAt(comboBox2.SelectedIndex);

            //  res = m_TrimEng.ResistorList.ElementAt(113);//1K
            // res = m_TrimEng.ResistorList.ElementAt(114);//22K3
            //res = m_TrimEng.ResistorList.ElementAt(115);//68K
            //res = m_TrimEng.ResistorList.ElementAt(116);//160K
            //res = m_TrimEng.ResistorList.ElementAt(117);//300K
            // res = m_TrimEng.ResistorList.ElementAt(118);//680K
            //res = m_TrimEng.ResistorList.ElementAt(119);//1M
            AvgNum =35;// res.FT_Cnt;
            //AvgNum =3;//1666 * 1;
            int sampleNum = 50000;

            double[] x = new double[sampleNum + AvgNum];
            double[] y = new double[sampleNum];
            double[] z = new double[sampleNum];
            double[] u = new double[sampleNum];
            double[] v = new double[sampleNum];
            double[] data = new double[sampleNum + AvgNum];
            double[] data1 = new double[sampleNum + AvgNum];

            double[] adc = new double[sampleNum + AvgNum];
            double[] adc1 = new double[sampleNum + AvgNum];

            int i;                                                                       //00 01 02 03 04 05 06 07 08 09 10 11
            m_Meter.SelectRelayMap(res.RelayIdx); //46 45 44 43 42 41 40 39 38 37 36 35

            m_TrimEng.TurnTrigOn();
            //  res = m_TrimEng.ResistorList.ElementAt(comboBox2.SelectedIndex );
            // m_Meter.SelectRelayMap(res.RelayIdx);

            //Random rnd = new Random(); 238 239
            // m_Meter.SelectRelayMap(res.HF,res.HS,res.LF,res.LS);
            // res.PT_Dly = 1000;
            timeStamps.DelayMicroSec(res.PT_Dly);


            x[0] = timeStamps.GetMicroSecondTime();
            if (res.RelayIdx % 2 == 0)
            {
                m_Meter.TrigADC2(ref data, ref data1, ref adc, ref adc1);
            }
            else
            {
                m_Meter.TrigADC2(ref data1, ref data, ref adc1, ref adc);
            }
            x[sampleNum + AvgNum - 1] = timeStamps.GetMicroSecondTime();
            m_TrimEng.TurnTrigOFF();
            for (i = 0; i < (sampleNum + AvgNum); i++)
            {
                //m_Meter.TrigADC(ref data[i]);
                x[i] = x[0] + (x[sampleNum + AvgNum - 1] - x[0]) * i / (sampleNum + AvgNum - 1);// 4 * i;// timeStamps.GetMicroSecondTime();

            }

            // move avg for 100 sample, get sampleNum data

            // NO logic

            res = m_TrimEng.ResistorList.ElementAt(m_TrimEng.CurrentResID - 1);
            double stamp = x[0];
            for (i = 0; i < (sampleNum + AvgNum); i++)
            {
                x[i] = (x[i] - stamp) / 1000;
                data[i] = data[i] + res.NominalDesign * res.MeasureBias / 100;   // 576.03 * 575.00;;
            }

            //for (i = 0; i < sampleNum; i++)
            //{
            //   // x[i] = 0.01 * i;
            //   // y[i] = data[i + AvgNum];
            //    y[i] = data[i ];
            //}

            double mean = 0;
            double maxValue = -999999999;
            double minValue = 999999999;
            double maxPercent = 0;
            double minPercent = 0;
            double meanPercent = 0;

            //for (i = 0; i < sampleNum; i++)
            //{
            //    mean = mean + y[i]/sampleNum;

            //}
            ////mean = mean / sampleNum;

            //for (i = 0; i < sampleNum; i++)
            //{
            //    // mean = mean + (y[i]/sampleNum);
            //    if (y[i] > maxValue)
            //    { maxValue = y[i]; }
            //    if (y[i] < minValue)
            //    { minValue = y[i]; }
            //}
            //maxPercent = ((maxValue - mean) / mean) * 100;
            //minPercent = ((minValue - mean) / mean) * 100;
            ////把舊的圖資清掉
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl2.GraphPane.CurveList.Clear();
            double coeV = 0;
            // coeV = CalcuCoefficientOfVariation(y);
            //zedGraphControl1.GraphPane.AddCurve("C.V. " + coeV.ToString("F3") + "%  " + " Mean " + mean.ToString("F3") + " Max " + maxPercent.ToString("F3") + "% Min " + minPercent.ToString("F3") + "%", x, y, Color.Red, SymbolType.None);


            double avg = 0;
            for (i = 0; i < AvgNum; i++)
            {
                avg = avg + data[i] / AvgNum;
            }

            double std = 0;
            //for (i = 0; i < 2; i++)
            //{
            //    std = std + data[i + 8] * data[i + 8] / 2;
            //}
            //std = Math.Sqrt(std - avg * avg);

            double[] oldData1 = new double[1];
            double[] newData1 = new double[1];
            for (i = 0; i < sampleNum; i++)
            {
                oldData1[0] = data[i];
                newData1[0] = data[i + AvgNum];
                v[i] = CalcuSMA(avg, oldData1, newData1, AvgNum);
                avg = v[i];
                //v[i] = data[i + AvgNum];
            }



            avg = 0;
            for (i = 0; i < AvgNum; i++)
            {
                avg = avg + adc[i] / AvgNum;
            }

            for (i = 0; i < sampleNum; i++)
            {
                oldData1[0] = adc[i];
                newData1[0] = adc[i + AvgNum];
                u[i] =( CalcuSMA(avg, oldData1, newData1, AvgNum));
                avg = u[i];

              //  u[i] = adc[i + AvgNum];
            }
            long adc111;
            for (i = 0; i < sampleNum; i++)
            {
                u[i] = (int)u[i];
                // v[i]= ((double)u[i] * 10000 / 65535) / (4 * 2);
                //       v[i]=

                adc111 = (long) u[i];
                if (res.RelayIdx % 2 == 0)
                {
                    m_Meter.ADC2ResValue1(adc111, out  v[i]);
                }
                else
                {
                    m_Meter.ADC2ResValue2(adc111, out v[i]);
                }

                u[i] = u[i]/10000;
            }


            mean = 0;
            maxValue = -99999999999;
            minValue = 99999999999;
            maxPercent = 0;
            minPercent = 0;


            for (i = 0; i < sampleNum; i++)
            {
                mean = mean + v[i];

            }
            mean = mean / sampleNum;

            for (i = 0; i < sampleNum; i++)
            {
                // mean = mean + (v[i] / sampleNum);
                if (v[i] > maxValue)
                { maxValue = v[i]; }
                if (v[i] < minValue)
                { minValue = v[i]; }
            }
            maxPercent = ((maxValue - m_TrimEng.ResistorList.ElementAt(0).NominalDesign) / m_TrimEng.ResistorList.ElementAt(0).NominalDesign) * 100;
            minPercent = ((minValue - m_TrimEng.ResistorList.ElementAt(0).NominalDesign) / m_TrimEng.ResistorList.ElementAt(0).NominalDesign) * 100;


            ////////////////////for (i = 0; i < sampleNum; i++)
            ////////////////////{

            ////////////////////    v[i] = ((v[i] - m_TrimEng.ResistorList.ElementAt(0).NominalDesign) / m_TrimEng.ResistorList.ElementAt(0).NominalDesign) * 100;

            ////////////////////}

            //int cnt=0;
            //double mean1sd=0;
            //double sd = CalcuStandardDeviation(v);
            //for (i = 0; i < sampleNum; i++)
            //{
            //    if ((v[i] <= (mean + sd)) && (v[i] >= (mean - sd)))
            //    {
            //        cnt = cnt + 1;
            //        mean1sd=mean1sd+v[i]/sampleNum;
            //    }
            //}
            //mean1sd = mean1sd * sampleNum / cnt;
            //maxValue = mean + sd;
            //minValue = mean- sd;
            //mean = mean1sd;
            //maxPercent = ((maxValue - mean) / mean) * 100;
            //minPercent = ((minValue - mean) / mean) * 100;




            //coeV = CalcuCoefficientOfVariation(z);
            //zedGraphControl1.GraphPane.AddCurve("C.V" + coeV.ToString("F3") + "%", x, z, Color.Blue, SymbolType.None);

            //coeV = CalcuCoefficientOfVariation(u);
            //zedGraphControl1.GraphPane.AddCurve("C.V" + coeV.ToString("F3") + "%", x, u, Color.Aqua, SymbolType.None);

            coeV = CalcuCoefficientOfVariation(v);
            meanPercent = ((mean - m_TrimEng.ResistorList.ElementAt(0).NominalDesign) / m_TrimEng.ResistorList.ElementAt(0).NominalDesign) * 100;



            for (i = 0; i < sampleNum; i++)
            {
                v[i] = ((v[i] - m_TrimEng.ResistorList.ElementAt(0).NominalDesign) / m_TrimEng.ResistorList.ElementAt(0).NominalDesign) * 100;
            }


            zedGraphControl1.GraphPane.AddCurve("cv" + coeV.ToString("F3") + "%" + " Mean " + mean.ToString("F1") + " Mean " + meanPercent.ToString("F3") + " Max " + maxPercent.ToString("F3") + "% Min " + minPercent.ToString("F3") + "% Range " + (maxPercent - minPercent).ToString("F3"), x, v, Color.DimGray, SymbolType.Plus);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();


            zedGraphControl2.GraphPane.AddCurve("ADC "  , x, u, Color.DimGray, SymbolType.Plus);
            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();



            //z1.GraphPane.AddCurve("Sine Wave", x, y, Color.Red, SymbolType.Square);
            // z1.AxisChange();
            //z1.Invalidate();
            m_TrimEng.TurnTrigOFF();

            if (m_TrimEng.ResistorList.ElementAt(0).NominalDesign > 1000)
            {
                m_Meter.SelectRelayMap(118);
                m_Meter.SelectRelayMap(119);
            }
            else
            {
                m_Meter.SelectRelayMap(116);
                m_Meter.SelectRelayMap(117);
            }


            //  m_TrimEng.TurnLaserOff();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboBox1.SelectedIndex)
            {
                case 0:
                    Move_Galvo_Move_Step = 0.001;
                    break;
                case 1:
                    Move_Galvo_Move_Step = 0.002;
                    break;
                case 2:
                    Move_Galvo_Move_Step = 0.01;
                    break;
                case 3:
                    Move_Galvo_Move_Step = 0.05;
                    break;
                case 4:
                    Move_Galvo_Move_Step = 0.1;
                    break;
                case 5:
                    Move_Galvo_Move_Step = 0.5;
                    break;
                case 6:
                    Move_Galvo_Move_Step = 1.0;
                    break;
                case 7:
                    Move_Galvo_Move_Step = 2.0;
                    break;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            m_TrimEng.GalvoRelMove(0, Move_Galvo_Move_Step);
            lblGalvoX.Text = m_TrimEng.GetGalvoPosX.ToString("F3");
            lblGalvoY.Text = m_TrimEng.GetGalvoPosY.ToString("F3");
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            m_TrimEng.GalvoRelMove(0, -1 * Move_Galvo_Move_Step);
            lblGalvoX.Text = m_TrimEng.GetGalvoPosX.ToString("F3");
            lblGalvoY.Text = m_TrimEng.GetGalvoPosY.ToString("F3");
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            m_TrimEng.GalvoRelMove(-1 * Move_Galvo_Move_Step, 0);
            lblGalvoX.Text = m_TrimEng.GetGalvoPosX.ToString("F3");
            lblGalvoY.Text = m_TrimEng.GetGalvoPosY.ToString("F3");
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            m_TrimEng.GalvoRelMove(Move_Galvo_Move_Step, 0);
            lblGalvoX.Text = m_TrimEng.GetGalvoPosX.ToString("F3");
            lblGalvoY.Text = m_TrimEng.GetGalvoPosY.ToString("F3");
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            m_TrimEng.GalvoAbsMove(0, 0);
            lblGalvoX.Text = m_TrimEng.GetGalvoPosX.ToString("F3");
            lblGalvoY.Text = m_TrimEng.GetGalvoPosY.ToString("F3");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // MeasureData[] trimData = new MeasureData[38];
            //m_TrimEng.TrimOne();
            int aryIdx;
            double time;
            double y;
            double z;
            double u;
            // Make up some data points based on the Sine function
            PointPairList vList = new PointPairList();
            PointPairList aList = new PointPairList();
            PointPairList dList = new PointPairList();
            for (aryIdx = 0; aryIdx < m_TrimEng.m_AnalysisData.Length; aryIdx++)
            {
                if (m_TrimEng.m_AnalysisData[aryIdx].TimeStamp == 0)
                {
                    break;
                }
                else
                {
                    time = (m_TrimEng.m_AnalysisData[aryIdx].TimeStamp - m_TrimEng.m_AnalysisData[0].TimeStamp) / 1000;
                    y = m_TrimEng.m_AnalysisData[aryIdx].PosX - m_TrimEng.m_AnalysisData[0].PosX;
                    z = m_TrimEng.m_AnalysisData[aryIdx].PosY - m_TrimEng.m_AnalysisData[0].PosY;
                    u = m_TrimEng.m_AnalysisData[aryIdx].ResVal;

                    aList.Add(time, u);
                    vList.Add(time, y);
                    dList.Add(time, z);
                }
            }
            for (aryIdx = 1; aryIdx < m_TrimEng.m_AnalysisData.Length; aryIdx++)
            {
                m_TrimEng.m_AnalysisData[aryIdx].TimeStamp = (m_TrimEng.m_AnalysisData[aryIdx].TimeStamp - m_TrimEng.m_AnalysisData[0].TimeStamp) / 1000;
            }
            m_TrimEng.m_AnalysisData[0].TimeStamp = 0;
            zedGraphControl1.IsShowPointValues = true;
            //zedGraphControl1.GraphPane.Title = "Test";
            //把舊的圖資清掉
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.YAxisList.Clear();
            GraphPane myPane = zedGraphControl1.GraphPane;
            // Set the titles and axis labels
            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "Time, ms";
            //myPane.YAxis.Title.Text = "PosX";
            myPane.Y2Axis.Title.Text = "ResValue";



            //PosX
            // Generate a red curve with diamond symbols, and "Velocity" in the legend
            LineItem myCurve = myPane.AddCurve("PosX", vList, Color.Red, SymbolType.None);
            // Fill the symbols with white
            myCurve.Symbol.Fill = new Fill(Color.White);

            //Res
            // Generate a blue curve with circle symbols, and "Acceleration" in the legend 
            myCurve = myPane.AddCurve("ResValue", aList, Color.Blue, SymbolType.Plus);
            // Fill the symbols with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the Y2 axis
            myCurve.IsY2Axis = true;

            // Generate a green curve with square symbols, and "Distance" in the legend
            myCurve = myPane.AddCurve("PosY", dList, Color.Green, SymbolType.None);
            // Fill the symbols with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the second Y axis
            myCurve.YAxisIndex = 1;

            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;

            YAxis yAxis = new YAxis("PosX");
            myPane.YAxisList.Add(yAxis);
            // Make the Y axis scale red
            myPane.YAxis.Scale.FontSpec.FontColor = Color.Red;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Red;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            myPane.YAxis.Scale.Max = 100;

            // Enable the Y2 axis display
            myPane.Y2Axis.IsVisible = true;
            // Make the Y2 axis scale blue
            myPane.Y2Axis.Scale.FontSpec.FontColor = Color.Blue;
            myPane.Y2Axis.Title.FontSpec.FontColor = Color.Blue;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            myPane.Y2Axis.MajorTic.IsOpposite = false;
            myPane.Y2Axis.MinorTic.IsOpposite = false;
            // Display the Y2 axis grid lines
            myPane.Y2Axis.MajorGrid.IsVisible = true;
            // Align the Y2 axis labels so they are flush to the axis
            myPane.Y2Axis.Scale.Align = AlignP.Inside;
            //myPane.Y2Axis.Scale.Min = 1.5;
            //myPane.Y2Axis.Scale.Max = 3;



            // Create a second Y Axis, green
            YAxis yAxis3 = new YAxis("PosY");
            myPane.YAxisList.Add(yAxis3);
            yAxis3.Scale.FontSpec.FontColor = Color.Green;
            yAxis3.Title.FontSpec.FontColor = Color.Green;
            yAxis3.Color = Color.Green;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis3.MajorTic.IsInside = false;
            yAxis3.MinorTic.IsInside = false;
            yAxis3.MajorTic.IsOpposite = false;
            yAxis3.MinorTic.IsOpposite = false;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis3.Scale.Align = AlignP.Inside;


            // Fill the axis background with a gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            lbl_Mode_4_Mark_1_Info.Text = "R" + m_TrimEng.CurrentResID.ToString() + " (" + m_TrimEng.GetGalvoPosX.ToString("F3") + ", " + m_TrimEng.GetGalvoPosY.ToString("F3") + ")";
            m_TrimEng.Mark1();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lbl_Mode_4_Mark_2_Info.Text = "R" + m_TrimEng.CurrentResID.ToString() + " (" + m_TrimEng.GetGalvoPosX.ToString("F3") + ", " + m_TrimEng.GetGalvoPosY.ToString("F3") + ")";
            m_TrimEng.Mark2();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            double[] xPos = new double[40];//[m_param.Product.NumOfRs - 1]  
            double[] yPos = new double[40];//(0 To (m_param.Product.NumOfRs - 1)) As Single

            for (int aryIdx = 0; aryIdx < 40; aryIdx++)
            {

            }
            //For aryIdx = 0 To (m_param.Product.NumOfRs - 1) Step 1
            //    xPos(aryIdx) = m_param.Product.ResistorPosXInGalvo.Item(aryIdx)
            //    yPos(aryIdx) = m_param.Product.ResistorPosYInGalvo.Item(aryIdx)
            //Next aryIdx
            m_TrimEng.CalculateResGalvoPos();
            //For aryIdx = 0 To (m_param.Product.NumOfRs - 1) Step 1
            //    m_param.Product.ResistorPosXInGalvo.Item(aryIdx) = xPos(aryIdx)
            //    m_param.Product.ResistorPosYInGalvo.Item(aryIdx) = yPos(aryIdx)
            //Next aryIdx

        }

        private void btnResRowfirst_Click(object sender, EventArgs e)
        {
            lblResNo.Text = "1";
            m_TrimEng.GoToResistor(Int32.Parse(lblResNo.Text));
            lblGalvoX.Text = m_TrimEng.GetGalvoPosX.ToString("F3");
            lblGalvoY.Text = m_TrimEng.GetGalvoPosY.ToString("F3");
        }

        private void btnResRowLaste_Click(object sender, EventArgs e)
        {
            lblResNo.Text = m_TrimEng.TotalResistor.ToString();
            m_TrimEng.GoToResistor(Int32.Parse(lblResNo.Text));
            lblGalvoX.Text = m_TrimEng.GetGalvoPosX.ToString("F3");
            lblGalvoY.Text = m_TrimEng.GetGalvoPosY.ToString("F3");
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            if (m_TrimEng.CurrentResID > 1)
            {
                lblResNo.Text = (m_TrimEng.CurrentResID - 1).ToString();
                m_TrimEng.GoToResistor(Int32.Parse(lblResNo.Text));
                lblGalvoX.Text = m_TrimEng.GetGalvoPosX.ToString("F3");
                lblGalvoY.Text = m_TrimEng.GetGalvoPosY.ToString("F3");
            }
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            if (m_TrimEng.CurrentResID < m_TrimEng.TotalResistor)
            {
                lblResNo.Text = (m_TrimEng.CurrentResID + 1).ToString();
                m_TrimEng.GoToResistor(Int32.Parse(lblResNo.Text));
                lblGalvoX.Text = m_TrimEng.GetGalvoPosX.ToString("F3");
                lblGalvoY.Text = m_TrimEng.GetGalvoPosY.ToString("F3");
            }
        }

        private void btnResRowCentra_Click(object sender, EventArgs e)
        {
            m_TrimEng.GalvoAbsMove(0, 0);
            lblGalvoX.Text = m_TrimEng.GetGalvoPosX.ToString("F3");
            lblGalvoY.Text = m_TrimEng.GetGalvoPosY.ToString("F3");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            m_TrimEng.MeasureAll();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            m_TrimEng.Open();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            m_TrimEng.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            m_TrimEng.TrimAll();
            int aryIdx;
            double time;
            double y;
            double z;
            double u;
            // Make up some data points based on the Sine function
            PointPairList vList = new PointPairList();
            PointPairList aList = new PointPairList();
            PointPairList dList = new PointPairList();
            for (aryIdx = 0; aryIdx < m_TrimEng.m_AnalysisData.Length; aryIdx++)
            {
                if (m_TrimEng.m_AnalysisData[aryIdx].TimeStamp == 0)
                {
                    break;
                }
                else
                {
                    time = m_TrimEng.m_AnalysisData[aryIdx].TimeStamp - m_TrimEng.m_AnalysisData[0].TimeStamp;
                    time = time / 1000;
                    y = m_TrimEng.m_AnalysisData[aryIdx].PosX - m_TrimEng.m_AnalysisData[0].PosX;
                    z = m_TrimEng.m_AnalysisData[aryIdx].PosY - m_TrimEng.m_AnalysisData[0].PosY;
                    u = m_TrimEng.m_AnalysisData[aryIdx].ResVal;

                    aList.Add(time, u);
                    vList.Add(time, y);
                    dList.Add(time, z);
                }
            }
            zedGraphControl1.IsShowPointValues = true;
            //zedGraphControl1.GraphPane.Title = "Test";
            //把舊的圖資清掉
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.YAxisList.Clear();
            GraphPane myPane = zedGraphControl1.GraphPane;
            // Set the titles and axis labels
            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "Time, us";
            //myPane.YAxis.Title.Text = "PosX";
            myPane.Y2Axis.Title.Text = "ResValue";



            //PosX
            // Generate a red curve with diamond symbols, and "Velocity" in the legend
            LineItem myCurve = myPane.AddCurve("PosX", vList, Color.Red, SymbolType.VDash);
            // Fill the symbols with white
            myCurve.Symbol.Fill = new Fill(Color.White);

            //Res
            // Generate a blue curve with circle symbols, and "Acceleration" in the legend 
            myCurve = myPane.AddCurve("ResValue", aList, Color.Blue, SymbolType.None);
            // Fill the symbols with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the Y2 axis
            myCurve.IsY2Axis = true;

            // Generate a green curve with square symbols, and "Distance" in the legend
            myCurve = myPane.AddCurve("PosY", dList, Color.Green, SymbolType.None);
            // Fill the symbols with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the second Y axis
            myCurve.YAxisIndex = 1;

            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;

            YAxis yAxis = new YAxis("PosX");
            myPane.YAxisList.Add(yAxis);
            // Make the Y axis scale red
            myPane.YAxis.Scale.FontSpec.FontColor = Color.Red;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Red;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            myPane.YAxis.Scale.Max = 100;

            // Enable the Y2 axis display
            myPane.Y2Axis.IsVisible = true;
            // Make the Y2 axis scale blue
            myPane.Y2Axis.Scale.FontSpec.FontColor = Color.Blue;
            myPane.Y2Axis.Title.FontSpec.FontColor = Color.Blue;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            myPane.Y2Axis.MajorTic.IsOpposite = false;
            myPane.Y2Axis.MinorTic.IsOpposite = false;
            // Display the Y2 axis grid lines
            myPane.Y2Axis.MajorGrid.IsVisible = true;
            // Align the Y2 axis labels so they are flush to the axis
            myPane.Y2Axis.Scale.Align = AlignP.Inside;
            //myPane.Y2Axis.Scale.Min = 1.5;
            //myPane.Y2Axis.Scale.Max = 3;



            // Create a second Y Axis, green
            YAxis yAxis3 = new YAxis("PosY");
            myPane.YAxisList.Add(yAxis3);
            yAxis3.Scale.FontSpec.FontColor = Color.Green;
            yAxis3.Title.FontSpec.FontColor = Color.Green;
            yAxis3.Color = Color.Green;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis3.MajorTic.IsInside = false;
            yAxis3.MinorTic.IsInside = false;
            yAxis3.MajorTic.IsOpposite = false;
            yAxis3.MinorTic.IsOpposite = false;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis3.Scale.Align = AlignP.Inside;


            // Fill the axis background with a gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            m_TrimEng.GalvoAbsMove(0, 0);
        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_Meter = null;
            m_TCPThread = false;
            try
            {
                for (int i = 0; i < SckSs.Length; i++)
                {
                    if (SckSs[i] != null)
                    {
                        SckSs[i].Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

            //m_TrimEng=Nothing;
        }

        private void btnNPoint_Click(object sender, EventArgs e)
        {
            btnNPoint.Enabled = false;
            m_TrimEng.Npoint();
            btnNPoint.Enabled = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            button16.Enabled = false;
            m_TrimEng.LineY();

            //   m_TrimEng.TurnLaserOn();

            //  m_TrimEng.TurnLaserOff();

            button16.Enabled = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {



            m_Meter.SetRes(1300, 1300, 1300);
            m_Meter.SetRes2(1300);


            //  m_Meter.SetRes(10, 10, 10);
            //   m_Meter.SetRes2(10);

            for (int aryIdx = 0; aryIdx < m_TrimEng.ResistorList.Count; aryIdx++)
            {
                m_TrimEng.ResistorList.ElementAt(aryIdx).NominalDesign = 1300;// numTargetR.Value;
            }
            Thread.Sleep(200);
            comboBox2.SelectedIndex = 113;
            // comboBox2.SelectedIndex = 1;
            button1_Click(null, null);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            m_Meter.SetRes(1500000, 1500000, 1500000);
            m_Meter.SetRes2(22000);
            for (int aryIdx = 0; aryIdx < m_TrimEng.ResistorList.Count; aryIdx++)
            {
                m_TrimEng.ResistorList.ElementAt(aryIdx).NominalDesign = 22000;// numTargetR.Value;
            }
            Thread.Sleep(200);
            comboBox2.SelectedIndex = 114;
            button1_Click(null, null);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            m_Meter.SetRes(1500000, 1500000, 1500000);
            m_Meter.SetRes2(68000);
            for (int aryIdx = 0; aryIdx < m_TrimEng.ResistorList.Count; aryIdx++)
            {
                m_TrimEng.ResistorList.ElementAt(aryIdx).NominalDesign = 68000;// numTargetR.Value;
            }
            Thread.Sleep(200);
            comboBox2.SelectedIndex = 115;
            button1_Click(null, null);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            m_Meter.SetRes(1500000, 1500000, 1500000);
            m_Meter.SetRes2(160000);
            for (int aryIdx = 0; aryIdx < m_TrimEng.ResistorList.Count; aryIdx++)
            {
                m_TrimEng.ResistorList.ElementAt(aryIdx).NominalDesign = 160000;// numTargetR.Value;
            }
            Thread.Sleep(200);
            comboBox2.SelectedIndex = 116;
            button1_Click(null, null);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            m_Meter.SetRes(1500000, 1500000, 1500000);
            m_Meter.SetRes2(300000);
            for (int aryIdx = 0; aryIdx < m_TrimEng.ResistorList.Count; aryIdx++)
            {
                m_TrimEng.ResistorList.ElementAt(aryIdx).NominalDesign = 300000;// numTargetR.Value;
            }
            Thread.Sleep(200);
            comboBox2.SelectedIndex = 117;
            button1_Click(null, null);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            m_Meter.SetRes(1500000, 1500000, 1500000);
            m_Meter.SetRes2(680000);
            for (int aryIdx = 0; aryIdx < m_TrimEng.ResistorList.Count; aryIdx++)
            {
                m_TrimEng.ResistorList.ElementAt(aryIdx).NominalDesign = 680000;// numTargetR.Value;
            }
            Thread.Sleep(200);
            comboBox2.SelectedIndex = 118;
            button1_Click(null, null);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            m_Meter.SetRes(1500000, 1500000, 1500000);
            m_Meter.SetRes2(1000000);
            for (int aryIdx = 0; aryIdx < m_TrimEng.ResistorList.Count; aryIdx++)
            {
                m_TrimEng.ResistorList.ElementAt(aryIdx).NominalDesign = 1000000;// numTargetR.Value;
            }
            Thread.Sleep(200);
            comboBox2.SelectedIndex = 119;
            button1_Click(null, null);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.GetFirmwareVer();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text= m_Meter.SelDutSource(3,0);
            //lblFirmwareVer.Text = m_Meter.SelDutSource(2, 0);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelDutSource(1, 1);
            lblFirmwareVer.Text = m_Meter.SelDutSource(2, 1);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCurrent(1, 1);
            lblFirmwareVer.Text = m_Meter.SelCurrent(2, 1);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCurrent(1, 2);
            lblFirmwareVer.Text = m_Meter.SelCurrent(2, 2);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCurrent(1, 3);
            lblFirmwareVer.Text = m_Meter.SelCurrent(2, 3);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCurrent(1, 4);
            lblFirmwareVer.Text = m_Meter.SelCurrent(2, 4);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCurrent(1, 5);
            lblFirmwareVer.Text = m_Meter.SelCurrent(2, 5);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCurrent(3, 6);
           // lblFirmwareVer.Text = m_Meter.SelCurrent(2, 6);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCurrent(1, 7);
            lblFirmwareVer.Text = m_Meter.SelCurrent(2, 7);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCurrent(1, 8);
            lblFirmwareVer.Text = m_Meter.SelCurrent(2, 8);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCurrent(1, 9);
            lblFirmwareVer.Text = m_Meter.SelCurrent(2, 9);
        }

        private void button40_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCurrent(1, 10);
            lblFirmwareVer.Text = m_Meter.SelCurrent(2, 10);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCurrentGain(1, 1);
            lblFirmwareVer.Text = m_Meter.SelCurrentGain(2, 1);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCurrentGain(1, 10);
            lblFirmwareVer.Text = m_Meter.SelCurrentGain(2, 10);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCurrentGain(1, 100);
            lblFirmwareVer.Text = m_Meter.SelCurrentGain(2, 100);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCurrentGain(1, 1000);
            lblFirmwareVer.Text = m_Meter.SelCurrentGain(2, 1000);
        }

        private void button45_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvCap(1, 1);
            lblFirmwareVer.Text = m_Meter.SelCvCap(2, 1);
        }

        private void button46_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvCap(1, 2);
            lblFirmwareVer.Text = m_Meter.SelCvCap(2, 2);
        }

        private void button47_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvCap(1, 3);
            lblFirmwareVer.Text = m_Meter.SelCvCap(2, 3);
        }

        private void button48_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvCap(1, 4);
            lblFirmwareVer.Text = m_Meter.SelCvCap(2, 4);
        }

        private void button49_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 1);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 1);
            //   m_Meter.SetRes2(bbb);
            //    for (int aryIdx = 0; aryIdx < m_TrimEng.ResistorList.Count; aryIdx++)
            //      {
            //         m_TrimEng.ResistorList.ElementAt(aryIdx).NominalDesign = bbb;// numTargetR.Value;
            //     }

        }

        private void button50_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 2);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 2);
        }

        private void button51_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 3);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 3);
        }

        private void button52_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 4);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 4);
        }

        private void button53_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 5);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 5);
        }

        private void button54_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 6);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 6);
        }

        private void button55_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 7);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 7);
        }

        private void button56_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 8);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 8);
        }

        private void button57_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 9);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 9);
        }

        private void button58_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 10);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 10);
        }

        private void button59_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 11);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 11);
        }

        private void button60_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 12);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 12);

        }

        private void button61_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 13);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 13);
        }

        private void button62_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 14);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 14);
        }

        private void button63_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 15);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 15);
        }

        private void button64_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 16);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 16);
        }

        private void button65_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 17);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 17);
        }

        private void button66_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 18);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 18);
        }

        private void button67_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 19);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 19);
        }

        private void button68_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 20);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 20);
        }

        private void button69_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.GetDut(1);
        }

        private void button70_Click(object sender, EventArgs e)
        {
            Single resValue;
            resValue = Convert.ToSingle(textBox1.Text);
            m_Meter.SetRes2(resValue);
            for (int aryIdx = 0; aryIdx < m_TrimEng.ResistorList.Count; aryIdx++)
            {
                m_TrimEng.ResistorList.ElementAt(aryIdx).NominalDesign = resValue;// numTargetR.Value;
            }
            //if (resValue < 2000)
            //{
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(1, 2);
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(2, 2);
            //}
            ////2K <= R < 4.3K 實際 2.2K <= R < 3.3K
            //else if (resValue < 4300)
            //{
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(1, 1);
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(2, 1);
            //}
            ////3.3K <= R < 4.8K 實際 3.3K <= R < 4.8K
            //else if (resValue < 6340)
            //{
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(1, 3);
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(2, 3);
            //}
            ////4.8K <= R < 7.0K 實際 4.8K <= R < 7.0K
            //else if (resValue < 9090)
            //{
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(1, 4);
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(2,4);
            //}
            ////7K <= R < 10K 實際 7K <= R < 10K
            //else if (resValue < 13000)
            //{
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(1, 5);
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(2, 5);
            //}
            ////10K <= R < 15K 實際 10K <= R < 15K
            //else if (resValue < 20000)
            //{
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(1, 6);
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(2, 6);
            //}
            //else if (resValue < 30000)
            //{
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(1, 7);
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(2, 7);
            //}
            //else if (resValue < 43200)
            //{
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(1, 8);
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(2, 8);
            //}
            //else if (resValue < 63400)
            //{
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(1, 9);
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(2, 9);
            //}
            //else if (resValue < 91000)
            //{
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(1, 10);
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(2, 10);
            //}
            //else if (resValue < 127000)
            //{
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(1, 11);
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(2, 11);
            //}
            //else if (resValue < 200000)
            //{
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(1, 12);
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(2, 12);
            //}
            //else if (resValue < 300000)
            //{
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(1, 13);
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(2, 13);
            //}
            //else if (resValue < 453000)
            //{
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(1, 14);
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(2, 14);
            //}
            //else if (resValue < 634000)
            //{
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(1,15);
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(2, 15);
            //}
            //else if (resValue < 909000)
            //{
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(1, 16);
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(2, 16);
            //}
            //else if (resValue < 1300000)
            //{
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(1, 17);
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(2, 17);
            //}
            //else
            //{
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(1, 18);
            //    lblFirmwareVer.Text = m_Meter.SelCvRes(2, 18);
            //}
        }

        private void button71_Click(object sender, EventArgs e)
        {
            button71.Enabled = false;


            CHighResolutionTimeStamps timeStamps = new CHighResolutionTimeStamps();



            zedGraphControl1.IsShowPointValues = true;
            //zedGraphControl1.GraphPane.Title = "20 Ohms Test";
            int AvgNum = 0;

            CRes res = m_TrimEng.ResistorList.ElementAt(comboBox2.SelectedIndex);

            AvgNum = 35;// res.FT_Cnt;
            //AvgNum =3;//1666 * 1;
            int sampleNum = 50000;

            double[] x = new double[sampleNum + AvgNum];
            double[] y = new double[sampleNum];
            double[] z = new double[sampleNum];
            double[] u = new double[sampleNum];
            double[] v = new double[sampleNum];
            double[] data = new double[sampleNum + AvgNum];
            int i;
            //Random rnd = new Random(); 238 239
            // m_Meter.SelectRelayMap(res.HF,res.HS,res.LF,res.LS);

            m_Meter.SelectRelayMap(0);
            m_Meter.SelectRelayMap(1);
            double bbb;
            bbb = 0;

            //    m_Meter.TrigADC(ref bbb);
            res.PT_Dly = 1500;
            timeStamps.DelayMicroSec(res.PT_Dly);

            //      m_Meter.TrigADC(ref data);

            //  m_Meter.SelectRelayMap(2 ,2, 3, 3);
            // timeStamps.DelayMicroSec(350);
            x[0] = timeStamps.GetMicroSecondTime();
            //  m_Meter.TrigADC2(ref data);

            //for (i = 0; i < (sampleNum + AvgNum); i++)
            //{
            //    m_Meter.TrigADC2(ref data[i]);
            //}

            x[sampleNum + AvgNum - 1] = timeStamps.GetMicroSecondTime();
            for (i = 0; i < (sampleNum + AvgNum); i++)
            {
                //m_Meter.TrigADC(ref data[i]);
                x[i] = x[0] + (x[sampleNum + AvgNum - 1] - x[0]) * i / (sampleNum + AvgNum - 1);// 4 * i;// timeStamps.GetMicroSecondTime();

            }

            // move avg for 100 sample, get sampleNum data

            // NO logic

            res = m_TrimEng.ResistorList.ElementAt(m_TrimEng.CurrentResID - 1);
            double stamp = x[0];
            for (i = 0; i < (sampleNum + AvgNum); i++)
            {
                //   res.NominalDesign = 100000;
                x[i] = (x[i] - stamp) / 1000;
                data[i] = data[i] + res.NominalDesign * res.MeasureBias / 100;   // 576.03 * 575.00;;
            }


            double mean = 0;
            double maxValue = -999999999;
            double minValue = 999999999;
            double maxPercent = 0;
            double minPercent = 0;
            double meanPercent = 0;

            ////把舊的圖資清掉
            zedGraphControl1.GraphPane.CurveList.Clear();

            double coeV = 0;


            double avg = 0;
            for (i = 0; i < AvgNum; i++)
            {
                avg = avg + data[i] / AvgNum;
            }

            double std = 0;
            //for (i = 0; i < 2; i++)
            //{
            //    std = std + data[i + 8] * data[i + 8] / 2;
            //}
            //std = Math.Sqrt(std - avg * avg);

            double[] oldData1 = new double[1];
            double[] newData1 = new double[1];
            for (i = 0; i < sampleNum; i++)
            {
                oldData1[0] = data[i];
                newData1[0] = data[i + AvgNum];
                v[i] = CalcuSMA(avg, oldData1, newData1, AvgNum);
                avg = v[i];
            }



            mean = 0;
            maxValue = -99999999999;
            minValue = 99999999999;
            maxPercent = 0;
            minPercent = 0;


            for (i = 0; i < sampleNum; i++)
            {
                mean = mean + v[i];

            }
            mean = mean / sampleNum;

            for (i = 0; i < sampleNum; i++)
            {
                // mean = mean + (v[i] / sampleNum);
                if (v[i] > maxValue)
                { maxValue = v[i]; }
                if (v[i] < minValue)
                { minValue = v[i]; }
            }
            maxPercent = ((maxValue - m_TrimEng.ResistorList.ElementAt(0).NominalDesign) / m_TrimEng.ResistorList.ElementAt(0).NominalDesign) * 100;
            minPercent = ((minValue - m_TrimEng.ResistorList.ElementAt(0).NominalDesign) / m_TrimEng.ResistorList.ElementAt(0).NominalDesign) * 100;



            coeV = CalcuCoefficientOfVariation(v);
            meanPercent = ((mean - m_TrimEng.ResistorList.ElementAt(0).NominalDesign) / m_TrimEng.ResistorList.ElementAt(0).NominalDesign) * 100;



            for (i = 0; i < sampleNum; i++)
            {
                v[i] = ((v[i] - m_TrimEng.ResistorList.ElementAt(0).NominalDesign) / m_TrimEng.ResistorList.ElementAt(0).NominalDesign) * 100;
            }


            zedGraphControl1.GraphPane.AddCurve("C.V. " + coeV.ToString("F3") + "%" + " M " + mean.ToString("F1") + " M " + meanPercent.ToString("F3") + " Max " + maxPercent.ToString("F3") + "% Min " + minPercent.ToString("F3") + "% Range " + (maxPercent - minPercent).ToString("F3"), x, v, Color.DimGray, SymbolType.Plus);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();



            button71.Enabled = true;

        }

        private void button72_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvRes(1, 0);
            lblFirmwareVer.Text = m_Meter.SelCvRes(2, 0);
        }

        private void button73_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCvCap(1, 0);
            lblFirmwareVer.Text = m_Meter.SelCvCap(2, 0);
        }

        private void button74_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text = "";
            lblFirmwareVer.Text = m_Meter.SelCurrent(1, 5);
            lblFirmwareVer.Text = m_Meter.SelCurrent(2, 5);
            lblFirmwareVer.Text = m_Meter.SelCCRes(1, 2);
            lblFirmwareVer.Text = m_Meter.SelCCRes(2, 2);
            lblFirmwareVer.Text = m_Meter.SetDACVolt(1, 10000);
            lblFirmwareVer.Text = m_Meter.SetDACVolt(2, 10000);

        }

        private double m_TestTargetR;
        private void btnMeasureColumn_Click(object sender, EventArgs e)
        {
            groupBox4.Enabled = false;
            try
            {
                if (ChangeResValue(txtTargetR.Text, ref m_TestTargetR))
                {
                    try
                    {
                        //double[] measureSetting = new double[11];
                        //measureSetting[0] = 113;
                        //measureSetting[1] = m_TestTargetR;//TargetR
                        //measureSetting[2] = (double)numPTSamples.Value;
                        //measureSetting[3] = (double)numPTDelay.Value;
                        //measureSetting[4] = (double)numHigh.Value;
                        //measureSetting[5] = (double)numLow.Value;
                        //measureSetting[6] = (double)numPTSamples.Value;
                        //measureSetting[7] = (double)numPTDelay.Value;
                        //measureSetting[8] = (double)numHigh.Value;
                        //measureSetting[9] = (double)numLow.Value;
                        //measureSetting[10] = 0;

                        //m_TrimEng.MeasureTestRSetting(ref measureSetting);
                        m_TrimEng.MeasureAll();
                        //將接收到的資料回傳給用戶端
                        double PreResHigh = m_TestTargetR * (1.0 + (double)numHigh.Value / 100.0);
                        double PreResLow = m_TestTargetR * (1.0 + (double)numLow.Value / 100.0);
                        int length;

                        for (int cellsIdx = 0; cellsIdx < m_TrimEng.TotalResistor; cellsIdx++)
                        {
                            //strSend = strSend + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PreVal.ToString("F5") + "," + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PrePercent.ToString("F2") + "," + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PostVal.ToString("F5") + "," + m_TrimEng.TrimmedDataList.ElementAt(aryIdx).PostPercent.ToString("F2") + ",";
                            length = m_TestTargetR.ToString().Length;
                            if (cellsIdx < 57)
                            {
                                

                                if (length <= 3)
                                {
                                    dgvResultList1.Rows[cellsIdx].Cells[1].Value = m_TrimEng.TrimmedDataList[cellsIdx].PreVal.ToString("F" + (5 - length).ToString());
                                }
                                else if (length <= 6)
                                {
                                    dgvResultList1.Rows[cellsIdx].Cells[1].Value = (m_TrimEng.TrimmedDataList[cellsIdx].PreVal / (double)1000).ToString("F" + (8 - length).ToString()) + "K";
                                }
                                else
                                {
                                    dgvResultList1.Rows[cellsIdx].Cells[1].Value = (m_TrimEng.TrimmedDataList[cellsIdx].PreVal / (double)1000000).ToString("F" + (11 - length).ToString()) + "M";
                                }

                                dgvResultList1.Rows[cellsIdx].Cells[2].Value = m_TrimEng.TrimmedDataList[cellsIdx].PreAdc.ToString();

                               // dgvResultList1.Rows[cellsIdx].Cells[2].Value = m_TrimEng.TrimmedDataList[cellsIdx].PrePercent.ToString("F3");


                                if (m_TrimEng.TrimmedDataList[cellsIdx].PreVal <= PreResLow)
                                {
                                    //dgvResultList1.Rows[cellsIdx].Cells[1].Value = "Short";
                                    //  dgvResultList1.Rows[cellsIdx].Cells[2].Value = "";
                                    dgvResultList1.Rows[cellsIdx].Cells[1].Style.BackColor = Color.Red;
                                    dgvResultList1.Rows[cellsIdx].Cells[2].Style.BackColor = Color.Red;
                                }
                                else if (m_TrimEng.TrimmedDataList[cellsIdx].PreVal >= PreResHigh)
                                {
                                    //  dgvResultList1.Rows[cellsIdx].Cells[1].Value = "Open";
                                    //  dgvResultList1.Rows[cellsIdx].Cells[2].Value = "";
                                    dgvResultList1.Rows[cellsIdx].Cells[1].Style.BackColor = Color.Red;
                                    dgvResultList1.Rows[cellsIdx].Cells[2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    if (m_TrimEng.TrimmedDataList[cellsIdx].PreVal > PreResHigh)
                                    {
                                        dgvResultList1.Rows[cellsIdx].Cells[1].Style.BackColor = Color.Orange;
                                        dgvResultList1.Rows[cellsIdx].Cells[2].Style.BackColor = Color.Orange;
                                    }
                                    else if (m_TrimEng.TrimmedDataList[cellsIdx].PreVal < PreResLow)
                                    {
                                        dgvResultList1.Rows[cellsIdx].Cells[1].Style.BackColor = Color.Yellow;
                                        dgvResultList1.Rows[cellsIdx].Cells[2].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgvResultList1.Rows[cellsIdx].Cells[1].Style.BackColor = Color.LightGreen;
                                        dgvResultList1.Rows[cellsIdx].Cells[2].Style.BackColor = Color.LightGreen;
                                    }
                                }
                            }
                            else
                            {
                                if (length <= 3)
                                {
                                    dgvResultList2.Rows[cellsIdx - 57].Cells[1].Value = m_TrimEng.TrimmedDataList[cellsIdx].PreVal.ToString("F" + (5 - length).ToString());
                                }
                                else if (length <= 6)
                                {
                                    dgvResultList2.Rows[cellsIdx - 57].Cells[1].Value = (m_TrimEng.TrimmedDataList[cellsIdx].PreVal / (double)1000).ToString("F" + (8 - length).ToString()) + "K";
                                }
                                else
                                {
                                    dgvResultList2.Rows[cellsIdx - 57].Cells[1].Value = (m_TrimEng.TrimmedDataList[cellsIdx].PreVal / (double)1000000).ToString("F" + (11 - length).ToString()) + "M";
                                }

                                dgvResultList2.Rows[cellsIdx-57].Cells[2].Value = m_TrimEng.TrimmedDataList[cellsIdx].PreAdc.ToString();
                               
                                // If cellsIdx = 47 Then Stop
                                // dgvResultList2.Rows[cellsIdx - 57].DefaultCellStyle.BackColor = Color.LightGreen
                                if (m_TrimEng.TrimmedDataList[cellsIdx].PreVal <= PreResLow)
                                {
                                    //dgvResultList2.Rows[cellsIdx - 57].Cells[1].Value = "Short";
                                    //  dgvResultList2.Rows[cellsIdx - 57].Cells[2].Value = "";
                                    dgvResultList2.Rows[cellsIdx - 57].Cells[1].Style.BackColor = Color.Red;
                                    dgvResultList2.Rows[cellsIdx - 57].Cells[2].Style.BackColor = Color.Red;
                                }
                                else if (m_TrimEng.TrimmedDataList[cellsIdx].PreVal >= PreResHigh)
                                {
                                    //   dgvResultList2.Rows[cellsIdx - 57].Cells[1].Value = "Open";
                                    //     dgvResultList2.Rows[cellsIdx - 57].Cells[2].Value = "";
                                    dgvResultList2.Rows[cellsIdx - 57].Cells[1].Style.BackColor = Color.Red;
                                    dgvResultList2.Rows[cellsIdx - 57].Cells[2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    if (m_TrimEng.TrimmedDataList[cellsIdx].PreVal > PreResHigh)
                                    {
                                        dgvResultList2.Rows[cellsIdx - 57].Cells[1].Style.BackColor = Color.Orange;
                                        dgvResultList2.Rows[cellsIdx - 57].Cells[2].Style.BackColor = Color.Orange;
                                    }
                                    else if (m_TrimEng.TrimmedDataList[cellsIdx].PreVal < PreResLow)
                                    {
                                        dgvResultList2.Rows[cellsIdx - 57].Cells[1].Style.BackColor = Color.Yellow;
                                        dgvResultList2.Rows[cellsIdx - 57].Cells[2].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgvResultList2.Rows[cellsIdx - 57].Cells[1].Style.BackColor = Color.LightGreen;
                                        dgvResultList2.Rows[cellsIdx - 57].Cells[2].Style.BackColor = Color.LightGreen;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    { }
                }
                else
                {
                    MessageBox.Show("Target error");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            groupBox4.Enabled = true;
            //    Call UpDateMeasureData()
        }


        //private void UpDateMeasureData()
        //{
        //    int length;
        //    double PreResHigh;
        //    double PreResLow;
        //    int avgNumPT = 0;
        //    int avgNum = 0;
        //    double mean = 0;
        //    double std = 0;
        //    double cv = 0;
        //    double maxPercent = -100;
        //    double minPercent = 100;
        //    PreResHigh = m_param.Product.TargetR * (1 + numHigh.Value / (double)100);
        //    PreResLow = m_param.Product.TargetR * (1 + numLow.Value / (double)100);
        //    for (int cellsIdx = 0; cellsIdx <= System.Convert.ToInt32(numResistorRowNumber.Value) - 1; cellsIdx++)
        //    {
        //        if (m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal <= m_param.Product.TargetR * 0.5)
        //        {
        //        }
        //        else if (m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal >= m_param.Product.TargetR * 1.5)
        //        {
        //        }
        //        else
        //        {
        //            if (m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal < PreResHigh && m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal > PreResLow)
        //                avgNumPT = avgNumPT + 1;
        //            avgNum = avgNum + 1;
        //            mean = mean + m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal;
        //            if (m_TrimEng.TrimmedDataList.Item(cellsIdx).PrePercent > maxPercent)
        //                maxPercent = m_TrimEng.TrimmedDataList.Item(cellsIdx).PrePercent;
        //            if (m_TrimEng.TrimmedDataList.Item(cellsIdx).PrePercent < minPercent)
        //                minPercent = m_TrimEng.TrimmedDataList.Item(cellsIdx).PrePercent;
        //        }
        //    }
        //    if (avgNum != 0)
        //    {
        //        mean = mean / avgNum;

        //        for (int cellsIdx = 0; cellsIdx <= System.Convert.ToInt32(numResistorRowNumber.Value) - 1; cellsIdx++)
        //        {
        //            if (m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal <= m_param.Product.TargetR * 0.5)
        //            {
        //            }
        //            else if (m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal >= m_param.Product.TargetR * 1.5)
        //            {
        //            }
        //            else
        //                std = std + Math.Pow((m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal - mean), 2);
        //        }

        //        std = Math.Sqrt(std / avgNum);
        //        cv = std / mean * 100;

        //        lblPreYield.Text = ((avgNumPT * 100 / (double)numResistorRowNumber.Value)).ToString("F2") + "%";
        //        lblPreMean.Text = (((mean - m_param.Product.TargetR) / (double)m_param.Product.TargetR) * 100).ToString("F2") + "%";
        //        lblPreSD.Text = cv.ToString("F2") + "%";
        //        lblPreMax.Text = maxPercent.ToString("F2") + "%";
        //        lblPreMin.Text = minPercent.ToString("F2") + "%";
        //    }


        //    for (int cellsIdx = 0; cellsIdx <= System.Convert.ToInt32(numResistorRowNumber.Value) - 1; cellsIdx++)
        //    {
        //        length = System.Convert.ToInt32(m_param.Product.TargetR).ToString().Length();
        //        if (cellsIdx < 57)
        //        {
        //            // dgvResultList1.Rows(cellsIdx).DefaultCellStyle.BackColor = Color.LightGreen
        //            if (m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal <= m_param.Product.TargetR * 0.5)
        //            {
        //                dgvResultList1.Rows[cellsIdx].Cells[1].Value = "Short";
        //                dgvResultList1.Rows(cellsIdx).Cells(2).Value = "";
        //                dgvResultList1.Rows(cellsIdx).Cells(1).Style.BackColor = Color.Red;
        //                dgvResultList1.Rows(cellsIdx).Cells(2).Style.BackColor = Color.Red;
        //            }
        //            else if (m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal >= m_param.Product.TargetR * 1.5)
        //            {
        //                dgvResultList1.Rows(cellsIdx).Cells(1).Value = "Open";
        //                dgvResultList1.Rows(cellsIdx).Cells(2).Value = "";
        //                dgvResultList1.Rows(cellsIdx).Cells(1).Style.BackColor = Color.Red;
        //                dgvResultList1.Rows(cellsIdx).Cells(2).Style.BackColor = Color.Red;
        //            }
        //            else
        //            {
        //                avgNum = avgNum + 1;
        //                mean = mean + m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal;
        //                switch (cmbResValue.SelectedIndex)
        //                {
        //                    case 0:
        //                        {
        //                            dgvResultList1.Rows(cellsIdx).Cells(1).Value = m_TrimEng.TrimmedDataList.Item(cellsIdx).PrePercent.ToString("F3");
        //                            dgvResultList1.Rows(cellsIdx).Cells(2).Value = m_TrimEng.TrimmedDataList.Item(cellsIdx).PostPercent.ToString("F3");
        //                            break;
        //                        }

        //                    default:
        //                        {
        //                            switch (length)
        //                            {
        //                                case object _ when length <= 3:
        //                            {
        //                                        dgvResultList1.Rows(cellsIdx).Cells(1).Value = m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal.ToString("F" + (5 - length).ToString());
        //                                        dgvResultList1.Rows(cellsIdx).Cells(2).Value = m_TrimEng.TrimmedDataList.Item(cellsIdx).PostVal.ToString("F" + (5 - length).ToString());
        //                                        break;
        //                                    }

        //                                case object _ when length <= 6:
        //                            {
        //                                        dgvResultList1.Rows(cellsIdx).Cells(1).Value = (m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal / (double)1000).ToString("F" + (8 - length).ToString()) + "K";
        //                                        dgvResultList1.Rows(cellsIdx).Cells(2).Value = (m_TrimEng.TrimmedDataList.Item(cellsIdx).PostVal / (double)1000).ToString("F" + (8 - length).ToString()) + "K";
        //                                        break;
        //                                    }

        //                                default:
        //                                    {
        //                                        dgvResultList1.Rows(cellsIdx).Cells(1).Value = (m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal / (double)1000000).ToString("F" + (11 - length).ToString()) + "M";
        //                                        dgvResultList1.Rows(cellsIdx).Cells(2).Value = (m_TrimEng.TrimmedDataList.Item(cellsIdx).PostVal / (double)1000000).ToString("F" + (11 - length).ToString()) + "M";
        //                                        break;
        //                                    }
        //                            }

        //                            break;
        //                        }
        //                }
        //                PreResHigh = m_param.Product.TargetR * (1 + numHigh.Value / (double)100);
        //                PreResLow = m_param.Product.TargetR * (1 + numLow.Value / (double)100);

        //                if (m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal > PreResHigh)
        //                {
        //                    dgvResultList1.Rows(cellsIdx).Cells(1).Style.BackColor = Color.Orange;
        //                    dgvResultList1.Rows(cellsIdx).Cells(2).Style.BackColor = Color.Orange;
        //                }
        //                else if (m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal < PreResLow)
        //                {
        //                    dgvResultList1.Rows(cellsIdx).Cells(1).Style.BackColor = Color.Yellow;
        //                    dgvResultList1.Rows(cellsIdx).Cells(2).Style.BackColor = Color.Yellow;
        //                }
        //                else
        //                {
        //                    dgvResultList1.Rows(cellsIdx).Cells(1).Style.BackColor = Color.LightGreen;
        //                    dgvResultList1.Rows(cellsIdx).Cells(2).Style.BackColor = Color.LightGreen;
        //                }
        //            }
        //        }
        //        else
        //            // If cellsIdx = 47 Then Stop
        //            // dgvResultList2.Rows(cellsIdx - 57).DefaultCellStyle.BackColor = Color.LightGreen
        //            if (m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal <= m_param.Product.TargetR * 0.5)
        //        {
        //            dgvResultList2.Rows(cellsIdx - 57).Cells(1).Value = "Short";
        //            dgvResultList2.Rows(cellsIdx - 57).Cells(2).Value = "";
        //            dgvResultList2.Rows(cellsIdx - 57).Cells(1).Style.BackColor = Color.Red;
        //            dgvResultList2.Rows(cellsIdx - 57).Cells(2).Style.BackColor = Color.Red;
        //        }
        //        else if (m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal >= m_param.Product.TargetR * 1.5)
        //        {
        //            dgvResultList2.Rows(cellsIdx - 57).Cells(1).Value = "Open";
        //            dgvResultList2.Rows(cellsIdx - 57).Cells(2).Value = "";
        //            dgvResultList2.Rows(cellsIdx - 57).Cells(1).Style.BackColor = Color.Red;
        //            dgvResultList2.Rows(cellsIdx - 57).Cells(2).Style.BackColor = Color.Red;
        //        }
        //        else
        //        {
        //            switch (cmbResValue.SelectedIndex)
        //            {
        //                case 0:
        //                    {
        //                        dgvResultList2.Rows(cellsIdx - 57).Cells(1).Value = m_TrimEng.TrimmedDataList.Item(cellsIdx).PrePercent.ToString("F3");
        //                        dgvResultList2.Rows(cellsIdx - 57).Cells(2).Value = m_TrimEng.TrimmedDataList.Item(cellsIdx).PostPercent.ToString("F3");
        //                        break;
        //                    }

        //                default:
        //                    {
        //                        switch (length)
        //                        {
        //                            case object _ when length <= 3:
        //                        {
        //                                    dgvResultList2.Rows(cellsIdx - 57).Cells(1).Value = m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal.ToString("F" + (5 - length).ToString());
        //                                    dgvResultList2.Rows(cellsIdx - 57).Cells(2).Value = m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal.ToString("F" + (5 - length).ToString());
        //                                    break;
        //                                }

        //                            case object _ when length <= 6:
        //                        {
        //                                    dgvResultList2.Rows(cellsIdx - 57).Cells(1).Value = (m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal / (double)1000).ToString("F" + (8 - length).ToString()) + "K";
        //                                    dgvResultList2.Rows(cellsIdx - 57).Cells(2).Value = (m_TrimEng.TrimmedDataList.Item(cellsIdx).PostVal / (double)1000).ToString("F" + (8 - length).ToString()) + "K";
        //                                    break;
        //                                }

        //                            default:
        //                                {
        //                                    dgvResultList2.Rows(cellsIdx - 57).Cells(1).Value = (m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal / (double)1000000).ToString("F" + (11 - length).ToString()) + "M";
        //                                    dgvResultList2.Rows(cellsIdx - 57).Cells(2).Value = (m_TrimEng.TrimmedDataList.Item(cellsIdx).PostVal / (double)1000000).ToString("F" + (11 - length).ToString()) + "M";
        //                                    break;
        //                                }
        //                        }

        //                        break;
        //                    }
        //            }
        //            PreResHigh = m_param.Product.TargetR * (1 + numHigh.Value / (double)100);
        //            PreResLow = m_param.Product.TargetR * (1 + numLow.Value / (double)100);

        //            if (m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal > PreResHigh)
        //            {
        //                dgvResultList2.Rows(cellsIdx - 57).Cells(1).Style.BackColor = Color.Orange;
        //                dgvResultList2.Rows(cellsIdx - 57).Cells(2).Style.BackColor = Color.Orange;
        //            }
        //            else if (m_TrimEng.TrimmedDataList.Item(cellsIdx).PreVal < PreResLow)
        //            {
        //                dgvResultList2.Rows(cellsIdx - 57).Cells(1).Style.BackColor = Color.Yellow;
        //                dgvResultList2.Rows(cellsIdx - 57).Cells(2).Style.BackColor = Color.Yellow;
        //            }
        //            else
        //            {
        //                dgvResultList2.Rows(cellsIdx - 57).Cells(1).Style.BackColor = Color.LightGreen;
        //                dgvResultList2.Rows(cellsIdx - 57).Cells(2).Style.BackColor = Color.LightGreen;
        //            }
        //        }
        //    }
        //}

        private void txtTargetR_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsControl(e.KeyChar))
                {

                }
                else
                {
                    bool b = false;
                    TextBox ctr = (TextBox)sender;
                    string tmp = ctr.Text;
                    if (ctr.SelectedText != "")
                    {
                        if (ctr.SelectedText.ToUpper() == tmp.ToUpper())
                        {
                            ctr.Text = "";
                            tmp = "";
                        }
                    }
                    if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == 'K' || e.KeyChar == 'k' || e.KeyChar == 'M' || e.KeyChar == 'm' || e.KeyChar == '.') || (tmp.IndexOf("M") != -1 || tmp.IndexOf("m") != -1 || tmp.IndexOf("K") != -1) || tmp.IndexOf("k") != -1)
                    {
                        if (ctr.SelectionStart < ctr.Text.Length)
                            b = false;
                        else
                            b = true;
                    }
                    if (tmp.IndexOf(".") != -1 && e.KeyChar == '.')
                        b = true;
                    e.Handled = b;
                }
            }
            catch (Exception ex)
            {
                string x = ex.Message;
            }
        }

        private void txtTargetR_Leave(object sender, EventArgs e)
        {
            TextBox ctr = (TextBox)sender;
            string tmp = ctr.Text.Trim();
            if (tmp == "")
                return;
            if (tmp[tmp.Length - 1] == '.')
                tmp = tmp.Substring(0, tmp.Length - 1);
            if (tmp.IndexOf(".K") != -1 || tmp.IndexOf(".M") != -1 || tmp.IndexOf(".m") != -1 || tmp.IndexOf(".k") != -1)
                tmp = tmp.Replace(".K", "K").Replace(".M", "M").Replace(".m", "m").Replace(".k", "k");
            if (tmp == "K" || tmp == "M" || tmp == "m" || tmp == "k")
                tmp = "1.00" + tmp;
            char Unit = tmp[tmp.Length - 1];
            if (Unit == 'k')
            {
                Unit = 'K';
                tmp = tmp.ToUpper();
            }
            if (Unit == 'K' || Unit == 'M' || Unit == 'm')
            {
                tmp = double.Parse(tmp.Replace(Unit.ToString(), "")).ToString("F2") + Unit;
                double v = 0;
                if (ChangeResValue(tmp, ref v))
                    tmp = ChangeValue(v);
            }
            else
            {
                double tmp2 = Math.Abs(double.Parse(tmp));
                tmp = ChangeValue(tmp2);
            }
            ctr.Text = tmp;
        }
        //    Private Sub txtNominal_Leave(sender As System.Object, e As System.EventArgs) Handles txtNominal.Leave
        //    Try
        //        Dim ctr As TextBox = CType(sender, TextBox)
        //        Dim tmp As String = ctr.Text.Trim()
        //        If (tmp = "") Then
        //            Exit Sub
        //        End If
        //        If(tmp(tmp.Length - 1) = "."c) Then
        //           tmp = tmp.Substring(0, tmp.Length - 1)
        //        End If
        //        If(tmp.IndexOf(".K") <> -1 Or tmp.IndexOf(".M") <> -1 Or tmp.IndexOf(".m") <> -1 Or tmp.IndexOf(".k") <> -1) Then
        //           tmp = tmp.Replace(".K", "K").Replace(".M", "M").Replace(".m", "m").Replace(".k", "k")
        //        End If
        //        If(tmp = "K" Or tmp = "M" Or tmp = "m" Or tmp = "k") Then
        //           tmp = "1.00" & tmp
        //        End If
        //        Dim Unit As String = tmp(tmp.Length - 1)
        //        If(Unit = "k") Then
        //           Unit = Unit.ToUpper()
        //            tmp = tmp.ToUpper
        //        End If
        //        If(Unit = "K" Or Unit = "M" Or Unit = "m") Then
        //           tmp = Double.Parse(tmp.Replace(Unit, "")).ToString("F2") & Unit
        //            Dim v As Double
        //            If(ChangeResValue(tmp, v)) Then
        //               tmp = ChangeValue(v)
        //            End If
        //        Else
        //            Dim tmp2 As Double = Math.Abs(Double.Parse(tmp))
        //            If(ctr.Name<> "txtTol") Then
        //              tmp = ChangeValue(tmp2)
        //            End If
        //        End If

        //        ctr.Text = tmp
        //    Catch ex As Exception
        //        MessageBox.Show(ex.Message, "Error txtLowLitmit_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
        //    End Try
        //End Sub

        private string ChangeValue(double R)
        {
            string result = "";
            try
            {
                if (R >= 1000000.0)
                    result = (R / 1000000.0).ToString("F2") + "M";
                else if (R >= 1000.0)
                    result = (R / 1000.0).ToString("F2") + "K";
                else if (R < 0.01 && R != 0)
                    result = (R * 1000.0).ToString("F2") + "m";
                else
                    result = R.ToString("F2");
            }
            catch { }
            return result;
        }

        //    Private Function ChangeValue(ByVal R As Double) As String
        //    Dim result As String = ""
        //    Try
        //        If(R >= 1000000.0) Then
        //           result = (R / 1000000.0).ToString("F2") & "M"
        //        ElseIf(R >= 1000.0) Then
        //           result = (R / 1000.0).ToString("F2") & "K"
        //        ElseIf(R< 0.01 And R<> 0) Then
        //         result = (R * 1000).ToString("F2") & "m"
        //        Else
        //            result = R.ToString("F2")
        //        End If
        //    Catch ex As Exception
        //        MessageBox.Show(ex.Message, "Error ChangeValue", MessageBoxButtons.OK, MessageBoxIcon.Error)
        //    End Try
        //    Return result
        //End Function
        private bool ChangeResValue(string strR, ref double Result)
        {
            Result = 0;
            try
            {
                char Unit = strR[strR.Length - 1];
                switch (Unit)
                {
                    case 'm':
                        strR = strR.Replace("m", "");
                        Result = (Double.Parse(strR)) * 0.001;
                        break;
                    case 'K':
                        strR = strR.Replace("K", "");
                        Result = (Double.Parse(strR)) * 1000;
                        break;
                    case 'M':
                        strR = strR.Replace("M", "");
                        Result = (Double.Parse(strR)) * 1000000;
                        break;
                    default:
                        Result = (Double.Parse(strR));
                        break;
                }
                return true;
            }
            catch
            {
                Result = 0;
                return false;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                groupBox4.Enabled = false;

                double[] measureSetting = new double[11];
                measureSetting[0] = 113;
                ChangeResValue(txtTargetR.Text, ref measureSetting[1]);//TargetR
                measureSetting[2] = (double)numPTSamples.Value;
                measureSetting[3] = (double)numPTDelay.Value;
                measureSetting[4] = (double)numHigh.Value;
                measureSetting[5] = (double)numLow.Value;
                measureSetting[6] = (double)numPTSamples.Value;
                measureSetting[7] = (double)numPTDelay.Value;
                measureSetting[8] = (double)numHigh.Value;
                measureSetting[9] = (double)numLow.Value;
                measureSetting[10] = 0;

                m_TrimEng.MeasureTestRSetting(ref measureSetting);

                groupBox4.Enabled = true;
            }
            catch (Exception)
            {

                MessageBox.Show("Target error");
            }

        }

        private void button75_Click(object sender, EventArgs e)
        {
            m_Meter.SetRes2(900);
        }

        private void button76_Click(object sender, EventArgs e)
        {
            m_Meter.SetRes2(1000);
        }

        private void button77_Click(object sender, EventArgs e)
        {
          //  m_Meter.SetID(int.Parse(txtSN.Text));
        }

        private void button78_Click(object sender, EventArgs e)
        {
            lblFirmwareVer.Text= m_Meter.GetID();
        }

        private void button79_Click(object sender, EventArgs e)
        {
            int i = 0;
            int rs=0;
            for (i = 0; i < 20; i++)
            {
                if (i < 1)
                {
                    rs = (int)(m_Meter.ADCValue1[i] * 100);

                }
                else if (i < 5)
                {
                    rs = (int)(m_Meter.ADCValue1[i] * 10);
                }
                else if (i < 11)
                {
                    rs = (int)(m_Meter.ADCValue1[i]);
                }
                else if (i < 17)
                {
                    rs = (int)(m_Meter.ADCValue1[i] / 10);
                }
                else
                {
                    rs = (int)(m_Meter.ADCValue1[i] / 100);
                }
                m_Meter.SetCalRes(1, i + 1, rs);
            }

            for (i = 0; i < 20; i++)
            {
                m_Meter.GetCalRes(1, i+1, ref rs);
                if (i < 1)
                {
                    m_Meter.ADCValue1[i] = (double)rs / 100;
                }
                else if (i < 5)
                {
                    m_Meter.ADCValue1[i] = (double)rs / 10;
                }
                else if (i < 11)
                {
                    m_Meter.ADCValue1[i] = (double)rs ;
                }
                else if (i < 17)
                {
                    m_Meter.ADCValue1[i] = (double)rs *10;
                }
                else
                {
                    m_Meter.ADCValue1[i] = (double)rs * 100;
                }
            }


           
             
        }

        private void button80_Click(object sender, EventArgs e)
        {
            m_Meter.SetCalRes(1, 2,int.Parse ( textBox2.Text) );
        }

        private void button81_Click(object sender, EventArgs e)
        {
            int res=0;
            m_Meter.GetCalRes (1, 2, ref res);
            textBox2.Text = res.ToString();
        }

        private void button82_Click(object sender, EventArgs e)
        {
            m_TrimEng.InitialHw();
        }

        //    Private Function ChangeResValue(ByVal strR As String, ByRef Result As Double) As Boolean
        //    Result = 0
        //    Try
        //        Dim Unit As Char = strR(strR.Length - 1)
        //        Select Case Unit
        //            Case "m"c
        //                strR = strR.Replace("m", "")
        //                Result = (Double.Parse(strR)) * 0.001
        //            Case "K"c
        //                strR = strR.Replace("K", "")
        //                Result = (Double.Parse(strR)) * 1000
        //            Case "M"c
        //                strR = strR.Replace("M", "")
        //                Result = (Double.Parse(strR)) * 1000000
        //            Case Else
        //                Result = Double.Parse(strR)
        //        End Select
        //    Catch ex As Exception
        //        Return False
        //    End Try
        //    Return True
        //End Function



        //        //目標阻值 轉彎阻值 結束阻值
        //        //----------------------------------------------------------------------------
        //// 's' StdRes.UcByte[0~3] FinalRes.UcByte[0~3] FirstRes.UcByte[0~3] CheckSum '\n'
        //// Total: 1 + 8 + 8 + 8 +2 +1 =28 Byts
        ////High Byte, High Nibble first. Chechsum=sum(2~25)
        ////----------------------------------------------------------------------------
        //void Float2Array()
        //{
        // int localint1=0;
        // System.Byte localchar1, localchar2;
        // //FinalRes.Fnumber FirstRes.Fbynber StdRes.Fnumber UcByte[4]
        // Tx_Buffer_Index=0;
        // Uart_Tx_Buffer[Tx_Buffer_Index]='s';
        // for(localint1=3;localint1>-1;localint1--) //High byte High Nibble 先送
        // //for(localint1=0;localint1<4;localint1++) //Low byte High Nibble 先送
        // {
        //  Tx_Buffer_Index++;
        //  localchar1=StdRes.UcByte[localint1] & 0xF0;
        //  localchar1 >>=4;
        //  localchar1=localchar1+0x30;
        //  Uart_Tx_Buffer[Tx_Buffer_Index]=localchar1;
        //  localchar2 +=localchar1;
        //  Tx_Buffer_Index++;
        //  localchar1=StdRes.UcByte[localint1] & 0x0F;
        //  localchar1=localchar1+0x30;
        //  Uart_Tx_Buffer[Tx_Buffer_Index]=localchar1;
        //  localchar2 +=localchar1;
        // }
        // //for(localint1=0;localint1<4;localint1++) //Low byte High Nibble 先送
        // for(localint1=3;localint1>-1;localint1--) //High byte High Nibble 先送
        // {
        //  Tx_Buffer_Index++;
        //  localchar1=FinalRes.UcByte[localint1] & 0xF0;
        //  localchar1 >>=4;
        //  localchar1=localchar1+0x30;
        //  Uart_Tx_Buffer[Tx_Buffer_Index]=localchar1;
        //  localchar2 +=localchar1;
        //  Tx_Buffer_Index++;
        //  localchar1=FinalRes.UcByte[localint1] & 0x0F;
        //  localchar1=localchar1+0x30;
        //  Uart_Tx_Buffer[Tx_Buffer_Index]=localchar1;
        //  localchar2 +=localchar1;
        // }
        // //for(localint1=0;localint1<4;localint1++) //Low byte High Nibble 先送
        // for(localint1=3;localint1>-1;localint1--) //High byte High Nibble 先送
        // {
        //  Tx_Buffer_Index++;
        //  localchar1=FirstRes.UcByte[localint1] & 0xF0;
        //  localchar1 >>=4;
        //  localchar1=localchar1+0x30;
        //  Uart_Tx_Buffer[Tx_Buffer_Index]=localchar1;
        //  localchar2 +=localchar1;
        //  Tx_Buffer_Index++;
        //  localchar1=FirstRes.UcByte[localint1] & 0x0F;
        //  localchar1=localchar1+0x30;
        //  Uart_Tx_Buffer[Tx_Buffer_Index]=localchar1;
        //  localchar2 +=localchar1;
        // }
        // Tx_Buffer_Index++;
        // localchar1=localchar2 & 0xF0;
        // localchar1 >>=4;
        // localchar1=localchar1+0x30;
        // Uart_Tx_Buffer[Tx_Buffer_Index]=localchar1;
        // Tx_Buffer_Index++;
        // localchar1=localchar2 & 0x0F;
        // localchar1=localchar1+0x30;
        // Uart_Tx_Buffer[Tx_Buffer_Index]=localchar1;
        // Tx_Buffer_Index++;
        // Uart_Tx_Buffer[Tx_Buffer_Index]='\n';
        //}
        //    }
    }
}
