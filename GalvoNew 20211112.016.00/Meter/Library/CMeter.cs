#define ResSize0201 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Meter.HeaderFile;
using Timer;
namespace Meter
{
    public struct ProbeMap
    {
        public int HiEnd;
        public int LowEnd;
    }
    public class CMeter
    {
        private const uint MAX_RESISTOR = 120;
        private bool m_IsHwPassed;
        private uint m_PortValue;
        private long[,] m_RelayValue;
        private int[] m_RelayOldValue;
        private int[] m_ProbeMapSource;
        private int[] m_ProbeMapSense;
        private double m_TargetRes;
        private double m_FirstRes;
        private double m_FinalRes;
        /// <summary>
        /// 量測到的阻值
        /// </summary>
        private double m_MeasureRes;
        private long m_MeasureADC;
        private SerialPort m_ComPort;
        private SerialPort m_ComPort2;
        private CHighResolutionTimeStamps m_Timer;
        private int m_KpGain;
        private int m_KpGain1;
        private int m_KpGain2;
        private double m_Current1;
        private double m_Current2;
        private double m_ResValue1;
        private double m_ResValue2;
        //private List<string> m_BinaryADC;
        public CMeter(bool IsHwPassed)
        {
            m_Current1 = 10;
            m_Current2 = 10;
            m_ResValue1 = 1000;
            m_ResValue2 = 1000;
            m_KpGain = 1;
            m_KpGain1 = 1;
            m_KpGain2 = 1;

            m_RelayValue = new long[12, 4];
            m_RelayOldValue = new int[2];
            m_RelayOldValue[0] = -1;
            m_RelayOldValue[1] = -1;
            m_HF = -1;
            m_LF = -1;
            m_HS = -1;
            m_LS = -1;

            m_IsHwPassed = IsHwPassed;
            if (m_Timer == null) { m_Timer = new CHighResolutionTimeStamps(); }
            //4
            if (!m_IsHwPassed)
            {
                //m_ComPort = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                //if (!m_ComPort.IsOpen)
                // {
                // m_ComPort.Open();

                m_ComPort2 = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
                if (!m_ComPort2.IsOpen)
                {
                    m_ComPort2.Open();
                }
                // }
            }
            // SetRes(1000000,1000000,1000000);//1M
            //  SetRes2(1000000);
            //     m_BinaryADC = new List<String>(); 
            m_TargetRes = 1000000;
            //ADC2ResValue((long)52428, out resValue);
            m_ProbeMapSource = new int[24];
            m_ProbeMapSense = new int[24];
            //m_ProbeMap = new ProbeMap[MAX_RESISTOR];
            InitProbeMap();
            ReadMeterRange("");
            short ret;
            short card = 0;
            card = PCIS_DASK.Register_Card(PCIS_DASK.PCI_7200, 0);
            if (card < 0)
            {
                throw new System.ArgumentException("PCIS_DASK_Register_Card fail", "Hardware Error");
            }
            ret = PCIS_DASK.DO_WritePort(0, (ushort)0, (uint)0x0);
            ret = PCIS_DASK.DO_ReadPort(0, (ushort)0, out m_PortValue);
        }

        public void InitialHw()
        {
            ushort card = 0;
            short ret;
            ret = PCIS_DASK.DI_7200_Config(card, PCIS_DASK.TRIG_EXT_STROBE, PCIS_DASK.DI_NOWAITING, PCIS_DASK.DI_TRIG_RISING, PCIS_DASK.IREQ_RISING);
            ret = PCIS_DASK.DO_WritePort(card, (ushort)0, (uint)0x2C0000);
            ret = PCIS_DASK.DO_ReadPort(card, (ushort)0, out m_PortValue);
            ClearRelayMap();
        }

        public void CloseHw()
        {
            ushort card = 0;
            short ret;
            ClearRelayMap();
            ret = PCIS_DASK.DI_7200_Config(card, PCIS_DASK.TRIG_EXT_STROBE, PCIS_DASK.DI_NOWAITING, PCIS_DASK.DI_TRIG_RISING, PCIS_DASK.IREQ_RISING);
            ret = PCIS_DASK.DO_WritePort(card, (ushort)0, (uint)0x0);
            ret = PCIS_DASK.DO_ReadPort(card, (ushort)0, out m_PortValue);
        }

        ~CMeter()
        {
            ClearRelayMap();
            short ret;
            ret = PCIS_DASK.DO_WritePort(0, (ushort)0, (uint)0x0);
            m_ComPort2.Close();
        }
        /// <summary>
        /// Software Channel to Hardware Pin
        /// </summary>
        private void InitProbeMap()
        {
            for (int aryIdx = 0; aryIdx < m_ProbeMapSource.Length; aryIdx++)
            {
                m_ProbeMapSource[aryIdx] = aryIdx;
            }
            for (int aryIdx = 0; aryIdx < m_ProbeMapSense.Length; aryIdx++)
            {
                m_ProbeMapSense[aryIdx] = aryIdx;
            }
        }
        private double ADCMeterValue1;
        private double ADCMeterValue2;
        private double ADCMeterValue3;
        private double[] ADCRange;
        public double[] ADCValue1;
        public double[] ADCValue2;
        private double[] m_CurrValue1;
        private double[] m_CurrValue2;
        public void ReadMeterRange(string path)
        {
            //D:\\DataSettings\\LaserTrimming1610\\Machine\\Parameter\\GalvoOffsetX.txt
            //"C:\\Users\\ZhengYe\\Desktop\\123.txt"
            ADCMeterValue1 = 0;
            ADCMeterValue2 = 0;
            ADCMeterValue3 = 0;
            ADCRange = new double[20];
            for (int i = 0; i <= ADCRange.Length - 1; i++)
            {
                ADCRange[i] = 0;
            }
            m_CurrValue1 = new double[21];
            m_CurrValue2 = new double[21];

            m_CurrValue1[20] = 4;
            m_CurrValue2[20] = 4;
            ADCValue1 = new double[20];
            ADCValue2 = new double[20];
            for (int i = 0; i <= ADCValue1.Length - 1; i++)
            {
                ADCValue1[i] = 0;
                ADCValue2[i] = 0;
            }
            if (path == "")
            {
                path = "D:\\DataSettings\\LaserTrimming1610\\Machine\\Parameter\\Recipe1.txt";
            }
            string[] line;
            line = System.IO.File.ReadAllLines(path);
            for (int i = 0; i <= line.Length - 1; i++)
            {
                line[i] = line[i].Replace(" ", "");
                string[] str = line[i].Split(',');

                if (i == 0)
                {
                    if (str.Length == 2)
                    {
                        ADCMeterValue1 = Convert.ToDouble(str[0]);
                        ADCMeterValue2 = Convert.ToDouble(str[1]);
                    }
                    else if (str.Length > 2)
                    {
                        ADCMeterValue1 = Convert.ToDouble(str[0]);
                        ADCMeterValue2 = Convert.ToDouble(str[1]);
                        ADCMeterValue3 = Convert.ToDouble(str[2]);
                    }
                }
                else
                {
                    if (i <= 21)
                    {
                        m_CurrValue1[i - 1] = Convert.ToDouble(str[1]);
                    }
                    else
                    {
                      
                        if (str.Length >= 2 && (i-22) < ADCValue1.Length)
                        {
                            ADCRange[i - 22] = Convert.ToDouble(str[0]);
                            ADCValue1[i - 22] = Convert.ToDouble(str[1]);
                        }
                        else if (i <= ADCValue1.Length)
                        {
                            ADCValue1[i - 22] = Convert.ToDouble(str[0]);
                        }
                    }

                }
            }
            //-----------------------------------                
            path = "D:\\DataSettings\\LaserTrimming1610\\Machine\\Parameter\\Recipe2.txt";
            line = System.IO.File.ReadAllLines(path);
            for (int i = 0; i <= line.Length - 1; i++)
            {
                line[i] = line[i].Replace(" ", "");
                string[] str = line[i].Split(',');
                if (i == 0)
                {
                    if (str.Length == 2)
                    {
                        ADCMeterValue1 = Convert.ToDouble(str[0]);
                        ADCMeterValue2 = Convert.ToDouble(str[1]);
                    }
                    else if (str.Length > 2)
                    {
                        ADCMeterValue1 = Convert.ToDouble(str[0]);
                        ADCMeterValue2 = Convert.ToDouble(str[1]);
                        ADCMeterValue3 = Convert.ToDouble(str[2]);
                    }
                }
                else
                {
                    if (i <= 21)
                    {
                        m_CurrValue2[i - 1] = Convert.ToDouble(str[1]);
                    }
                    else
                    {
                        if (str.Length >= 2 && (i-22) < ADCValue1.Length)
                        {
                            ADCRange[i - 22] = Convert.ToDouble(str[0]);
                            ADCValue2[i - 22] = Convert.ToDouble(str[1]);
                        }
                        else if (i <= ADCValue1.Length)
                        {
                            ADCValue2[i - 22] = Convert.ToDouble(str[0]);
                        }
                    }

                }
            }
        }
        //public void SelectRelayMap(ProbeMap RelayID)
        //{
        //    int relayCardNum=0;
        //    int relayIdx = 0;
        //    int relayChannelNum = 0;
        //    //High End
        //    relayCardNum = RelayID.HiEnd / 24;
        //    relayIdx = RelayID.HiEnd % 24;
        //    //Set HF
        //    relayChannelNum = m_ProbeMapSource[relayIdx];
        //    SetOutput(relayCardNum, relayChannelNum);
        //    HighSourceLatch();
        //    //Set HS
        //    relayChannelNum = m_ProbeMapSense[relayIdx];
        //    SetOutput(relayCardNum, relayChannelNum);
        //    HighSenseLatch();
        //    //Low End
        //    relayCardNum = RelayID.LowEnd / 12;
        //    relayIdx = RelayID.LowEnd % 12;
        //    //Set LF
        //    relayChannelNum = m_ProbeMapSource[relayIdx];
        //    SetOutput(relayCardNum, relayChannelNum);
        //    LowSourceLatch();
        //    //Set LS
        //    relayChannelNum = m_ProbeMapSense[relayIdx];
        //    SetOutput(relayCardNum, relayChannelNum);
        //    LowSenseLatch();
        //    m_Timer.DelayMicroSec(10);

