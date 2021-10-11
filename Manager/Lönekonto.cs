﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
   public class Lönekonto 
    {
        private int Balance;
        public ITime time;
        private long depositTime;
        private bool putInMoney;
        private int depositLimit;

        
        public Lönekonto(ITime time)
        {
            this.time = time;
        }

        public  bool CanTakeOutMoney(int amount)
        {
            bool takeOutMoney = amount <= Balance;

            if (takeOutMoney)
            {
                Balance -= amount;
            }

            return takeOutMoney;
        }
        public bool CanPutInMoney(int amount)
        {
            if (time.GetTime() > depositTime + Time.DayInMillisec)
            {
                depositLimit = 15000;
            }
            bool putInMoney = Balance <= amount;

            if (amount > depositLimit || amount < 0)
            {
                return false;
            }

            depositTime = time.GetTime();
            depositLimit -= amount;
            Balance += amount;
            return putInMoney;
        }
    }
}
