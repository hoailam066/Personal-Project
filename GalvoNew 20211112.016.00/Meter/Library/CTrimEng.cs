#define GreenLaser 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using Automation.BDaq;
using Algorithm;
using Timer;
using PseudoLaserSystem;
internal struct AnalysisData
{
    internal double ResVal;//阻值
    internal double TimeStamp; //時間
    internal double PosY;//振鏡位置
    internal double PosX;//振鏡位置
}


namespace Meter
{

    public class CTrimEng
    {
        private InstantDoCtrl m_InstantDoCtrl;
        private PwModulatorCtrl m_PwModulatorCtrl;
        private CMeter m_Meter;
        private CHighResolutionTimeStamps m_Timer;
        /// <summary>
        /// 電阻總列數
        /// </summary>
        private int m_TotalResistor;
        public int TotalResistor
        {
            get { return m_TotalResistor; }
            set { m_TotalResistor = value; }
        }

        /// <summary>
        /// 機板總排數
        /// </summary>
        private int m_TotalCol;
        public int TotalCol
        {
            get { return m_TotalCol; }
            set { m_TotalCol = value; }
        }

        /// <summary>
        /// 目前電阻索引值,從1開始
        /// </summary>
        private int m_CurrentResId;
        /// <summary>
        /// 目前電阻索引值,從1開始
        /// </summary>
        public int CurrentResID
        {
            get { return m_CurrentResId; }
            set { m_CurrentResId = value; }
        }
        /// <summary>
        /// 目前電阻排數索引值,從1開始
        /// </summary>
        private int m_CurrentColId = 1;
        public int CurrentColId
        {
            get { return m_CurrentColId; }
            set { m_CurrentColId = value; }
        }
        /// <summary>
        /// 目前刀數索引值,從0開始
        /// </summary>
        private int m_CurrentCutId;

        internal int CurrentCutId
        {
            get { return m_CurrentCutId; }
            set { m_CurrentCutId = value; }
        }
        private CPseudoGalvo m_PseudoGalvo;
        /// <summary>
        ///  目前雷射功率百分比
        /// </summary>
        public double m_SetPower;
        /// <summary>
        /// 目前雷射頻率KHz
        /// </summary>
        private double m_SetFrequency;



        /// <summary>
        /// 
        /// </summary>
        public int m_SetPulseWidth;

        /// <summary>
        ///  Voltage/mm
        /// </summary>
        private double m_ScaleFactorX;
        public double ScaleFactorX
        {
            get { return m_ScaleFactorX; }
            set { m_ScaleFactorX = value; }
        }
        /// <summary>
        /// Voltage/mm
        /// </summary>
        private double m_ScaleFactorY;
        public double ScaleFactorY
        {
            get { return m_ScaleFactorY; }
            set { m_ScaleFactorY = value; }
        }
        private double m_CurPosX;

        public double GetGalvoPosX
        {
            get { return m_CurPosX; }
        }
        private double m_CurPosY;
        public double GetGalvoPosY
        {
            get { return m_CurPosY; }
        }

        /// <summary>
        /// 電阻Galvo位置
        /// </summary>
        private List<CRes> m_ResistorList;
        public List<CRes> ResistorList
        {
            get { return m_ResistorList; }
            set { m_ResistorList = value; }
        }

        private List<CPanel> m_PanelList;
        public List<CPanel> PanelList
        {
            get { return m_PanelList; }
            set { m_PanelList = value; }
        }

        // private List<MeasureData> m_MeasureList;
        //public List<MeasureData> MeasureList
        //{
        //    get { return m_MeasureList; }
        //    set { m_MeasureList = value; }
        //} 



        /// <summary>
        /// 切完後的阻值
        /// </summary>
        private List<CTrimData> m_TrimmedDataList;
        public List<CTrimData> TrimmedDataList
        {
            get { return m_TrimmedDataList; }
            set { m_TrimmedDataList = value; }
        }

        private int m_TotalCuts;
        public int TotalCuts
        {
            get { return m_TotalCuts; }
            set { m_TotalCuts = value; }
        }
        /// <summary>
        /// 切割參數
        /// </summary>
        private List<CCutParam> m_CutInfoList;
        internal AnalysisData[] m_AnalysisData;
        private int m_AnalysisIdx = 0;
        private Thread m_threadMeasureOne;
        private Thread m_threadTrimOne;

        private double[] m_ResStopValue;
        //private double[] m_ResStopPerc;
        private int m_ResRangeIdx = 0;
        public CTrimEng(ref CMeter Meter)
        {
            m_Meter = Meter;
        }
        ~CTrimEng()
        {
            m_StopTrim = true;
            m_StopMeasure = true;
        }

        public Boolean InitialHw()
        {
            Automation.BDaq.ErrorCode errCode;

            m_PwModulatorCtrl = new PwModulatorCtrl();
            DeviceInformation deviceInformation;
            deviceInformation = new DeviceInformation(0, "PCIE-1816,BID#0", AccessMode.ModeWrite, 0);
            m_PwModulatorCtrl.SelectedDevice = deviceInformation;
            // Read profile to configure device
            errCode = m_PwModulatorCtrl.LoadProfile("C:\\Profile.xml");
            // Start 'PWM Output' function
            m_PwModulatorCtrl.ChannelStart = 0;
            m_PwModulatorCtrl.ChannelCount = 1;

            m_PwModulatorCtrl.Enabled = false;
            // Stop 'PWM Output' function
            //pwModulatorCtrl1.Enabled = false;



            m_InstantDoCtrl = new InstantDoCtrl();

            deviceInformation = new DeviceInformation(0, "PCIE-1816,BID#0", AccessMode.ModeWrite, 0);
            m_InstantDoCtrl.SelectedDevice = deviceInformation;


            errCode = m_InstantDoCtrl.LoadProfile("C:\\Profile.xml");

            m_Meter.InitialHw();
            m_Meter.SetRes2(1000000);

            m_AnalysisData = new AnalysisData[1500000];
            m_ResStopValue = new double[40];
            //m_ResStopPerc = new double[40];
            m_CurrentResId = 1;
            m_ScaleFactorX = 0.27;// 10.0 / 25 * 0.3181336161; //10.0/25*0.3181336161;
            m_ScaleFactorY = 0.27;// 10.0 / 25 * 0.3181336161;





            StreamReader sr1 = new StreamReader("D:\\DataSettings\\LaserTrimming1610\\Machine\\Parameter\\GalvoScaleX.txt", Encoding.Default);
            string line;
            line = sr1.ReadLine();
            m_ScaleFactorX = double.Parse(line);

            StreamReader sr2 = new StreamReader("D:\\DataSettings\\LaserTrimming1610\\Machine\\Parameter\\GalvoScaleY.txt", Encoding.Default);
            line = sr2.ReadLine();
            m_ScaleFactorY = double.Parse(line);



            m_CurPosX = 0;
            m_CurPosY = 0;
            m_JumpSpeed = 400;
            if (m_Timer == null) { m_Timer = new CHighResolutionTimeStamps(); }
            if (m_Laser == null) { m_Laser = new CLaser(); }
            if (m_ResistorList == null) { m_ResistorList = new List<CRes>(); }
            if (m_PanelList == null) { m_PanelList = new List<CPanel>(); }
            if (m_TrimmedDataList == null) { m_TrimmedDataList = new List<CTrimData>(); }
            m_TotalResistor = 120;
            for (int aryIdx = 0; aryIdx < m_TotalResistor; aryIdx++)
            {
                CRes res;
                res = new CRes();
                res.FT_Cnt = 5;
                res.FT_Dly = 650;
                res.FT_High = 0.5;
                res.FT_Low = -0.5;
                if (aryIdx < 46)
                {
                    res.RelayIdx = 45 - aryIdx;
                    res.HF = 2 * (45 - aryIdx);
                    res.HS = 2 * (45 - aryIdx);
                    res.LF = 2 * (45 - aryIdx) + 1;
                    res.LS = 2 * (45 - aryIdx) + 1;
                }
                else
                {
                    res.RelayIdx = aryIdx;
                    res.HF = 2 * aryIdx;
                    res.HS = 2 * aryIdx;
                    res.LF = 2 * aryIdx + 1;
                    res.LS = 2 * aryIdx + 1;
                }

                res.RelayIdx = aryIdx;
                res.HF = 2 * aryIdx;
                res.HS = 2 * aryIdx;
                res.LF = 2 * aryIdx + 1;
                res.LS = 2 * aryIdx + 1;



                res.MeasureBias = 0;
                res.MeasureHotBias = 0;
                res.NominalDesign = 1000000;
                res.NominalOffset1 = 0;
                res.NominalOffset2 = 0;
                res.NominalOffset3 = 0;
                res.NominalOffset4 = 0;
                res.NominalOffset5 = 0;
                res.NominalOffset6 = 0;
                res.NominalOffset7 = 0;
                res.NominalReal1 = 1000000;
                res.NominalReal2 = 1000000;
                res.NominalReal3 = 1000000;
                res.NominalReal4 = 1000000;
                res.NominalReal5 = 1000000;
                res.NominalReal6 = 1000000;
                res.NominalReal7 = 1000000;
                res.PT_Cnt = 35;
                res.PT_Dly = 3000;
                res.PT_High = 0.5;
                res.PT_Low = -35;
                m_ResistorList.Add(res);
                CTrimData trimmedData;
                trimmedData = new CTrimData();
                m_TrimmedDataList.Add(trimmedData);
            }
            m_TotalCol = 200;
            for (int aryIdx = 0; aryIdx < m_TotalCol; aryIdx++)
            {
                CPanel panel = new CPanel();
                m_PanelList.Add(panel);
            }

            m_TotalCuts = 100;
            if (m_CutInfoList == null) { m_CutInfoList = new List<CCutParam>(); }
            for (int aryIdx = 0; aryIdx < m_TotalCuts; aryIdx++)
            {
                CCutParam cutData = new CCutParam();
                m_CutInfoList.Add(cutData);
            }
            if (m_TrimmedDataList == null) { m_TrimmedDataList = new List<CTrimData>(); }
            for (int aryIdx = 0; aryIdx < m_TotalResistor; aryIdx++)
            {
                CTrimData trimData = new CTrimData();
                m_TrimmedDataList.Add(trimData);
            }

            // Write port values to DO port
            double timeSpan;
            timeSpan = m_Timer.GetMicroSecondTime();
            errCode = m_InstantDoCtrl.Write(0, (byte)0x0);
            if (errCode != ErrorCode.Success)
            {
                throw new System.ArgumentException("WriteBit fail", "Hardware Error");
            }
            timeSpan = m_Timer.GetMicroSecondTime() - timeSpan;
            //m_Meter.SetRes(20, 20, 20);
            m_PseudoGalvo = new CPseudoGalvo();
            //開始非同步量測
            m_StopMeasure = false;
            m_RdyToTrim = false;
            m_ThreadMeasureStarted = false;
            var p = Process.GetCurrentProcess();
            // p.ProcessorAffinity= (IntPtr)0xF0;
            p.PriorityClass = ProcessPriorityClass.High;

            Thread m_threadMeasureOne = new Thread(MeasureOne);
            // Of course this only affects the main thread rather than child threads.
            m_threadMeasureOne.IsBackground = true;
            m_threadMeasureOne.Priority = ThreadPriority.Highest;
            m_threadMeasureOne.Start();

            Thread m_threadTrimOne = new Thread(TrimMyBackgroundTask);
            m_threadTrimOne.IsBackground = true;
            m_threadTrimOne.Priority = ThreadPriority.Highest;
            m_threadTrimOne.Start();
            //////////ProcessThreadCollection threads;
            //////////threads = p.Threads;
            //////////int[] prccessorId = new int[8];
            //////////prccessorId[0] = 128;
            //////////prccessorId[1] = 64;
            //////////prccessorId[2] = 32;
            //////////prccessorId[3] = 16;
            //////////prccessorId[4] = 8;
            //////////prccessorId[5] = 4;
            //////////prccessorId[6] = 2;
            //////////prccessorId[7] = 1;
            //////////int pIdx;
            //////////pIdx = 0;
            //////////for (int aryIdx = 0; aryIdx < threads.Count; aryIdx++)
            //////////{
            //////////    if (threads[aryIdx].ThreadState == System.Diagnostics.ThreadState.Running)
            //////////    {
            //////////       // threads[aryIdx].IdealProcessor =4;
            //////////        threads[aryIdx].ProcessorAffinity = (IntPtr)prccessorId[pIdx];
            //////////        pIdx++;
            //////////        if (pIdx >= 7) { pIdx = 7; }
            //////////    }
            //////////}



            //// Make sure there is an instance of notepad running.
            //Process notepads;// = Process.GetCurrentProcess();tepad");

            //ProcessThreadCollection threads;
            ////Process[] notepads;
            //// Retrieve the Notepad processes.
            //notepads = Process.GetCurrentProcess();// ("Notepad");
            //// Get the ProcessThread collection for the first instance
            //threads = notepads.Threads;
            //// Set the properties on the first ProcessThread in the collection
            //for (int aryIdx = 0; aryIdx < threads.Count; aryIdx++)
            //{
            //    threads[aryIdx].IdealProcessor = 2;
            //    threads[aryIdx].ProcessorAffinity = (IntPtr)1;
            //}





            // SetThreadRunAtProcesser
            return true;
        }

        public void CloseHw()
        {
            m_Meter.CloseHw();
        }
        public void CutSetting(ref CCutParam[] Data)
        {

            m_CutInfoList.Clear();
            for (int aryIdx = 0; aryIdx < Data.Length; aryIdx++)
            {
                CCutParam cutData;
                cutData = new CCutParam();
                cutData.CutID = Data[aryIdx].CutID;
                cutData.Delay = Data[aryIdx].Delay;
                cutData.Direction = Data[aryIdx].Direction;
                cutData.PulseDensity = Data[aryIdx].PulseDensity;
                cutData.QRate = Data[aryIdx].QRate;
                cutData.Repo = Data[aryIdx].Repo;
                cutData.Speed = Data[aryIdx].Speed;
                cutData.Length = Data[aryIdx].Length;
                //cutData.StopPercentA = Data[aryIdx].StopPercentA;
                //cutData.StopPercentB = Data[aryIdx].StopPercentB;
                //cutData.StopPercentC = Data[aryIdx].StopPercentC;
                //cutData.StopPercentD = Data[aryIdx].StopPercentD;
                //cutData.StopPercentE = Data[aryIdx].StopPercentE;
                //cutData.StopPercentF = Data[aryIdx].StopPercentF;
                //cutData.StopPercentG = Data[aryIdx].StopPercentG;
                cutData.XOffset = Data[aryIdx].XOffset;
                cutData.YOffset = Data[aryIdx].YOffset;



                cutData.ResStopPerc[0] = Data[aryIdx].StopPercentA; // 0% < X <= -1%
                cutData.ResStopPerc[1] = Data[aryIdx].StopPercentA; // -1% < X <= -2%
                cutData.ResStopPerc[2] = Data[aryIdx].StopPercentA; // -2% < X <= -3%
                cutData.ResStopPerc[3] = Data[aryIdx].StopPercentA; // -3% < X <= -4%
                cutData.ResStopPerc[4] = Data[aryIdx].StopPercentA; // -4% < X <= -5%

                cutData.ResStopPerc[5] = Data[aryIdx].StopPercentA + (Data[aryIdx].StopPercentB - Data[aryIdx].StopPercentA) * 1 / 5; // -5% < X <= -6% 
                cutData.ResStopPerc[6] = Data[aryIdx].StopPercentA + (Data[aryIdx].StopPercentB - Data[aryIdx].StopPercentA) * 2 / 5;  // -6% < X <= -7%
                cutData.ResStopPerc[7] = Data[aryIdx].StopPercentA + (Data[aryIdx].StopPercentB - Data[aryIdx].StopPercentA) * 3 / 5;  // -7% < X <= -8%
                cutData.ResStopPerc[8] = Data[aryIdx].StopPercentA + (Data[aryIdx].StopPercentB - Data[aryIdx].StopPercentA) * 4 / 5;  // -8% < X <= -9%
                cutData.ResStopPerc[9] = Data[aryIdx].StopPercentA + (Data[aryIdx].StopPercentB - Data[aryIdx].StopPercentA) * 5 / 5;  // -9% < X <= -10% 

                cutData.ResStopPerc[10] = Data[aryIdx].StopPercentB + (Data[aryIdx].StopPercentC - Data[aryIdx].StopPercentB) * 1 / 5; //-10 % < X <= -11 %
                cutData.ResStopPerc[11] = Data[aryIdx].StopPercentB + (Data[aryIdx].StopPercentC - Data[aryIdx].StopPercentB) * 2 / 5;
                cutData.ResStopPerc[12] = Data[aryIdx].StopPercentB + (Data[aryIdx].StopPercentC - Data[aryIdx].StopPercentB) * 3 / 5;
                cutData.ResStopPerc[13] = Data[aryIdx].StopPercentB + (Data[aryIdx].StopPercentC - Data[aryIdx].StopPercentB) * 4 / 5;
                cutData.ResStopPerc[14] = Data[aryIdx].StopPercentB + (Data[aryIdx].StopPercentC - Data[aryIdx].StopPercentB) * 5 / 5;

                cutData.ResStopPerc[15] = Data[aryIdx].StopPercentC + (Data[aryIdx].StopPercentD - Data[aryIdx].StopPercentC) * 1 / 5;
                cutData.ResStopPerc[16] = Data[aryIdx].StopPercentC + (Data[aryIdx].StopPercentD - Data[aryIdx].StopPercentC) * 2 / 5;
                cutData.ResStopPerc[17] = Data[aryIdx].StopPercentC + (Data[aryIdx].StopPercentD - Data[aryIdx].StopPercentC) * 3 / 5;
                cutData.ResStopPerc[18] = Data[aryIdx].StopPercentC + (Data[aryIdx].StopPercentD - Data[aryIdx].StopPercentC) * 4 / 5;
                cutData.ResStopPerc[19] = Data[aryIdx].StopPercentC + (Data[aryIdx].StopPercentD - Data[aryIdx].StopPercentC) * 5 / 5;

                cutData.ResStopPerc[20] = Data[aryIdx].StopPercentD + (Data[aryIdx].StopPercentE - Data[aryIdx].StopPercentD) * 1 / 5;
                cutData.ResStopPerc[21] = Data[aryIdx].StopPercentD + (Data[aryIdx].StopPercentE - Data[aryIdx].StopPercentD) * 2 / 5;
                cutData.ResStopPerc[22] = Data[aryIdx].StopPercentD + (Data[aryIdx].StopPercentE - Data[aryIdx].StopPercentD) * 3 / 5;
                cutData.ResStopPerc[23] = Data[aryIdx].StopPercentD + (Data[aryIdx].StopPercentE - Data[aryIdx].StopPercentD) * 4 / 5;
                cutData.ResStopPerc[24] = Data[aryIdx].StopPercentD + (Data[aryIdx].StopPercentE - Data[aryIdx].StopPercentD) * 5 / 5;

                cutData.ResStopPerc[25] = Data[aryIdx].StopPercentE + (Data[aryIdx].StopPercentF - Data[aryIdx].StopPercentE) * 1 / 5;
                cutData.ResStopPerc[26] = Data[aryIdx].StopPercentE + (Data[aryIdx].StopPercentF - Data[aryIdx].StopPercentE) * 2 / 5;
                cutData.ResStopPerc[27] = Data[aryIdx].StopPercentE + (Data[aryIdx].StopPercentF - Data[aryIdx].StopPercentE) * 3 / 5;
                cutData.ResStopPerc[28] = Data[aryIdx].StopPercentE + (Data[aryIdx].StopPercentF - Data[aryIdx].StopPercentE) * 4 / 5;
                cutData.ResStopPerc[29] = Data[aryIdx].StopPercentE + (Data[aryIdx].StopPercentF - Data[aryIdx].StopPercentE) * 5 / 5;

                cutData.ResStopPerc[30] = Data[aryIdx].StopPercentF + (Data[aryIdx].StopPercentG - Data[aryIdx].StopPercentF) * 1 / 5;
                cutData.ResStopPerc[31] = Data[aryIdx].StopPercentF + (Data[aryIdx].StopPercentG - Data[aryIdx].StopPercentF) * 2 / 5;
                cutData.ResStopPerc[32] = Data[aryIdx].StopPercentF + (Data[aryIdx].StopPercentG - Data[aryIdx].StopPercentF) * 3 / 5;
                cutData.ResStopPerc[33] = Data[aryIdx].StopPercentF + (Data[aryIdx].StopPercentG - Data[aryIdx].StopPercentF) * 4 / 5;
                cutData.ResStopPerc[34] = Data[aryIdx].StopPercentF + (Data[aryIdx].StopPercentG - Data[aryIdx].StopPercentF) * 5 / 5;
                m_CutInfoList.Add(cutData);
            }
            m_SetFrequency = m_CutInfoList.ElementAt(0).QRate;
            m_Laser.PRR = m_CutInfoList.ElementAt(0).QRate;
        }


        public void PulseLaser()
        {
            m_Laser.LaserEmissionOn = true;
            //Thread.Sleep(40);
            SpinWait.SpinUntil(() => false, 40);
            //m_Laser.OperatingPower = 50;
            // Thread.Sleep(100);
            //m_Laser.PRR = 20;

            ErrorCode errCode;
            byte portValue;

            portValue = 0x1;
            errCode = m_InstantDoCtrl.Write(0, portValue);
            if (errCode != ErrorCode.Success)
            {
                throw new System.ArgumentException("WriteBit fail", "Hardware Error");
            }
            //Thread.Sleep(1000);
            SpinWait.SpinUntil(() => false, 2000);
            TurnLaserOff();
        }

        public void ProbeSetting(ref CRes[] ProbeData)
        {
        }


        public void MeasureBias(ref double[] Data)
        {
            try
            {
                for (int aryIdx = 0; aryIdx < m_ResistorList.Count; aryIdx++)
                {
                    if (aryIdx < Data.Length)
                    { m_ResistorList.ElementAt(aryIdx).MeasureBias = Data[aryIdx]; }
                }
            }
            catch { }
        }