        //}
        int m_HF;
        int m_LF;
        int m_HS;
        int m_LS;

        public void ClearRelayMap()
        {
            //InitProbeMap();
            int cardIdx = 0;
            int channelIdx = 0;
            int relayIdx = 0;


            long cardValue;
            string cardBin;
            long channelValue;
            string channelBin;

            long relayValue;
            string relayBin;

            long portValue;
            string portBin;
            short ret;

            for (cardIdx = 0; cardIdx < 10; cardIdx++)
            {
                cardValue = cardIdx << 10;
                cardBin = Convert.ToString(cardValue, 2);
                for (channelIdx = 0; channelIdx < 4; channelIdx++)
                {
                    m_RelayValue[cardIdx, channelIdx] = 0;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//00000000

                    channelValue = channelIdx << 8;
                    channelBin = Convert.ToString(channelValue, 2);

                    //relayValue = relayValue;
                    relayBin = Convert.ToString(relayValue, 2);


                    portValue = cardValue + channelValue + relayValue;
                    portBin = Convert.ToString(portValue, 2);

                    portValue = (m_PortValue & 0xFFFF0000) + portValue;
                    portBin = Convert.ToString(portValue, 2);
                    m_PortValue = (uint)portValue;

                    ret = PCIS_DASK.DO_WritePort(0, (ushort)0, m_PortValue);
                    m_Timer.DelayMicroSec(10);

                    //portValue = (1 << 19)+ (1 << 21);
                    //portValue = (m_PortValue & 0xFFD7FFFF) + portValue;
                    //portBin = Convert.ToString(portValue, 2);

                    //m_PortValue = (uint)portValue;
                    //ret = PCIS_DASK.DO_WritePort(0, (ushort)0, m_PortValue);
                    //m_Timer.DelayMicroSec(10);

                    portValue = (0 << 19) + (0 << 21);
                    portValue = (m_PortValue & 0xFFD7FFFF) + portValue;

                    portBin = Convert.ToString(portValue, 2);

                    m_PortValue = (uint)portValue;
                    ret = PCIS_DASK.DO_WritePort(0, (ushort)0, m_PortValue);
                    m_Timer.DelayMicroSec(10);

                    portValue = (1 << 19) + (1 << 21);
                    portValue = (m_PortValue & 0xFFD7FFFF) + portValue;

                    portBin = Convert.ToString(portValue, 2);

                    m_PortValue = (uint)portValue;
                    ret = PCIS_DASK.DO_WritePort(0, (ushort)0, m_PortValue);
                    m_Timer.DelayMicroSec(10);
                }
            }
            m_RelayOldValue[0] = -1;
            m_RelayOldValue[1] = -1;

        }

        /// <summary>
        /// ResIdx = 0 ~ 119
        /// </summary>
        /// <param name="ResIdx"></param>
        public void SelectRelayMap(int ResIdx)
        {
            //  return;
            int resOldIdx = -1;
            int cardIdx = 0;
            int channelIdx = 0;
            int relayIdx = 0;


            long cardValue;
            string cardBin;
            long channelValue;
            string channelBin;

            long relayValue;
            string relayBin;

            long portValue;
            string portBin;
            short ret;


            #region "並聯先上新的"
            cardIdx = (int)(ResIdx / 12);
            relayIdx = ResIdx % 12;
            //並聯先上新的Relay
            switch (relayIdx)
            {
                case 0:
                    channelIdx = 0;//00
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 3;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0000_0011
                    break;
                case 1:
                    channelIdx = 2;//10
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 3;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0000_0011
                    break;
                case 2:
                    channelIdx = 0;//00
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 12;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1100
                    break;
                case 3:
                    channelIdx = 2;//10
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 12;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1100
                    break;
                case 4:
                    channelIdx = 0;
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 48;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0011_0000
                    break;
                case 5:
                    channelIdx = 2;
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 48;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0011_0000
                    break;
                case 6:
                    channelIdx = 0;
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 192;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//1100_0000
                    break;
                case 7:
                    channelIdx = 2;
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 192;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//1100_0000
                    break;
                case 8:
                    channelIdx = 1;
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 3;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0000_0011
                    break;
                case 9:
                    channelIdx = 3;
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 3;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0000_0011
                    break;
                case 10:
                    channelIdx = 1;
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 12;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1100
                    break;
                default://11
                    channelIdx = 3;
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 12;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1100
                    break;
            }
            #region "Latch"
            cardValue = cardIdx << 10;
            cardBin = Convert.ToString(cardValue, 2);
            channelValue = channelIdx << 8;
            channelBin = Convert.ToString(channelValue, 2);
            //relayValue = relayValue;
            relayBin = Convert.ToString(relayValue, 2);
            portValue = cardValue + channelValue + relayValue;
            portBin = Convert.ToString(portValue, 2);
            portValue = (m_PortValue & 0xFFFF0000) + portValue;
            portBin = Convert.ToString(portValue, 2);
            m_PortValue = (uint)portValue;
            ret = PCIS_DASK.DO_WritePort(0, (ushort)0, m_PortValue);
            m_Timer.DelayMicroSec(5);
            //Low->High
            if ((channelIdx == 0) || (channelIdx == 1))
            {
                portValue = (0 << 19);
                portValue = (m_PortValue & 0xFFF7FFFF) + portValue;
            }
            else
            {
                portValue = (0 << 21);
                portValue = (m_PortValue & 0xFFDFFFFF) + portValue;
            }
            portBin = Convert.ToString(portValue, 2);
            m_PortValue = (uint)portValue;
            ret = PCIS_DASK.DO_WritePort(0, (ushort)0, m_PortValue);
            m_Timer.DelayMicroSec(5);
            if ((channelIdx == 0) || (channelIdx == 1))
            {
                portValue = (1 << 19);
                portValue = (m_PortValue & 0xFFF7FFFF) + portValue;
            }
            else
            {
                portValue = (1 << 21);
                portValue = (m_PortValue & 0xFFDFFFFF) + portValue;
            }
            m_PortValue = (uint)portValue;
            ret = PCIS_DASK.DO_WritePort(0, (ushort)0, m_PortValue);
            m_Timer.DelayMicroSec(5);
            #endregion
            //再選擇哪一張板子
            switch (relayIdx)
            {
                case 0:
                    channelIdx = 1;//00
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 16;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0000_0011
                    break;
                case 1:
                    channelIdx = 1;//10
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 32;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0000_0011
                    break;
                case 2:
                    channelIdx = 1;//00
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 16;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1100
                    break;
                case 3:
                    channelIdx = 1;//10
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 32;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1100
                    break;
                case 4:
                    channelIdx = 1;
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 16;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0011_0000
                    break;
                case 5:
                    channelIdx = 1;
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 32;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0011_0000
                    break;
                case 6:
                    channelIdx = 1;
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 16;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//1100_0000
                    break;
                case 7:
                    channelIdx = 1;
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 32;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//1100_0000
                    break;
                case 8:
                    channelIdx = 1;
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 16;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0000_0011
                    break;
                case 9:
                    channelIdx = 1;
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 32;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0000_0011
                    break;
                case 10:
                    channelIdx = 1;
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 16;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1100
                    break;
                default://11
                    channelIdx = 1;
                    m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] | 32;
                    relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1100
                    break;
            }
            #region "Latch"
            cardValue = cardIdx << 10;
            cardBin = Convert.ToString(cardValue, 2);
            channelValue = channelIdx << 8;
            channelBin = Convert.ToString(channelValue, 2);
            //relayValue = relayValue;
            relayBin = Convert.ToString(relayValue, 2);
            portValue = cardValue + channelValue + relayValue;
            portBin = Convert.ToString(portValue, 2);
            portValue = (m_PortValue & 0xFFFF0000) + portValue;
            portBin = Convert.ToString(portValue, 2);
            m_PortValue = (uint)portValue;
            ret = PCIS_DASK.DO_WritePort(0, (ushort)0, m_PortValue);
            m_Timer.DelayMicroSec(5);
            //Low->High
            portValue = (0 << 19);
            portValue = (m_PortValue & 0xFFF7FFFF) + portValue;
            portBin = Convert.ToString(portValue, 2);
            m_PortValue = (uint)portValue;
            ret = PCIS_DASK.DO_WritePort(0, (ushort)0, m_PortValue);
            m_Timer.DelayMicroSec(5);
            portValue = (1 << 19);
            portValue = (m_PortValue & 0xFFF7FFFF) + portValue;
            m_PortValue = (uint)portValue;
            ret = PCIS_DASK.DO_WritePort(0, (ushort)0, m_PortValue);
            //m_Timer.DelayMicroSec(10);
            m_Timer.DelayMicroSec(350);
            #endregion
            #endregion


