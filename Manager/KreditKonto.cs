using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class KreditKonto : BankKonto
    {
        private int v;

        //Kreditkonto som tillåter kredit över en viss gräns
        public KreditKonto(int balance) : base(balance)
        {
        }

        public KreditKonto(int balance, int v) : this(balance)
        {
            this.v = v;
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
