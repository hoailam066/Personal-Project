using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Timer
{
    public class CHighResolutionTimeStamps
    {
        private static Stopwatch m_Stopwatch;
        public CHighResolutionTimeStamps()
        {
            if (m_Stopwatch == null)
            {
                m_Stopwatch = new Stopwatch();
            }
        }
        ~CHighResolutionTimeStamps()
        {
        }
        public double GetMicroSecondTime()
        {
            long ElapsedTime = Stopwatch.GetTimestamp();
            return ElapsedTime * ((double)1.0 / Stopwatch.Frequency) * 1000000;
        }
        public double GetMilliseconds()
        {
            long ElapsedTime = Stopwatch.GetTimestamp();
            return ElapsedTime * ((double)1.0 / Stopwatch.Frequency) * 1000;
        }


        

        public void DelayMicroSec(int DelayTime)
        {
            double startTime = GetMicroSecondTime();
            while ((GetMicroSecondTime() - startTime) < DelayTime)
            { }
        }
    }
}