            #region "再關舊的"
            if (ResIdx % 2 == 0)
            {
                resOldIdx = m_RelayOldValue[0];
            }
            else
            {
                resOldIdx = m_RelayOldValue[1];
            }
            if (resOldIdx != -1)
            {
                if (ResIdx != resOldIdx)
                {
                    // 再把上一顆舊的關掉
                    cardIdx = (int)(resOldIdx / 12);
                    relayIdx = resOldIdx % 12;
                    switch (relayIdx)
                    {
                        case 0:
                            channelIdx = 0;
                            m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~3;
                            relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1111 -> 0000_0011
                            break;
                        case 1:
                            channelIdx = 2;
                            m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~3;
                            relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1111 -> 0000_0011
                            break;
                        case 2:
                            channelIdx = 0;
                            m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~12;
                            relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1111 -> 0000_0011
                            break;
                        case 3:
                            channelIdx = 2;
                            m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~12;
                            relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1111 -> 0000_0011
                            break;
                        case 4:
                            channelIdx = 0;
                            m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~48;
                            relayValue = m_RelayValue[cardIdx, channelIdx];//1111_0000 -> 0011_00000
                            break;
                        case 5:
                            channelIdx = 2;
                            m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~48;
                            relayValue = m_RelayValue[cardIdx, channelIdx];//1111_0000 -> 0011_00000
                            break;
                        case 6:
                            channelIdx = 0;
                            m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~192;
                            relayValue = m_RelayValue[cardIdx, channelIdx];//0000_0000
                            break;
                        case 7:
                            channelIdx = 2;
                            m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~192;
                            relayValue = m_RelayValue[cardIdx, channelIdx];//0000_0000
                            break;
                        case 8:
                            channelIdx = 1;
                            m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~3;
                            relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1111 -> 0000_0011
                            break;
                        case 9:
                            channelIdx = 3;
                            m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~3;
                            relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1111 -> 0000_0011
                            break;
                        case 10:
                            channelIdx = 1;
                            m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~12;
                            relayValue = m_RelayValue[cardIdx, channelIdx];
                            break;
                        default://11
                            channelIdx = 3;
                            m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~12;
                            relayValue = m_RelayValue[cardIdx, channelIdx];
                            break;
                    }
                    #region "Latch"
                    cardValue = cardIdx << 10;
                    cardBin = Convert.ToString(cardValue, 2);
                    channelValue = channelIdx << 8;
                    channelBin = Convert.ToString(channelValue, 2);
                    //relayValue = relayValue;
                    relayBin = Convert.ToString(relayValue, 2);
                    portValue = cardValue + channelValue + relayValue;
                    portBin = Convert.ToString(portValue, 2);
                    portValue = (m_PortValue & 0xFFFF0000) + portValue;
                    portBin = Convert.ToString(portValue, 2);
                    m_PortValue = (uint)portValue;
                    ret = PCIS_DASK.DO_WritePort(0, (ushort)0, m_PortValue);
                    m_Timer.DelayMicroSec(5);
                    //Low->High
                    if ((channelIdx == 0) || (channelIdx == 1))
                    {
                        portValue = (0 << 19);
                        portValue = (m_PortValue & 0xFFF7FFFF) + portValue;
                    }
                    else
                    {
                        portValue = (0 << 21);
                        portValue = (m_PortValue & 0xFFDFFFFF) + portValue;
                    }
                    portBin = Convert.ToString(portValue, 2);
                    m_PortValue = (uint)portValue;
                    ret = PCIS_DASK.DO_WritePort(0, (ushort)0, m_PortValue);
                    m_Timer.DelayMicroSec(5);
                    if ((channelIdx == 0) || (channelIdx == 1))
                    {
                        portValue = (1 << 19);
                        portValue = (m_PortValue & 0xFFF7FFFF) + portValue;
                    }
                    else
                    {
                        portValue = (1 << 21);
                        portValue = (m_PortValue & 0xFFDFFFFF) + portValue;
                    }
                    m_PortValue = (uint)portValue;
                    ret = PCIS_DASK.DO_WritePort(0, (ushort)0, m_PortValue);
                    m_Timer.DelayMicroSec(10);
                    #endregion
                    if ((int)(ResIdx / 12) != (int)(resOldIdx / 12))
                    {
                        switch (relayIdx)
                        {
                            case 0:
                                channelIdx = 1;
                                m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~16;
                                relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1111 -> 0000_0011
                                break;
                            case 1:
                                channelIdx = 1;
                                m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~32;
                                relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1111 -> 0000_0011
                                break;
                            case 2:
                                channelIdx = 1;
                                m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~16;
                                relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1111 -> 0000_0011
                                break;
                            case 3:
                                channelIdx = 1;
                                m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~32;
                                relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1111 -> 0000_0011
                                break;
                            case 4:
                                channelIdx = 1;
                                m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~16;
                                relayValue = m_RelayValue[cardIdx, channelIdx];//1111_0000 -> 0011_00000
                                break;
                            case 5:
                                channelIdx = 1;
                                m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~32;
                                relayValue = m_RelayValue[cardIdx, channelIdx];//1111_0000 -> 0011_00000
                                break;
                            case 6:
                                channelIdx = 1;
                                m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~16;
                                relayValue = m_RelayValue[cardIdx, channelIdx];//0000_0000
                                break;
                            case 7:
                                channelIdx = 1;
                                m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~32;
                                relayValue = m_RelayValue[cardIdx, channelIdx];//0000_0000
                                break;
                            case 8:
                                channelIdx = 1;
                                m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~16;
                                relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1111 -> 0000_0011
                                break;
                            case 9:
                                channelIdx = 1;
                                m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~32;
                                relayValue = m_RelayValue[cardIdx, channelIdx];//0000_1111 -> 0000_0011
                                break;
                            case 10:
                                channelIdx = 1;
                                m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~16;
                                relayValue = m_RelayValue[cardIdx, channelIdx];
                                break;
                            default://11
                                channelIdx = 1;
                                m_RelayValue[cardIdx, channelIdx] = m_RelayValue[cardIdx, channelIdx] & ~32;
                                relayValue = m_RelayValue[cardIdx, channelIdx];
                                break;
                        }
                        #region "Latch"
                        cardValue = cardIdx << 10;
                        cardBin = Convert.ToString(cardValue, 2);
                        channelValue = channelIdx << 8;
                        channelBin = Convert.ToString(channelValue, 2);
                        //relayValue = relayValue;
                        relayBin = Convert.ToString(relayValue, 2);
                        portValue = cardValue + channelValue + relayValue;
                        portBin = Convert.ToString(portValue, 2);
                        portValue = (m_PortValue & 0xFFFF0000) + portValue;
                        portBin = Convert.ToString(portValue, 2);
                        m_PortValue = (uint)portValue;
                        ret = PCIS_DASK.DO_WritePort(0, (ushort)0, m_PortValue);
                        m_Timer.DelayMicroSec(5);
                        //Low->High
                        portValue = (0 << 19);
                        portValue = (m_PortValue & 0xFFF7FFFF) + portValue;
                        portBin = Convert.ToString(portValue, 2);
                        m_PortValue = (uint)portValue;
                        ret = PCIS_DASK.DO_WritePort(0, (ushort)0, m_PortValue);
                        m_Timer.DelayMicroSec(5);
                        portValue = (1 << 19);
                        portValue = (m_PortValue & 0xFFF7FFFF) + portValue;
                        m_PortValue = (uint)portValue;
                        ret = PCIS_DASK.DO_WritePort(0, (ushort)0, m_PortValue);
                        m_Timer.DelayMicroSec(10);
                        #endregion
                    }
                }
            }
            #endregion

            if (ResIdx % 2 == 0)
            {
                m_RelayOldValue[0] = ResIdx;
            }
            else
            {
                m_RelayOldValue[1] = ResIdx;
            }
        }
        internal void SelectRelayMap(int HF, int HS, int LF, int LS)
        {
        }
        private void SetOutput(int CardId, int BitId)
        {
        }
        private void HighSourceLatch()
        {


        }
        private void HighSenseLatch()
        {

        }
        private void LowSourceLatch()
        {

        }
        private void LowSenseLatch()
        {

        }

        public void InitADC()
        {
            //m_BinaryADC.Clear();
        }

        public void EndADC()
        {

        }
        /// <summary>
        /// 一筆資料5us
        /// </summary>
        /// <param name="ResValue"></param>
        internal void TrigADC(ref double ResValue)
        {
        }

        internal void TrigADC2(ref double ResValue1, ref double ResValue2)
        {
            // const short adcCnvstBit = 10;//轉換腳位 Low觸發
            uint outValue1 = 256;
            uint outValue2 = 256;
            short ret;
            ushort cardNum = 0;
            uint[] data_buffer = new uint[1];
            uint busy = 0;


            //二代電壓高表示轉換完成
            do
            {
                //CHighResolutionTimeStamps timer = new CHighResolutionTimeStamps();
                // double test = timer.GetMicroSecondTime();
                ret = PCIS_DASK.DI_ReadPort(cardNum, 0, out data_buffer[0]);
                // test = timer.GetMicroSecondTime() - test;
                outValue1 = data_buffer[0];
                busy = outValue1 & 0x1;
            } while (busy == 0);

            outValue1 = data_buffer[0];
            outValue1 = outValue1 & 0xFFFE;//Bit0 是Busy
            outValue2 = data_buffer[0];
            outValue2 = outValue2 & 0xFFFE0000;//Bit0 是Busy
            outValue2 = outValue2 / 65536;


            m_MeasureADC = outValue1;
            //ADC轉實際阻值
            ADC2ResValue1(m_MeasureADC, out m_MeasureRes);
            ResValue1 = m_MeasureRes;

            m_MeasureADC = outValue2;
            //ADC轉實際阻值
            ADC2ResValue2(m_MeasureADC, out m_MeasureRes);
            ResValue2 = m_MeasureRes;
        }

