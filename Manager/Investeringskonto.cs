using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
   public class Investeringskonto : BankKonto
   {
       public ITime itime;
        //Investeringskonto som tillåter ett uttag om året
        public Investeringskonto(int balance) : base(balance)
        {
            //itime = tid;
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
    }
}