        public void MeasureSetting(ref double[] Data)
        {
            m_TotalResistor = (int)Data[0];
            //探針腳位定義要更新
            for (int aryIdx = 0; aryIdx < m_ResistorList.Count; aryIdx++)
            {
                m_ResistorList.ElementAt(aryIdx).NominalDesign = Data[1];// numTargetR.Value;
                m_ResistorList.ElementAt(aryIdx).PT_Cnt = (int)Data[2];// numPTSamples.Value;
                m_ResistorList.ElementAt(aryIdx).PT_Dly = (int)Data[3]; //numPTDelay.Value;
                m_ResistorList.ElementAt(aryIdx).PT_High = Data[4];// (float)numPTHigh.Value;
                m_ResistorList.ElementAt(aryIdx).PT_Low = Data[5];// (float)numPTLow.Value;
                m_ResistorList.ElementAt(aryIdx).FT_Cnt = (int)Data[6];// numFTSamples.Value;
                m_ResistorList.ElementAt(aryIdx).FT_Dly = (int)Data[7];// numFTDelay.Value;
                m_ResistorList.ElementAt(aryIdx).FT_High = Data[8];// (float)numFTHigh.Value;
                m_ResistorList.ElementAt(aryIdx).FT_Low = Data[9];// (float)numFTLow.Value;
                m_ResistorList.ElementAt(aryIdx).NominalOffset1 = Data[10];
                m_ResistorList.ElementAt(aryIdx).NominalOffset2 = Data[11];
                m_ResistorList.ElementAt(aryIdx).NominalOffset3 = Data[12];
                m_ResistorList.ElementAt(aryIdx).NominalOffset4 = Data[13];
                m_ResistorList.ElementAt(aryIdx).NominalOffset5 = Data[14];
                m_ResistorList.ElementAt(aryIdx).NominalOffset6 = Data[15];
                m_ResistorList.ElementAt(aryIdx).NominalOffset7 = Data[16];
                //m_ResistorList.ElementAt(aryIdx).NominalReal1 = m_ResistorList.ElementAt(aryIdx).NominalDesign * (1 + (m_ResistorList.ElementAt(aryIdx).NominalOffset1 - 0.5) / 100);
                //m_ResistorList.ElementAt(aryIdx).NominalReal2 = m_ResistorList.ElementAt(aryIdx).NominalDesign * (1 + (m_ResistorList.ElementAt(aryIdx).NominalOffset2 - 0.5) / 100);
                //m_ResistorList.ElementAt(aryIdx).NominalReal3 = m_ResistorList.ElementAt(aryIdx).NominalDesign * (1 + (m_ResistorList.ElementAt(aryIdx).NominalOffset3 - 0.5) / 100);
                //m_ResistorList.ElementAt(aryIdx).NominalReal4 = m_ResistorList.ElementAt(aryIdx).NominalDesign * (1 + (m_ResistorList.ElementAt(aryIdx).NominalOffset4 - 0.5) / 100);
                //m_ResistorList.ElementAt(aryIdx).NominalReal5 = m_ResistorList.ElementAt(aryIdx).NominalDesign * (1 + (m_ResistorList.ElementAt(aryIdx).NominalOffset5 - 0.5) / 100);
                //m_ResistorList.ElementAt(aryIdx).NominalReal6 = m_ResistorList.ElementAt(aryIdx).NominalDesign * (1 + (m_ResistorList.ElementAt(aryIdx).NominalOffset6 - 0.5) / 100);
                //m_ResistorList.ElementAt(aryIdx).NominalReal7 = m_ResistorList.ElementAt(aryIdx).NominalDesign * (1 + (m_ResistorList.ElementAt(aryIdx).NominalOffset7 - 0.5) / 100);
                m_ResistorList.ElementAt(aryIdx).MeasureBias = Data[17];
                m_ResistorList.ElementAt(aryIdx).MeasureHotBias = Data[18];
            }
            float nominalRes = (float)m_ResistorList.ElementAt(0).NominalDesign;

            m_ResStopValue[0] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset1 - 0.5) / 100);  // 0% < X <=-1%
            m_ResStopValue[1] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset1 - 0.5) / 100);  // -1% < X <=-2%
            m_ResStopValue[2] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset1 - 0.5) / 100);  // -2% < X <=-3%
            m_ResStopValue[3] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset1 - 0.5) / 100); // -3% < X <=-4%
            m_ResStopValue[4] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset1 - 0.5) / 100); // -4% < X <=-5%

            m_ResStopValue[5] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset2 - 0.5) / 100);  // -5% < X <=-6%
            m_ResStopValue[6] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset2 - 0.5) / 100);  // -6% < X <=-7%
            m_ResStopValue[7] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset2 - 0.5) / 100);  // -7% < X <=-8%
            m_ResStopValue[8] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset2 - 0.5) / 100);  // -8% < X <=-9%
            m_ResStopValue[9] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset2 - 0.5) / 100); // -9% < X <=-10%

            m_ResStopValue[10] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset3 - 0.5) / 100);  // -10% < X <=-11%
            m_ResStopValue[11] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset3 - 0.5) / 100);  // -11% < X <=-12%
            m_ResStopValue[12] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset3 - 0.5) / 100); // -12% < X <=-13%
            m_ResStopValue[13] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset3 - 0.5) / 100);  // -13% < X <=-14%
            m_ResStopValue[14] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset3 - 0.5) / 100);  // -14% < X <=-15%

            m_ResStopValue[15] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset4 - 0.5) / 100); // -15% < X <=-16%
            m_ResStopValue[16] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset4 - 0.5) / 100);  // -16% < X <=-17%
            m_ResStopValue[17] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset4 - 0.5) / 100);  // -17% < X <=-18%
            m_ResStopValue[18] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset4 - 0.5) / 100); // -18% < X <=-19%
            m_ResStopValue[19] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset4 - 0.5) / 100);  // -19% < X <=-20%

            m_ResStopValue[20] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset5 - 0.5) / 100); // -20% < X <=-21%
            m_ResStopValue[21] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset5 - 0.5) / 100); // -21% < X <=-22%
            m_ResStopValue[22] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset5 - 0.5) / 100); // -22% < X <=-23%
            m_ResStopValue[23] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset5 - 0.5) / 100);  // -23% < X <=-24%
            m_ResStopValue[24] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset5 - 0.5) / 100);  // -24% < X <=-25%

            m_ResStopValue[25] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset6 - 0.5) / 100); // -25% < X <=-26%
            m_ResStopValue[26] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset6 - 0.5) / 100); // -26% < X <=-27%
            m_ResStopValue[27] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset6 - 0.5) / 100); // -27% < X <=-28%
            m_ResStopValue[28] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset6 - 0.5) / 100); // -28% < X <=-29%
            m_ResStopValue[29] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset6 - 0.5) / 100); // -29% < X <=-30%

            m_ResStopValue[30] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset7 - 0.5) / 100);  // -30% < X <=-31%
            m_ResStopValue[31] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset7 - 0.5) / 100);  // -31% < X <=-32%
            m_ResStopValue[32] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset7 - 0.5) / 100);  // -32% < X <=-33%
            m_ResStopValue[33] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset7 - 0.5) / 100);  // -33% < X <=-34%
            m_ResStopValue[34] = m_ResistorList.ElementAt(0).NominalDesign * (1 + (m_ResistorList.ElementAt(0).NominalOffset7 - 0.5) / 100);// -34% < X <=-35%


            m_Meter.SetRes2(nominalRes);
            CRes res;
            for (int aryIdx = 0; aryIdx < m_ResistorList.Count; aryIdx++)
            {
                res = m_ResistorList.ElementAt(aryIdx);
                if (aryIdx < m_TotalResistor)
                {
                    res.RelayIdx = (m_TotalResistor - 1) - aryIdx;
                    res.HF = 2 * ((m_TotalResistor - 1) - aryIdx);
                    res.HS = 2 * ((m_TotalResistor - 1) - aryIdx);
                    res.LF = 2 * ((m_TotalResistor - 1) - aryIdx) + 1;
                    res.LS = 2 * ((m_TotalResistor - 1) - aryIdx) + 1;
                }
                else
                {
                    res.RelayIdx = aryIdx;
                    res.HF = 2 * aryIdx;
                    res.HS = 2 * aryIdx;
                    res.LF = 2 * aryIdx + 1;
                    res.LS = 2 * aryIdx + 1;
                }

                //res.RelayIdx = aryIdx;
                //res.HF = 2 * aryIdx;
                //res.HS = 2 * aryIdx;
                //res.LF = 2 * aryIdx + 1;
                //res.LS = 2 * aryIdx + 1;

            }
        }

        public void MeasureTestRSetting(ref double[] Data)
        {
            m_TotalResistor = (int)Data[0];
            //探針腳位定義要更新
            for (int aryIdx = 0; aryIdx < m_ResistorList.Count; aryIdx++)
            {
                m_ResistorList.ElementAt(aryIdx).NominalDesign = Data[1];// numTargetR.Value;
                m_ResistorList.ElementAt(aryIdx).PT_Cnt = (int)Data[2];// numPTSamples.Value;
                m_ResistorList.ElementAt(aryIdx).PT_Dly = (int)Data[3]; //numPTDelay.Value;
                m_ResistorList.ElementAt(aryIdx).PT_High = Data[4];// (float)numPTHigh.Value;
                m_ResistorList.ElementAt(aryIdx).PT_Low = Data[5];// (float)numPTLow.Value;
                m_ResistorList.ElementAt(aryIdx).FT_Cnt = (int)Data[6];// numFTSamples.Value;
                m_ResistorList.ElementAt(aryIdx).FT_Dly = (int)Data[7];// numFTDelay.Value;
                m_ResistorList.ElementAt(aryIdx).FT_High = Data[8];// (float)numFTHigh.Value;
                m_ResistorList.ElementAt(aryIdx).FT_Low = Data[9];// (float)numFTLow.Value;
                m_ResistorList.ElementAt(aryIdx).MeasureBias = Data[10]; ;
            }
            float nominalRes = (float)m_ResistorList.ElementAt(0).NominalDesign;



            m_Meter.SetRes2(nominalRes);
            // CRes res;
            //  for (int aryIdx = 0; aryIdx < m_ResistorList.Count; aryIdx++)
            //   {
            //     res = m_ResistorList.ElementAt(aryIdx);
            //if (aryIdx < m_TotalResistor)
            //{
            //    res.RelayIdx = (m_TotalResistor - 1) - aryIdx;
            //    res.HF = 2 * ((m_TotalResistor - 1) - aryIdx);
            //    res.HS = 2 * ((m_TotalResistor - 1) - aryIdx);
            //    res.LF = 2 * ((m_TotalResistor - 1) - aryIdx) + 1;
            //    res.LS = 2 * ((m_TotalResistor - 1) - aryIdx) + 1;
            //}
            //else
            //{
            //    res.RelayIdx = aryIdx;
            //    res.HF = 2 * aryIdx;
            //    res.HS = 2 * aryIdx;
            //    res.LF = 2 * aryIdx + 1;
            //    res.LS = 2 * aryIdx + 1;
            //}

            //   res.RelayIdx = aryIdx;
            //   res.HF = 2 * aryIdx;
            //   res.HS = 2 * aryIdx;
            //   res.LF = 2 * aryIdx + 1;
            //   res.LS = 2 * aryIdx + 1;

            //   }
        }
        /// <summary>
        ///  電阻索引值,從1開始
        /// </summary>
        private int m_ResIdMark1;
        public int ResIdMark1
        {
            get { return m_ResIdMark1; }
        }
        private double m_ResCurPosXMark1;
        private double m_ResCurPosYMark1;
        /// <summary>
        /// 電阻索引值,從1開始
        /// </summary>
        private int m_ResIdMark2;
        public int ResIdMark2
        {
            get { return m_ResIdMark2; }
        }
        private double m_ResCurPosXMark2;
        private double m_ResCurPosYMark2;
        public void Mark1()
        {
            m_ResIdMark1 = m_CurrentResId;
            m_ResCurPosXMark1 = m_CurPosX;// m_ResistorList.ElementAt(m_CurrentResId - 1).GalvoXPos;
            m_ResCurPosYMark1 = m_CurPosY;// m_ResistorList.ElementAt(m_CurrentResId - 1).GalvoYPos;
        }
        public void Mark2()
        {
            m_ResIdMark2 = m_CurrentResId;
            m_ResCurPosXMark2 = m_CurPosX;// m_ResistorList.ElementAt(m_CurrentResId - 1).GalvoXPos;
            m_ResCurPosYMark2 = m_CurPosY;// m_ResistorList.ElementAt(m_CurrentResId - 1).GalvoYPos;
        }


        /// <summary>
        ///  電阻排數索引值,從1開始
        /// </summary>
        private int m_ResColIdMark1;
        public int ResColIdMark1
        {
            get { return m_ResColIdMark1; }
        }
        private double m_ResCurColPosXMark1;
        private double m_ResCurColPosYMark1;
        /// <summary>
        /// 電阻排數索引值,從1開始
        /// </summary>
        private int m_ResColIdMark2;
        public int ResColIdMark2
        {
            get { return m_ResColIdMark2; }
        }
        private double m_ResCurColPosXMark2;
        private double m_ResCurColPosYMark2;
        public void MarkCol1()
        {
            m_ResColIdMark1 = m_CurrentColId;
            m_ResCurColPosXMark1 = m_CurPosX;// m_ResistorList.ElementAt(m_CurrentResId - 1).GalvoXPos;
            m_ResCurColPosYMark1 = m_CurPosY;// m_ResistorList.ElementAt(m_CurrentResId - 1).GalvoYPos;
        }
        public void MarkCol2()
        {
            m_ResColIdMark2 = m_CurrentColId;
            m_ResCurColPosXMark2 = m_CurPosX;// m_ResistorList.ElementAt(m_CurrentResId - 1).GalvoXPos;
            m_ResCurColPosYMark2 = m_CurPosY;// m_ResistorList.ElementAt(m_CurrentResId - 1).GalvoYPos;
        }
        /// <summary>
        /// 計算電阻排數振鏡位置
        /// </summary>
        /// <param name="XPos"></param>
        /// <param name="YPos"></param>
        public void CalculateResColGalvoPos()
        {
            if (m_ResColIdMark1 > m_ResColIdMark2)
            {
                int resColIdMark = m_ResColIdMark1;
                double resCurColPosXMark = m_ResCurColPosXMark1;
                double resCurColPosYMark = m_ResCurColPosYMark1;
                m_ResColIdMark1 = m_ResColIdMark2;
                m_ResCurColPosXMark1 = m_ResCurColPosXMark2;
                m_ResCurColPosYMark1 = m_ResCurColPosYMark2;
                m_ResColIdMark2 = resColIdMark;
                m_ResCurColPosXMark2 = m_ResCurColPosXMark1;
                m_ResCurColPosYMark2 = m_ResCurColPosYMark1;
            }
            double pitchX = 0;
            double pitchY = 0;
            if (m_ResColIdMark1 != m_ResColIdMark2)
            {
                pitchX = (double)(m_ResCurColPosXMark2 - m_ResCurColPosXMark1) / (double)(m_ResColIdMark2 - m_ResColIdMark1);
                pitchY = (double)(m_ResCurColPosYMark2 - m_ResCurColPosYMark1) / (double)(m_ResColIdMark2 - m_ResColIdMark1);
                for (int i = m_ResColIdMark1; i <= m_ResColIdMark2; i++)
                {
                    double posX = (i - m_ResColIdMark1) * pitchX;
                    double posY = (i - m_ResColIdMark1) * pitchY;

                    CPanel res = m_PanelList.ElementAt(i - 1);
                    res.GalvoColOffsetX = posX;
                    res.GalvoColOffsetY = posY;
                }
            }
        }
        /// <summary>
        /// 更新電阻振鏡位置
        /// </summary>
        /// <param name="XPos"></param>
        /// <param name="YPos"></param>
        public void UpdateResGalvoColOffset(ref double[] XOffset, ref double[] YOffset)
        {
            for (int i = 0; i < XOffset.Length; i++)
            {
                double offsetX = XOffset[i];
                double offsetY = YOffset[i];
                CPanel res = m_PanelList.ElementAt(i);
                res.GalvoColOffsetX = offsetX;
                res.GalvoColOffsetY = offsetY;
            }
        }


        /// <summary>
        /// 更新電阻振鏡位置
        /// </summary>
        /// <param name="XPos"></param>
        /// <param name="YPos"></param>
        public void UpdateResGalvoPos(ref double[] XPos, ref double[] YPos)
        {
            double posX;
            double posY;
            CRes res;
            for (int i = 0; i < XPos.Length; i++)
            {
                posX = XPos[i];
                posY = YPos[i];
                res = m_ResistorList.ElementAt(i);
                res.GalvoXPos = posX;
                res.GalvoYPos = posY;
            }
        }
        /// <summary>
        /// 計算電阻振鏡位置
        /// </summary>
        /// <param name="XPos"></param>
        /// <param name="YPos"></param>
        public void CalculateResGalvoPos()
        {
            if (m_ResIdMark1 > m_ResIdMark2)
            {
                int resIdMark = m_ResIdMark1;
                double resCurPosXMark = m_ResCurPosXMark1;
                double resCurPosYMark = m_ResCurPosYMark1;
                m_ResIdMark1 = m_ResIdMark2;
                m_ResCurPosXMark1 = m_ResCurPosXMark2;
                m_ResCurPosYMark1 = m_ResCurPosYMark2;
                m_ResIdMark2 = resIdMark;
                m_ResCurPosXMark2 = m_ResCurPosXMark1;
                m_ResCurPosYMark2 = m_ResCurPosYMark1;
            }
            double pitchX = 0;
            double pitchY = 0;
            if (m_ResIdMark1 != m_ResIdMark2)
            {
                pitchX = (double)(m_ResCurPosXMark2 - m_ResCurPosXMark1) / (double)(m_ResIdMark2 - m_ResIdMark1);
                pitchY = (double)(m_ResCurPosYMark2 - m_ResCurPosYMark1) / (double)(m_ResIdMark2 - m_ResIdMark1);
                for (int i = m_ResIdMark1; i <= m_ResIdMark2; i++)
                {
                    double posX = m_ResCurPosXMark1 + (i - m_ResIdMark1) * pitchX;
                    double posY = m_ResCurPosYMark1 + (i - m_ResIdMark1) * pitchY;

                    CRes res = m_ResistorList.ElementAt(i - 1);
                    res.GalvoXPos = posX;
                    res.GalvoYPos = posY;
                }
            }
        }

        public void Open()
        {
            // m_Laser.Open();
        }

        public void Close()
        {
            //    m_Laser.Close();
        }


        /// <summary>
        /// mm/s, um/ms,default 400mm/s
        /// </summary>
        private double m_JumpSpeed = 400;
        public double JumpSpeed
        {
            get
            {
                return m_JumpSpeed;
            }
            set
            {
                m_JumpSpeed = value;
            }
        }
        private double m_speedYNoWork = 400;
        public double SpeedYNoWork
        {
            get
            {
                return m_speedYNoWork;
            }
            set
            {
                m_speedYNoWork = value;
            }
        }
        /// <summary>
        /// us
        /// </summary>
        private double m_JumpDelay;
        public double JumpDelay
        {
            get
            {
                return m_JumpDelay;
            }
            set
            {
                m_JumpDelay = value;
            }
        }

        private double m_resNoWorkOffset=0;
        public double ResNoWorkOffset
        {
            get
            {
                return m_resNoWorkOffset;
            }
            set
            {
                m_resNoWorkOffset = value;
            }
        }

        #region TrimOneMyBackgroundTask
        ///// <summary>
        ///// 座標是一象限
        ///// 直接等待Galvo整定效果不好
        ///// </summary>
        //private void TrimOneMyBackgroundTask()
        //{
        //    int runIdx=0;
        //    double nextPosX = 0;
        //    double nextPosY = 0;
        //    int timeInc = 10; // us
        //    double speedX=10;// mm/us
        //    double speedY=10;// mm/us
        //    int aryIdx =0;
        //    int arySizeX = 0;
        //    int arySizeY = 0;
        //    double[] PosAryX;
        //    double[] PosAryY;
        //    double TimeStart = 0;
        //    double sec2us = 100000.0;
        //    double timeSpan =0;
        //    double resValueStop = 0;
        //    double resIRV = 0; //初R值

        //    while(! m_ThreadFinished)
        //    {
        //    }

        //    //開起非同步量測
        //   m_StopMeasure = false;
        //   m_RdyToTrim = false;
        //   m_ThreadStarted = false;
        //   Thread t1 = new Thread(MeasureOne);
        //   // Of course this only affects the main thread rather than child threads.
        //   t1.Priority = ThreadPriority.Highest;
        //   t1.Start();
        //   m_Laser.LaserEmissionOn = true;
        //   Thread.Sleep(1000);
        //    // 跳躍移動 計算路徑
        //    nextPosX = m_ResistorList.ElementAt(m_CurrentResId-1).GalvoXPos;
        //    nextPosY = m_ResistorList.ElementAt(m_CurrentResId-1).GalvoYPos;
        //    if (Math.Abs(m_CurPosX - nextPosX) > Math.Abs(m_CurPosY - nextPosY))
        //    {
        //        //橫線為主
        //        speedX = m_JumpSpeed / sec2us;
        //        speedY = (speedX * Math.Abs(m_CurPosY - nextPosY)) / Math.Abs(m_CurPosX - nextPosX);
        //        arySizeX = (int)(Math.Abs(m_CurPosX - nextPosY) / speedX);
        //        //int remainder = (int)((m_CurPosX - m_ResistorList.ElementAt(m_CurrentResId-1).GalvoXPos) % speedX);
        //        //if (remainder != 0) { arySizeX += 1; }
        //        arySizeY = arySizeX;
        //    }
        //    else
        //    {
        //        //直線為主
        //        speedY = m_JumpSpeed /  sec2us;
        //        speedX = (speedY * Math.Abs(m_CurPosX - nextPosX)) / Math.Abs(m_CurPosY - nextPosY);
        //        arySizeY = (int)(Math.Abs(m_CurPosY - nextPosY) / speedY);
        //        //int remainder = (int)((m_CurPosY - m_ResistorList.ElementAt(m_CurrentResId-1).GalvoYPos) % speedY);
        //        //if (remainder != 0) { arySizeY += 1; }
        //        arySizeX = arySizeY;
        //    }

        //    if (m_CurPosX > nextPosX) { speedX = speedX * -1; }
        //    if (m_CurPosY > nextPosY) { speedY = speedY * -1; }
        //    PosAryX = new double[arySizeY];
        //    PosAryY = new double[arySizeY];
        //    if (arySizeX != 0)
        //     {    
        //        for (aryIdx = 0; aryIdx < arySizeY; aryIdx++)
        //        {
        //            PosAryX[aryIdx] = (aryIdx * speedX) + m_CurPosX;
        //            PosAryY[aryIdx] = (aryIdx * speedY) + m_CurPosY;
        //        }
        //        PosAryX[arySizeX-1] = nextPosX;
        //        PosAryY[arySizeY-1] = nextPosY;
        //        // 執行路徑
        //        aryIdx = 0;
        //        TimeStart = m_Timer.GetMicroSecondTime();
        //        runIdx = 1010;
        //        if (arySizeY != 0)
        //        {
        //            while (runIdx < 2000)
        //            {
        //                switch (runIdx)
        //                {
        //                    case 1010:
        //                        //if ( PosAryX is null) {PosAryX = new double[arySizeY];}
        //                        m_CurPosX = PosAryX[aryIdx];
        //                        double x_Pos = m_CurPosX * m_ScaleFactorX;
        //                        m_CurPosY = PosAryY[aryIdx];
        //                        double y_Pos = m_CurPosY * m_ScaleFactorY;

        //                        m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
        //                        //TimeStart = m_Timer.GetMicroSecondTime();
        //                        aryIdx += 1;
        //                        runIdx = 1020;
        //                        break;
        //                    case 1020:
        //                        timeSpan=m_Timer.GetMicroSecondTime() - TimeStart;
        //                        if (timeSpan >= (aryIdx*timeInc))
        //                        //if (timeSpan >= timeInc)
        //                        {
        //                             aryIdx = (int)(timeSpan / timeInc);
        //                            if (aryIdx < arySizeX)
        //                            {
        //                                runIdx = 1010;
        //                            }
        //                            else
        //                            {
        //                                TimeStart = m_Timer.GetMicroSecondTime();
        //                                runIdx = 1030;
        //                            }
        //                        }
        //                        break;
        //                    case 1030:
        //                        if ((m_Timer.GetMicroSecondTime() - TimeStart) >= m_JumpDelay)
        //                        {
        //                            runIdx = 2000;
        //                        }
        //                        break;
        //                }
        //            }
        //        }
        //    }





        //    short ret;
        //    ushort cardNum = 0;
        //    ushort portNum = 0;
        //    uint outValue = 0;
        //    int BitId = 28; //雷射開啟控制點
        //    ret = PCIS_DASK.DO_ReadPort(cardNum, portNum, out outValue);
        //    uint portValue = (uint)(1 << BitId);

        //    int resID;
        //    resID = m_CurrentResId - 1;
        //    while (!m_ThreadStarted)
        //    {
        //    }
        //    while (!m_RdyToTrim)
        //    {
        //    }
        //    resIRV = m_TrimmedDataList.ElementAt(resID).PostVal;

        //    // 切割移動 計算路徑 
        //    int currentCutId = 0;
        //    for (currentCutId = 0; currentCutId < m_CutInfoList.Count; currentCutId++)
        //    {
        //        CCutParam cutInfo = m_CutInfoList.ElementAt(currentCutId);
        //        m_ResistorList.ElementAt(resID).NominalReal = 9.52;
        //        resValueStop = ((m_ResistorList.ElementAt(resID).NominalReal - resIRV) * cutInfo.StopPercent / 100) + resIRV;
        //        if (cutInfo.Direction == 270)
        //        {
        //            //直線
        //            nextPosY = (m_ResistorList.ElementAt(m_CurrentResId-1).GalvoYPos - cutInfo.Length);
        //            speedY = m_CutInfoList.ElementAt(currentCutId).Speed / sec2us;
        //            arySizeY = (int)(Math.Abs(cutInfo.Length) / speedY);
        //            //int remainder = (int)((m_CurPosY - nextPosY) % speedY);
        //            //if (remainder != 0) { arySizeY += 1; }
        //            arySizeX = arySizeY;
        //            if (m_CurPosY > nextPosY) { speedY = speedY * -1; }
        //            PosAryX = new double[arySizeX];
        //            PosAryY = new double[arySizeY];
        //            if (arySizeX != 0)
        //            {
        //                for (aryIdx = 0; aryIdx < arySizeY; aryIdx++)
        //                {
        //                    PosAryX[aryIdx] = m_CurPosX;
        //                    PosAryY[aryIdx] = (aryIdx * speedY) + m_CurPosY;
        //                }
        //            }
        //        }
        //        else if (m_CutInfoList.ElementAt(currentCutId).Direction == 0)
        //        {
        //            //橫線
        //            nextPosX = (m_ResistorList.ElementAt(m_CurrentResId-1).GalvoXPos + cutInfo.Length);
        //            speedX = m_CutInfoList.ElementAt(currentCutId).Speed / (double)sec2us; //600um 100mm/s
        //            arySizeX = (int)(Math.Abs(cutInfo.Length) / speedX);
        //            //int remainder = (int)((m_CurPosX - nextPosX) % speedX);
        //            //if (remainder != 0) { arySizeX += 1; }
        //            if (m_CurPosX > nextPosX) { speedX = speedX * -1; }
        //            arySizeY = arySizeX;
        //            PosAryX = new double[arySizeX];
        //            PosAryY = new double[arySizeY];
        //            if (arySizeX != 0)
        //            {
        //                for (aryIdx = 0; aryIdx < arySizeX; aryIdx++)
        //                {
        //                    PosAryX[aryIdx] = (aryIdx * speedX) + m_CurPosX;
        //                    PosAryY[aryIdx] = m_CurPosY;
        //                }
        //            }
        //        }



        //        //打開雷射
        //        ret = PCIS_DASK.DO_ReadPort(cardNum, portNum, out outValue);
        //        portValue = (uint)(1 << BitId);
        //        portValue = (outValue & (~portValue)) + portValue;
        //        ret = PCIS_DASK.DO_WritePort(cardNum, portNum, (uint)portValue);

        //        //執行路徑
        //        aryIdx = 0;
        //        TimeStart = m_Timer.GetMicroSecondTime();
        //        runIdx = 1010;
        //        if (arySizeX != 0)
        //        {
        //            while (runIdx < 2000)
        //            {
        //                switch (runIdx)
        //                {
        //                    case 1010:
        //                        //if ( PosAryX is null) {PosAryX = new double[arySizeY];}
        //                        m_CurPosX = PosAryX[aryIdx];
        //                        double x_Pos = m_CurPosX * m_ScaleFactorX;
        //                        m_CurPosY = PosAryY[aryIdx];
        //                        double y_Pos = m_CurPosY * m_ScaleFactorY;
        //                        m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
        //                        //TimeStart = m_Timer.GetMicroSecondTime();
        //                        aryIdx += 1;
        //                        runIdx = 1020;
        //                        break;
        //                    case 1020:
        //                        timeSpan=m_Timer.GetMicroSecondTime() - TimeStart;
        //                        if (timeSpan >= (aryIdx*timeInc))
        //                        //if (timeSpan >=  timeInc)
        //                        {
        //                            aryIdx = (int)(timeSpan / timeInc);
        //                            if (aryIdx < arySizeX)
        //                            {
        //                                runIdx = 1010;
        //                            }
        //                            else
        //                            {
        //                                TimeStart = m_Timer.GetMicroSecondTime();
        //                                runIdx = 1030;
        //                            }
        //                        }
        //                        if (m_TrimmedDataList.ElementAt(resID).PostVal >= resValueStop)
        //                        {
        //                            TimeStart = m_Timer.GetMicroSecondTime();
        //                            runIdx = 1030;
        //                        }
        //                        break;
        //                    case 1030:
        //                        if ((m_Timer.GetMicroSecondTime() - TimeStart) >= cutInfo.Delay)
        //                        {
        //                            runIdx = 2000;
        //                        }
        //                        break;
        //                }
        //            }
        //        }

        //        if (m_CutInfoList.ElementAt(currentCutId).Repo == "Y")
        //        {
        //            //關閉雷射
        //            ret = PCIS_DASK.DO_ReadPort(cardNum, portNum, out outValue);
        //            portValue = (uint)(1 << BitId);
        //            portValue = (outValue & (~portValue));
        //            ret = PCIS_DASK.DO_WritePort(cardNum, portNum, (uint)portValue);
        //        }
        //    }
        //    //關閉雷射
        //    ret = PCIS_DASK.DO_ReadPort(cardNum, portNum, out outValue);
        //    portValue = (uint)(1 << BitId);
        //    portValue = (outValue & (~portValue));
        //    ret = PCIS_DASK.DO_WritePort(cardNum, portNum, (uint)portValue);

        //    m_Laser.LaserEmissionOn = false;
        //    //關閉量測
        //    m_StopMeasure = true;
        //    while (!m_ThreadFinished)
        //    { 
        //    }
        //}
        #endregion

        /// <summary>
        /// 要修阻的數量
        /// </summary>
        private int m_DestTrimId = 0;
        private bool m_IsLogUsed = false;
        /// <summary>
        /// Galvo 一象限
        /// </summary>
        private void TrimMyBackgroundTask()
        {
            Automation.BDaq.ErrorCode errCode;
            int runIdx = 0;
            int runIdx2 = 0;
            double nextPosX = 0;
            double nextPosY = 0;
            double speedYNoWork = 100;// mm/us
            double speedXFast = 10;// mm/us
            double speedX = 10;// mm/us
            double speedXSlow = 10; //mm/s
            double speedYFast = 10;// mm/us
            double speedY = 10;// mm/us
            double speedYSlow = 10; //mm/s
            double speed = 0;
            double decA = 0;
            int aryIdx = 0;
            int arySizeX = 0;
            int arySizeY = 0;
            double[] PosAryX;
            double[] PosAryY;
            double posX;
            double posY;
            double tmpX = 0;
            double tmpY = 0;
            double TimeStart = 0;

            double timeSpan = 0;
            double resValueStopNoWork = 0;
            double resNoWorkPosY = 0;
            double resValueStopFast = 0;
            double resValueStop = 0;
            double resValueStopSlow = 0;
            double resIRV = 0; //初R值
            int timeInc = 10; // 10us 更新資料一次
            double sec2us = 1000 * 1000.0; // 10us
            sec2us = sec2us / timeInc;

            double x_Pos = 0;
            double y_Pos = 0;
            byte turnOn = 0x1;
            byte turnOff = 0x0;
            int resID;
            int oldCurrentResId = 0;
            CCutParam cutInfo;
            try
            {
                m_ThreadTrimFinished = false;
                m_ThreadTrimStarted = true;
                PosAryX = new double[5000000];
                PosAryY = new double[5000000];
                while (!m_StopTrim)
                {
                    switch (m_RunIdxTrimOne)
                    {
                        case 0:
                            // 等待新命令
                            break;
                        case 1000:
                            m_resBufferID = -1;

                            #region "Edited for Client settings"

                            //切整排
                            //                            switch (m_TotalResistor)
                            //                            {
                            //                                case 113: //04 113-70
                            //                                    m_resNoWorkOffset = 0.12;
                            //                                    m_JumpSpeed = 800;//300;// 100;
                            //                                    m_JumpDelay = 10;//380;// 500;
                            //                                    if ((m_ResistorList.ElementAt(0).FT_High - m_ResistorList.ElementAt(0).FT_Low) <= 2) // 1%
                            //                                    {
                            //                                        if (m_ResistorList.ElementAt(0).NominalDesign <= 10)
                            //                                        { m_speedYNoWork = 30; }
                            //                                        else if (m_ResistorList.ElementAt(0).NominalDesign <= 30)//200K
                            //                                        { m_speedYNoWork = 60; }
                            //                                        else if (m_ResistorList.ElementAt(0).NominalDesign <= 40000)//200K
                            //                                        { m_speedYNoWork = 150; }
                            //                                        else if (m_ResistorList.ElementAt(0).NominalDesign <= 200000)//200K
                            //                                        { m_speedYNoWork = 100; }
                            //                                        else
                            //                                        { m_speedYNoWork = 60; }// 45 / sec2us;}
                            //                                    }
                            //                                    else // 5%
                            //                                    {
                            //                                        if (m_ResistorList.ElementAt(0).NominalDesign < 30)
                            //                                        { m_speedYNoWork = 60; }
                            //                                        else if (m_ResistorList.ElementAt(0).NominalDesign < 200000)//200K
                            //                                        { m_speedYNoWork = 250; }// 45 / sec2us;}
                            //                                        else
                            //                                        {
                            //                                            m_speedYNoWork = 60;
                            //                                        }// 45 / sec2us;}
                            //                                    }

                            //                                    break;
                            //                                case 70: //06 70-44
                            //                                    m_resNoWorkOffset = 0.150;
                            //                                    m_JumpSpeed = 300;//300;// 100;
                            //                                    m_JumpDelay = 450;//380;// 500;
                            //                                    if (m_ResistorList.ElementAt(0).NominalDesign < 20000)
                            //                                    { m_speedYNoWork = 190; }// 45 / sec2us;}
                            //                                    else
                            //                                    {
                            //                                        m_speedYNoWork = 150;
                            //                                    }// 45 / sec2us;}
                            //                                    break;

                            //                                case 98: //02 98-119
                            //                                    m_resNoWorkOffset = 0.04;
                            //                                    m_JumpSpeed = 800;//300;// 100;
                            //                                    m_JumpDelay = 3000;// 380;// 500;
                            //                                    if ((m_ResistorList.ElementAt(0).FT_High - m_ResistorList.ElementAt(0).FT_Low) <= 2) // 1%
                            //                                    {
                            //                                        if (m_ResistorList.ElementAt(0).NominalDesign < 1000)
                            //                                        { m_speedYNoWork = 10; }// 45 / sec2us;}
                            //                                                                // 1K~99K
                            //                                        else if (m_ResistorList.ElementAt(0).NominalDesign < 100000)
                            //                                        { m_speedYNoWork = 70; }// 45 / sec2us;}
                            //                                                                // 100K~999K
                            //                                        else if (m_ResistorList.ElementAt(0).NominalDesign < 1000000)
                            //                                        { m_speedYNoWork = 60; }// 45 / sec2us;}
                            //                                        else // >=1M
                            //                                        {
                            //                                            m_speedYNoWork = 25;
                            //                                        }// 45 / sec2us;}
                            //                                    }
                            //                                    else if ((m_ResistorList.ElementAt(0).FT_High - m_ResistorList.ElementAt(0).FT_Low) <= 0.7) // 1%
                            //                                    {
                            //                                        m_resNoWorkOffset = 0.06;
                            //                                        if (m_ResistorList.ElementAt(0).NominalDesign < 1000)
                            //                                        { m_speedYNoWork = 25; }// 45 / sec2us;}
                            //                                        else if (m_ResistorList.ElementAt(0).NominalDesign < 100000)
                            //                                        { m_speedYNoWork = 40; }// 45 / sec2us;}
                            //                                        else if (m_ResistorList.ElementAt(0).NominalDesign < 1000000)
                            //                                        { m_speedYNoWork = 35; }// 45 / sec2us;}
                            //                                        else
                            //                                        {
                            //                                            m_speedYNoWork = 25;
                            //                                        }// 45 / sec2us;}
                            //                                    }
                            //                                    else
                            //                                    {
                            //                                        m_speedYNoWork = 40;
                            //                                    }
                            //                                    break;
                            //                                case 100: //02 98-119
                            //                                    m_resNoWorkOffset = 0.04;
                            //                                    m_JumpSpeed = 400;//300;// 100;
                            //                                    m_JumpDelay = 380;//380;// 500;
                            //                                    if (m_ResistorList.ElementAt(0).NominalDesign < 20000)
                            //                                    { m_speedYNoWork = 40; }// 45 / sec2us;}
                            //                                    else
                            //                                    {
                            //                                        m_speedYNoWork = 30;
                            //                                    }// 45 / sec2us;}

                            //                                    break;
                            //                                case 46: //01 46-138
                            //                                    m_resNoWorkOffset = 0.03;
                            //                                    m_JumpSpeed = 8000;//300;// 100;
                            //                                    m_JumpDelay = 1500;//380;// 500;
                            //                                    if ((m_ResistorList.ElementAt(0).FT_High - m_ResistorList.ElementAt(0).FT_Low) <= 2) // 1%
                            //                                    {
                            //                                        if (m_ResistorList.ElementAt(0).NominalDesign <= 20)
                            //                                        {
                            //                                            m_speedYNoWork = 30;
                            //                                            // resNoWorkOffset = 0.04;
                            //                                        }// 45 / sec2us;}
                            //                                        else if (m_ResistorList.ElementAt(0).NominalDesign < 1000)
                            //                                        {
                            //                                            m_speedYNoWork = 10;
                            //                                            //    resNoWorkOffset = 0.02;
                            //                                        }// 45 / sec2us;}
                            //                                        else if (m_ResistorList.ElementAt(0).NominalDesign < 50000)
                            //                                        {
                            //                                            m_speedYNoWork = 45;
                            //                                            //     resNoWorkOffset =0.08;
                            //                                        }// 45 / sec2us;}
                            //                                        else if (m_ResistorList.ElementAt(0).NominalDesign < 100000)
                            //                                        { m_speedYNoWork = 40; }
                            //                                        else
                            //                                        {
                            //#if (GreenLaser)
                            //                                            m_speedYNoWork = 15;
                            //                                            //   resNoWorkOffset = 0.04;
                            //#else
                            //                                            //uv
                            //                                            m_speedYNoWork = 10;
                            //                                            resNoWorkOffset = 0.05;
                            //#endif
                            //                                        }// 45 / sec2us;}
                            //                                    }
                            //                                    else
                            //                                    {
                            //                                        if (m_ResistorList.ElementAt(0).NominalDesign < 10000)
                            //                                        { m_speedYNoWork = 70; }// 45 / sec2us;}
                            //                                        else
                            //                                        {
                            //                                            m_speedYNoWork = 50;
                            //                                        }// 45 / sec2us;}
                            //                                    }
                            //                                    break;
                            //                                case 38: //12 21-38
                            //                                    m_resNoWorkOffset = 0.40;
                            //                                    m_JumpSpeed = 500;//300;// 100;
                            //                                    m_JumpDelay = 1000;//380;// 500;
                            //                                    if (m_ResistorList.ElementAt(0).NominalDesign < 20000)
                            //                                    { m_speedYNoWork = 280; }// 45 / sec2us;}
                            //                                    else
                            //                                    {
                            //                                        m_speedYNoWork = 240;
                            //                                    }// 45 / sec2us;}
                            //                                    break;
                            //                                default:
                            //                                    m_resNoWorkOffset = 0.03;
                            //                                    m_JumpSpeed = 8000;//300;// 100;
                            //                                    m_JumpDelay = 1500;//380;// 500;
                            //                                    m_speedYNoWork = 40;
                            //                                    break;
                            //                            }


                            #endregion

                            m_IsLogUsed = true;
                            if (m_IsLogUsed == true)
                            {
                                for (aryIdx = 0; aryIdx < m_AnalysisData.Length; aryIdx++)
                                {
                                    m_AnalysisData[aryIdx].TimeStamp = 0;
                                    m_AnalysisData[aryIdx].PosX = 0;
                                    m_AnalysisData[aryIdx].PosY = 0;
                                    m_AnalysisData[aryIdx].ResVal = 0;
                                }
                                m_AnalysisIdx = 0;
                            }

                            if (m_CutInfoList.Count == 2)
                            {
                                if ((m_CutInfoList.ElementAt(0).Direction == 270) && (m_CutInfoList.ElementAt(1).Direction == 0))
                                {
                                    #region 90
                                    try
                                    {
                                        #region 1stCut
                                        #endregion
                                        oldCurrentResId = m_CurrentResId;
                                        runIdx2 = 1010;
                                        for (resID = (m_CurrentResId - 1); resID < m_DestTrimId; resID++)
                                        {
                                            // 開始非同步量測
                                            m_CurrentResId = resID + 1;
                                            m_CurrentCutId = 0;
                                            m_CutIdx = CurrentCutId + 1;
                                            // 切割移動 計算路徑 
                                            cutInfo = m_CutInfoList.ElementAt(CurrentCutId);
                                            // 跳躍移動 計算路徑
                                            nextPosX = m_ResistorList.ElementAt(resID).GalvoXPos + cutInfo.XOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetX;
                                            nextPosY = m_ResistorList.ElementAt(resID).GalvoYPos + cutInfo.YOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetY;
                                            if (Math.Abs(m_CurPosX - nextPosX) > Math.Abs(m_CurPosY - nextPosY))
                                            {
                                                //橫線為主
                                                speedXFast = m_JumpSpeed / sec2us;
                                                arySizeX = (int)(Math.Abs(m_CurPosX - nextPosX) / speedXFast);
                                                if (arySizeX != 0)
                                                {
                                                    speedYFast = (speedXFast * Math.Abs(m_CurPosY - nextPosY)) / Math.Abs(m_CurPosX - nextPosX);
                                                }
                                                arySizeY = arySizeX;
                                            }
                                            else
                                            {
                                                //直線為主
                                                speedYFast = m_JumpSpeed / sec2us;
                                                arySizeY = (int)(Math.Abs(m_CurPosY - nextPosY) / speedYFast);
                                                if (arySizeY != 0)
                                                {
                                                    speedXFast = (speedYFast * Math.Abs(m_CurPosX - nextPosX)) / Math.Abs(m_CurPosY - nextPosY);
                                                }
                                                arySizeX = arySizeY;
                                            }
                                            if (m_CurPosX > nextPosX) { speedXFast = speedXFast * -1; }
                                            if (m_CurPosY > nextPosY) { speedYFast = speedYFast * -1; }
                                            if (arySizeX != 0)
                                            {
                                                for (aryIdx = 0; aryIdx < arySizeY; aryIdx++)
                                                {
                                                    if (arySizeY > PosAryX.Length) { break; }
                                                    PosAryX[aryIdx] = (aryIdx * speedXFast) + m_CurPosX;
                                                    PosAryY[aryIdx] = (aryIdx * speedYFast) + m_CurPosY;
                                                }
                                                int NewarySizeX = arySizeX;
                                                int NewarySizeY = arySizeY;
                                                if (NewarySizeX > PosAryX.Length) { NewarySizeX = PosAryX.Length; }
                                                if (NewarySizeY > PosAryY.Length) { NewarySizeY = PosAryY.Length; }
                                                PosAryX[NewarySizeX - 1] = nextPosX;
                                                PosAryY[NewarySizeY - 1] = nextPosY;
                                                // 執行路徑
                                                aryIdx = 0;
                                                TimeStart = m_Timer.GetMicroSecondTime();
                                                runIdx = 1010;
                                                while (runIdx < 2000 || runIdx2 < 2000)
                                                {

                                                    switch (runIdx)
                                                    {
                                                        case 1010:
                                                            m_CurPosX = PosAryX[aryIdx];
                                                            x_Pos = m_CurPosX * m_ScaleFactorX;
                                                            m_CurPosY = PosAryY[aryIdx];
                                                            y_Pos = m_CurPosY * m_ScaleFactorY;
                                                            TimeStart = m_Timer.GetMicroSecondTime();
                                                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                                                            aryIdx += 1;
                                                            runIdx = 1020;
                                                            break;
                                                        case 1020:
                                                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                                                            if (timeSpan >= timeInc)
                                                            {
                                                                if (aryIdx < arySizeX)
                                                                {
                                                                    runIdx = 1010;
                                                                }
                                                                else
                                                                {
                                                                    TimeStart = m_Timer.GetMicroSecondTime();
                                                                    runIdx = 1030;
                                                                }
                                                            }
                                                            break;
                                                        case 1030:
                                                            if ((m_Timer.GetMicroSecondTime() - TimeStart) >= m_JumpDelay)
                                                            {
                                                                runIdx = 2000;
                                                            }
                                                            break;
                                                    }

                                                    switch (runIdx2)
                                                    {
                                                        case 1010:
                                                            if (m_ChangeRes == false)
                                                            {
                                                                runIdx2 = 1020;
                                                            }
                                                            break;
                                                        case 1020:
                                                            if (m_RunIdxMeasureOne == 0)
                                                            {
                                                                m_RdyToTrim = false;
                                                                m_ChangeRes = false;
                                                                m_RunIdxMeasureOne = 1000;
                                                                runIdx2 = 2000;
                                                            }
                                                            break;
                                                    }
                                                }//while (runIdx < 2000)
                                            }//(arySizeX != 0)
                                            else
                                            {
                                                runIdx2 = 2000;
                                                while (m_ChangeRes == true) { }
                                                // 非同步量測結束
                                                while (m_RunIdxMeasureOne != 0) { }//500us
                                                m_RdyToTrim = false;
                                                m_ChangeRes = false;
                                                m_RunIdxMeasureOne = 1000;
                                            }
                                            //Wait for Res Measure
                                            while (!m_RdyToTrim) { }

                                            if (m_TrimmedDataList.ElementAt(resID).PrePercent <= m_ResistorList.ElementAt(resID).PT_High)
                                            {
                                                if (m_TrimmedDataList.ElementAt(resID).PrePercent >= m_ResistorList.ElementAt(resID).PT_Low)
                                                {
                                                    // 依照初值決定中心值
                                                    errCode = m_InstantDoCtrl.Write(0, turnOn);
                                                    if (errCode != ErrorCode.Success) { throw new System.ArgumentException("WriteBit fail", "Hardware Error"); }
                                                    resIRV = m_TrimmedDataList.ElementAt(resID).PreVal;
                                                    if (cutInfo.Direction == 270)
                                                    {
                                                        if (m_ResistorList.ElementAt(resID).NominalDesign < 200000)
                                                        { resValueStopNoWork = resIRV + m_ResistorList.ElementAt(resID).NominalDesign * 0.03 / 100; }
                                                        else
                                                        { resValueStopNoWork = resIRV + m_ResistorList.ElementAt(resID).NominalDesign * 0.05 / 100; }

                                                        resValueStopFast = ((m_ResStopValue[m_ResRangeIdx] - resIRV) * cutInfo.ResStopPerc[m_ResRangeIdx] * 0.6 / 100) + resIRV;
                                                        resValueStop = ((m_ResStopValue[m_ResRangeIdx] - resIRV) * cutInfo.ResStopPerc[m_ResRangeIdx] * 0.8 / 100) + resIRV;
                                                        resValueStopSlow = ((m_ResStopValue[m_ResRangeIdx] - resIRV) * cutInfo.ResStopPerc[m_ResRangeIdx] * 1 / 100) + resIRV;
                                                        speedYFast = m_CutInfoList.ElementAt(CurrentCutId).Speed * 1 / sec2us;
                                                        speedY = m_CutInfoList.ElementAt(CurrentCutId).Speed * 1 / sec2us;
                                                        speedYSlow = m_CutInfoList.ElementAt(CurrentCutId).Speed * 1 / sec2us; //*0.75 / sec2us;
                                                        nextPosY = (m_ResistorList.ElementAt(resID).GalvoYPos + cutInfo.YOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetY - cutInfo.Length);
                                                        speedYNoWork = (m_CutInfoList.ElementAt(CurrentCutId).Speed + 20) * 1 / sec2us;
                                                        resNoWorkPosY = m_ResistorList.ElementAt(resID).GalvoYPos + cutInfo.YOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetY - m_resNoWorkOffset;
                                                        //speedYNoWork = speedY;
                                                        if (m_CurPosY > nextPosY)
                                                        {
                                                            speedYNoWork = speedYNoWork * -1;
                                                            speedYFast = speedYFast * -1;
                                                            speedY = speedY * -1;
                                                            speedYSlow = speedYSlow * -1;
                                                        }
                                                        decA = (speedYFast * speedYFast - speedYNoWork * speedYNoWork) / (2 * -1 * m_resNoWorkOffset);
                                                        //執行路徑
                                                        //double testTimeStart = 0;
                                                        aryIdx = 0;
                                                        runIdx = 1010;
                                                        TimeStart = m_Timer.GetMicroSecondTime();
                                                        tmpX = m_CurPosX;
                                                        tmpY = m_CurPosY;
                                                        speed = speedYNoWork;
                                                        while (runIdx < 2000)
                                                        {
                                                            switch (runIdx)
                                                            {
                                                                case 1010:
                                                                    posX = m_CurPosX;
                                                                    if ((m_TrimmedDataList.ElementAt(resID).PostVal <= resValueStopNoWork) && m_CurPosY >= resNoWorkPosY)
                                                                    {
                                                                        //speed = speed + decA;
                                                                        //if (Math.Abs(speed) < Math.Abs(speedYFast)) { speed = speedYFast; }
                                                                        posY = speedYNoWork + m_CurPosY;
                                                                        if (posY < nextPosY) { posY = nextPosY; }
                                                                    }
                                                                    else if (m_TrimmedDataList.ElementAt(resID).PostVal <= resValueStopFast)
                                                                    {
                                                                        posY = speedYFast + m_CurPosY;
                                                                        if (posY < nextPosY) { posY = nextPosY; }
                                                                    }
                                                                    else if (m_TrimmedDataList.ElementAt(resID).PostVal <= resValueStop)
                                                                    {
                                                                        posY = speedY + m_CurPosY;
                                                                        if (posY < nextPosY) { posY = nextPosY; }
                                                                    }
                                                                    else
                                                                    {
                                                                        posY = speedYSlow + m_CurPosY;
                                                                        if (posY < nextPosY) { posY = nextPosY; }
                                                                    }
                                                                    m_CurPosX = posX;
                                                                    x_Pos = m_CurPosX * m_ScaleFactorX;
                                                                    m_CurPosY = posY;
                                                                    y_Pos = m_CurPosY * m_ScaleFactorY;
                                                                    TimeStart = m_Timer.GetMicroSecondTime();
                                                                    m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                                                                    runIdx = 1020;
                                                                    break;

                                                                case 1020:
                                                                    //往下是負
                                                                    timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                                                                    if (timeSpan >= timeInc)
                                                                    // if (timeSpan >= timeInc)
                                                                    {
                                                                        if (m_CurPosY <= nextPosY)
                                                                        {
                                                                            //ret = D2KDASK.D2K_DO_WritePort(cardNum, (ushort)0, turnOff);
                                                                            // span1 = m_Timer.GetMicroSecondTime() - TimeStart;
                                                                            TimeStart = m_Timer.GetMicroSecondTime();
                                                                            runIdx = 1030;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (m_TrimmedDataList.ElementAt(resID).PostVal >= resValueStopSlow)
                                                                            {
                                                                                //關閉雷射
                                                                                //ret = D2KDASK.D2K_DO_WritePort(cardNum, (ushort)0, turnOff);

                                                                                runIdx = 1030;
                                                                            }
                                                                            else
                                                                            {
                                                                                runIdx = 1010;
                                                                            }
                                                                        }
                                                                    }
                                                                    break;

                                                                case 1030:
                                                                    m_CurPosX = m_CurPosX - 0.002;
                                                                    m_CurPosY = m_CurPosY + 0.002;
                                                                    x_Pos = m_CurPosX * m_ScaleFactorX;
                                                                    y_Pos = m_CurPosY * m_ScaleFactorY;
                                                                    m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                                                                    TimeStart = m_Timer.GetMicroSecondTime();
                                                                    runIdx = 1040;
                                                                    break;
                                                                case 1040:
                                                                    if ((m_Timer.GetMicroSecondTime() - TimeStart) >= cutInfo.Delay)
                                                                    {
                                                                        //打開雷射
                                                                        //ret = D2KDASK.D2K_DO_WritePort(cardNum, (ushort)0, turnOn);
                                                                        //if (m_CutInfoList.ElementAt(CurrentCutId).Repo == "Y")
                                                                        //{
                                                                        //    //關閉雷射
                                                                        //    ret = D2KDASK.D2K_DO_WritePort(cardNum, (ushort)0, turnOff);
                                                                        //}
                                                                        runIdx = 2000;
                                                                    }
                                                                    break;
                                                            }
                                                        }//while (runIdx < 2000)
                                                    }//if (cutInfo.Direction == 270)

                                                    //橫線
                                                    CurrentCutId = 1;
                                                    m_CutIdx = CurrentCutId + 1;
                                                    cutInfo = m_CutInfoList.ElementAt(CurrentCutId);
                                                    resIRV = m_TrimmedDataList.ElementAt(resID).PostVal;
                                                    if (m_CutInfoList.ElementAt(CurrentCutId).Direction == 0)
                                                    {
                                                        resValueStopFast = ((m_ResStopValue[m_ResRangeIdx] - resIRV) * cutInfo.ResStopPerc[m_ResRangeIdx] * 0.75 / 100) + resIRV;
                                                        resValueStop = ((m_ResStopValue[m_ResRangeIdx] - resIRV) * cutInfo.ResStopPerc[m_ResRangeIdx] * 0.85 / 100) + resIRV;
                                                        resValueStopSlow = m_ResStopValue[m_ResRangeIdx];

                                                        nextPosX = (m_ResistorList.ElementAt(resID).GalvoXPos + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetX + cutInfo.Length);
                                                        speedXFast = m_CutInfoList.ElementAt(CurrentCutId).Speed * 1 / sec2us;
                                                        speedX = m_CutInfoList.ElementAt(CurrentCutId).Speed * 0.85 / sec2us;
                                                        speedXSlow = m_CutInfoList.ElementAt(CurrentCutId).Speed * 0.65 / sec2us;
                                                        if (m_CurPosX > nextPosX)
                                                        {
                                                            speedXFast = speedXFast * -1;
                                                            speedX = speedX * -1;
                                                            speedXSlow = speedXSlow * -1;
                                                        }
                                                        //執行路徑
                                                        aryIdx = 0;
                                                        runIdx = 1010;
                                                        tmpX = m_CurPosX;
                                                        tmpY = m_CurPosY;
                                                        TimeStart = m_Timer.GetMicroSecondTime();
                                                        while (runIdx < 2000)
                                                        {
                                                            switch (runIdx)
                                                            {
                                                                case 1010:
                                                                    //timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;

                                                                    posY = m_CurPosY;
                                                                    if (m_TrimmedDataList.ElementAt(resID).PostVal <= resValueStopFast)
                                                                    {
                                                                        posX = speedXFast + m_CurPosX;
                                                                        if (posX > nextPosX) { posX = nextPosX; }
                                                                    }
                                                                    else if (m_TrimmedDataList.ElementAt(resID).PostVal <= resValueStop)
                                                                    {
                                                                        posX = speedX + m_CurPosX;
                                                                        if (posX > nextPosX) { posX = nextPosX; }
                                                                    }
                                                                    else
                                                                    {
                                                                        posX = speedXSlow + m_CurPosX;
                                                                        if (posX > nextPosX) { posX = nextPosX; }
                                                                    }
                                                                    m_CurPosX = posX;
                                                                    x_Pos = m_CurPosX * m_ScaleFactorX;
                                                                    m_CurPosY = posY;
                                                                    y_Pos = m_CurPosY * m_ScaleFactorY;
                                                                    TimeStart = m_Timer.GetMicroSecondTime();
                                                                    m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                                                                    runIdx = 1020;
                                                                    break;

                                                                case 1020:
                                                                    timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                                                                    if (timeSpan >= timeInc)
                                                                    // if (timeSpan >= timeInc)
                                                                    {
                                                                        if (m_CurPosX >= nextPosX)
                                                                        {
                                                                            //關閉雷射
                                                                            errCode = m_InstantDoCtrl.Write(0, turnOff);
                                                                            if (errCode != ErrorCode.Success)
                                                                            {
                                                                                throw new System.ArgumentException("WriteBit fail", "Hardware Error");
                                                                            }
                                                                            TimeStart = m_Timer.GetMicroSecondTime();
                                                                            runIdx = 1030;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (m_TrimmedDataList.ElementAt(resID).PostVal >= resValueStopSlow)
                                                                            {
                                                                                TimeStart = m_Timer.GetMicroSecondTime();
                                                                                runIdx = 1030;
                                                                            }
                                                                            else
                                                                            {
                                                                                runIdx = 1010;
                                                                            }
                                                                        }
                                                                    }
                                                                    break;

                                                                case 1030:
                                                                    if ((m_Timer.GetMicroSecondTime() - TimeStart) >= cutInfo.Delay)
                                                                    {
                                                                        //打開雷射
                                                                        //ret = D2KDASK.D2K_DO_WritePort(cardNum, (ushort)0, turnOn);
                                                                        runIdx = 2000;
                                                                    }
                                                                    break;
                                                            }
                                                        }//while (runIdx < 2000)
                                                    }//if (m_CutInfoList.ElementAt(CurrentCutId).Direction == 0)
                                                     //停止量測
                                                    m_ChangeRes = true;
                                                    //關閉雷射
                                                    errCode = m_InstantDoCtrl.Write(0, turnOff);
                                                    if (errCode != ErrorCode.Success)
                                                    {
                                                        throw new System.ArgumentException("WriteBit fail", "Hardware Error");
                                                    }
                                                    if (CurrentResID == m_TotalResistor)
                                                    {
                                                        while (m_ChangeRes == true) { }
                                                    }
                                                    else
                                                    {
                                                        // while (m_ChangeRes == true) { }
                                                        runIdx2 = 1010;
                                                    }
                                                }
                                                else//if ((m_TrimmedDataList.ElementAt(resID).PrePercent >= m_ResistorList.ElementAt(resID).PT_Low) 
                                                {
                                                    m_ChangeRes = true;
                                                    while (m_ChangeRes == true) { }
                                                    runIdx2 = 1010;
                                                    CurrentCutId = m_CutInfoList.Count - 1;
                                                    m_CutIdx = CurrentCutId + 1;
                                                    cutInfo = m_CutInfoList.ElementAt(CurrentCutId);
                                                }
                                            }
                                            else//if ((m_TrimmedDataList.ElementAt(resID).PrePercent >= m_ResistorList.ElementAt(resID).PT_Low) 
                                            {
                                                m_ChangeRes = true;
                                                while (m_ChangeRes == true) { }
                                                runIdx2 = 1010;
                                                CurrentCutId = m_CutInfoList.Count - 1;
                                                m_CutIdx = CurrentCutId + 1;
                                                cutInfo = m_CutInfoList.ElementAt(CurrentCutId);
                                            }
                                        }//(resID = (m_CurrentResId - 1); resID < m_TotalResistor; resID++)
                                    }
                                    catch (Exception e)
                                    {
                                        //關閉雷射
                                        errCode = m_InstantDoCtrl.Write(0, turnOff);
                                        if (errCode != ErrorCode.Success)
                                        {
                                            throw new System.ArgumentException("WriteBit fail", "Hardware Error");
                                        }
                                        throw new System.ArgumentException(e.ToString(), "TrimMyBackgroundTask");
                                    }
                                    #endregion
                                }
                                else if ((m_CutInfoList.ElementAt(0).Direction == 270) && (m_CutInfoList.ElementAt(1).Direction == 270))
                                {
                                    #region 270
                                    // same 270
                                    try
                                    {
                                        for (resID = (m_CurrentResId - 1); resID < m_DestTrimId; resID++)
                                        {
                                            // 非同步量測結束
                                            while (m_RunIdxMeasureOne != 0) { }
                                            //開始非同步量測
                                            m_CurrentResId = resID + 1;
                                            m_CurrentCutId = 0;
                                            m_CutIdx = CurrentCutId + 1;
                                            m_RdyToTrim = false;
                                            m_ChangeRes = false;
                                            m_RunIdxMeasureOne = 1000;

                                            // 切割移動 計算路徑 
                                            cutInfo = m_CutInfoList.ElementAt(CurrentCutId);
                                            // 跳躍移動 計算路徑
                                            nextPosX = m_ResistorList.ElementAt(resID).GalvoXPos + cutInfo.XOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetX;
                                            nextPosY = m_ResistorList.ElementAt(resID).GalvoYPos + cutInfo.YOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetY;
                                            if (Math.Abs(m_CurPosX - nextPosX) > Math.Abs(m_CurPosY - nextPosY))
                                            {
                                                //橫線為主
                                                speedXFast = m_JumpSpeed / sec2us;
                                                arySizeX = (int)(Math.Abs(m_CurPosX - nextPosX) / speedXFast);
                                                if (arySizeX != 0)
                                                {
                                                    speedYFast = (speedXFast * Math.Abs(m_CurPosY - nextPosY)) / Math.Abs(m_CurPosX - nextPosX);
                                                }
                                                arySizeY = arySizeX;
                                            }
                                            else
                                            {
                                                //直線為主
                                                speedYFast = m_JumpSpeed / sec2us;
                                                arySizeY = (int)(Math.Abs(m_CurPosY - nextPosY) / speedYFast);
                                                if (arySizeY != 0)
                                                {
                                                    speedXFast = (speedYFast * Math.Abs(m_CurPosX - nextPosX)) / Math.Abs(m_CurPosY - nextPosY);
                                                }
                                                arySizeX = arySizeY;
                                            }
                                            if (m_CurPosX > nextPosX) { speedXFast = speedXFast * -1; }
                                            if (m_CurPosY > nextPosY) { speedYFast = speedYFast * -1; }
                                            if (arySizeX != 0)
                                            {
                                                //Parallel.For(0, arySizeY, aryIdx1 =>
                                                //{
                                                //    PosAryX[aryIdx1] = (aryIdx1 * speedXFast) + m_CurPosX;
                                                //    PosAryY[aryIdx1] = (aryIdx1 * speedYFast) + m_CurPosY;
                                                //}); // Parallel.For
                                                for (aryIdx = 0; aryIdx < arySizeY; aryIdx++)
                                                {
                                                    if (arySizeY > PosAryX.Length) { break; }
                                                    PosAryX[aryIdx] = nextPosX; //(aryIdx * speedXFast) + m_CurPosX;
                                                    PosAryY[aryIdx] = (aryIdx * speedYFast) + m_CurPosY;
                                                }
                                                int NewarySizeX = arySizeX;
                                                int NewarySizeY = arySizeY;
                                                if (NewarySizeX > PosAryX.Length) { NewarySizeX = PosAryX.Length; }
                                                if (NewarySizeY > PosAryY.Length) { NewarySizeY = PosAryY.Length; }
                                                PosAryX[NewarySizeX - 1] = nextPosX;
                                                PosAryY[NewarySizeY - 1] = nextPosY;
                                                // 執行路徑
                                                aryIdx = 0;
                                                TimeStart = m_Timer.GetMicroSecondTime();
                                                runIdx = 1010;
                                                while (runIdx < 2000)
                                                {
                                                    switch (runIdx)
                                                    {
                                                        case 1010:
                                                            m_CurPosX = PosAryX[aryIdx];
                                                            x_Pos = m_CurPosX * m_ScaleFactorX;
                                                            m_CurPosY = PosAryY[aryIdx];
                                                            y_Pos = m_CurPosY * m_ScaleFactorY;
                                                            TimeStart = m_Timer.GetMicroSecondTime();
                                                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                                                            aryIdx += 1;
                                                            runIdx = 1020;
                                                            break;
                                                        case 1020:
                                                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                                                            if (timeSpan >= timeInc)
                                                            // if (timeSpan >= timeInc)
                                                            {
                                                                //aryIdx = (int)(timeSpan / timeInc);
                                                                if (aryIdx < arySizeX)
                                                                {
                                                                    runIdx = 1010;
                                                                }
                                                                else
                                                                {
                                                                    TimeStart = m_Timer.GetMicroSecondTime();
                                                                    runIdx = 1030;
                                                                }
                                                            }
                                                            break;
                                                        case 1030:
                                                            if ((m_Timer.GetMicroSecondTime() - TimeStart) >= m_JumpDelay)
                                                            {
                                                                runIdx = 2000;
                                                            }
                                                            break;
                                                    }
                                                }//while (runIdx < 2000)
                                            }//(arySizeX != 0)
                                             //Wait for Res Measure
                                            while (!m_RdyToTrim)
                                            {
                                            }
                                            if (m_TrimmedDataList.ElementAt(resID).PrePercent <= m_ResistorList.ElementAt(resID).PT_High)
                                                if (m_TrimmedDataList.ElementAt(resID).PrePercent >= m_ResistorList.ElementAt(resID).PT_Low)
                                                {
                                                    // if (m_TrimmedDataList.ElementAt(resID).PrePercent < m_ResistorList.ElementAt(resID).FT_Low)
                                                    // {
                                                    // 依照初值決定中心值
                                                    //m_Timer.DelayMicroSec(5);
                                                    errCode = m_InstantDoCtrl.Write(0, turnOn);
                                                    if (errCode != ErrorCode.Success) { throw new System.ArgumentException("WriteBit fail", "Hardware Error"); }
                                                    //m_Timer.DelayMicroSec(3);
                                                    resIRV = m_TrimmedDataList.ElementAt(resID).PreVal;
                                                    //first cut
                                                    if (m_ResistorList.ElementAt(resID).NominalDesign < 500)
                                                    { resValueStopNoWork = resIRV + m_ResistorList.ElementAt(resID).NominalDesign * 0.07 / 100; }
                                                    else if (m_ResistorList.ElementAt(resID).NominalDesign < 200000)
                                                    { resValueStopNoWork = resIRV + m_ResistorList.ElementAt(resID).NominalDesign * 0.03 / 100; }
                                                    else
                                                    { resValueStopNoWork = resIRV + m_ResistorList.ElementAt(resID).NominalDesign * 0.05 / 100; }
                                                    resValueStopNoWork = m_ResStopValue[m_ResRangeIdx];
                                                    resValueStopFast = ((m_ResStopValue[m_ResRangeIdx] - resIRV) * cutInfo.ResStopPerc[m_ResRangeIdx] * 0.6 / 100) + resIRV;
                                                    resValueStop = ((m_ResStopValue[m_ResRangeIdx] - resIRV) * cutInfo.ResStopPerc[m_ResRangeIdx] * 0.8 / 100) + resIRV;
                                                    resValueStopSlow = ((m_ResStopValue[m_ResRangeIdx] - resIRV) * cutInfo.ResStopPerc[m_ResRangeIdx] * 1 / 100) + resIRV;
                                                    speedYFast = m_CutInfoList.ElementAt(CurrentCutId).Speed * 1 / sec2us;
                                                    speedY = m_CutInfoList.ElementAt(CurrentCutId).Speed * 1 / sec2us;
                                                    speedYSlow = m_CutInfoList.ElementAt(CurrentCutId).Speed * 1 / sec2us; //*0.75 / sec2us;
                                                    nextPosY = (m_ResistorList.ElementAt(resID).GalvoYPos + cutInfo.YOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetY - cutInfo.Length);
                                                    speedYNoWork = m_speedYNoWork / sec2us;
                                                    speedYNoWork = (m_CutInfoList.ElementAt(CurrentCutId).Speed + 15) / sec2us;
                                                    resNoWorkPosY = m_ResistorList.ElementAt(resID).GalvoYPos + cutInfo.YOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetY - m_resNoWorkOffset;
                                                    //speedYNoWork = speedY;
                                                    if (m_CurPosY > nextPosY)
                                                    {
                                                        speedYNoWork = speedYNoWork * -1;
                                                        speedYFast = speedYFast * -1;
                                                        speedY = speedY * -1;
                                                        speedYSlow = speedYSlow * -1;
                                                    }
                                                    //decA = (speedYFast * speedYFast - speedYNoWork * speedYNoWork) / (2 * -1 * resNoWorkOffset);
                                                    //執行路徑
                                                    //double testTimeStart = 0;
                                                    aryIdx = 0;
                                                    runIdx = 1010;
                                                    TimeStart = m_Timer.GetMicroSecondTime();
                                                    tmpX = m_CurPosX;
                                                    tmpY = m_CurPosY;
                                                    speed = speedYNoWork;
                                                    while (runIdx < 2000)
                                                    {
                                                        switch (runIdx)
                                                        {
                                                            case 1010:
                                                                posX = m_CurPosX;
                                                                if ((m_TrimmedDataList.ElementAt(resID).PostVal <= resValueStopNoWork) && m_CurPosY >= resNoWorkPosY)
                                                                {
                                                                    //speed = speed + decA;
                                                                    // if (Math.Abs(speed) < Math.Abs(speedYFast)) { speed = speedYFast; }
                                                                    speed = speedYNoWork;
                                                                    posY = speed + m_CurPosY;
                                                                    if (posY < nextPosY) { posY = nextPosY; } //大往小走
                                                                }
                                                                else if (m_TrimmedDataList.ElementAt(resID).PostVal <= resValueStopFast)
                                                                {
                                                                    posY = speedYFast + m_CurPosY;
                                                                    if (posY < nextPosY) { posY = nextPosY; }
                                                                }
                                                                else if (m_TrimmedDataList.ElementAt(resID).PostVal <= resValueStop)
                                                                {
                                                                    posY = speedY + m_CurPosY;
                                                                    if (posY < nextPosY) { posY = nextPosY; }
                                                                }
                                                                else
                                                                {
                                                                    posY = speedYSlow + m_CurPosY;
                                                                    if (posY < nextPosY) { posY = nextPosY; }
                                                                }
                                                                m_CurPosX = posX;
                                                                x_Pos = m_CurPosX * m_ScaleFactorX;
                                                                m_CurPosY = posY;
                                                                y_Pos = m_CurPosY * m_ScaleFactorY;
                                                                TimeStart = m_Timer.GetMicroSecondTime();
                                                                m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                                                                runIdx = 1020;
                                                                break;

                                                            case 1020:
                                                                //往下是負
                                                                timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                                                                if (timeSpan >= timeInc)
                                                                {
                                                                    if (m_CurPosY <= nextPosY)
                                                                    {
                                                                        TimeStart = m_Timer.GetMicroSecondTime();
                                                                        runIdx = 1030;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (m_TrimmedDataList.ElementAt(resID).PostVal >= resValueStopSlow)
                                                                        {
                                                                            errCode = m_InstantDoCtrl.Write(0, turnOff);
                                                                            if (errCode != ErrorCode.Success) { throw new System.ArgumentException("WriteBit fail", "Hardware Error"); }
                                                                            TimeStart = m_Timer.GetMicroSecondTime();
                                                                            runIdx = 1030;
                                                                        }
                                                                        else
                                                                        {
                                                                            runIdx = 1010;
                                                                        }
                                                                    }
                                                                }
                                                                break;

                                                            case 1030:
                                                                if ((m_Timer.GetMicroSecondTime() - TimeStart) >= cutInfo.Delay)
                                                                {
                                                                    runIdx = 2000;
                                                                }
                                                                break;
                                                        }
                                                    }//while (runIdx < 2000)

                                                    #region second cut 
                                                    CurrentCutId = 1;
                                                    m_CutIdx = CurrentCutId + 1;
                                                    cutInfo = m_CutInfoList.ElementAt(CurrentCutId);
                                                    // 切割移動 計算路徑 
                                                    cutInfo = m_CutInfoList.ElementAt(CurrentCutId);
                                                    // 跳躍移動 計算路徑
                                                    nextPosX = m_ResistorList.ElementAt(resID).GalvoXPos + cutInfo.XOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetX;
                                                    nextPosY = m_ResistorList.ElementAt(resID).GalvoYPos + cutInfo.YOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetY;

                                                    //直線為主
                                                    speedYFast = 300 / sec2us; //m_JumpSpeed  / sec2us;
                                                    arySizeY = (int)(Math.Abs(m_CurPosY - nextPosY) / speedYFast);
                                                    if (arySizeY != 0)
                                                    {
                                                        speedXFast = (speedYFast * Math.Abs(m_CurPosX - nextPosX)) / Math.Abs(m_CurPosY - nextPosY);
                                                    }
                                                    arySizeX = arySizeY;

                                                    if (m_CurPosX > nextPosX) { speedXFast = speedXFast * -1; }
                                                    if (m_CurPosY > nextPosY) { speedYFast = speedYFast * -1; }

                                                    aryIdx = 0;
                                                    TimeStart = m_Timer.GetMicroSecondTime();
                                                    runIdx = 1010;
                                                    while (runIdx < 2000)
                                                    {
                                                        switch (runIdx)
                                                        {
                                                            case 1010:
                                                                m_CurPosX = nextPosX;
                                                                x_Pos = m_CurPosX * m_ScaleFactorX;
                                                                m_CurPosY = nextPosY;
                                                                y_Pos = m_CurPosY * m_ScaleFactorY;
                                                                TimeStart = m_Timer.GetMicroSecondTime();
                                                                m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                                                                aryIdx += 1;
                                                                runIdx = 1020;
                                                                break;
                                                            case 1020:
                                                                if ((m_Timer.GetMicroSecondTime() - TimeStart) >= 500)
                                                                {
                                                                    runIdx = 2000;
                                                                }
                                                                break;
                                                        }
                                                    }//while (runIdx < 2000)


                                                    resIRV = m_TrimmedDataList.ElementAt(resID).PostVal;

                                                    if (m_ResistorList.ElementAt(resID).NominalDesign < 500)
                                                    { resValueStopNoWork = resIRV + m_ResistorList.ElementAt(resID).NominalDesign * 0.07 / 100; }
                                                    else if (m_ResistorList.ElementAt(resID).NominalDesign < 200000)
                                                    { resValueStopNoWork = resIRV + m_ResistorList.ElementAt(resID).NominalDesign * 0.03 / 100; }
                                                    else
                                                    { resValueStopNoWork = resIRV + m_ResistorList.ElementAt(resID).NominalDesign * 0.05 / 100; }

                                                    resValueStopFast = ((m_ResStopValue[m_ResRangeIdx] - resIRV) * cutInfo.ResStopPerc[m_ResRangeIdx] * 0.5 / 100) + resIRV;
                                                    resValueStop = ((m_ResStopValue[m_ResRangeIdx] - resIRV) * cutInfo.ResStopPerc[m_ResRangeIdx] * 0.7 / 100) + resIRV;
                                                    resValueStopSlow = m_ResStopValue[m_ResRangeIdx];
                                                    speedYFast = m_CutInfoList.ElementAt(CurrentCutId).Speed * 1 / sec2us;
                                                    speedY = m_CutInfoList.ElementAt(CurrentCutId).Speed * 1 / sec2us;
                                                    speedYSlow = m_CutInfoList.ElementAt(CurrentCutId).Speed * 1 / sec2us;
                                                    nextPosY = (m_ResistorList.ElementAt(resID).GalvoYPos + cutInfo.YOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetY - cutInfo.Length);
                                                    speedYNoWork = (m_CutInfoList.ElementAt(CurrentCutId).Speed + 20) / sec2us;
                                                    resNoWorkPosY = m_ResistorList.ElementAt(resID).GalvoYPos + cutInfo.YOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetY - m_resNoWorkOffset;
                                                    speedYNoWork = speedY;
                                                    if (m_CurPosY > nextPosY)
                                                    {
                                                        speedYNoWork = speedYNoWork * -1;
                                                        speedYFast = speedYFast * -1;
                                                        speedY = speedY * -1;
                                                        speedYSlow = speedYSlow * -1;
                                                    }
                                                    decA = (speedYFast * speedYFast - speedYNoWork * speedYNoWork) / (2 * -1 * m_resNoWorkOffset);

                                                    errCode = m_InstantDoCtrl.Write(0, turnOn);
                                                    if (errCode != ErrorCode.Success) { throw new System.ArgumentException("WriteBit fail", "Hardware Error"); }
                                                    //m_Timer.DelayMicroSec(3);


                                                    double oldX;
                                                    double oldY;
                                                    oldX = m_CurPosX;
                                                    oldY = m_CurPosY;
                                                    //執行路徑
                                                    //double testTimeStart = 0;
                                                    aryIdx = 0;
                                                    runIdx = 1010;
                                                    TimeStart = m_Timer.GetMicroSecondTime();
                                                    tmpX = m_CurPosX;
                                                    tmpY = m_CurPosY;
                                                    speed = speedYNoWork;
                                                    while (runIdx < 2000)
                                                    {
                                                        switch (runIdx)
                                                        {
                                                            case 1010:
                                                                posX = m_CurPosX;
                                                                if ((m_TrimmedDataList.ElementAt(resID).PostVal <= resValueStopNoWork) && m_CurPosY >= resNoWorkPosY)
                                                                {
                                                                    speed = speed + decA;
                                                                    if (Math.Abs(speed) < Math.Abs(speedYFast)) { speed = speedYFast; }
                                                                    speed = speedYFast;
                                                                    posY = speed + m_CurPosY;
                                                                    if (posY < nextPosY) { posY = nextPosY; }
                                                                }
                                                                else if (m_TrimmedDataList.ElementAt(resID).PostVal <= resValueStopFast)
                                                                {
                                                                    posY = speedYFast + m_CurPosY;
                                                                    if (posY < nextPosY) { posY = nextPosY; }
                                                                }
                                                                else if (m_TrimmedDataList.ElementAt(resID).PostVal <= resValueStop)
                                                                {
                                                                    posY = speedY + m_CurPosY;
                                                                    if (posY < nextPosY) { posY = nextPosY; }
                                                                }
                                                                else
                                                                {
                                                                    posY = speedYSlow + m_CurPosY;
                                                                    if (posY < nextPosY) { posY = nextPosY; }
                                                                }
                                                                m_CurPosX = posX;
                                                                x_Pos = m_CurPosX * m_ScaleFactorX;
                                                                m_CurPosY = posY;
                                                                y_Pos = m_CurPosY * m_ScaleFactorY;
                                                                TimeStart = m_Timer.GetMicroSecondTime();
                                                                m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                                                                runIdx = 1020;
                                                                break;

                                                            case 1020:
                                                                //往下是負
                                                                timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                                                                if (timeSpan >= timeInc)
                                                                {
                                                                    if (m_CurPosY <= nextPosY)
                                                                    {
                                                                        TimeStart = m_Timer.GetMicroSecondTime();
                                                                        runIdx = 1030;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (m_TrimmedDataList.ElementAt(resID).PostVal >= resValueStopSlow)
                                                                        {
                                                                            m_CurPosX = oldX;
                                                                            x_Pos = m_CurPosX * m_ScaleFactorX;
                                                                            m_CurPosY = oldY;
                                                                            y_Pos = m_CurPosY * m_ScaleFactorY;
                                                                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                                                                            errCode = m_InstantDoCtrl.Write(0, turnOff);
                                                                            if (errCode != ErrorCode.Success) { throw new System.ArgumentException("WriteBit fail", "Hardware Error"); }
                                                                            TimeStart = m_Timer.GetMicroSecondTime();
                                                                            runIdx = 1030;
                                                                        }
                                                                        else
                                                                        {
                                                                            runIdx = 1010;
                                                                        }
                                                                    }
                                                                }
                                                                break;

                                                            case 1030:
                                                                if ((m_Timer.GetMicroSecondTime() - TimeStart) >= cutInfo.Delay)
                                                                {
                                                                    runIdx = 2000;
                                                                }
                                                                break;
                                                        }
                                                    }//while (runIdx < 2000)
                                                    #endregion


                                                    //停止量測
                                                    m_ChangeRes = true;
                                                    //關閉雷射
                                                    errCode = m_InstantDoCtrl.Write(0, turnOff);
                                                    if (errCode != ErrorCode.Success)
                                                    {
                                                        throw new System.ArgumentException("WriteBit fail", "Hardware Error");
                                                    }
                                                    while (m_ChangeRes == true) { }
                                                    // }
                                                    // else//if (m_TrimmedDataList.ElementAt(resID).PrePercent < m_ResistorList.ElementAt(resID).FT_High)
                                                    // {
                                                    //    m_ChangeRes = true;
                                                    //    while (m_ChangeRes == true) { }
                                                    //    CurrentCutId = m_CutInfoList.Count - 1;
                                                    //     m_CutIdx = CurrentCutId + 1;
                                                    //      cutInfo = m_CutInfoList.ElementAt(CurrentCutId);
                                                    //  }
                                                }
                                                else//if ((m_TrimmedDataList.ElementAt(resID).PrePercent >= m_ResistorList.ElementAt(resID).PT_Low) 
                                                {
                                                    m_ChangeRes = true;
                                                    while (m_ChangeRes == true) { }
                                                    CurrentCutId = m_CutInfoList.Count - 1;
                                                    m_CutIdx = CurrentCutId + 1;
                                                    cutInfo = m_CutInfoList.ElementAt(CurrentCutId);
                                                }

                                            else//if ((m_TrimmedDataList.ElementAt(resID).PrePercent >= m_ResistorList.ElementAt(resID).PT_Low) 
                                            {
                                                m_ChangeRes = true;
                                                while (m_ChangeRes == true) { }
                                                CurrentCutId = m_CutInfoList.Count - 1;
                                                m_CutIdx = CurrentCutId + 1;
                                                cutInfo = m_CutInfoList.ElementAt(CurrentCutId);
                                            }
                                        }//(resID = (m_CurrentResId - 1); resID < m_TotalResistor; resID++)
                                    }
                                    catch (Exception e)
                                    {
                                        //關閉雷射
                                        errCode = m_InstantDoCtrl.Write(0, turnOff);
                                        if (errCode != ErrorCode.Success)
                                        {
                                            throw new System.ArgumentException("WriteBit fail", "Hardware Error");
                                        }
                                        throw new System.ArgumentException(e.ToString(), "TrimMyBackgroundTask");
                                    }
                                    #endregion
                                }
                            }
                            else
                            {
                                //m_JumpSpeed = 70;//300;// 100;
                                //m_JumpDelay = 380;
                                //multi
                                try
                                {
                                    for (resID = (m_CurrentResId - 1); resID < m_DestTrimId; resID++)
                                    {
                                        // 非同步量測結束
                                        while (m_RunIdxMeasureOne != 0) { }


                                        //開始非同步量測
                                        m_CurrentResId = resID + 1;
                                        m_CurrentCutId = 0;
                                        m_CutIdx = CurrentCutId + 1;
                                        m_RdyToTrim = false;
                                        m_ChangeRes = false;
                                        m_RunIdxMeasureOne = 1000;


                              

                                        // 切割移動 計算路徑 
                                        cutInfo = m_CutInfoList.ElementAt(CurrentCutId);
                                        // 跳躍移動 計算路徑
                                        nextPosX = m_ResistorList.ElementAt(resID).GalvoXPos + cutInfo.XOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetX;
                                        nextPosY = m_ResistorList.ElementAt(resID).GalvoYPos + cutInfo.YOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetY;
                                         

                                        if (Math.Abs(m_CurPosX - nextPosX) > Math.Abs(m_CurPosY - nextPosY))
                                        {
                                            //橫線為主
                                            speedXFast = m_JumpSpeed / sec2us;
                                            arySizeX = (int)(Math.Abs(m_CurPosX - nextPosX) / speedXFast);
                                            if (arySizeX != 0)
                                            {
                                                speedYFast = (speedXFast * Math.Abs(m_CurPosY - nextPosY)) / Math.Abs(m_CurPosX - nextPosX);
                                            }
                                            arySizeY = arySizeX;
                                        }
                                        else
                                        {
                                            //直線為主
                                            speedYFast = m_JumpSpeed / sec2us;
                                            arySizeY = (int)(Math.Abs(m_CurPosY - nextPosY) / speedYFast);
                                            if (arySizeY != 0)
                                            {
                                                speedXFast = (speedYFast * Math.Abs(m_CurPosX - nextPosX)) / Math.Abs(m_CurPosY - nextPosY);
                                            }
                                            arySizeX = arySizeY;
                                        }
                                        if (m_CurPosX > nextPosX) { speedXFast = speedXFast * -1; }
                                        if (m_CurPosY > nextPosY) { speedYFast = speedYFast * -1; }
                                        if (arySizeX != 0)
                                        {
                                            //Parallel.For(0, arySizeY, aryIdx1 =>
                                            //{
                                            //    PosAryX[aryIdx1] = (aryIdx1 * speedXFast) + m_CurPosX;
                                            //    PosAryY[aryIdx1] = (aryIdx1 * speedYFast) + m_CurPosY;
                                            //}); // Parallel.For
                                            for (aryIdx = 0; aryIdx < arySizeY; aryIdx++)
                                            {
                                                if (arySizeY > PosAryX.Length) { break; }
                                                PosAryX[aryIdx] = nextPosX; //(aryIdx * speedXFast) + m_CurPosX;
                                                PosAryY[aryIdx] = (aryIdx * speedYFast) + m_CurPosY;
                                            }
                                            int NewarySizeX = arySizeX;
                                            int NewarySizeY = arySizeY;
                                            if (NewarySizeX > PosAryX.Length) { NewarySizeX = PosAryX.Length; }
                                            if (NewarySizeY > PosAryY.Length) { NewarySizeY = PosAryY.Length; }
                                            PosAryX[NewarySizeX - 1] = nextPosX;
                                            PosAryY[NewarySizeY - 1] = nextPosY;
                                            // 執行路徑
                                            aryIdx = 0;
                                            TimeStart = m_Timer.GetMicroSecondTime();
                                            runIdx = 1010;
                                            while (runIdx < 2000)
                                            {
                                                switch (runIdx)
                                                {
                                                    case 1010:
                                                        m_CurPosX = PosAryX[aryIdx];
                                                        x_Pos = m_CurPosX * m_ScaleFactorX;
                                                        m_CurPosY = PosAryY[aryIdx];
                                                        y_Pos = m_CurPosY * m_ScaleFactorY;
                                                        TimeStart = m_Timer.GetMicroSecondTime();
                                                        m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                                                        aryIdx += 1;
                                                        runIdx = 1020;
                                                        break;
                                                    case 1020:
                                                        timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                                                        if (timeSpan >= timeInc)
                                                        // if (timeSpan >= timeInc)
                                                        {
                                                            //aryIdx = (int)(timeSpan / timeInc);
                                                            if (aryIdx < arySizeX)
                                                            {
                                                                runIdx = 1010;
                                                            }
                                                            else
                                                            {
                                                                TimeStart = m_Timer.GetMicroSecondTime();
                                                                runIdx = 1030;
                                                            }
                                                        }
                                                        break;
                                                    case 1030:
                                                        if ((m_Timer.GetMicroSecondTime() - TimeStart) >= m_JumpDelay)
                                                        {
                                                            runIdx = 2000;
                                                        }
                                                        break;
                                                }
                                            }//while (runIdx < 2000)
                                        }//(arySizeX != 0)
                                         //Wait for Res Measure
                                        while (!m_RdyToTrim)
                                        {
                                        }
                                        if (m_TrimmedDataList.ElementAt(resID).PrePercent <= m_ResistorList.ElementAt(resID).PT_High)
                                            if (m_TrimmedDataList.ElementAt(resID).PrePercent >= m_ResistorList.ElementAt(resID).PT_Low)
                                            {
                                                for (m_CurrentCutId = 0; m_CurrentCutId < m_CutInfoList.Count; m_CurrentCutId++)
                                                {

                                                    m_CutIdx = m_CurrentCutId + 1;

                                                    // 切割移動 計算路徑 
                                                    cutInfo = m_CutInfoList.ElementAt(m_CurrentCutId);
                                                    // 跳躍移動 計算路徑
                                                    nextPosX = m_ResistorList.ElementAt(resID).GalvoXPos + cutInfo.XOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetX;
                                                    nextPosY = m_ResistorList.ElementAt(resID).GalvoYPos + cutInfo.YOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetY;


                                                    if (Math.Abs(m_CurPosX - nextPosX) > Math.Abs(m_CurPosY - nextPosY))
                                                    {
                                                        //橫線為主
                                                        speedXFast = m_JumpSpeed / sec2us;
                                                        arySizeX = (int)(Math.Abs(m_CurPosX - nextPosX) / speedXFast);
                                                        if (arySizeX != 0)
                                                        {
                                                            speedYFast = (speedXFast * Math.Abs(m_CurPosY - nextPosY)) / Math.Abs(m_CurPosX - nextPosX);
                                                        }
                                                        arySizeY = arySizeX;
                                                    }
                                                    else
                                                    {
                                                        //直線為主
                                                        speedYFast = m_JumpSpeed / sec2us;
                                                        arySizeY = (int)(Math.Abs(m_CurPosY - nextPosY) / speedYFast);
                                                        if (arySizeY != 0)
                                                        {
                                                            speedXFast = (speedYFast * Math.Abs(m_CurPosX - nextPosX)) / Math.Abs(m_CurPosY - nextPosY);
                                                        }
                                                        arySizeX = arySizeY;
                                                    }
                                                    if (m_CurPosX > nextPosX) { speedXFast = speedXFast * -1; }
                                                    if (m_CurPosY > nextPosY) { speedYFast = speedYFast * -1; }
                                                    if (arySizeX != 0)
                                                    {
                                                        //Parallel.For(0, arySizeY, aryIdx1 =>
                                                        //{
                                                        //    PosAryX[aryIdx1] = (aryIdx1 * speedXFast) + m_CurPosX;
                                                        //    PosAryY[aryIdx1] = (aryIdx1 * speedYFast) + m_CurPosY;
                                                        //}); // Parallel.For
                                                        for (aryIdx = 0; aryIdx < arySizeY; aryIdx++)
                                                        {
                                                            if (arySizeY > PosAryX.Length) { break; }
                                                            PosAryX[aryIdx] = nextPosX; //(aryIdx * speedXFast) + m_CurPosX;
                                                            PosAryY[aryIdx] = (aryIdx * speedYFast) + m_CurPosY;
                                                        }
                                                        int NewarySizeX = arySizeX;
                                                        int NewarySizeY = arySizeY;
                                                        if (NewarySizeX > PosAryX.Length) { NewarySizeX = PosAryX.Length; }
                                                        if (NewarySizeY > PosAryY.Length) { NewarySizeY = PosAryY.Length; }
                                                        PosAryX[NewarySizeX - 1] = nextPosX;
                                                        PosAryY[NewarySizeY - 1] = nextPosY;
                                                        // 執行路徑
                                                        aryIdx = 0;
                                                        TimeStart = m_Timer.GetMicroSecondTime();
                                                        runIdx = 1010;
                                                        while (runIdx < 2000)
                                                        {
                                                            switch (runIdx)
                                                            {
                                                                case 1010:
                                                                    m_CurPosX = PosAryX[aryIdx];
                                                                    x_Pos = m_CurPosX * m_ScaleFactorX;
                                                                    m_CurPosY = PosAryY[aryIdx];
                                                                    y_Pos = m_CurPosY * m_ScaleFactorY;
                                                                    TimeStart = m_Timer.GetMicroSecondTime();
                                                                    m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                                                                    aryIdx += 1;
                                                                    runIdx = 1020;
                                                                    break;
                                                                case 1020:
                                                                    timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                                                                    if (timeSpan >= timeInc)
                                                                    // if (timeSpan >= timeInc)
                                                                    {
                                                                        //aryIdx = (int)(timeSpan / timeInc);
                                                                        if (aryIdx < arySizeX)
                                                                        {
                                                                            runIdx = 1010;
                                                                        }
                                                                        else
                                                                        {
                                                                            TimeStart = m_Timer.GetMicroSecondTime();
                                                                            runIdx = 1030;
                                                                        }
                                                                    }
                                                                    break;
                                                                case 1030:
                                                                    if ((m_Timer.GetMicroSecondTime() - TimeStart) >= m_JumpDelay)
                                                                    {
                                                                        runIdx = 2000;
                                                                    }
                                                                    break;
                                                            }
                                                        }//while (runIdx < 2000)
                                                    }//(arySizeX != 0)
                                                    
                                                    // if (m_TrimmedDataList.ElementAt(resID).PrePercent < m_ResistorList.ElementAt(resID).FT_Low)
                                                    // {
                                                    // 依照初值決定中心值
                                                    //m_Timer.DelayMicroSec(5);
                                                    errCode = m_InstantDoCtrl.Write(0, turnOn);
                                                    if (errCode != ErrorCode.Success) { throw new System.ArgumentException("WriteBit fail", "Hardware Error"); }
                                                    //m_Timer.DelayMicroSec(3);
                                                    resIRV = m_TrimmedDataList.ElementAt(resID).PreVal;
                                                    //first cut
                                                    if (m_ResistorList.ElementAt(resID).NominalDesign < 500)
                                                    { resValueStopNoWork = resIRV + m_ResistorList.ElementAt(resID).NominalDesign * 0.07 / 100; }
                                                    else if (m_ResistorList.ElementAt(resID).NominalDesign < 200000)
                                                    { resValueStopNoWork = resIRV + m_ResistorList.ElementAt(resID).NominalDesign * 0.03 / 100; }
                                                    else
                                                    { resValueStopNoWork = resIRV + m_ResistorList.ElementAt(resID).NominalDesign * 0.05 / 100; }
                                                    resValueStopNoWork = m_ResStopValue[m_ResRangeIdx];
                                                    resValueStopFast = ((m_ResStopValue[m_ResRangeIdx] - resIRV) * cutInfo.ResStopPerc[m_ResRangeIdx] * 0.6 / 100) + resIRV;
                                                    resValueStop = ((m_ResStopValue[m_ResRangeIdx] - resIRV) * cutInfo.ResStopPerc[m_ResRangeIdx] * 0.8 / 100) + resIRV;
                                                    resValueStopSlow = ((m_ResStopValue[m_ResRangeIdx] - resIRV) * cutInfo.ResStopPerc[m_ResRangeIdx] * 1 / 100) + resIRV;
                                                    speedYFast = m_CutInfoList.ElementAt(CurrentCutId).Speed * 1 / sec2us;
                                                    speedY = m_CutInfoList.ElementAt(CurrentCutId).Speed * 1 / sec2us;
                                                    speedYSlow = m_CutInfoList.ElementAt(CurrentCutId).Speed * 1 / sec2us; //*0.75 / sec2us;
                                                    switch (cutInfo.Direction)
                                                    {
                                                        case 0:
                                                            {
                                                                nextPosX = (m_ResistorList.ElementAt(resID).GalvoXPos + cutInfo.XOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetX + cutInfo.Length);
                                                                break;
                                                            }
                                                        case 90:
                                                            {
                                                                nextPosY = (m_ResistorList.ElementAt(resID).GalvoYPos + cutInfo.YOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetY + cutInfo.Length);
                                                                break;
                                                            }
                                                        case 180:
                                                            {
                                                                nextPosX = (m_ResistorList.ElementAt(resID).GalvoXPos + cutInfo.XOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetX - cutInfo.Length);
                                                                break;
                                                            }
                                                        case 270:
                                                            {
                                                                nextPosY = (m_ResistorList.ElementAt(resID).GalvoYPos + cutInfo.YOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetY - cutInfo.Length);
                                                                break;
                                                            }
                                                    }

                                                    if (cutInfo.Direction == 0 || cutInfo.Direction == 180)
                                                    {
                                                        speedXFast = m_CutInfoList.ElementAt(CurrentCutId).Speed * 1 / sec2us;
                                                        speedX = m_CutInfoList.ElementAt(CurrentCutId).Speed * 0.85 / sec2us;
                                                        speedXSlow = m_CutInfoList.ElementAt(CurrentCutId).Speed * 0.65 / sec2us;
                                                        if (m_CurPosX > nextPosX)
                                                        {
                                                            speedXFast = speedXFast * -1;
                                                            speedX = speedX * -1;
                                                            speedXSlow = speedXSlow * -1;
                                                        }
                                                        //執行路徑
                                                        aryIdx = 0;
                                                        runIdx = 1010;
                                                        tmpX = m_CurPosX;
                                                        tmpY = m_CurPosY;
                                                        TimeStart = m_Timer.GetMicroSecondTime();
                                                        while (runIdx < 2000)
                                                        {
                                                            switch (runIdx)
                                                            {
                                                                case 1010:
                                                                    //timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;

                                                                    posY = m_CurPosY;
                                                                    if (m_TrimmedDataList.ElementAt(resID).PostVal <= resValueStopFast)
                                                                    {
                                                                        posX = speedXFast + m_CurPosX;
                                                                        if(cutInfo.Direction == 0)
                                                                        {
                                                                            if (posX > nextPosX) { posX = nextPosX; }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (posX < nextPosX) { posX = nextPosX; }
                                                                        }
                                                                    }
                                                                    else if (m_TrimmedDataList.ElementAt(resID).PostVal <= resValueStop)
                                                                    {
                                                                        posX = speedX + m_CurPosX;
                                                                        if (cutInfo.Direction == 0)
                                                                        {
                                                                            if (posX > nextPosX) { posX = nextPosX; }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (posX < nextPosX) { posX = nextPosX; }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        posX = speedXSlow + m_CurPosX;
                                                                        if (cutInfo.Direction == 0)
                                                                        {
                                                                            if (posX > nextPosX) { posX = nextPosX; }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (posX < nextPosX) { posX = nextPosX; }
                                                                        }
                                                                    }
                                                                    m_CurPosX = posX;
                                                                    x_Pos = m_CurPosX * m_ScaleFactorX;
                                                                    m_CurPosY = posY;
                                                                    y_Pos = m_CurPosY * m_ScaleFactorY;
                                                                    TimeStart = m_Timer.GetMicroSecondTime();
                                                                    m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                                                                    runIdx = 1020;
                                                                    break;

                                                                case 1020:
                                                                    timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                                                                    if (timeSpan >= timeInc)
                                                                    // if (timeSpan >= timeInc)
                                                                    {
                                                                        if (cutInfo.Direction == 0)
                                                                        {
                                                                            if (m_CurPosX >= nextPosX)
                                                                            {
                                                                                //關閉雷射
                                                                                errCode = m_InstantDoCtrl.Write(0, turnOff);
                                                                                if (errCode != ErrorCode.Success)
                                                                                {
                                                                                    throw new System.ArgumentException("WriteBit fail", "Hardware Error");
                                                                                }
                                                                                TimeStart = m_Timer.GetMicroSecondTime();
                                                                                runIdx = 1030;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (m_TrimmedDataList.ElementAt(resID).PostVal >= resValueStopSlow)
                                                                                {
                                                                                    TimeStart = m_Timer.GetMicroSecondTime();
                                                                                    runIdx = 1030;
                                                                                }
                                                                                else
                                                                                {
                                                                                    runIdx = 1010;
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (m_CurPosX <= nextPosX)
                                                                            {
                                                                                //關閉雷射
                                                                                errCode = m_InstantDoCtrl.Write(0, turnOff);
                                                                                if (errCode != ErrorCode.Success)
                                                                                {
                                                                                    throw new System.ArgumentException("WriteBit fail", "Hardware Error");
                                                                                }
                                                                                TimeStart = m_Timer.GetMicroSecondTime();
                                                                                runIdx = 1030;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (m_TrimmedDataList.ElementAt(resID).PostVal >= resValueStopSlow)
                                                                                {
                                                                                    TimeStart = m_Timer.GetMicroSecondTime();
                                                                                    runIdx = 1030;
                                                                                }
                                                                                else
                                                                                {
                                                                                    runIdx = 1010;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    break;

                                                                case 1030:
                                                                    if ((m_Timer.GetMicroSecondTime() - TimeStart) >= cutInfo.Delay)
                                                                    {
                                                                        //打開雷射
                                                                        //ret = D2KDASK.D2K_DO_WritePort(cardNum, (ushort)0, turnOn);
                                                                        runIdx = 2000;
                                                                    }
                                                                    break;
                                                            }
                                                        }//while (runIdx < 2000)
                                                    }
                                                    else
                                                    {
                                                        speedYNoWork = (m_CutInfoList.ElementAt(CurrentCutId).Speed + 15) / sec2us;
                                                        resNoWorkPosY = m_ResistorList.ElementAt(resID).GalvoYPos + cutInfo.YOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetY - m_resNoWorkOffset;
                                                        //speedYNoWork = speedY;
                                                        if (m_CurPosY > nextPosY)
                                                        {
                                                            speedYNoWork = speedYNoWork * -1;
                                                            speedYFast = speedYFast * -1;
                                                            speedY = speedY * -1;
                                                            speedYSlow = speedYSlow * -1;
                                                        }
                                                        //decA = (speedYFast * speedYFast - speedYNoWork * speedYNoWork) / (2 * -1 * resNoWorkOffset);
                                                        //執行路徑
                                                        //double testTimeStart = 0;
                                                        aryIdx = 0;
                                                        runIdx = 1010;
                                                        TimeStart = m_Timer.GetMicroSecondTime();
                                                        tmpX = m_CurPosX;
                                                        tmpY = m_CurPosY;
                                                        speed = speedYNoWork;
                                                        while (runIdx < 2000)
                                                        {
                                                            switch (runIdx)
                                                            {
                                                                case 1010:
                                                                    posX = m_CurPosX;
                                                                    if ((m_TrimmedDataList.ElementAt(resID).PostVal <= resValueStopNoWork) && m_CurPosY >= resNoWorkPosY)
                                                                    {
                                                                        //speed = speed + decA;
                                                                        // if (Math.Abs(speed) < Math.Abs(speedYFast)) { speed = speedYFast; }
                                                                        speed = speedYNoWork;
                                                                        posY = speed + m_CurPosY;
                                                                        if(cutInfo.Direction==270)
                                                                        {
                                                                            if (posY <= nextPosY) { posY = nextPosY; } //大往小走
                                                                        }
                                                                        else
                                                                        {
                                                                            if (posY >= nextPosY) { posY = nextPosY; } //大往小走
                                                                        }
                                                                        
                                                                    }
                                                                    else if (m_TrimmedDataList.ElementAt(resID).PostVal <= resValueStopFast)
                                                                    {
                                                                        posY = speedYFast + m_CurPosY;
                                                                        if (cutInfo.Direction == 270)
                                                                        {
                                                                            if (posY <= nextPosY) { posY = nextPosY; } //大往小走
                                                                        }
                                                                        else
                                                                        {
                                                                            if (posY >= nextPosY) { posY = nextPosY; } //大往小走
                                                                        }
                                                                    }
                                                                    else if (m_TrimmedDataList.ElementAt(resID).PostVal <= resValueStop)
                                                                    {
                                                                        posY = speedY + m_CurPosY;
                                                                        if (cutInfo.Direction == 270)
                                                                        {
                                                                            if (posY <= nextPosY) { posY = nextPosY; } //大往小走
                                                                        }
                                                                        else
                                                                        {
                                                                            if (posY >= nextPosY) { posY = nextPosY; } //大往小走
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        posY = speedYSlow + m_CurPosY;
                                                                        if (cutInfo.Direction == 270)
                                                                        {
                                                                            if (posY <= nextPosY) { posY = nextPosY; } //大往小走
                                                                        }
                                                                        else
                                                                        {
                                                                            if (posY >= nextPosY) { posY = nextPosY; } //大往小走
                                                                        }
                                                                    }
                                                                    m_CurPosX = posX;
                                                                    x_Pos = m_CurPosX * m_ScaleFactorX;
                                                                    m_CurPosY = posY;
                                                                    y_Pos = m_CurPosY * m_ScaleFactorY;
                                                                    TimeStart = m_Timer.GetMicroSecondTime();
                                                                    m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                                                                    runIdx = 1020;
                                                                    break;

                                                                case 1020:
                                                                    //往下是負
                                                                    timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                                                                    if (timeSpan >= timeInc)
                                                                    {
                                                                        if (cutInfo.Direction == 270)
                                                                        {
                                                                            if (m_CurPosY <= nextPosY)
                                                                            {
                                                                                errCode = m_InstantDoCtrl.Write(0, turnOff);
                                                                                TimeStart = m_Timer.GetMicroSecondTime();
                                                                                runIdx = 1030;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (m_TrimmedDataList.ElementAt(resID).PostVal >= resValueStopSlow)
                                                                                {
                                                                                    errCode = m_InstantDoCtrl.Write(0, turnOff);
                                                                                    if (errCode != ErrorCode.Success) { throw new System.ArgumentException("WriteBit fail", "Hardware Error"); }
                                                                                    TimeStart = m_Timer.GetMicroSecondTime();
                                                                                    runIdx = 1030;
                                                                                }
                                                                                else
                                                                                {
                                                                                    runIdx = 1010;
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (m_CurPosY >= nextPosY)
                                                                            {
                                                                                errCode = m_InstantDoCtrl.Write(0, turnOff);
                                                                                TimeStart = m_Timer.GetMicroSecondTime();
                                                                                runIdx = 1030;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (m_TrimmedDataList.ElementAt(resID).PostVal >= resValueStopSlow)
                                                                                {
                                                                                    errCode = m_InstantDoCtrl.Write(0, turnOff);
                                                                                    if (errCode != ErrorCode.Success) { throw new System.ArgumentException("WriteBit fail", "Hardware Error"); }
                                                                                    TimeStart = m_Timer.GetMicroSecondTime();
                                                                                    runIdx = 1030;
                                                                                }
                                                                                else
                                                                                {
                                                                                    runIdx = 1010;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    break;

                                                                case 1030:
                                                                    if ((m_Timer.GetMicroSecondTime() - TimeStart) >= cutInfo.Delay)
                                                                    {
                                                                        runIdx = 2000;
                                                                    }
                                                                    break;
                                                            }
                                                        }//while (runIdx < 2000)
                                                    }


                                                    //#region "Focus to next cut"
                                                    //if (m_CurrentCutId + 1 < m_CutInfoList.Count)
                                                    //{
                                                    //    cutInfo = m_CutInfoList.ElementAt(m_CurrentCutId + 1);
                                                    //    nextPosX = m_ResistorList.ElementAt(resID).GalvoXPos + cutInfo.XOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetX;
                                                    //    nextPosY = m_ResistorList.ElementAt(resID).GalvoYPos + cutInfo.YOffset + m_PanelList.ElementAt(m_CurrentColId - 1).GalvoColOffsetY;


                                                    //    if (Math.Abs(m_CurPosX - nextPosX) > Math.Abs(m_CurPosY - nextPosY))
                                                    //    {
                                                    //        //橫線為主
                                                    //        speedXFast = m_JumpSpeed / sec2us;
                                                    //        arySizeX = (int)(Math.Abs(m_CurPosX - nextPosX) / speedXFast);
                                                    //        if (arySizeX != 0)
                                                    //        {
                                                    //            speedYFast = (speedXFast * Math.Abs(m_CurPosY - nextPosY)) / Math.Abs(m_CurPosX - nextPosX);
                                                    //        }
                                                    //        arySizeY = arySizeX;
                                                    //    }
                                                    //    else
                                                    //    {
                                                    //        //直線為主
                                                    //        speedYFast = m_JumpSpeed / sec2us;
                                                    //        arySizeY = (int)(Math.Abs(m_CurPosY - nextPosY) / speedYFast);
                                                    //        if (arySizeY != 0)
                                                    //        {
                                                    //            speedXFast = (speedYFast * Math.Abs(m_CurPosX - nextPosX)) / Math.Abs(m_CurPosY - nextPosY);
                                                    //        }
                                                    //        arySizeX = arySizeY;
                                                    //    }
                                                    //    if (m_CurPosX > nextPosX) { speedXFast = speedXFast * -1; }
                                                    //    if (m_CurPosY > nextPosY) { speedYFast = speedYFast * -1; }
                                                    //    if (arySizeX != 0)
                                                    //    {
                                                    //        //Parallel.For(0, arySizeY, aryIdx1 =>
                                                    //        //{
                                                    //        //    PosAryX[aryIdx1] = (aryIdx1 * speedXFast) + m_CurPosX;
                                                    //        //    PosAryY[aryIdx1] = (aryIdx1 * speedYFast) + m_CurPosY;
                                                    //        //}); // Parallel.For
                                                    //        for (aryIdx = 0; aryIdx < arySizeY; aryIdx++)
                                                    //        {
                                                    //            if (arySizeY > PosAryX.Length) { break; }
                                                    //            PosAryX[aryIdx] = nextPosX; //(aryIdx * speedXFast) + m_CurPosX;
                                                    //            PosAryY[aryIdx] = (aryIdx * speedYFast) + m_CurPosY;
                                                    //        }
                                                    //        int NewarySizeX = arySizeX;
                                                    //        int NewarySizeY = arySizeY;
                                                    //        if (NewarySizeX > PosAryX.Length) { NewarySizeX = PosAryX.Length; }
                                                    //        if (NewarySizeY > PosAryY.Length) { NewarySizeY = PosAryY.Length; }
                                                    //        PosAryX[NewarySizeX - 1] = nextPosX;
                                                    //        PosAryY[NewarySizeY - 1] = nextPosY;
                                                    //        // 執行路徑
                                                    //        aryIdx = 0;
                                                    //        TimeStart = m_Timer.GetMicroSecondTime();
                                                    //        runIdx = 1010;
                                                    //        while (runIdx < 2000)
                                                    //        {
                                                    //            switch (runIdx)
                                                    //            {
                                                    //                case 1010:
                                                    //                    m_CurPosX = PosAryX[aryIdx];
                                                    //                    x_Pos = m_CurPosX * m_ScaleFactorX;
                                                    //                    m_CurPosY = PosAryY[aryIdx];
                                                    //                    y_Pos = m_CurPosY * m_ScaleFactorY;
                                                    //                    TimeStart = m_Timer.GetMicroSecondTime();
                                                    //                    m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                                                    //                    aryIdx += 1;
                                                    //                    runIdx = 1020;
                                                    //                    break;
                                                    //                case 1020:
                                                    //                    timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                                                    //                    if (timeSpan >= timeInc)
                                                    //                    // if (timeSpan >= timeInc)
                                                    //                    {
                                                    //                        //aryIdx = (int)(timeSpan / timeInc);
                                                    //                        if (aryIdx < arySizeX)
                                                    //                        {
                                                    //                            runIdx = 1010;
                                                    //                        }
                                                    //                        else
                                                    //                        {
                                                    //                            TimeStart = m_Timer.GetMicroSecondTime();
                                                    //                            runIdx = 1030;
                                                    //                        }
                                                    //                    }
                                                    //                    break;
                                                    //                case 1030:
                                                    //                    if ((m_Timer.GetMicroSecondTime() - TimeStart) >= m_JumpDelay)
                                                    //                    {
                                                    //                        runIdx = 2000;
                                                    //                    }
                                                    //                    break;
                                                    //            }
                                                    //        }//while (runIdx < 2000)
                                                    //    }//(arySizeX != 0)
                                                    //     //Wait for Res Measure
                                                    //    while (!m_RdyToTrim)
                                                    //    {
                                                    //    }

                                                    //}
                                                    //else//if (resID + 1 < m_DestTrimId)
                                                    //{
                                                    //    m_ChangeRes = true;
                                                    //    while (m_ChangeRes == true) { }
                                                    //}
                                                    //#endregion















                                                }//End for multi cut


                                                //停止量測
                                                m_ChangeRes = true;
                                                //關閉雷射
                                                errCode = m_InstantDoCtrl.Write(0, turnOff);
                                                if (errCode != ErrorCode.Success)
                                                {
                                                    throw new System.ArgumentException("WriteBit fail", "Hardware Error");
                                                }
                                                while (m_ChangeRes == true) { }
                                                // }
                                                // else//if (m_TrimmedDataList.ElementAt(resID).PrePercent < m_ResistorList.ElementAt(resID).FT_High)
                                                // {
                                                //    m_ChangeRes = true;
                                                //    while (m_ChangeRes == true) { }
                                                //    CurrentCutId = m_CutInfoList.Count - 1;
                                                //     m_CutIdx = CurrentCutId + 1;
                                                //      cutInfo = m_CutInfoList.ElementAt(CurrentCutId);
                                                //  }
                                            }
                                            else//if ((m_TrimmedDataList.ElementAt(resID).PrePercent >= m_ResistorList.ElementAt(resID).PT_Low) 
                                            {
                                                m_ChangeRes = true;
                                                while (m_ChangeRes == true) { }
                                                CurrentCutId = m_CutInfoList.Count - 1;
                                                m_CutIdx = CurrentCutId + 1;
                                                cutInfo = m_CutInfoList.ElementAt(CurrentCutId);
                                            }

                                        else//if ((m_TrimmedDataList.ElementAt(resID).PrePercent >= m_ResistorList.ElementAt(resID).PT_Low) 
                                        {
                                            m_ChangeRes = true;
                                            while (m_ChangeRes == true) { }
                                            CurrentCutId = m_CutInfoList.Count - 1;
                                            m_CutIdx = CurrentCutId + 1;
                                            cutInfo = m_CutInfoList.ElementAt(CurrentCutId);
                                        }
                                    }//(resID = (m_CurrentResId - 1); resID < m_TotalResistor; resID++)
                                }
                                catch (Exception e)
                                {
                                    //關閉雷射
                                    errCode = m_InstantDoCtrl.Write(0, turnOff);
                                    if (errCode != ErrorCode.Success)
                                    {
                                        throw new System.ArgumentException("WriteBit fail", "Hardware Error");
                                    }
                                    throw new System.ArgumentException(e.ToString(), "TrimMyBackgroundTask");
                                }
                                
                            }
                            m_RunIdxTrimOne = 0;
                            //如果是最後一顆 Galvo回到第一顆的位置 增加速度
                            if (CurrentResID >= m_TotalResistor)
                            {
                                if (m_ResistorList.ElementAt(0).NominalDesign > 1000)
                                {
                                    m_Meter.SelectRelayMap(118);
                                    m_Meter.SelectRelayMap(119);
                                }
                                else
                                {
                                    m_Meter.SelectRelayMap(116);
                                    m_Meter.SelectRelayMap(117);
                                }
                                
                                // 切割移動 計算路徑 回到第一顆位置 50ms走完
                                CurrentResID = 1;
                                resID = 0;
                                cutInfo = m_CutInfoList.ElementAt(0);
                                // 跳躍移動 
                                if (CurrentColId == m_TotalCol)
                                {
                                    nextPosX = m_ResistorList.ElementAt(resID).GalvoXPos + m_PanelList.ElementAt(0).GalvoColOffsetX + cutInfo.XOffset;
                                    nextPosY = m_ResistorList.ElementAt(resID).GalvoYPos + m_PanelList.ElementAt(0).GalvoColOffsetY + cutInfo.YOffset;
                                }
                                else
                                {
                                    nextPosX = m_ResistorList.ElementAt(resID).GalvoXPos + m_PanelList.ElementAt(m_CurrentColId).GalvoColOffsetX + cutInfo.XOffset;
                                    nextPosY = m_ResistorList.ElementAt(resID).GalvoYPos + m_PanelList.ElementAt(m_CurrentColId).GalvoColOffsetY + cutInfo.YOffset;
                                }

                                double DistanceX;
                                double DistanceY;
                                int jumpSpeed = 800;
                                #region "(1) Jump to Start point"
                                DistanceX = Math.Abs(m_CurPosX - nextPosX);
                                DistanceY = Math.Abs(m_CurPosY - nextPosY);
                                int arrSize = 0;
                                arrSize = 0;
                                if (DistanceX > DistanceY)
                                {
                                    arrSize = (int)(DistanceX / (jumpSpeed / sec2us));
                                }
                                else
                                { arrSize = (int)(DistanceY / (jumpSpeed / sec2us)); }
                                runIdx = 1010;
                                aryIdx = 0;
                                if (arrSize > 0)
                                {
                                    DistanceX = Math.Abs(m_CurPosX - nextPosX);
                                    DistanceY = Math.Abs(m_CurPosY - nextPosY);
                                    speedYFast = DistanceY / arrSize;
                                    speedXFast = DistanceX / arrSize;
                                    if (m_CurPosX > nextPosX)
                                    {
                                        speedXFast = Math.Abs(speedXFast) * -1;
                                    }
                                    else
                                    {
                                        speedXFast = Math.Abs(speedXFast);
                                    }
                                    if (m_CurPosY > nextPosY)
                                    {
                                        speedYFast = Math.Abs(speedYFast) * -1;
                                    }
                                    else
                                    {
                                        speedYFast = Math.Abs(speedYFast);
                                    }
                                    double checkTimeStart = m_Timer.GetMicroSecondTime();
                                    while (runIdx < 2000)
                                    {
                                        switch (runIdx)
                                        {
                                            case 1010:
                                                m_CurPosY += speedYFast;
                                                m_CurPosX += speedXFast;
                                                x_Pos = m_CurPosX * m_ScaleFactorX;
                                                y_Pos = m_CurPosY * m_ScaleFactorY;
                                                TimeStart = m_Timer.GetMicroSecondTime();
                                                m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                                                runIdx = 1020;
                                                aryIdx++;
                                                break;
                                            case 1020:
                                                if (m_Timer.GetMicroSecondTime() - TimeStart >= timeInc)
                                                {
                                                    if (aryIdx < arrSize)
                                                        runIdx = 1010;
                                                    else
                                                    {
                                                        TimeStart = m_Timer.GetMicroSecondTime();
                                                        m_CurPosY = nextPosY;
                                                        m_CurPosX = nextPosX;
                                                        x_Pos = m_CurPosX * m_ScaleFactorX;
                                                        y_Pos = m_CurPosY * m_ScaleFactorY;
                                                        m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                                                        runIdx = 2000;
                                                    }
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                #endregion
                            } //(m_CurrentResId == m_TotalResistor)
                            break;
                    }
                }
            }
            catch (Exception e)
            { throw new System.ArgumentException(e.ToString(), "TrimMyBackgroundTask"); }
            m_ThreadTrimFinished = true;
        }



        internal void Npoint()
        {
            Automation.BDaq.ErrorCode errCode;
            int runIdx = 0;
            double nextPosX = 0;
            double nextPosY = 0;
            double speedYNoWork = 100;// mm/us
            double speedXFast = 10;// mm/us
            double speedX = 10;// mm/us
            double speedXSlow = 10; //mm/s
            double speedYFast = 10;// mm/us
            double speedY = 10;// mm/us
            double speedYSlow = 10; //mm/s
            int aryIdx = 0;
            int arySizeX = 0;
            int arySizeY = 0;
            double[] PosAryX;
            double[] PosAryY;
            double posX;
            double posY;
            double tmpX = 0;
            double tmpY = 0;
            double TimeStart = 0;

            double timeSpan = 0;
            double resValueStopNoWork = 0;
            double resValueStopFast = 0;
            double resValueStop = 0;
            double resValueStopSlow = 0;
            double resIRV = 0; //初R值
            int timeInc = 10; // 10us 更新資料一次
            double sec2us = 1000 * 1000.0; // 10us
            sec2us = sec2us / timeInc;

            double x_Pos = 0;
            double y_Pos = 0;
            byte turnOn = 0x1;
            byte turnOff = 0x0;
            int resID;

            TurnLaserOn();
            try
            {
                speedXFast = 45 / sec2us;
                speedYFast = 45 / sec2us;
                arySizeX = (int)(30 / speedXFast);
                arySizeY = (int)(30 / speedYFast);
                PosAryX = new double[arySizeX];
                PosAryY = new double[arySizeY];
                aryIdx = 0;
                TimeStart = m_Timer.GetMicroSecondTime();
                runIdx = 1010;
                while (runIdx < 9000)
                {
                    switch (runIdx)
                    {
                        case 1010:
                            m_CurPosX = -15;
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = -15;
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            runIdx = 1020;
                            break;
                        case 1020:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= 200 * 1000)
                            {
                                errCode = m_InstantDoCtrl.Write(0, turnOn);
                                if (errCode != ErrorCode.Success)
                                {
                                    throw new System.ArgumentException("WriteBit fail", "Hardware Error");
                                }
                                runIdx = 1030;
                            }
                            break;
                        case 1030:
                            nextPosX = 15;
                            nextPosY = -15;
                            for (aryIdx = 0; aryIdx < arySizeY; aryIdx++)
                            {
                                PosAryX[aryIdx] = (aryIdx * speedXFast) + m_CurPosX;
                                PosAryY[aryIdx] = nextPosY;
                            }
                            PosAryX[arySizeX - 1] = nextPosX;
                            PosAryY[arySizeY - 1] = nextPosY;
                            // 執行路徑
                            aryIdx = 0;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            runIdx = 1040;
                            break;
                        case 1040:
                            m_CurPosX = PosAryX[aryIdx];
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = PosAryY[aryIdx];
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            aryIdx += 1;
                            runIdx = 1050;
                            break;
                        case 1050:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= timeInc)
                            {
                                if (aryIdx < arySizeX)
                                {
                                    runIdx = 1040;
                                }
                                else
                                {
                                    TimeStart = m_Timer.GetMicroSecondTime();
                                    runIdx = 2010;
                                }
                            }
                            break;

                        case 2010:
                            m_CurPosX = -15;
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = -15 + 30 * 1 / 3;
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            runIdx = 2020;
                            break;
                        case 2020:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= 200 * 1000)
                            {
                                runIdx = 2030;
                            }
                            break;
                        case 2030:
                            nextPosX = 15;
                            nextPosY = -15 + 30 * 1 / 3;
                            for (aryIdx = 0; aryIdx < arySizeY; aryIdx++)
                            {
                                PosAryX[aryIdx] = (aryIdx * speedXFast) + m_CurPosX;
                                PosAryY[aryIdx] = nextPosY;
                            }
                            PosAryX[arySizeX - 1] = nextPosX;
                            PosAryY[arySizeY - 1] = nextPosY;
                            // 執行路徑
                            aryIdx = 0;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            runIdx = 2040;
                            break;
                        case 2040:
                            m_CurPosX = PosAryX[aryIdx];
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = PosAryY[aryIdx];
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            aryIdx += 1;
                            runIdx = 2050;
                            break;
                        case 2050:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= timeInc)
                            {
                                if (aryIdx < arySizeX)
                                {
                                    runIdx = 2040;
                                }
                                else
                                {
                                    TimeStart = m_Timer.GetMicroSecondTime();
                                    runIdx = 3010;
                                }
                            }
                            break;

                        case 3010:
                            m_CurPosX = -15;
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = -15 + 30 * 2 / 3;
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            runIdx = 3020;
                            break;
                        case 3020:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= 200 * 1000)
                            {
                                runIdx = 3030;
                            }
                            break;
                        case 3030:
                            nextPosX = 15;
                            nextPosY = -15 + 30 * 2 / 3;
                            for (aryIdx = 0; aryIdx < arySizeY; aryIdx++)
                            {
                                PosAryX[aryIdx] = (aryIdx * speedXFast) + m_CurPosX;
                                PosAryY[aryIdx] = nextPosY;
                            }
                            PosAryX[arySizeX - 1] = nextPosX;
                            PosAryY[arySizeY - 1] = nextPosY;
                            // 執行路徑
                            aryIdx = 0;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            runIdx = 3040;
                            break;
                        case 3040:
                            m_CurPosX = PosAryX[aryIdx];
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = PosAryY[aryIdx];
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            aryIdx += 1;
                            runIdx = 3050;
                            break;
                        case 3050:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= timeInc)
                            {
                                if (aryIdx < arySizeX)
                                {
                                    runIdx = 3040;
                                }
                                else
                                {
                                    TimeStart = m_Timer.GetMicroSecondTime();
                                    runIdx = 4010;
                                }
                            }
                            break;

                        case 4010:
                            m_CurPosX = -15;
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = -15 + 30 * 3 / 3;
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            runIdx = 4020;
                            break;
                        case 4020:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= 200 * 1000)
                            {
                                runIdx = 4030;
                            }
                            break;
                        case 4030:
                            nextPosX = 15;
                            nextPosY = -15 + 30 * 3 / 3;
                            for (aryIdx = 0; aryIdx < arySizeY; aryIdx++)
                            {
                                PosAryX[aryIdx] = (aryIdx * speedXFast) + m_CurPosX;
                                PosAryY[aryIdx] = nextPosY;
                            }
                            PosAryX[arySizeX - 1] = nextPosX;
                            PosAryY[arySizeY - 1] = nextPosY;
                            // 執行路徑
                            aryIdx = 0;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            runIdx = 4040;
                            break;
                        case 4040:
                            m_CurPosX = PosAryX[aryIdx];
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = PosAryY[aryIdx];
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            aryIdx += 1;
                            runIdx = 4050;
                            break;
                        case 4050:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= timeInc)
                            {
                                if (aryIdx < arySizeX)
                                {
                                    runIdx = 4040;
                                }
                                else
                                {
                                    TimeStart = m_Timer.GetMicroSecondTime();
                                    runIdx = 5010;
                                }
                            }
                            break;


                        case 5010:
                            m_CurPosX = -15 + 30 * 0 / 3;
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = -15;
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            runIdx = 5020;
                            break;
                        case 5020:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= 200 * 1000)
                            {
                                runIdx = 5030;
                            }
                            break;
                        case 5030:
                            nextPosX = -15 + 30 * 0 / 3;
                            nextPosY = 15;
                            for (aryIdx = 0; aryIdx < arySizeY; aryIdx++)
                            {
                                PosAryX[aryIdx] = nextPosX;
                                PosAryY[aryIdx] = (aryIdx * speedYFast) + m_CurPosY;
                            }
                            PosAryX[arySizeX - 1] = nextPosX;
                            PosAryY[arySizeY - 1] = nextPosY;
                            // 執行路徑
                            aryIdx = 0;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            runIdx = 5040;
                            break;
                        case 5040:
                            m_CurPosX = PosAryX[aryIdx];
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = PosAryY[aryIdx];
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            aryIdx += 1;
                            runIdx = 5050;
                            break;
                        case 5050:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= timeInc)
                            {
                                if (aryIdx < arySizeX)
                                {
                                    runIdx = 5040;
                                }
                                else
                                {
                                    TimeStart = m_Timer.GetMicroSecondTime();
                                    runIdx = 6010;
                                }
                            }
                            break;


                        case 6010:
                            m_CurPosX = -15 + 30 * 1 / 3;
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = -15;
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            runIdx = 6020;
                            break;
                        case 6020:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= 200 * 1000)
                            {
                                runIdx = 6030;
                            }
                            break;
                        case 6030:
                            nextPosX = -15 + 30 * 1 / 3;
                            nextPosY = 15;
                            for (aryIdx = 0; aryIdx < arySizeY; aryIdx++)
                            {
                                PosAryX[aryIdx] = nextPosX;
                                PosAryY[aryIdx] = (aryIdx * speedYFast) + m_CurPosY;
                            }
                            PosAryX[arySizeX - 1] = nextPosX;
                            PosAryY[arySizeY - 1] = nextPosY;
                            // 執行路徑
                            aryIdx = 0;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            runIdx = 6040;
                            break;
                        case 6040:
                            m_CurPosX = PosAryX[aryIdx];
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = PosAryY[aryIdx];
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            aryIdx += 1;
                            runIdx = 6050;
                            break;
                        case 6050:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= timeInc)
                            {
                                if (aryIdx < arySizeX)
                                {
                                    runIdx = 6040;
                                }
                                else
                                {
                                    TimeStart = m_Timer.GetMicroSecondTime();
                                    runIdx = 7010;
                                }
                            }
                            break;


                        case 7010:
                            m_CurPosX = -15 + 30 * 2 / 3;
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = -15;
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            runIdx = 7020;
                            break;
                        case 7020:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= 200 * 1000)
                            {
                                runIdx = 7030;
                            }
                            break;
                        case 7030:
                            nextPosX = -15 + 30 * 2 / 3;
                            nextPosY = 15;
                            for (aryIdx = 0; aryIdx < arySizeY; aryIdx++)
                            {
                                PosAryX[aryIdx] = nextPosX;
                                PosAryY[aryIdx] = (aryIdx * speedYFast) + m_CurPosY;
                            }
                            PosAryX[arySizeX - 1] = nextPosX;
                            PosAryY[arySizeY - 1] = nextPosY;
                            // 執行路徑
                            aryIdx = 0;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            runIdx = 7040;
                            break;
                        case 7040:
                            m_CurPosX = PosAryX[aryIdx];
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = PosAryY[aryIdx];
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            aryIdx += 1;
                            runIdx = 7050;
                            break;
                        case 7050:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= timeInc)
                            {
                                if (aryIdx < arySizeX)
                                {
                                    runIdx = 7040;
                                }
                                else
                                {
                                    TimeStart = m_Timer.GetMicroSecondTime();
                                    runIdx = 8010;
                                }
                            }
                            break;


                        case 8010:
                            m_CurPosX = -15 + 30 * 3 / 3;
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = -15;
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            runIdx = 8020;
                            break;
                        case 8020:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= 200 * 1000)
                            {
                                runIdx = 8030;
                            }
                            break;
                        case 8030:
                            nextPosX = -15 + 30 * 3 / 3;
                            nextPosY = 15;
                            for (aryIdx = 0; aryIdx < arySizeY; aryIdx++)
                            {
                                PosAryX[aryIdx] = nextPosX;
                                PosAryY[aryIdx] = (aryIdx * speedYFast) + m_CurPosY;
                            }
                            PosAryX[arySizeX - 1] = nextPosX;
                            PosAryY[arySizeY - 1] = nextPosY;
                            // 執行路徑
                            aryIdx = 0;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            runIdx = 8040;
                            break;
                        case 8040:
                            m_CurPosX = PosAryX[aryIdx];
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = PosAryY[aryIdx];
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            aryIdx += 1;
                            runIdx = 8050;
                            break;
                        case 8050:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= timeInc)
                            {
                                if (aryIdx < arySizeX)
                                {
                                    runIdx = 8040;
                                }
                                else
                                {
                                    TimeStart = m_Timer.GetMicroSecondTime();
                                    runIdx = 9000;
                                }
                            }
                            break;
                    }
                }//while (runIdx < 9000)
            }
            catch (Exception e)
            { throw new System.ArgumentException(e.ToString(), "NPoint"); }

            errCode = m_InstantDoCtrl.Write(0, turnOff);
            if (errCode != ErrorCode.Success)
            {
                throw new System.ArgumentException("WriteBit fail", "Hardware Error");
            }

            TurnLaserOff();
        }

        public void MarkT()
        {
            Automation.BDaq.ErrorCode errCode;
            int runIdx = 0;
            double nextPosX = 0;
            double nextPosY = 0;
            double speedYNoWork = 100;// mm/us
            double speedXFast = 10;// mm/us
            double speedX = 10;// mm/us
            double speedXSlow = 10; //mm/s
            double speedYFast = 10;// mm/us
            double speedY = 10;// mm/us
            double speedYSlow = 10; //mm/s
            int aryIdx = 0;
            int arySizeX = 0;
            int arySizeY = 0;
            double[] PosAryX;
            double[] PosAryY;
            double posX;
            double posY;
            double tmpX = 0;
            double tmpY = 0;
            double TimeStart = 0;

            double timeSpan = 0;
            double resValueStopNoWork = 0;
            double resValueStopFast = 0;
            double resValueStop = 0;
            double resValueStopSlow = 0;
            double resIRV = 0; //初R值
            int timeInc = 10; // 10us 更新資料一次
            double sec2us = 1000 * 1000.0; // 10us
            sec2us = sec2us / timeInc;

            double x_Pos = 0;
            double y_Pos = 0;
            byte turnOn = 0x1;
            byte turnOff = 0x0;
            int resID;
            int laserONIdx;
            int laserOffIdx;
            //        TurnLaserOn();
            try
            {
                // 25mm/s = 25/1000000 mm/us
                speedXFast = 20 / sec2us;
                speedYFast = 20 / sec2us;
                arySizeX = (int)(3 / speedXFast);
                arySizeY = (int)(3 / speedYFast);
                PosAryX = new double[arySizeX];
                PosAryY = new double[arySizeY];

                laserONIdx = (int)(0.5 / speedYFast);
                laserOffIdx = (int)(2 / speedYFast);
                aryIdx = 0;
                TimeStart = m_Timer.GetMicroSecondTime();
                runIdx = 5010;
                while (runIdx < 6000)
                {
                    switch (runIdx)
                    {
                        case 5010:
                            m_CurPosX = 0;
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = 0;
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            runIdx = 5020;
                            break;
                        case 5020:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= 200 * 1000)
                            {
                                //errCode = m_InstantDoCtrl.Write(0, turnOn);
                                //if (errCode != ErrorCode.Success)
                                //{
                                //    throw new System.ArgumentException("WriteBit fail", "Hardware Error");
                                //}
                                runIdx = 5030;
                            }
                            break;
                        case 5030:
                            nextPosX = 0;// - 22.5 + 45 * 0 / 3;
                            nextPosY = 3;
                            for (aryIdx = 0; aryIdx < arySizeY; aryIdx++)
                            {
                                PosAryX[aryIdx] = nextPosX;
                                PosAryY[aryIdx] = (aryIdx * speedYFast) + m_CurPosY;
                            }
                            PosAryX[arySizeX - 1] = nextPosX;
                            PosAryY[arySizeY - 1] = nextPosY;
                            // 執行路徑
                            aryIdx = 0;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            runIdx = 5040;
                            break;
                        case 5040:
                            m_CurPosX = PosAryX[aryIdx];
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = PosAryY[aryIdx];
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            aryIdx += 1;
                            if (aryIdx == laserONIdx) { errCode = m_InstantDoCtrl.Write(0, turnOn); }
                            if (aryIdx == laserOffIdx) { errCode = m_InstantDoCtrl.Write(0, turnOff); }
                            runIdx = 5050;
                            break;
                        case 5050:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= timeInc)
                            {
                                if (aryIdx < arySizeX)
                                {
                                    runIdx = 5040;
                                }
                                else
                                {
                                    TimeStart = m_Timer.GetMicroSecondTime();
                                    runIdx = 6010;
                                }
                            }
                            break;
                    }
                }//while (runIdx < 9000)
            }
            catch (Exception e)
            { throw new System.ArgumentException(e.ToString(), "NPoint"); }

            errCode = m_InstantDoCtrl.Write(0, turnOff);
            if (errCode != ErrorCode.Success)
            {
                throw new System.ArgumentException("WriteBit fail", "Hardware Error");
            }

            TurnLaserOff();
        }

        internal void LineY()
        {
            Automation.BDaq.ErrorCode errCode;
            int runIdx = 0;
            double nextPosX = 0;
            double nextPosY = 0;
            double speedYNoWork = 100;// mm/us
            double speedXFast = 10;// mm/us
            double speedX = 10;// mm/us
            double speedXSlow = 10; //mm/s
            double speedYFast = 10;// mm/us
            double speedY = 10;// mm/us
            double speedYSlow = 10; //mm/s
            int aryIdx = 0;
            int arySizeX = 0;
            int arySizeY = 0;
            double[] PosAryX;
            double[] PosAryY;
            double posX;
            double posY;
            double tmpX = 0;
            double tmpY = 0;
            double TimeStart = 0;

            double timeSpan = 0;
            double resValueStopNoWork = 0;
            double resValueStopFast = 0;
            double resValueStop = 0;
            double resValueStopSlow = 0;
            double resIRV = 0; //初R值
            int timeInc = 10; // 10us 更新資料一次
            double sec2us = 1000 * 1000.0; // 10us
            sec2us = sec2us / timeInc;

            double x_Pos = 0;
            double y_Pos = 0;
            byte turnOn = 0x1;
            byte turnOff = 0x0;
            int resID;

            TurnLaserOn();
            try
            {
                // 25mm/s = 25/1000000 mm/us
                speedXFast = 2 / sec2us;
                speedYFast = 2 / sec2us;
                arySizeX = (int)(20 / speedXFast);
                arySizeY = (int)(20 / speedYFast);
                PosAryX = new double[arySizeX];
                PosAryY = new double[arySizeY];
                aryIdx = 0;
                TimeStart = m_Timer.GetMicroSecondTime();
                runIdx = 5010;
                while (runIdx < 6000)
                {
                    switch (runIdx)
                    {
                        case 5010:
                            //m_CurPosX = -22.5 + 45 * 0 / 3;
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = -10;
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            runIdx = 5020;
                            break;
                        case 5020:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= 200 * 1000)
                            {
                                errCode = m_InstantDoCtrl.Write(0, turnOn);
                                if (errCode != ErrorCode.Success)
                                {
                                    throw new System.ArgumentException("WriteBit fail", "Hardware Error");
                                }
                                runIdx = 5030;
                            }
                            break;
                        case 5030:
                            nextPosX = m_CurPosX;// - 22.5 + 45 * 0 / 3;
                            nextPosY = 10;
                            for (aryIdx = 0; aryIdx < arySizeY; aryIdx++)
                            {
                                PosAryX[aryIdx] = nextPosX;
                                PosAryY[aryIdx] = (aryIdx * speedYFast) + m_CurPosY;
                            }
                            PosAryX[arySizeX - 1] = nextPosX;
                            PosAryY[arySizeY - 1] = nextPosY;
                            // 執行路徑
                            aryIdx = 0;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            runIdx = 5040;
                            break;
                        case 5040:
                            m_CurPosX = PosAryX[aryIdx];
                            x_Pos = m_CurPosX * m_ScaleFactorX;
                            m_CurPosY = PosAryY[aryIdx];
                            y_Pos = m_CurPosY * m_ScaleFactorY;
                            TimeStart = m_Timer.GetMicroSecondTime();
                            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
                            aryIdx += 1;
                            runIdx = 5050;
                            break;
                        case 5050:
                            timeSpan = m_Timer.GetMicroSecondTime() - TimeStart;
                            if (timeSpan >= timeInc)
                            {
                                if (aryIdx < arySizeX)
                                {
                                    runIdx = 5040;
                                }
                                else
                                {
                                    TimeStart = m_Timer.GetMicroSecondTime();
                                    runIdx = 6010;
                                }
                            }
                            break;
                    }
                }//while (runIdx < 9000)
            }
            catch (Exception e)
            { throw new System.ArgumentException(e.ToString(), "NPoint"); }

            errCode = m_InstantDoCtrl.Write(0, turnOff);
            if (errCode != ErrorCode.Success)
            {
                throw new System.ArgumentException("WriteBit fail", "Hardware Error");
            }

            TurnLaserOff();
        }
        public void UpdateResPos(ref double[] XPos, ref double[] YPos)
        {
            double X_Pos;
            double Y_Pos;
            CRes Res;
            for (int i = 1; i <= XPos.Length; i++)
            {
                X_Pos = XPos[i - 1];
                Y_Pos = YPos[i - 1];
                Res = m_ResistorList.ElementAt(i - 1);
                Res.GalvoXPos = X_Pos;
                Res.GalvoYPos = Y_Pos;
            }
        }
        public void MeasureAll()
        {
            int AvgNum = 0;
            CRes res;
            for (int aryIdx = 0; aryIdx < m_TotalResistor; aryIdx++)
            {
                res = m_ResistorList.ElementAt(aryIdx);
                //切換繼電器
                m_Meter.SelectRelayMap(m_ResistorList.ElementAt(aryIdx).RelayIdx);
                m_Meter.SelectRelayMap(m_ResistorList.ElementAt(aryIdx + 1).RelayIdx);
                m_PwModulatorCtrl.Enabled = true;
                //繼電器延遲時間
                m_Timer.DelayMicroSec(res.PT_Dly);
                //收集初始樣本
                AvgNum = res.PT_Cnt;

                //最小平方
                double[] data1 = new double[AvgNum];
                double[] data2 = new double[AvgNum];
                double[] adc1 = new double[AvgNum];
                double[] adc2 = new double[AvgNum];

                if (m_ResistorList.ElementAt(aryIdx).RelayIdx % 2 == 0)
                {
                    m_Meter.TrigADC2(ref data1, ref data2, ref adc1, ref adc2);
                }
                else
                {
                    m_Meter.TrigADC2(ref data2, ref data1, ref adc2, ref adc1);
                }

                if (aryIdx == 12)
                {
                    aryIdx = aryIdx;
                }
                double mean1 = 0;
                double mean2 = 0;
                mean1 = 0;
                mean2 = 0;


                for (int i = 0; i < AvgNum; i++)
                {
                    mean1 = mean1 + adc1[i] / AvgNum; ;
                }


                for (int i = 0; i < AvgNum; i++)
                {
                    mean2 = mean2 + adc2[i] / AvgNum; ;
                }


                CTrimData trimmedData;
                trimmedData = m_TrimmedDataList.ElementAt(aryIdx);
                m_TrimmedDataList.ElementAt(aryIdx).PreAdc = (int)mean1;
                m_TrimmedDataList.ElementAt(aryIdx+1).PreAdc = (int)mean2;

                if (m_ResistorList.ElementAt(aryIdx).RelayIdx % 2 == 0)
                {
                    m_Meter.ADC2ResValue1((long)mean1, out mean1);
                    m_Meter.ADC2ResValue2((long)mean2, out mean2);
                }
                else
                {
                    m_Meter.ADC2ResValue2((long)mean1, out mean1);
                    m_Meter.ADC2ResValue1((long)mean2, out mean2);
                }


                    // mean = mean / AvgNum;
                    
                trimmedData.PreVal = mean1 + res.NominalDesign * res.MeasureBias / 100;
                trimmedData.PrePercent = ((trimmedData.PreVal - res.NominalDesign) / res.NominalDesign) * 100;

                trimmedData = m_TrimmedDataList.ElementAt(aryIdx + 1);
                trimmedData.PreVal = mean2 + res.NominalDesign * res.MeasureBias / 100;
                trimmedData.PrePercent = ((trimmedData.PreVal - res.NominalDesign) / res.NominalDesign) * 100;


                //繼電器延遲時間
                m_Timer.DelayMicroSec(1000);
                if (m_ResistorList.ElementAt(aryIdx).RelayIdx % 2 == 0)
                {
                    m_Meter.TrigADC2(ref data1, ref data2, ref adc1, ref adc2);
                }
                else
                {
                    m_Meter.TrigADC2(ref data2, ref data1, ref adc2, ref adc1);
                }

                //平均
                mean1 = 0;
                mean2 = 0;
                for (int i = 0; i < AvgNum; i++)
                {
                    mean1 = mean1 + data1[i] / AvgNum;
                    mean2 = mean2 + data2[i] / AvgNum;
                }
                trimmedData = m_TrimmedDataList.ElementAt(aryIdx);
                trimmedData.PostVal = mean1 + res.NominalDesign * res.MeasureBias / 100; ;
                trimmedData.PostPercent = ((trimmedData.PostVal - res.NominalDesign) / res.NominalDesign) * 100;
                trimmedData = m_TrimmedDataList.ElementAt(aryIdx + 1);
                trimmedData.PostVal = mean2 + res.NominalDesign * res.MeasureBias / 100; ;
                trimmedData.PostPercent = ((trimmedData.PostVal - res.NominalDesign) / res.NominalDesign) * 100;
                aryIdx = aryIdx + 1;

                data1 = null;
                data2 = null;
                m_PwModulatorCtrl.Enabled = false;
                //m_Timer.DelayMicroSec(350);
            }
            m_Timer.DelayMicroSec(10000);

            if (m_ResistorList.ElementAt(0).NominalDesign <= 1000)
            {
                m_Meter.SelectRelayMap(116);
                m_Meter.SelectRelayMap(117);
            }
            else
            {
                m_Meter.SelectRelayMap(118);
                m_Meter.SelectRelayMap(119);
            }


        }

        public void MeasureCold()
        {

            int i;
            int AvgNum = 0;
            CRes res;
            for (int aryIdx = 0; aryIdx < m_TotalResistor; aryIdx++)
            {
                res = m_ResistorList.ElementAt(aryIdx);
                //切換繼電器
                m_Meter.SelectRelayMap(m_ResistorList.ElementAt(aryIdx).RelayIdx);
                m_Meter.SelectRelayMap(m_ResistorList.ElementAt(aryIdx + 1).RelayIdx);
                m_PwModulatorCtrl.Enabled = true;
                //繼電器延遲時間
                m_Timer.DelayMicroSec(res.PT_Dly);
                //收集初始樣本
                AvgNum = res.PT_Cnt;

                //最小平方
                double[] data1 = new double[AvgNum];
                double[] data2 = new double[AvgNum];

                if (m_ResistorList.ElementAt(aryIdx).RelayIdx % 2 == 0)
                {
                    m_Meter.TrigADC2(ref data1, ref data2);
                }
                else
                {
                    m_Meter.TrigADC2(ref data2, ref data1);
                }

                double mean1 = 0;
                double mean2 = 0;
                mean1 = 0;
                mean2 = 0;
                for (i = 0; i < AvgNum; i++)
                {
                    mean1 = mean1 + data1[i] / AvgNum; ;
                    mean2 = mean2 + data2[i] / AvgNum; ;
                }
                // mean = mean / AvgNum;
                CTrimData trimmedData;
                trimmedData = m_TrimmedDataList.ElementAt(aryIdx);
                trimmedData.PostVal = mean1 + res.NominalDesign * res.MeasureBias / 100; ;
                trimmedData.PostPercent = ((trimmedData.PostVal - res.NominalDesign) / res.NominalDesign) * 100;

                trimmedData = m_TrimmedDataList.ElementAt(aryIdx + 1);
                trimmedData.PostVal = mean2 + res.NominalDesign * res.MeasureBias / 100; ;
                trimmedData.PostPercent = ((trimmedData.PostVal - res.NominalDesign) / res.NominalDesign) * 100;
                aryIdx = aryIdx + 1;

                data1 = null;
                data2 = null;
                m_PwModulatorCtrl.Enabled = false;
                m_Timer.DelayMicroSec(350);
            }
            m_Timer.DelayMicroSec(10000);

            if (m_ResistorList.ElementAt(0).NominalDesign <= 1000)
            {
                m_Meter.SelectRelayMap(116);
                m_Meter.SelectRelayMap(117);
            }
            else
            {
                m_Meter.SelectRelayMap(118);
                m_Meter.SelectRelayMap(119);
            }

        }
        /// <summary>
        /// 換一顆電阻量測
        /// </summary>
        private bool m_ChangeRes;
        /// <summary>
        /// 停止量測
        /// </summary>
        private bool m_StopMeasure;
        /// <summary>
        /// 抓到初R值可以開始切
        /// </summary>
        private bool m_RdyToTrim = false;
        private bool m_ThreadMeasureStarted = false;
        private bool m_ThreadMeasureFinished = true;
        private int m_RunIdxMeasureOne = 0;
        /// <summary>
        /// 目前刀數索引值,從1開始
        /// </summary>
        private int m_CutIdx = 1;
        private bool m_StopTrim;
        private bool m_ThreadTrimStarted = false;
        private bool m_ThreadTrimFinished = true;
        private int m_RunIdxTrimOne = 0;
        private int m_resBufferID = -1;
        private double m_BufferRelayTimeStart = 0;
        /// <summary>
        /// 切割時候多執行緒抓量測
        /// </summary>
        private void MeasureOne()
        {
            ErrorCode errCode;
            int i;
            int resID = 0;
            int colID = 0;
            CRes res;
            CTrimData trimmedData;
            int AvgNum = 2;
            int AvgNum1 = 2;
            List<double> dataMaster;//移動平均用的資料
            List<double> dataMaster1;//移動平均用的資料final
            List<double> dataSlave;//移動平均用的資料
            double meanMaster = 0;
            double meanSlave = 0;
            double meanMaster1 = 0;
            double measureValue = 0;
            double measureValueSrc2 = 0;
            double[] measureAryMaster;
            double[] measureArySlave;
            double[] measureAryMaster1;
            List<PointF> Points = new List<PointF>();
            double BestM = 0;
            double BestB = 0;
            bool firstLaserOff = true;
            double resValueStop = 0;
            double timeStart = 0;
            double timeSpan = 0;
            measureAryMaster1 = new double[5];
            try
            {
                m_ThreadMeasureFinished = false;
                m_ThreadMeasureStarted = true;
                dataMaster = new List<double>();
                dataMaster1 = new List<double>();
                dataSlave = new List<double>();
                i = 0;

                resID = 0;
                res = m_ResistorList.ElementAt(resID);
                trimmedData = m_TrimmedDataList.ElementAt(resID);
                double curPosX = 0;
                double curPosY = 0;
                while (!m_StopMeasure)
                {
                    switch (m_RunIdxMeasureOne)
                    {
                        case 0:
                            //      SpinWait.SpinUntil(() => false, 1);
                            break;
                        //
                        case 1000:
                            m_ChangeRes = false;
                            m_RdyToTrim = false;
                            dataMaster.Clear();
                            dataMaster1.Clear();
                            meanMaster = 0;
                            meanMaster1 = 0;
                            firstLaserOff = true;
                            i = 0;
                            resID = m_CurrentResId - 1;
                            colID = m_CurrentColId - 1;
                            m_RunIdxMeasureOne = 1010;
                            break;

                        case 1010:
                            res = m_ResistorList.ElementAt(resID);
                            trimmedData = m_TrimmedDataList.ElementAt(resID);
                            //切換繼電器
                            if ((m_resBufferID == -1) || (m_resBufferID != resID))
                            {
                                m_Meter.SelectRelayMap(m_ResistorList.ElementAt(resID).RelayIdx);
                                m_resBufferID = resID;
                                if ((resID + 1) < m_TotalResistor)
                                {
                                    m_Meter.SelectRelayMap(m_ResistorList.ElementAt(resID + 1).RelayIdx);
                                    m_resBufferID = resID + 1;
                                    m_BufferRelayTimeStart = m_Timer.GetMicroSecondTime();
                                }
                                m_PwModulatorCtrl.Enabled = true;
                                //繼電器延遲時間
                                if (resID == 0 || resID == 1)
                                { m_Timer.DelayMicroSec(res.FT_Dly+100000); }
                                else
                                { m_Timer.DelayMicroSec(res.FT_Dly + 1000); }
                                m_RunIdxMeasureOne = 1012;
                            }
                            else
                            {
                                if (m_resBufferID == resID)
                                {
                                    //切1量2再切2的時候如果時間夠久已經有2的資料
                                    timeSpan = m_Timer.GetMicroSecondTime() - m_BufferRelayTimeStart;
                                    if ((resID + 1) < m_TotalResistor)
                                    {
                                        m_Meter.SelectRelayMap(m_ResistorList.ElementAt(resID + 1).RelayIdx);
                                        m_resBufferID = resID + 1;
                                        m_BufferRelayTimeStart = m_Timer.GetMicroSecondTime();
                                    }
                                    m_PwModulatorCtrl.Enabled = true;
                                    if (resID == 0 || resID == 1)
                                    {
                                        if (timeSpan >= res.FT_Dly +100000)
                                        {
                                            timeStart = m_Timer.GetMicroSecondTime();
                                            m_RunIdxMeasureOne = 1012;
                                          //  m_RunIdxMeasureOne = 1012;
                                        }
                                        else
                                        {
                                            m_Timer.DelayMicroSec((res.FT_Dly + 100000));
                                            m_RunIdxMeasureOne = 1012;
                                        }
                                    }
                                    else
                                    {
                                        if (timeSpan >= (res.FT_Dly + 1000))
                                        {
                                            timeStart = m_Timer.GetMicroSecondTime();
                                            m_RunIdxMeasureOne = 1014;
                                            // m_RunIdxMeasureOne = 1012;
                                        }
                                        else
                                        {

                                            m_Timer.DelayMicroSec((res.FT_Dly + 1000));
                                            m_RunIdxMeasureOne = 1012;
                                        }
                                    }

                                }
                            }
                            break;

                        case 1012:
                            //收集初始樣本
                            dataSlave.Clear();
                            AvgNum = res.PT_Cnt;
                            AvgNum1 = res.FT_Cnt;
                            measureAryMaster = new double[AvgNum];
                            measureArySlave = new double[AvgNum];
                            if (m_ResistorList.ElementAt(resID).RelayIdx % 2 == 0)
                            {
                                m_Meter.TrigADC2(ref measureAryMaster, ref measureArySlave);
                            }
                            else
                            {
                                m_Meter.TrigADC2(ref measureArySlave, ref measureAryMaster);
                            }
                            // 40 samples for 200us
                            for (i = 0; i < AvgNum; i++)
                            {

                                meanMaster = meanMaster + measureAryMaster[i];
                                dataSlave.Add((measureArySlave[i] + m_ResistorList.ElementAt(resID + 1).NominalDesign * m_ResistorList.ElementAt(resID + 1).MeasureBias / 100));
                            }
                            meanMaster = meanMaster / AvgNum;
                            meanMaster = meanMaster + res.NominalDesign * res.MeasureBias / 100;
                            meanMaster1 = meanMaster;
                            //AvgNum = res.PT_Cnt;
                            for (i = 0; i < AvgNum; i++)
                            {
                                dataMaster.Add(meanMaster);
                            }
                            //AvgNum1 = res.FT_Cnt;
                            for (i = 0; i < AvgNum1; i++)
                            {
                                dataMaster1.Add(meanMaster);
                            }
                            trimmedData.PreVal = meanMaster;
                            trimmedData.PrePercent = (trimmedData.PreVal - res.NominalDesign) / res.NominalDesign * 100;
                            trimmedData.PostVal = trimmedData.PreVal;
                            trimmedData.PostPercent = trimmedData.PrePercent;
                            // 依照初值決定中心值
                            m_ResRangeIdx = (int)Math.Abs(trimmedData.PrePercent) % 40;
                            if (m_ResRangeIdx <= 0)
                            {
                                m_ResRangeIdx = 0;
                            }
                            if (m_ResRangeIdx >= 34)
                            {
                                m_ResRangeIdx = 34;
                            }
                            resValueStop = m_ResStopValue[m_ResRangeIdx];

                            m_RdyToTrim = true;
                            if ((m_TrimmedDataList.ElementAt(resID).PrePercent <= m_ResistorList.ElementAt(resID).PT_High) && (m_TrimmedDataList.ElementAt(resID).PrePercent >= m_ResistorList.ElementAt(resID).PT_Low))
                            {
                                m_RunIdxMeasureOne = 1020;
                            }
                            else
                            {
                                //m_ChangeRes = true;
                                m_RunIdxMeasureOne = 1060;
                            }
                            break;
                        case 1014:
                            //收集初始樣本
                            AvgNum = res.PT_Cnt;
                            AvgNum1 = res.FT_Cnt;
                            measureAryMaster = new double[AvgNum];
                            measureArySlave = new double[AvgNum];
                            // 40 samples for 200us
                            for (i = 0; i < AvgNum; i++)
                            {
                                meanMaster = meanMaster + dataSlave.ElementAt(i);
                            }
                            meanMaster = meanMaster / AvgNum;
                            meanMaster1 = meanMaster;
                            //AvgNum = res.PT_Cnt;
                            for (i = 0; i < AvgNum; i++)
                            {
                                dataMaster.Add(meanMaster);
                            }
                            //AvgNum1 = res.FT_Cnt;
                            for (i = 0; i < AvgNum1; i++)
                            {
                                dataMaster1.Add(meanMaster);
                            }
                            trimmedData.PreVal = meanMaster;
                            trimmedData.PrePercent = (trimmedData.PreVal - res.NominalDesign) / res.NominalDesign * 100;
                            trimmedData.PostVal = trimmedData.PreVal;
                            trimmedData.PostPercent = trimmedData.PrePercent;
                            // 依照初值決定中心值
                            m_ResRangeIdx = (int)Math.Abs(trimmedData.PrePercent) % 40;
                            if (m_ResRangeIdx <= 0)
                            {
                                m_ResRangeIdx = 0;
                            }
                            if (m_ResRangeIdx >= 34)
                            {
                                m_ResRangeIdx = 34;
                            }
                            resValueStop = m_ResStopValue[m_ResRangeIdx];

                            m_RdyToTrim = true;
                            if ((m_TrimmedDataList.ElementAt(resID).PrePercent <= m_ResistorList.ElementAt(resID).PT_High) && (m_TrimmedDataList.ElementAt(resID).PrePercent >= m_ResistorList.ElementAt(resID).PT_Low))
                            {
                                m_RunIdxMeasureOne = 1015;
                            }
                            else
                            {
                                //m_ChangeRes = true;
                                m_RunIdxMeasureOne = 1060;
                            }
                            break;
                        case 1015:
                            if (m_Timer.GetMicroSecondTime() - timeStart >= 1000)
                            {
                                m_RunIdxMeasureOne = 1020;
                            }
                            break;

                        case 1020:
                            //最小平方
                            if (m_ResistorList.ElementAt(resID).RelayIdx % 2 == 0)
                            { m_Meter.TrigADC2(ref measureValue, ref measureValueSrc2); }
                            else
                            { m_Meter.TrigADC2(ref measureValueSrc2, ref measureValue); }
                            measureValue = measureValue + res.NominalDesign * res.MeasureBias / 100;
                            dataMaster.Add(measureValue);
                            dataMaster.RemoveAt(0);
                            dataMaster1.Add(measureValue);
                            dataMaster1.RemoveAt(0);
                            dataSlave.Add(measureValueSrc2 + m_ResistorList.ElementAt(resID + 1).NominalDesign * m_ResistorList.ElementAt(resID + 1).MeasureBias / 100);
                            dataSlave.RemoveAt(0);
                            if (m_CutIdx == 2)
                            {
                                Points.Clear();
                                //最後一刀
                                for (i = 0; i < AvgNum1; i++)
                                {
                                    PointF pts;
                                    pts.X = i;
                                    pts.Y = dataMaster1[i];
                                    Points.Add(pts);
                                }
                                CurveFunctions.FindLinearLeastSquaresFit(Points, out BestM, out BestB);
                                meanMaster1 = 0;
                                for (i = 0; i < AvgNum1; i++)
                                {
                                    meanMaster1 = meanMaster1 + (double)((BestM * i + BestB) / AvgNum1);
                                }
                                // meanMaster1 = BestM * AvgNum1 + BestB;

                                //meanMaster1 = BestM * (AvgNum - 1) + BestB;
                                meanMaster = meanMaster1;
                                //meanMaster1 =  (double)((BestM * (AvgNum1-1) + BestB));
                                trimmedData.PostVal = meanMaster1;
                            }
                            else
                            {
                                Points.Clear();
                                for (i = 0; i < AvgNum; i++)
                                {
                                    PointF pts;
                                    pts.X = i;
                                    pts.Y = dataMaster[i];
                                    Points.Add(pts);
                                }
                                CurveFunctions.FindLinearLeastSquaresFit(Points, out BestM, out BestB);
                                meanMaster = 0;
                                for (i = 0; i < AvgNum; i++)
                                {
                                    meanMaster = meanMaster + (double)((BestM * i + BestB) / AvgNum);
                                }
                                // meanMaster = BestM * AvgNum + BestB;
                                // meanMaster  =  (double)((BestM * (AvgNum-1) + BestB));
                                meanMaster1 = meanMaster;
                                trimmedData.PostVal = meanMaster1;
                                //meanMaster = meanMaster + (double)((measureValue - data.ElementAt(0)) / AvgNum);
                                //trimmedData.PostVal = meanMaster;
                            }
                            trimmedData.PostPercent = (meanMaster - res.NominalDesign) / res.NominalDesign * 100;

                            if (firstLaserOff == true)
                            {
                                if (meanMaster1 >= resValueStop)//m_ResistorList.ElementAt(resID).NominalReal)
                                {
                                    // m_AnalysisData[m_AnalysisIdx].PosX = 10;
                                    errCode = m_InstantDoCtrl.Write(0, 0);
                                    if (errCode != ErrorCode.Success)
                                    {
                                        throw new System.ArgumentException("WriteBit fail", "Hardware Error");
                                    }
                                    firstLaserOff = false;
                                    //m_Laser.LaserEmissionOn = false;
                                }
                            }


                            if (m_ChangeRes)
                            {
                                timeStart = m_Timer.GetMicroSecondTime();
                                m_RunIdxMeasureOne = 1040;
                            }
                            break;

                        case 1040:
                            if (m_ResistorList.ElementAt(resID).RelayIdx % 2 == 0)
                            {
                                m_Meter.TrigADC2(ref measureValue, ref measureValueSrc2);
                            }
                            else
                            {
                                m_Meter.TrigADC2(ref measureValueSrc2, ref measureValue);
                            }
                            measureValue = measureValue + res.NominalDesign * res.MeasureBias / 100;
                            dataMaster.Add(measureValue);
                            dataMaster.RemoveAt(0);
                            dataMaster1.Add(measureValue);
                            dataMaster1.RemoveAt(0);
                            dataSlave.Add(measureValueSrc2 + m_ResistorList.ElementAt(resID + 1).NominalDesign * m_ResistorList.ElementAt(resID + 1).MeasureBias / 100);
                            dataSlave.RemoveAt(0);
                            //最後一刀
                            meanMaster1 = 0;
                            for (i = 0; i < AvgNum1; i++)
                            {
                                meanMaster1 = meanMaster1 + (double)(dataMaster1[i] / AvgNum1);
                            }

                            // meanMaster1 = BestM * AvgNum1 + BestB;

                            meanMaster = meanMaster1;
                            trimmedData.PostVal = meanMaster1;
                            trimmedData.PostPercent = (trimmedData.PostVal - res.NominalDesign) / res.NominalDesign * 100;
                            if (m_Timer.GetMicroSecondTime() - timeStart >= 350)
                            {
                                //最後一次把熱阻轉換成冷阻
                                trimmedData.PostVal = (meanMaster1 + res.NominalDesign * res.MeasureHotBias / 100);
                                trimmedData.PostPercent = (trimmedData.PostVal - res.NominalDesign) / res.NominalDesign * 100;
                                m_RdyToTrim = false;
                                dataMaster.Clear();
                                dataMaster1.Clear();
                                meanMaster = 0;
                                meanMaster1 = 0;
                                m_PwModulatorCtrl.Enabled = false;
                                m_RunIdxMeasureOne = 0;
                                m_ChangeRes = false;
                            }
                            break;

                        case 1060:
                            if (m_ChangeRes)
                            {
                                m_RdyToTrim = false;
                                dataMaster.Clear();
                                dataMaster1.Clear();
                                meanMaster = 0;
                                meanMaster1 = 0;
                                m_PwModulatorCtrl.Enabled = false;
                                m_RunIdxMeasureOne = 0;
                                m_ChangeRes = false;
                            }
                            break;
                    }
                    if (m_IsLogUsed == true && m_RunIdxMeasureOne > 1010)
                    {
                        if (m_AnalysisIdx < m_AnalysisData.Length)
                        {
                            m_AnalysisData[m_AnalysisIdx].TimeStamp = m_Timer.GetMicroSecondTime();
                            curPosX = m_ResistorList.ElementAt(resID).GalvoXPos + m_PanelList.ElementAt(colID).GalvoColOffsetX;
                            curPosY = m_ResistorList.ElementAt(resID).GalvoYPos + m_PanelList.ElementAt(colID).GalvoColOffsetY;
                            m_AnalysisData[m_AnalysisIdx].PosX = m_CurPosX - curPosX;
                            m_AnalysisData[m_AnalysisIdx].PosY = m_CurPosY - curPosY;
                            m_AnalysisData[m_AnalysisIdx].ResVal = trimmedData.PostPercent;
                            m_AnalysisIdx = m_AnalysisIdx + 1;
                        }
                    }
                }
            }
            catch (Exception e)
            { throw new System.ArgumentException(e.ToString(), "MeasureOne"); }
            dataMaster.Clear();
            m_ThreadMeasureFinished = true;
        }

        public void TrimOne()
        {
            m_DestTrimId = m_CurrentResId;
            while (m_RunIdxTrimOne != 0)
            { SpinWait.SpinUntil(() => false, 1); }
            m_RunIdxTrimOne = 1000;
            while (m_RunIdxTrimOne != 0)
            { SpinWait.SpinUntil(() => false, 1); }
        }
        public void TrimAll()
        {
            m_DestTrimId = m_TotalResistor;
            while (m_RunIdxTrimOne != 0)
            { SpinWait.SpinUntil(() => false, 1); }
            m_RunIdxTrimOne = 1000;
            while (m_RunIdxTrimOne != 0)
            { SpinWait.SpinUntil(() => false, 1); }
        }

        public void TurnLaserOff()
        {
            short ret;
            ushort cardNum = 0;
            byte portValue;
            portValue = 0x0;
            ErrorCode errCode;
            errCode = m_InstantDoCtrl.Write(0, portValue);
            if (errCode != ErrorCode.Success)
            {
                throw new System.ArgumentException("WriteBit fail", "Hardware Error");
            }
            // m_Laser.LaserEmissionOn = false;
        }

        private CLaser m_Laser;

        public void LaserEmissionON()
        {
            m_Laser.LaserEmissionOn = true;


        }

        public void LaserEmissionOFF()
        {
            m_Laser.LaserEmissionOn = false;

        }
        public void TurnTrigOn()
        {
            m_PwModulatorCtrl.Enabled = true;
        }
        public void TurnTrigOFF()
        {
            m_PwModulatorCtrl.Enabled = false;
        }

        public void TurnLaserOn()
        {
            //m_Laser.LaserEmissionOn = true;

            ErrorCode errCode;
            errCode = m_InstantDoCtrl.Write(0, 1);
            if (errCode != ErrorCode.Success)
            {
                throw new System.ArgumentException("WriteBit fail", "Hardware Error");
            }
            ////////////////////////Thread.Sleep(100);
            //m_Laser.OperatingPower = 50;
            //Thread.Sleep(100);
            //m_Laser.PRR = 20;

            //short ret;
            //ushort cardNum = 0;
            //uint portValue;
            //portValue = 0x1;
            //ret = D2KDASK.D2K_DO_WritePort(cardNum, (ushort)0, (uint)portValue);
            //Thread.Sleep(1000);
            //TurnLaserOff();
        }

        public void GalvoAbsMove(double XPos, double YPos)
        {
            m_CurPosX = XPos;
            double x_Pos = m_CurPosX * m_ScaleFactorX;
            m_CurPosY = YPos;
            double y_Pos = m_CurPosY * m_ScaleFactorY;
            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
        }
        public void GalvoRelMove(double XDist, double YDist)
        {
            m_CurPosX = m_CurPosX + XDist;
            double x_Pos = m_CurPosX * m_ScaleFactorX;
            m_CurPosY = m_CurPosY + YDist;
            double y_Pos = m_CurPosY * m_ScaleFactorY;
            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);
        }
        /// <summary>
        /// ResId start from 1
        /// </summary>
        /// <param name="ResId"></param>
        public void GoToResistor(int ResId)
        {
            if (ResId < 1)
            {
                ResId = 1;
            }
            if (ResId > m_TotalResistor)
            {
                ResId = m_TotalResistor;
            }
            m_CurrentResId = ResId;
            CRes res = m_ResistorList.ElementAt(ResId - 1);

            CPanel panel = m_PanelList.ElementAt(m_CurrentColId - 1);
            double x_Pos = (res.GalvoXPos + panel.GalvoColOffsetX) * m_ScaleFactorX;
            m_CurPosX = (res.GalvoXPos + panel.GalvoColOffsetX);
            double y_Pos = (res.GalvoYPos + panel.GalvoColOffsetY) * m_ScaleFactorY;
            m_CurPosY = (res.GalvoYPos + panel.GalvoColOffsetY);
            m_PseudoGalvo.GalvoAbsMove(x_Pos, y_Pos);

        }

        public void GuideLaserOff()
        {
            //m_Laser.LaserEmissionOn = false;
            //Thread.Sleep(50);
            m_Laser.GuideLaserOn = false;
        }
        public void GuideLaserOn()
        {
            //m_Laser.LaserEmissionOn = true;
            m_Laser.LaserEmissionOn = false;
            //Thread.Sleep(50);

            SpinWait.SpinUntil(() => false, 50);
            m_Laser.GuideLaserOn = true;
        }

        public double LaserPower
        {
            get { return m_SetPower; }
            set
            {
                //    value = 44;
                m_SetPower = value;
                m_Laser.OperatingPower = value;
            }
        }

        private double m_SetPRR;
        public double LaserPRR
        {
            get { return m_SetPRR; }
            set
            {
                if (m_SetPRR != value)
                {
                    m_SetPRR = value;
                    m_Laser.LaserEmissionOn = false;
                    m_Laser.PRR = value;
                    m_Laser.LaserEmissionOn = true;
                }
            }
        }


        public int LaserPulseWidth
        {
            get { return m_SetPulseWidth; }
            set
            {
                m_SetPulseWidth = value;
                m_Laser.OperatingModes = m_SetPulseWidth.ToString();
            }
        }


    }
}