        internal void TrigADC(ref double[] ResValue)
        {
        }


        internal void TrigADC2(ref double[] ResValue1, ref double[] ResValue2)
        {
            uint outValue1 = 256;
            uint outValue2 = 256;
            short ret;
            ushort cardNum = 0;
            uint[] data_buffer = new uint[ResValue1.Length];

            ret = PCIS_DASK.DI_ContReadPort(cardNum, 0, data_buffer, (uint)data_buffer.Length, PCIS_DASK.CLKSRC_EXT_SampRate, PCIS_DASK.SYNCH_OP);
            for (int i = 0; i < data_buffer.Length; i++)
            {
                outValue1 = data_buffer[i];
                outValue1 = outValue1 & 0xFFFE;//Bit0 是Busy
                outValue2 = data_buffer[i];
                outValue2 = outValue2 & 0xFFFE0000;//Bit0 是Busy
                outValue2 = outValue2 / 65536;

                m_MeasureADC = outValue1;
                //ADC轉實際阻值
                ADC2ResValue1(m_MeasureADC, out m_MeasureRes);
                ResValue1[i] = m_MeasureRes;

                m_MeasureADC = outValue2;
                //ADC轉實際阻值
                ADC2ResValue2(m_MeasureADC, out m_MeasureRes);
                ResValue2[i] = m_MeasureRes;
            }
        }

        internal void TrigADC2(ref double[] ResValue1, ref double[] ResValue2, ref double[] AdcValue1, ref double[] AdcValue2)
        {
            uint outValue1 = 256;
            uint outValue2 = 256;
            short ret;
            ushort cardNum = 0;
            uint[] data_buffer = new uint[ResValue1.Length];

            ret = PCIS_DASK.DI_ContReadPort(cardNum, 0, data_buffer, (uint)data_buffer.Length, PCIS_DASK.CLKSRC_EXT_SampRate, PCIS_DASK.SYNCH_OP);
            for (int i = 0; i < data_buffer.Length; i++)
            {
                outValue1 = data_buffer[i];
                outValue1 = outValue1 & 0xFFFE;//Bit0 是Busy
                outValue2 = data_buffer[i];
                outValue2 = outValue2 & 0xFFFE0000;//Bit0 是Busy
                outValue2 = outValue2 / 65536;

                m_MeasureADC = outValue1;
                //ADC轉實際阻值
                ADC2ResValue1(m_MeasureADC, out m_MeasureRes);
                AdcValue1[i] = m_MeasureADC;
                ResValue1[i] = m_MeasureRes;

                m_MeasureADC = outValue2;
                //ADC轉實際阻值
                ADC2ResValue2(m_MeasureADC, out m_MeasureRes);
                AdcValue2[i] = m_MeasureADC;
                ResValue2[i] = m_MeasureRes;
            }
        }
        /// <summary>
        /// 探卡沒接觸好開路狀況ADC變小
        /// 電流檔會在正常使用範圍
        /// 電壓檔會在錯誤範圍可以偵測
        /// </summary>
        /// <param name="ADC"></param>
        /// <param name="ResValue"></param>
        internal void ADC2ResValue1(long ADC, out double ResValue)
        {
            ResValue = 1;
#if ResSize0201
            if (m_TargetRes <= 1000)//0.2 ~ 2.4 ohm
            {
                ResValue = ((double)ADC * 10000 / 65535) / (m_Current1 * m_KpGain);

                //      ResValue = ADC;

            }
            else// if (m_TargetRes < 2400000)// 1603K ~ 2400K ohm
            {
                if (ADC <= 2000)
                { ResValue = 100000000; } //100M
                else
                {
                    // ResValue = ((double)7000 / (double)10000) * ((double)65536 / (double)ADC) * (double)1300000;
                    ResValue = ((double)ADCMeterValue1 / (double)ADCMeterValue3) * ((double)ADCMeterValue2 / (double)ADC) * m_ResValue1 * m_KpGain;
                }
            }
#else

#endif

        }
        /// <summary>
        /// 探卡沒接觸好開路狀況ADC變小
        /// 電流檔會在正常使用範圍
        /// 電壓檔會在錯誤範圍可以偵測
        /// </summary>
        /// <param name="ADC"></param>
        /// <param name="ResValue"></param>
        internal void ADC2ResValue2(long ADC, out double ResValue)
        {
            ResValue = 1;
#if ResSize0201
            if (m_TargetRes <= 1000)//0.2 ~ 2.4 ohm
            {
                ResValue = ((double)ADC * 10000 / 65535) / (m_Current2 * m_KpGain);

                //  ResValue = ADC;
            }
            else// if (m_TargetRes < 2400000)// 1603K ~ 2400K ohm
            {
                if (ADC <= 2000)
                { ResValue = 100000000; } //100M
                else
                {
                    // ResValue = ((double)7000 / (double)10000) * ((double)65536 / (double)ADC) * (double)1300000;
                    ResValue = ((double)ADCMeterValue1 / (double)ADCMeterValue3) * ((double)ADCMeterValue2 / (double)ADC) * m_ResValue2 * m_KpGain;
                }
            }
#else

#endif

        }


        public void SetRes(float FinalRes, float FirstRes, float TargetRes)
        {
            m_TargetRes = TargetRes;
            m_FirstRes = FirstRes;
            m_FinalRes = FinalRes;
        }

        public string GetFirmwareVer()
        {
            string resCode;
            resCode = "GETVER";

            Byte[] buffer = new Byte[resCode.Length + 2];
            for (int aryIdx = 0; aryIdx < resCode.Length; aryIdx++)
            {
                buffer[aryIdx] = Convert.ToByte(resCode.ElementAt(aryIdx));
            }
            buffer[resCode.Length] = 0x0D;
            buffer[resCode.Length + 1] = 0x0A;
            string rtnStr = "";
            if (!m_IsHwPassed)
            {
                m_ComPort2.Write(buffer, 0, resCode.Length + 2);
                //1System.Threading.Thread.Sleep(100);
                rtnStr = m_ComPort2.ReadLine();
                rtnStr = rtnStr.TrimEnd((char[])"\r\n".ToCharArray());
            }
            return rtnStr;
        }

        private int m_SourceMode = -1;
        /// <summary>
        /// mode = 0 CC   mode=1 CV
        /// </summary>
        /// <param name="SrcIdx"></param>
        /// <param name="Mode"></param>
        /// <returns></returns>
        public string SelDutSource(int SrcIdx, int Mode)
        {
            string rtnStr = "";
            int retryCnt = 0;

            // if (m_SourceMode != Mode)
            //  {
            m_SourceMode = Mode;
            m_CurIdx = -1;
            m_CurGainIdx = -1;
            m_PGAGainIdx = -1;
            string resCode;
            resCode = "SELDUTSOURCE " + SrcIdx.ToString() + "," + Mode.ToString();
            Byte[] buffer = new Byte[resCode.Length + 2];
            for (int aryIdx = 0; aryIdx < resCode.Length; aryIdx++)
            {
                buffer[aryIdx] = Convert.ToByte(resCode.ElementAt(aryIdx));
            }
            buffer[resCode.Length] = 0x0D;
            buffer[resCode.Length + 1] = 0x0A;
            if (!m_IsHwPassed)
            {
                while (retryCnt < 100)
                {
                    retryCnt++;
                    m_ComPort2.Write(buffer, 0, resCode.Length + 2);
                    //System.Threading.Thread.Sleep(1000);
                    rtnStr = m_ComPort2.ReadLine();
                    rtnStr = rtnStr.TrimEnd((char[])"\r\n".ToCharArray());
                    if (rtnStr == "OK")
                    {
                        break;
                    }
                }
            }
            return rtnStr;
        }
        /// <summary>
        /// SrcIdx = 1 ~ 2
        /// ResIdx =0 Clear All   1 ~ 20
        /// </summary>
        /// <param name="SrcIdx"></param>
        /// <param name="ResIdx"></param>
        /// <returns></returns>
        public string SelCvRes(int SrcIdx, int ResIdx)
        {
            string resCode;
            int retryCnt = 0;
            resCode = "SELCVRES " + SrcIdx.ToString() + "," + ResIdx.ToString();
            Byte[] buffer = new Byte[resCode.Length + 2];
            for (int aryIdx = 0; aryIdx < resCode.Length; aryIdx++)
            {
                buffer[aryIdx] = Convert.ToByte(resCode.ElementAt(aryIdx));
            }
            buffer[resCode.Length] = 0x0D;
            buffer[resCode.Length + 1] = 0x0A;
            string rtnStr = "";
            if (!m_IsHwPassed)
            {
                while (retryCnt < 100)
                {
                    retryCnt++;
                    m_ComPort2.Write(buffer, 0, resCode.Length + 2);
                    //System.Threading.Thread.Sleep(1000);
                    rtnStr = m_ComPort2.ReadLine();
                    rtnStr = rtnStr.TrimEnd((char[])"\r\n".ToCharArray());
                    if (rtnStr == "OK")
                    {
                        break;
                    }
                }
            }
            return rtnStr;
        }



