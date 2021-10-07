using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class KreditKonto : BankKonto
    {
        private int _credit;

        //Kreditkonto som tillåter kredit över en viss gräns
        public KreditKonto(int balance) : base(balance)
        {
        }

        public KreditKonto(int balance, int credit) : this(balance)
        {
            this._credit = credit;
        }

        public override bool CanTakeOutMoney(int amount)
        {
            bool takeOutMoney = amount <= (Balance + _credit);

            if (takeOutMoney)
            {
                if (Balance < amount)
                {
                    amount -= Balance;
                    Balance = 0;

                    _credit -= amount;
                }
                else
                {
                    Balance -= amount;
                }
            }

            return takeOutMoney;
        }
    }
}
