using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meter
{
    public class CTrimData
    {
        public double PostPercent { get; set; }
        /// <summary>
        /// 顯示用的阻值 外線量測單位
        /// </summary>
        public double PostVal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double PrePercent { get; set; }
        /// <summary>
        /// 顯示用的阻值 外線量測單位
        /// </summary>
        public double PreVal { get; set; }

        public double PreAdc{ get; set; }
    }
}