        public string SetCalRes(int SrcIdx, int ResIdx, int ResValue)
        {
            string resCode;
            resCode = "SETCALRES " + SrcIdx.ToString() + "," + ResIdx.ToString() + "," + ResValue.ToString();
            Byte[] buffer = new Byte[resCode.Length + 2];
            for (int aryIdx = 0; aryIdx < resCode.Length; aryIdx++)
            {
                buffer[aryIdx] = Convert.ToByte(resCode.ElementAt(aryIdx));
            }
            buffer[resCode.Length] = 0x0D;
            buffer[resCode.Length + 1] = 0x0A;
            string rtnStr = "";
            if (!m_IsHwPassed)
            {
                int retryIdx = 0;
                while (retryIdx < 2000)
                {
                    retryIdx++;
                    m_ComPort2.ReadExisting();
                    m_ComPort2.Write(buffer, 0, resCode.Length + 2);
                    rtnStr = m_ComPort2.ReadLine();
                    rtnStr = rtnStr.TrimEnd((char[])"\r\n".ToCharArray());
                    if (rtnStr == "OK")
                    {
                        break;
                    }
                }
            }
            return rtnStr;
        }

        public string GetCalRes(int SrcIdx, int ResIdx, ref int ResValue)
        {
            string resCode;
            resCode = "GETCALRES " + SrcIdx.ToString() + "," + ResIdx.ToString(); ;

            Byte[] buffer = new Byte[resCode.Length + 2];
            for (int aryIdx = 0; aryIdx < resCode.Length; aryIdx++)
            {
                buffer[aryIdx] = Convert.ToByte(resCode.ElementAt(aryIdx));
            }
            buffer[resCode.Length] = 0x0D;
            buffer[resCode.Length + 1] = 0x0A;
            string rtnStr = "";
            if (!m_IsHwPassed)
            {
                m_ComPort2.Write(buffer, 0, resCode.Length + 2);
                //System.Threading.Thread.Sleep(100);
                rtnStr = m_ComPort2.ReadLine();
                rtnStr = rtnStr.TrimEnd((char[])"\r\n".ToCharArray());
                rtnStr = rtnStr.Remove(0, 30);
                ResValue = int.Parse(rtnStr);
            }
            return rtnStr;
        }


        /// <summary>
        /// SrcIdx = 1 ~ 2
        /// CapIdx = 0 Clear All  1 ~ 4 22p 100p 220p 300p
        /// </summary>
        /// <param name="SrcIdx"></param>
        /// <param name="CapIdx"></param>
        /// <returns></returns>
        public string SelCvCap(int SrcIdx, int CapIdx)
        {
            string resCode;
            int retryCnt = 0;
            resCode = "SELCVCAP " + SrcIdx.ToString() + "," + CapIdx.ToString();
            Byte[] buffer = new Byte[resCode.Length + 2];
            for (int aryIdx = 0; aryIdx < resCode.Length; aryIdx++)
            {
                buffer[aryIdx] = Convert.ToByte(resCode.ElementAt(aryIdx));
            }
            buffer[resCode.Length] = 0x0D;
            buffer[resCode.Length + 1] = 0x0A;
            string rtnStr = "";
            if (!m_IsHwPassed)
            {
                while (retryCnt < 100)
                {
                    retryCnt++;
                    m_ComPort2.Write(buffer, 0, resCode.Length + 2);
                    //System.Threading.Thread.Sleep(1000);
                    rtnStr = m_ComPort2.ReadLine();
                    rtnStr = rtnStr.TrimEnd((char[])"\r\n".ToCharArray());
                    if (rtnStr == "OK")
                    {
                        break;
                    }
                }
            }
            return rtnStr;
        }
        /// <summary>
        /// SrcIdx = 1 ~ 2
        /// ResIdx= 0 Clear All  1 ~ 2
        /// </summary>
        /// <param name="SrcIdx"></param>
        /// <param name="ResIdx"></param>
        /// <returns></returns>
        public string SelCcRes(int SrcIdx, int ResIdx)
        {
            string resCode;
            resCode = "SELCCRES " + SrcIdx.ToString() + "," + ResIdx.ToString();
            Byte[] buffer = new Byte[resCode.Length + 2];
            for (int aryIdx = 0; aryIdx < resCode.Length; aryIdx++)
            {
                buffer[aryIdx] = Convert.ToByte(resCode.ElementAt(aryIdx));
            }
            buffer[resCode.Length] = 0x0D;
            buffer[resCode.Length + 1] = 0x0A;
            string rtnStr = "";
            if (!m_IsHwPassed)
            {
                m_ComPort2.Write(buffer, 0, resCode.Length + 2);
                rtnStr = m_ComPort2.ReadLine();
                rtnStr = rtnStr.TrimEnd((char[])"\r\n".ToCharArray());
            }
            return rtnStr;
        }
        public string GetDut(int SrcIdx)
        {
            string resCode;
            resCode = "GETDUT " + SrcIdx.ToString();
            Byte[] buffer = new Byte[resCode.Length + 2];
            for (int aryIdx = 0; aryIdx < resCode.Length; aryIdx++)
            {
                buffer[aryIdx] = Convert.ToByte(resCode.ElementAt(aryIdx));
            }
            buffer[resCode.Length] = 0x0D;
            buffer[resCode.Length + 1] = 0x0A;
            string rtnStr = "";
            if (!m_IsHwPassed)
            {
                m_ComPort2.Write(buffer, 0, resCode.Length + 2);
                //  System.Threading.Thread.Sleep(500);
                rtnStr = m_ComPort2.ReadLine();
                rtnStr = rtnStr.TrimEnd((char[])"\r\n".ToCharArray());
            }
            return rtnStr;
        }

        private int m_CurIdx = -1;
        /// <summary>
        /// SrcIdx =1 ~ 2
        /// CurIdx = 1 ~ 20 5mA~100mA
        /// </summary>
        /// <param name="SrcIdx"></param>
        /// <param name="CurIdx"></param>
        /// <returns></returns>
        public string SelCurrent(int SrcIdx, int CurIdx)
        {
            string rtnStr = "";
            int retryCnt = 0;

            //if (m_CurIdx != CurIdx)
            //{
            m_CurIdx = CurIdx;
            string resCode;
            resCode = "SELCURRENT " + SrcIdx.ToString() + "," + CurIdx.ToString();
            Byte[] buffer = new Byte[resCode.Length + 2];
            for (int aryIdx = 0; aryIdx < resCode.Length; aryIdx++)
            {
                buffer[aryIdx] = Convert.ToByte(resCode.ElementAt(aryIdx));
            }
            buffer[resCode.Length] = 0x0D;
            buffer[resCode.Length + 1] = 0x0A;
            if (!m_IsHwPassed)
            {
                while (retryCnt < 100)
                {
                    retryCnt++;
                    m_ComPort2.Write(buffer, 0, resCode.Length + 2);
                    rtnStr = m_ComPort2.ReadLine();
                    rtnStr = rtnStr.TrimEnd((char[])"\r\n".ToCharArray());
                    if (rtnStr == "OK")
                    {
                        break;
                    }
                }
            }
            return rtnStr;
        }




        public string SelCCRes(int SrcIdx, int ResIdx)
        {
            string resCode;
            int retryCnt = 0;
            resCode = "SELCCRES " + SrcIdx.ToString() + "," + ResIdx.ToString();
            Byte[] buffer = new Byte[resCode.Length + 2];
            for (int aryIdx = 0; aryIdx < resCode.Length; aryIdx++)
            {
                buffer[aryIdx] = Convert.ToByte(resCode.ElementAt(aryIdx));
            }
            buffer[resCode.Length] = 0x0D;
            buffer[resCode.Length + 1] = 0x0A;
            string rtnStr = "";
            if (!m_IsHwPassed)
            {
                while (retryCnt < 100)
                {
                    retryCnt++;
                    m_ComPort2.Write(buffer, 0, resCode.Length + 2);
                    rtnStr = m_ComPort2.ReadLine();
                    rtnStr = rtnStr.TrimEnd((char[])"\r\n".ToCharArray());
                    if (rtnStr == "OK")
                    {
                        break;
                    }
                }
            }
            return rtnStr;
        }

        /// <summary>
        /// VoltIdx = mV 0-10000
        /// </summary>
        /// <param name="SrcIdx"></param>
        /// <param name="VoltIdx"></param>
        /// <returns></returns>
        public string SetDACVolt(int SrcIdx, int VoltIdx)
        {
            string resCode;
            resCode = "SETDACVOLT " + SrcIdx.ToString() + "," + VoltIdx.ToString();
            Byte[] buffer = new Byte[resCode.Length + 2];
            for (int aryIdx = 0; aryIdx < resCode.Length; aryIdx++)
            {
                buffer[aryIdx] = Convert.ToByte(resCode.ElementAt(aryIdx));
            }
            buffer[resCode.Length] = 0x0D;
            buffer[resCode.Length + 1] = 0x0A;
            string rtnStr = "";
            if (!m_IsHwPassed)
            {
                m_ComPort2.Write(buffer, 0, resCode.Length + 2);
                rtnStr = m_ComPort2.ReadLine();
                rtnStr = rtnStr.TrimEnd((char[])"\r\n".ToCharArray());
            }
            return rtnStr;
        }

