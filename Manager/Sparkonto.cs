using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
   public class Sparkonto : BankKonto
   {
        //Sparkonto som tillåter max 5 uttag om året (fler kan göras men då kostar det 1% av uttaget)
        private int gånger=0;
        readonly DateTime resetTime=DateTime.Now-TimeSpan.FromDays(-365);
        
        public Sparkonto(int balance) : base(balance)
        {
            List<int> sparaGånger = new List<int>();
            if (gånger>6 && resetTime==DateTime.Now)
            {
                //dra %1 från kontot
            }
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
