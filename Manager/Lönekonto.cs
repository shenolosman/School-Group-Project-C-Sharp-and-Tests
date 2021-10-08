using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
   public class Lönekonto : BankKonto
    {
        //Lönekonto som tillåter obegränsat antal uttag
        public Lönekonto(int balance) : base(balance)
        {
        }

        public override bool CanTakeOutMoney(int amount)
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

            bool putInMoney = Balance <= amount;

            if (amount > 1500 || amount < 0)
            {
                return false;
            }

            Balance += amount;
            return putInMoney;
        }
    }
}