        private int m_CurGainIdx = -1;
        /// <summary>
        /// SrcIdx =1 ~ 2
        /// GainIdx = 1, 10, 100, 1000
        /// </summary>
        /// <param name="SrcIdx"></param>
        /// <param name="CurIdx"></param>
        /// <returns></returns>
        public string SelCurrentGain(int SrcIdx, int GainIdx)
        {
            string rtnStr = "";
            int retryCnt = 0;
            //if (m_CurGainIdx != GainIdx)
            // {
            m_CurGainIdx = GainIdx;
            string resCode;
            resCode = "SELCURRENTGAIN " + SrcIdx.ToString() + "," + GainIdx.ToString();
            Byte[] buffer = new Byte[resCode.Length + 2];
            for (int aryIdx = 0; aryIdx < resCode.Length; aryIdx++)
            {
                buffer[aryIdx] = Convert.ToByte(resCode.ElementAt(aryIdx));
            }
            buffer[resCode.Length] = 0x0D;
            buffer[resCode.Length + 1] = 0x0A;
            if (!m_IsHwPassed)
            {
                while (retryCnt < 100)
                {
                    retryCnt++;
                    m_ComPort2.Write(buffer, 0, resCode.Length + 2);

                    rtnStr = m_ComPort2.ReadLine();
                    rtnStr = rtnStr.TrimEnd((char[])"\r\n".ToCharArray());
                    if (rtnStr == "OK")
                    {
                        break;
                    }
                }
            }
            return rtnStr;
        }
        private int m_PGAGainIdx = -1;
        /// <summary>
        /// SrcIdx =1 ~ 2
        ///  GainIdx = 1, 2, 4, 8, 16
        /// </summary>
        /// <param name="SrcIdx"></param>
        /// <param name="GainIdx"></param>
        /// <returns></returns>
        public string SelPGA1(int SrcIdx, int GainIdx)
        {
            string rtnStr = "";
            int retryCnt = 0;
            //if (m_PGAGainIdx != GainIdx)
            // {
            m_PGAGainIdx = GainIdx;
            string resCode;
            resCode = "SELPGA1 " + SrcIdx.ToString() + "," + GainIdx.ToString();
            Byte[] buffer = new Byte[resCode.Length + 2];
            for (int aryIdx = 0; aryIdx < resCode.Length; aryIdx++)
            {
                buffer[aryIdx] = Convert.ToByte(resCode.ElementAt(aryIdx));
            }
            buffer[resCode.Length] = 0x0D;
            buffer[resCode.Length + 1] = 0x0A;
            if (!m_IsHwPassed)
            {
                while (retryCnt < 100)
                {
                    retryCnt++;
                    m_ComPort2.Write(buffer, 0, resCode.Length + 2);
                    //System.Threading.Thread.Sleep(1000);
                    rtnStr = m_ComPort2.ReadLine();
                    rtnStr = rtnStr.TrimEnd((char[])"\r\n".ToCharArray());
                    if (rtnStr == "OK")
                    {
                        break;
                    }
                }
            }
            return rtnStr;
        }
        double m_PeakPower;
        double m_MaxVoltage;

        public void SetGain(double VoltageIn)
        {
            //9.5V
            if (VoltageIn <= 0.011875)
            {
                m_KpGain1 = 100;
                m_KpGain2 = 8;
            }
            else if (VoltageIn <= 0.02375)
            {
                m_KpGain1 = 100;
                m_KpGain2 = 4;
            }
            else if (VoltageIn <= 0.0475)
            {
                m_KpGain1 = 100;
                m_KpGain2 = 2;
            }
            else if (VoltageIn <= 0.095)
            {
                m_KpGain1 = 100;
                m_KpGain2 = 1;
            }
            else if (VoltageIn <= 0.11875)
            {
                m_KpGain1 = 10;
                m_KpGain2 = 8;
            }
            else if (VoltageIn <= 0.2375)
            {
                m_KpGain1 = 10;
                m_KpGain2 = 4;
            }
            else if (VoltageIn <= 0.475)
            {
                m_KpGain1 = 10;
                m_KpGain2 = 2;
            }
            else if (VoltageIn <= 0.95)
            {
                m_KpGain1 = 10;
                m_KpGain2 = 1;
            }
            else if (VoltageIn <= 1.1875)
            {
                m_KpGain1 = 1;
                m_KpGain2 = 8;
            }
            else if (VoltageIn <= 2.375)
            {
                m_KpGain1 = 1;
                m_KpGain2 = 4;
            }
            else if (VoltageIn <= 4.75)
            {
                m_KpGain1 = 1;
                m_KpGain2 = 2;
            }
            else
            {
                m_KpGain1 = 1;
                m_KpGain2 = 1;
            }
            SelCurrentGain(3, m_KpGain1);
            SelPGA1(3, m_KpGain2);
            m_KpGain = m_KpGain1 * m_KpGain2;
        }


     

        public string GetID()
        {
            string resCode;
            resCode = "GETID";

            Byte[] buffer = new Byte[resCode.Length + 2];
            for (int aryIdx = 0; aryIdx < resCode.Length; aryIdx++)
            {
                buffer[aryIdx] = Convert.ToByte(resCode.ElementAt(aryIdx));
            }
            buffer[resCode.Length] = 0x0D;
            buffer[resCode.Length + 1] = 0x0A;
            string rtnStr = "";
            if (!m_IsHwPassed)
            {
                m_ComPort2.Write(buffer, 0, resCode.Length + 2);
                System.Threading.Thread.Sleep(100);
                rtnStr = m_ComPort2.ReadLine();
                rtnStr = rtnStr.TrimEnd((char[])"\r\n".ToCharArray());
            }
            return rtnStr;
        }



