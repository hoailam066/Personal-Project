using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Automation.BDaq;
namespace Meter
{
    internal class CPseudoGalvo
    {
        private const int Buffer_size = 1000;
        private const double Timebase = 40000000.0;
        private const int Update_interval = 40; // Update rate = Timebase / Update_interval = 40,000,000 / 40 = 1000k Samples/sec = 1000,000 Updates(Scans)/sec
        private const short Iterations = 1;
        private double m_XOffsetVoltage;
        private double m_YOffsetVoltage;
        private int m_XDirect;
        private int m_YDirect;
        private double m_RotateDeg;
        private Automation.BDaq.InstantAoCtrl m_InstantAoCtrl1;


        private ushort m_cardNum = 0;
        private short card = 0;

        public CPseudoGalvo()
        {
            m_InstantAoCtrl1 = new Automation.BDaq.InstantAoCtrl();
            DeviceInformation deviceInformation;
            deviceInformation = new DeviceInformation(0, "PCIE-1816,BID#0", AccessMode.ModeWrite, 0);
            m_InstantAoCtrl1.SelectedDevice = deviceInformation;
            m_InstantAoCtrl1.Channels.ElementAt(0).ValueRange = ValueRange.V_Neg10To10;
            m_InstantAoCtrl1.Channels.ElementAt(1).ValueRange = ValueRange.V_Neg10To10;
            if (m_InstantAoCtrl1.Initialized != true)
            {
                throw new System.ArgumentException("Initialized fail", "Hardware Error");
            }


            StreamReader sr1 = new StreamReader("D:\\DataSettings\\LaserTrimming1610\\Machine\\Parameter\\GalvoOffsetX.txt", Encoding.Default);
            string line;
            line = sr1.ReadLine();
            m_XOffsetVoltage = double.Parse(line);

            StreamReader sr2 = new StreamReader("D:\\DataSettings\\LaserTrimming1610\\Machine\\Parameter\\GalvoOffsetY.txt", Encoding.Default);
            line = sr2.ReadLine();
            m_YOffsetVoltage = double.Parse(line);

            ReadGlavoDirect("");

        }
        public void ReadGlavoDirect(string path)
        {
            try
            {
                m_XDirect = 1;
                m_YDirect = 1;
                if (path == "")
                {
                    path = "D:\\DataSettings\\LaserTrimming1610\\Machine\\Parameter\\GalvoXY.txt";
                }
                string[] line;
                line = System.IO.File.ReadAllLines(path);
                line[0] = line[0].Replace(" ", "");
                string[] str = line[0].Split(',');
                m_RotateDeg = Convert.ToDouble(str[0]);
                m_XDirect = Convert.ToInt32(str[1]);
                m_YDirect = Convert.ToInt32(str[2]);
            }
            catch
            {
                m_XDirect = 1;
                m_YDirect = 1;
            }
        }
        public void GalvoAbsMove(double XVoltage, double YVoltage)
        {
            XVoltage = XVoltage+ m_XOffsetVoltage;//XVoltage = XVoltage - 0.1;
            YVoltage =YVoltage + m_YOffsetVoltage;
            Automation.BDaq.ErrorCode errCode;
            if (XVoltage > 9.98) { XVoltage = 9.98; }
            else if (XVoltage < -9.98) { XVoltage = -9.98; }
            if (YVoltage > 9.98) { YVoltage = 9.98; }
            else if (YVoltage < -9.98) { YVoltage = -9.98; }
            double voltX;
            double voltY;
            double thi;
            thi = m_RotateDeg * Math.PI / 180;
            voltX = XVoltage * Math.Cos(m_RotateDeg * Math.PI / 180) + YVoltage * Math.Sin(m_RotateDeg * Math.PI / 180);
            voltY = XVoltage * -1*Math.Sin(m_RotateDeg * Math.PI / 180) + YVoltage * Math.Cos(m_RotateDeg * Math.PI / 180);
            //double[] VoltageOut = {-1* YVoltage ,XVoltage  };
            double[] VoltageOut = { m_XDirect* voltX, m_YDirect * voltY };
            //   CHighResolutionTimeStamps timer = new CHighResolutionTimeStamps();
            // double test = timer.GetMicroSecondTime();
            errCode = m_InstantAoCtrl1.Write(0, 2, VoltageOut);
          // test = timer.GetMicroSecondTime() - test;

            if (errCode != ErrorCode.Success)
            {
                throw new System.ArgumentException("Write fail", "Hardware Error");
            }
        }
    }
}
