using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    class Lönekonto
    {
        private int _balance;

        public Lönekonto(int balance)
        {
            _balance = balance;
        }

        public bool CanTakeOutMoney(int amount)
        {
            bool TakeOutMoney = amount <= _balance;

            if (TakeOutMoney)
            {
                _balance -= amount;
            }

            return TakeOutMoney;
        }
    }
}