        public void SetCurrent(ref double CurrentIn)
        {
            if (1 == 2)
            {
                #region "new"
                if (CurrentIn >= 300)
                {
                    CurrentIn = 300;
                    m_Current1 = m_CurrValue1[17];
                    m_Current2 = m_CurrValue2[17];
                    SelCurrent(3, 18);
                }
                else if (CurrentIn >= 200)
                {
                    CurrentIn = 200;
                    m_Current1 = m_CurrValue1[16];
                    m_Current2 = m_CurrValue2[16];
                    SelCurrent(3, 17);
                }
                else if (CurrentIn >= 120)
                {
                    CurrentIn = 120;
                    m_Current1 = m_CurrValue1[15];
                    m_Current2 = m_CurrValue2[15];
                    SelCurrent(3, 16);
                }
                else if (CurrentIn >= 70)
                {
                    CurrentIn = 70;
                    m_Current1 = m_CurrValue1[13];
                    m_Current2 = m_CurrValue2[13];
                    SelCurrent(3, 14);
                }
                else if (CurrentIn >= 60)
                {
                    CurrentIn = 60;
                    m_Current1 = m_CurrValue1[11];
                    m_Current2 = m_CurrValue2[11];
                    SelCurrent(3, 12);
                }
                else if (CurrentIn >= 50)
                {
                    CurrentIn = 50;
                    m_Current1 = m_CurrValue1[9];
                    m_Current2 = m_CurrValue2[9];
                    SelCurrent(3, 10);
                }
                else if (CurrentIn >= 40)
                {
                    CurrentIn = 40;
                    m_Current1 = m_CurrValue1[7];
                    m_Current2 = m_CurrValue2[7];
                    SelCurrent(3, 8);
                }
                else if (CurrentIn >= 30)
                {
                    CurrentIn = 30;
                    m_Current1 = m_CurrValue1[5];
                    m_Current2 = m_CurrValue2[5];
                    SelCurrent(3, 6);
                }
                else if (CurrentIn >= 20)
                {
                    CurrentIn = 20;
                    m_Current1 = m_CurrValue1[3];
                    m_Current2 = m_CurrValue2[3];
                    SelCurrent(3, 4);
                }
                else if (CurrentIn >= 10)
                {
                    CurrentIn = 10;
                    m_Current1 = m_CurrValue1[1];
                    m_Current2 = m_CurrValue2[1];
                    SelCurrent(3, 2);
                }
                else if (CurrentIn >= 5)
                {
                    CurrentIn = 5;
                    m_Current1 = m_CurrValue1[0];
                    m_Current2 = m_CurrValue2[0];
                    SelCurrent(3, 1);
                }
                else
                {
                    CurrentIn = 4;
                    m_Current1 = m_CurrValue1[20];
                    m_Current2 = m_CurrValue2[20];
                    SelCurrent(3, 21);
                }
                #endregion
            }
            else
            {
                #region "old"
                if (CurrentIn >= 100)
                {
                    CurrentIn = 100;
                    m_Current1 = m_CurrValue1[19];
                    m_Current2 = m_CurrValue2[19];
                    SelCurrent(3, 20);
                }
                else if (CurrentIn >= 90)
                {
                    CurrentIn = 90;
                    m_Current1 = m_CurrValue1[17];
                    m_Current2 = m_CurrValue2[17];
                    SelCurrent(3, 18);
                }
                else if (CurrentIn >= 80)
                {
                    CurrentIn = 80;
                    m_Current1 = m_CurrValue1[15];
                    m_Current2 = m_CurrValue2[15];
                    SelCurrent(3, 16);
                }
                else if (CurrentIn >= 70)
                {
                    CurrentIn = 70;
                    m_Current1 = m_CurrValue1[13];
                    m_Current2 = m_CurrValue2[13];
                    SelCurrent(3, 14);
                }
                else if (CurrentIn >= 60)
                {
                    CurrentIn = 60;
                    m_Current1 = m_CurrValue1[11];
                    m_Current2 = m_CurrValue2[11];
                    SelCurrent(3, 12);
                }
                else if (CurrentIn >= 50)
                {
                    CurrentIn = 50;
                    m_Current1 = m_CurrValue1[9];
                    m_Current2 = m_CurrValue2[9];
                    SelCurrent(3, 10);
                }
                else if (CurrentIn >= 40)
                {
                    CurrentIn = 40;
                    m_Current1 = m_CurrValue1[7];
                    m_Current2 = m_CurrValue2[7];
                    SelCurrent(3, 8);
                }
                else if (CurrentIn >= 30)
                {
                    CurrentIn = 30;
                    m_Current1 = m_CurrValue1[5];
                    m_Current2 = m_CurrValue2[5];
                    SelCurrent(3, 6);
                }
                else if (CurrentIn >= 20)
                {
                    CurrentIn = 20;
                    m_Current1 = m_CurrValue1[3];
                    m_Current2 = m_CurrValue2[3];
                    SelCurrent(3, 4);
                }
                else if (CurrentIn >= 10)
                {
                    CurrentIn = 10;
                    m_Current1 = m_CurrValue1[1];
                    m_Current2 = m_CurrValue2[1];
                    SelCurrent(3, 2);
                }
                else if (CurrentIn >= 5)
                {
                    CurrentIn = 5;
                    m_Current1 = m_CurrValue1[0];
                    m_Current2 = m_CurrValue2[0];
                    SelCurrent(3, 1);
                }
                else
                {
                    CurrentIn = 4;
                    m_Current1 = m_CurrValue1[20];
                    m_Current2 = m_CurrValue2[20];
                    SelCurrent(3, 21);
                }
                #endregion
            }
        }
        public void SetRes2(float TargetRes)
        {
            double Ip;
            double Iv;
            double Vp;
#if ResSize0201
            //0201 0.05W Peak抓3.21倍
            m_PeakPower = 0.16;
            m_MaxVoltage = 4;
            if (TargetRes <= 1000)//0.1 ~ 0.105 ohm
            {
                SelDutSource(3, 0);
                Ip = 1000 * Math.Sqrt(m_PeakPower / (TargetRes * 1.05));
                Iv = m_MaxVoltage * 1000 / (TargetRes * 1.05);
                if (Ip > Iv) { Ip = Iv; }
                SetCurrent(ref Ip);
                Vp = Ip * TargetRes * 1.05 / 1000;
                SetGain(Vp);
            }
            else if (TargetRes < 1100)// 1.0K ~ 1.1K ohm
            {
                SelDutSource(3, 1);
                m_ResValue1 = ADCValue1[0] * ADCValue1[2] / (ADCValue1[0] + ADCValue1[2]);
                m_ResValue2 = ADCValue2[0] * ADCValue2[2] / (ADCValue2[0] + ADCValue2[2]);
                SelCvRes(3, 0);
                SelCvRes(3, 1);
                SelCvRes(3, 3);
                m_KpGain1 = 1;
                SelCurrentGain(3, m_KpGain1);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                m_KpGain = m_KpGain1 * m_KpGain2;
                SelCvCap(3, 0);
                SelCvCap(3, 2);
            }
            else if (TargetRes < 1500)// 1.1K ~ 1.5K ohm
            {
                SelDutSource(3, 1);
                m_ResValue1 = ADCValue1[0];
                m_ResValue2 = ADCValue2[0];
                SelCvRes(3, 0);
                SelCvRes(3, 1);
                m_KpGain1 = 1;
                SelCurrentGain(3, m_KpGain1);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                m_KpGain = m_KpGain1 * m_KpGain2;
                SelCvCap(3, 0);
                SelCvCap(3, 2);
            }
            else if (TargetRes < 1800)// 1.5K ~ 1.8K ohm
            {
                SelDutSource(3, 1);
                m_ResValue1 = ADCValue1[1] * ADCValue1[2] / (ADCValue1[1] + ADCValue1[2]);
                m_ResValue2 = ADCValue2[1] * ADCValue2[2] / (ADCValue2[1] + ADCValue2[2]);
                SelCvRes(3, 0);
                SelCvRes(3, 2);
                SelCvRes(3, 3);
                m_KpGain1 = 1;
                SelCurrentGain(3, m_KpGain1);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                m_KpGain = m_KpGain1 * m_KpGain2;
                SelCvCap(3, 0);
                SelCvCap(3, 2);
            }
            else if (TargetRes < 2200)// 1.8K ~ 2.2K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[1] * ADCValue1[8] / (ADCValue1[1] + ADCValue1[8]);
                m_ResValue2 = ADCValue2[1] * ADCValue2[8] / (ADCValue2[1] + ADCValue2[8]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 2);
                //SelCvRes(2, 2);
                SelCvRes(3, 9);
                //SelCvRes(2, 9);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 2800)// 2.2K ~ 2.8K ohm
            {
                SelDutSource(3, 1);
                m_ResValue1 = ADCValue1[1];
                m_ResValue2 = ADCValue2[1];
                SelCvRes(3, 0);
                SelCvRes(3, 2);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                SelCvCap(3, 2);
            }
            else if (TargetRes < 3500)// 2.8K ~ 3.5K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[2] * ADCValue1[3] / (ADCValue1[2] + ADCValue1[3]);
                m_ResValue2 = ADCValue2[2] * ADCValue2[3] / (ADCValue2[2] + ADCValue2[3]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 3);
                //SelCvRes(2, 3);
                SelCvRes(3, 4);
                //SelCvRes(2, 4);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 4700)// 3.5K ~ 4.7K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[2] * ADCValue1[7] / (ADCValue1[2] + ADCValue1[7]);
                m_ResValue2 = ADCValue2[2] * ADCValue2[7] / (ADCValue2[2] + ADCValue2[7]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 3);
                //SelCvRes(2, 3);
                SelCvRes(3, 8);
                //SelCvRes(2, 8);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 6000)// 4.7K ~ 6.0K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[2];
                m_ResValue2 = ADCValue2[2];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 3);
                //SelCvRes(2, 3);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 6900)// 6.0K ~ 6.9K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[3] * ADCValue1[8] / (ADCValue1[3] + ADCValue1[8]);
                m_ResValue2 = ADCValue2[3] * ADCValue2[8] / (ADCValue2[3] + ADCValue2[8]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 4);
                //SelCvRes(2, 4);
                SelCvRes(3, 9);
                //SelCvRes(2, 9);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 9000)// 6.9K ~ 9.0K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[3];
                m_ResValue2 = ADCValue2[3];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 4);
                //SelCvRes(2, 4);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 10000)// 9.0K ~10.0K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[4] * ADCValue1[10] / (ADCValue1[4] + ADCValue1[10]);
                m_ResValue2 = ADCValue2[4] * ADCValue2[10] / (ADCValue2[4] + ADCValue2[10]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 5);
                //SelCvRes(2, 5);
                SelCvRes(3, 11);
                //SelCvRes(2, 11);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 12400)// 10.0K ~ 12.4K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[4];
                m_ResValue2 = ADCValue2[4];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 5);
                //SelCvRes(2, 5);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 14200)// 12.4K ~ 14.2K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[5] * ADCValue1[10] / (ADCValue1[5] + ADCValue1[10]);
                m_ResValue2 = ADCValue2[5] * ADCValue2[10] / (ADCValue2[5] + ADCValue2[10]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 6);
                //SelCvRes(2, 6);
                SelCvRes(3, 11);
                //SelCvRes(2, 11);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 17900)// 14.2K ~ 17.9K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[5];
                m_ResValue2 = ADCValue2[5];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 6);
                //SelCvRes(2, 6);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 21900)// 17.9K ~ 21.9K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[6] * ADCValue1[10] / (ADCValue1[6] + ADCValue1[10]);
                m_ResValue2 = ADCValue2[6] * ADCValue2[10] / (ADCValue2[6] + ADCValue2[10]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 7);
                //SelCvRes(2, 7);
                SelCvRes(3, 11);
                //SelCvRes(2, 11);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 28500)// 21.9K ~ 28.5K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[6];
                m_ResValue2 = ADCValue2[6];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 7);
                //SelCvRes(2, 7);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 32800)// 28.5K ~ 32.8K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[7] * ADCValue1[11] / (ADCValue1[7] + ADCValue1[11]);
                m_ResValue2 = ADCValue2[7] * ADCValue2[11] / (ADCValue2[7] + ADCValue2[11]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 8);
                //SelCvRes(2, 8);
                SelCvRes(3, 12);
                //SelCvRes(2, 12);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 42900)// 32.8K ~ 42.9K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[7];
                m_ResValue2 = ADCValue2[7];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 8);
                //SelCvRes(2, 8);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 47300)// 42.9K ~ 47.3K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[8] * ADCValue1[14] / (ADCValue1[8] + ADCValue1[14]);
                m_ResValue2 = ADCValue2[8] * ADCValue2[14] / (ADCValue2[8] + ADCValue2[14]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 9);
                //SelCvRes(2, 9);
                SelCvRes(3, 15);
                //SelCvRes(2, 15);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 60400)// 47.3K ~ 60.4K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[8];
                m_ResValue2 = ADCValue2[8];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 9);
                //SelCvRes(2, 9);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 69300)// 60.4K ~ 69.3K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[9] * ADCValue1[14] / (ADCValue1[9] + ADCValue1[14]);
                m_ResValue2 = ADCValue2[9] * ADCValue2[14] / (ADCValue2[9] + ADCValue2[14]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 10);
                //SelCvRes(2, 10);
                SelCvRes(3, 15);
                //SelCvRes(2, 15);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 90500)// 69.3K ~ 90.5K ohm
            { 
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[9];
                m_ResValue2 = ADCValue2[9];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 10);
                //SelCvRes(2, 10);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 99500)// 90.5K ~ 99.5K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[10] * ADCValue1[16] / (ADCValue1[10] + ADCValue1[16]);
                m_ResValue2 = ADCValue2[10] * ADCValue2[16] / (ADCValue2[10] + ADCValue2[16]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 11);
                //SelCvRes(2, 11);
                SelCvRes(3, 17);
                //SelCvRes(2, 17);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 121900)// 99.5K ~ 121.9K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[10];
                m_ResValue2 = ADCValue2[10];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 11);
                //SelCvRes(2, 11);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 138900)// 121.9K ~ 138.9K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[11] * ADCValue1[16] / (ADCValue1[11] + ADCValue1[16]);
                m_ResValue2 = ADCValue2[11] * ADCValue2[16] / (ADCValue2[11] + ADCValue2[16]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 12);
                //SelCvRes(2, 12);
                SelCvRes(3, 17);
                //SelCvRes(2, 17);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 166300)// 138.9K ~ 166.3K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[11];
                m_ResValue2 = ADCValue2[11];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 12);
                //SelCvRes(2, 12);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 218800)// 166.3K ~ 218.8K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[12] * ADCValue1[15] / (ADCValue1[12] + ADCValue1[15]);
                m_ResValue2 = ADCValue2[12] * ADCValue2[15] / (ADCValue2[12] + ADCValue2[15]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 13);
                //SelCvRes(2, 13);
                SelCvRes(3, 16);
                //SelCvRes(2, 16);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 280200)// 218.8K ~ 280.2K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[12];
                m_ResValue2 = ADCValue2[12];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 13);
                //SelCvRes(2, 13);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 328100)// 280.2K ~ 328.1K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[12] * ADCValue1[13] / (ADCValue1[12] + ADCValue1[13]);
                m_ResValue2 = ADCValue2[12] * ADCValue2[13] / (ADCValue2[12] + ADCValue2[13]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 13);
                //SelCvRes(2, 13);
                SelCvRes(3, 14);
                //SelCvRes(2, 14);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes <408500)// 328.1K ~ 408.5K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[13];
                m_ResValue2 = ADCValue2[13];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 14);
                //SelCvRes(2, 14);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 470300)// 408.5K ~ 470.3K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[15] * ADCValue1[16] / (ADCValue1[15] + ADCValue1[16]);
                m_ResValue2 = ADCValue2[15] * ADCValue2[16] / (ADCValue2[15] + ADCValue2[16]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 16);
                //SelCvRes(2, 16);
                SelCvRes(3, 17);
                //SelCvRes(2, 17);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 585100)// 470.3K ~ 585.1K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[14];
                m_ResValue2 = ADCValue2[14];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 15);
                //SelCvRes(2, 15);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 693400)// 585.1K ~ 693.4K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[16] * ADCValue1[17] / (ADCValue1[16] + ADCValue1[17]);
                m_ResValue2 = ADCValue2[16] * ADCValue2[17] / (ADCValue2[16] + ADCValue2[17]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 17);
                //SelCvRes(2, 17);
                SelCvRes(3, 18);
                //SelCvRes(2, 18);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 877000)// 693.4K ~ 877.0K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[15];
                m_ResValue2 = ADCValue2[15];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 16);
                //SelCvRes(2, 16);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 911400)// 877.0K ~ 911.4K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[16] * ADCValue1[18] / (ADCValue1[16] + ADCValue1[18]);
                m_ResValue2 = ADCValue2[16] * ADCValue2[18] / (ADCValue2[16] + ADCValue2[18]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 17);
                //SelCvRes(2, 17);
                SelCvRes(3, 19);
                //SelCvRes(2, 19);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 994200)// 911.4K ~ 994.2K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[16] * ADCValue1[19] / (ADCValue1[16] + ADCValue1[19]);
                m_ResValue2 = ADCValue2[16] * ADCValue2[19] / (ADCValue2[16] + ADCValue2[19]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 17);
                //SelCvRes(2, 17);
                SelCvRes(3, 20);
                //SelCvRes(2, 19);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 1193700)// 994.2K ~ 1193.7K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[16];
                m_ResValue2 = ADCValue2[16];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 17);
                //SelCvRes(2, 17);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 1421900)// 1193.7K ~ 1421.9K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[17] * ADCValue1[18] / (ADCValue1[17] + ADCValue1[18]);
                m_ResValue2 = ADCValue2[17] * ADCValue2[18] / (ADCValue2[17] + ADCValue2[18]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 18);
                //SelCvRes(2, 18);
                SelCvRes(3, 19);
                //SelCvRes(2, 19);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 2168600)// 1421.9K ~ 2168.6K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[17];
                m_ResValue2 = ADCValue2[17];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 18);
                // SelCvRes(2, 18);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 3309100)// 2.1686M ~ 3.3091M ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[17];
                m_ResValue2 = ADCValue2[17];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 18);
                //SelCvRes(2, 18);
                m_KpGain2 = 2;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 4427200)// 2.1686M ~ 4.4272M ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[17];
                m_ResValue2 = ADCValue2[17];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 18);
                //SelCvRes(2, 18);
                m_KpGain2 = 4;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes <6752200)// 4427.2K ~ 6752.2K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[18] * ADCValue1[19] / (ADCValue1[18] + ADCValue1[19]);
                m_ResValue2 = ADCValue2[18] * ADCValue2[19] / (ADCValue2[18] + ADCValue2[19]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 19);
                //SelCvRes(2, 19);
                SelCvRes(3, 20);
                //SelCvRes(2, 20);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 7437600)// 6752.2K ~ 7437.6K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[18] * ADCValue1[19] / (ADCValue1[18] + ADCValue1[19]);
                m_ResValue2 = ADCValue2[18] * ADCValue2[19] / (ADCValue2[18] + ADCValue2[19]);
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 19);
                //SelCvRes(2, 19);
                SelCvRes(3, 20);
                //SelCvRes(2, 20);
                m_KpGain2 = 2;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 10937700)// 7437.6K ~ 10937.7K ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[18];
                m_ResValue2 = ADCValue2[18];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 19);
                //SelCvRes(2, 19);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 16681900)// 10.9377M ~ 16.6819M ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[19];
                m_ResValue2 = ADCValue2[19];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 20);
                //SelCvRes(2, 20);
                m_KpGain2 = 1;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 25454500)// 16.6819M ~ 25.4545M ohm
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[19];
                m_ResValue2 = ADCValue2[19];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 20);
                //SelCvRes(2, 20);
                m_KpGain2 = 2;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
            else if (TargetRes < 50000000)
            {
                SelDutSource(3, 1);
                //SelDutSource(2, 1);
                m_ResValue1 = ADCValue1[19];
                m_ResValue2 = ADCValue2[19];
                SelCvRes(3, 0);
                //SelCvRes(2, 0);
                SelCvRes(3, 20);
                //SelCvRes(2, 20);
                m_KpGain2 = 4;
                SelPGA1(3, m_KpGain2);
                //SelPGA1(2, m_KpGain2);
                m_KpGain = m_KpGain2;
                SelCvCap(3, 0);
                //SelCvCap(2, 0);
                SelCvCap(3, 2);
                //SelCvCap(2, 3);
            }
