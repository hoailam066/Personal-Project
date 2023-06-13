using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meter
{
    public class CCutParam
    {

        private double[] m_ResStopPerc = new double[40];
        public double[] ResStopPerc
        {
            get { return m_ResStopPerc; }
            set { m_ResStopPerc = value; }
        }

        private int m_CutID;
        public int CutID
        {
            get { return m_CutID; }
            set { m_CutID = value; }
        }
        /// <summary>
        /// 停止比例
        /// </summary>
        private double m_StopPercentA;
        public double StopPercentA
        {
            get { return m_StopPercentA; }
            set { m_StopPercentA = value; }
        }
        /// <summary>
        /// 停止比例
        /// </summary>
        private double m_StopPercentB;
        public double StopPercentB
        {
            get { return m_StopPercentB; }
            set { m_StopPercentB = value; }
        }
        /// <summary>
        /// 停止比例
        /// </summary>
        private double m_StopPercentC;
        public double StopPercentC
        {
            get { return m_StopPercentC; }
            set { m_StopPercentC = value; }
        }
        /// <summary>
        /// 停止比例
        /// </summary>
        private double m_StopPercentD;
        public double StopPercentD
        {
            get { return m_StopPercentD; }
            set { m_StopPercentD = value; }
        }

        private double m_StopPercentE;
        public double StopPercentE
        {
            get { return m_StopPercentE; }
            set { m_StopPercentE = value; }
        }

        private double m_StopPercentF;
        public double StopPercentF
        {
            get { return m_StopPercentF; }
            set { m_StopPercentF = value; }
        }

        private double m_StopPercentG;
        public double StopPercentG
        {
            get { return m_StopPercentG; }
            set { m_StopPercentG = value; }
        }
        /// <summary>
        /// mm
        /// </summary>
        public double XOffset { get; set; }
        /// <summary>
        /// mm
        /// </summary>
        public double YOffset { get; set; }
        /// <summary>
        /// 最大長度 mm
        /// </summary>
        public double Length { get; set; }
        /// <summary>
        ///  最高速度 mm/s
        /// </summary>
        public double Speed { get; set; }
        /// <summary>
        /// 雷射功率百分比
        /// </summary>
        public double Power { get; set; }
        /// <summary>
        /// 頻率 KHz
        /// </summary>
        public double QRate { get; set; }
        /// <summary>
        /// 脈衝密度 p/mm
        /// </summary>
        public int PulseDensity { get; set; }
        /// <summary>
        /// 方向 0 90 180 270
        /// </summary>
        public int Direction { get; set; }
        /// <summary>
        /// 雷射控制模式 Y表示關閉雷射再開 N 表示不關閉雷射
        /// </summary>
        public string Repo { get; set; }
        ///// <summary>
        ///// 切割模式
        ///// </summary>
        //public string PMode { get; set; }
        ///// <summary>
        ///// 量測模式
        ///// </summary>
        //public string CMode { get; set; }
        /// <summary>
        /// 延遲時間 us
        /// </summary>
        public int Delay { get; set; }
    }
}
