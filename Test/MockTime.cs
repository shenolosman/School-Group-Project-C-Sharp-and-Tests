﻿using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class MockTime : ITime
    {
        private DateTime _fakeNow;
        public MockTime()
        {
            _fakeNow = DateTime.Now;
        }
        public DateTime Now
        {
            get
            {
                return _fakeNow;
            }
        }
        public void SetNowTo(DateTime newNow)
        {
            _fakeNow = newNow;
        }
    }
}