#else

#endif
            ClearRelayMap();
            m_TargetRes = TargetRes;
            m_FirstRes = TargetRes;
            m_FinalRes = TargetRes;
        }
        private void CheckSum(byte[] SrcAry, out byte DestMSB, out byte DestLSB)
        {
            long chkSum = 0;
            for (int aryIdx = 1; aryIdx <= 24; aryIdx++)
            {
                switch (SrcAry[aryIdx])
                {
                    case 0x30:
                    case 0x31:
                    case 0x32:
                    case 0x33:
                    case 0x34:
                    case 0x35:
                    case 0x36:
                    case 0x37:
                    case 0x38:
                    case 0x39:
                        chkSum = chkSum + SrcAry[aryIdx];
                        break;
                    case 0x61:
                    case 0x62:
                    case 0x63:
                    case 0x64:
                    case 0x65:
                    case 0x66:
                        chkSum = chkSum + SrcAry[aryIdx];
                        break;
                    default:
                        break;
                }
            }
            string sChkSum = "";
            sChkSum = Convert.ToString(chkSum, 16);
            char[] cChkSum = new char[sChkSum.Length];
            cChkSum = sChkSum.ToCharArray();
            DestMSB = Convert.ToByte(cChkSum[sChkSum.Length - 2]); ;// Convert.ToByte(sChkSum.ToCharArray(0)); ;//Convert.ToByte(Convert.ToString(chkSum, 16)).ElementAt(aryIdx)); ;
            DestLSB = Convert.ToByte(cChkSum[sChkSum.Length - 1]); ;
            //char aaa = sFinalRes.ElementAt(0);
            // DestMSB = Convert.ToByte(sFirstRes.ElementAt(aryIdx));
        }
    }
}