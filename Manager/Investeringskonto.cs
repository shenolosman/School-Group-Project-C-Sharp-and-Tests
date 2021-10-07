using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
   public class Investeringskonto : BankKonto
   {
       public ITime _itime;

       private DateTime nu = DateTime.Now;
        //Investeringskonto som tillåter ett uttag om året

        public Investeringskonto(int balance) : base(balance)
        {
            
        }

        public Investeringskonto(int balance, ITime time) : base(balance, time)
        {
            _itime = time;
        }
        public override bool CanTakeOutMoney(int amount)
        {
            bool takeOutMoney = amount <= Balance;
            if (nu<DateTime.Now-TimeSpan.FromDays(-365))
            {
                if (takeOutMoney)
                {
                    Balance -= amount;
                }
            }
          

            return takeOutMoney;
        }

     
   }
}
