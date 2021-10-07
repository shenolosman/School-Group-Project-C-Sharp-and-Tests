using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class RealTime : ITime
    {
        public long GetTime()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }
        
    }
}
