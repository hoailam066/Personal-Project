using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meter
{
    public class CPanel
    {
        /// <summary>
        /// 電阻排數振鏡偏差 mm
        /// </summary>
        public double GalvoColOffsetX { get; set; }
        /// <summary>
        /// 電阻排數振鏡偏差 mm
        /// </summary>
        public double GalvoColOffsetY { get; set; }
        public CPanel()
        {
        }
    }
    public class CRes
    {

        public double Galvo2ndXPos { get; set; }
        public double Galvo2ndYPos { get; set; }
        /// <summary>
        /// 電阻振鏡位置 mm
        /// </summary>
        public double GalvoXPos { get; set; }
        /// <summary>
        /// 電阻振鏡位置 mm
        /// </summary>
        public double GalvoYPos { get; set; }
        public int RelayIdx { get; set; }
        public int HF { get; set; }
        public int HS { get; set; }
        public int LF { get; set; }
        public int LS { get; set; }
        /// <summary>
        ///  2線式量測
        /// </summary>
        public bool Is2TMeasurement { get; set; }
        /// <summary>
        /// 目標阻值,客戶規格 線外量測單位
        /// </summary>
        public double NominalDesign { get; set; }
        /// <summary>
        /// 實際目標阻值,機器要用的 線內量測單位
        /// </summary>
        public double NominalReal1 { get; set; }
        public double NominalReal2 { get; set; }
        public double NominalReal3 { get; set; }
        public double NominalReal4 { get; set; }
        public double NominalReal5 { get; set; }
        public double NominalReal6 { get; set; }
        public double NominalReal7 { get; set; }
        /// <summary>
        /// 調整比例 NominalReal = NominalDesign *(1+NominalOffset/100)
        /// </summary>
        public double NominalOffset1 { get; set; }
        public double NominalOffset2 { get; set; }
        public double NominalOffset3 { get; set; }
        public double NominalOffset4 { get; set; }
        public double NominalOffset5 { get; set; }
        public double NominalOffset6 { get; set; }
        public double NominalOffset7 { get; set; }

        /// <summary>
        /// 量測偏差補正(冷阻) ; 線外量測 = Meter量到阻值 * (1+量測偏差補正/100)
        /// </summary>
        public double MeasureBias { get; set; }
        /// <summary>
        /// 熱阻偏差補正; 線外量測 = (Meter量到阻值 *熱阻偏差補正) * 量測偏差補正
        /// </summary>
        public double MeasureHotBias { get; set; }
        /// <summary>
        /// 初測移動平均樣本數
        /// </summary>
        public int PT_Cnt { get; set; }
        /// <summary>
        /// 初測繼電器延遲時間 標準要350us
        /// </summary>
        public int PT_Dly { get; set; }
        /// <summary>
        ///  初測上限
        /// </summary>
        public double PT_High { get; set; }
        /// <summary>
        /// 初測下限
        /// </summary>
        public double PT_Low { get; set; }
        /// <summary>
        /// 終測移動平均樣本數
        /// </summary>
        public int FT_Cnt { get; set; }
        /// <summary>
        /// 終測繼電器延遲時間
        /// </summary>
        public int FT_Dly { get; set; }
        public double FT_High { get; set; }
        public double FT_Low { get; set; }
        public CRes()
        {
            NominalOffset1 = 0;
            NominalOffset2 = 0;
            NominalOffset3 = 0;
            NominalOffset4 = 0;
            NominalOffset5 = 0;
            NominalOffset6 = 0;
            NominalOffset7 = 0;
            MeasureBias = 0;
            MeasureHotBias = 0;
        }

    }
}
