using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class MockTime : ITime
    {
        public long time;
        public long GetTime()
        {
            return time;
        }
    }
}
