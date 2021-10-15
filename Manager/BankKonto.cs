using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public abstract class BankKonto
    {
        public int Balance;
        protected ITime tid;
        protected long depositTime;
        protected bool putInMoney;
        protected int depositLimit;
        protected BankKonto(int balance)
        {
            Balance = balance;
        }
        protected BankKonto(ITime time)
        {
            tid = time;
        }
        

        public abstract bool Withdraw(int amount);
    }
    public class Investeringskonto : BankKonto
    {
        public ITime itime;
        //Investeringskonto som tillåter ett uttag om året
        public Investeringskonto(int balance) : base(balance)
        {
            //itime = tid;
        }
        public override bool Withdraw(int amount)
        {
            bool takeOutMoney = amount <= Balance;

            if (takeOutMoney)
            {
                Balance -= amount;
            }
            return takeOutMoney;
        }
    }
    public class KreditKonto : BankKonto
    {
        private int _credit;
        //Kreditkonto som tillåter kredit över en viss gräns
        public KreditKonto(int balance) : base(balance) { }
        public KreditKonto(int balance, int credit) : this(balance) {
            this._credit = credit;
        }
        public override bool Withdraw(int amount)
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
    public class Lönekonto : BankKonto
    {
        //Lönekonto som tillåter obegränsat antal uttag

        public Lönekonto(int balance) : base(balance)
        {
            depositLimit = 15000; }
        public Lönekonto(ITime time) : base(time) { depositLimit = 15000; }
        public override bool Withdraw(int amount)
        {
            bool takeOutMoney = amount <= Balance;

            if (takeOutMoney)
            {
                Balance -= amount;
            }

            return takeOutMoney;
        }

        public bool Deposit(int amount)
        {
            if (amount <= 0)
                return false;

            if (tid.GetTime() > depositTime + Time.DayInMillisec)
            {
                depositLimit = 15000;
                depositTime = tid.GetTime();
            }
            
            if (amount > depositLimit)
                return false;

            depositLimit -= amount;
            Balance += amount;
            return true;
        }

    }
    public class Sparkonto : BankKonto
    {
        //Sparkonto som tillåter max 5 uttag om året (fler kan göras men då kostar det 1% av uttaget)
        private int gånger = 0;
        readonly DateTime resetTime = DateTime.Now - TimeSpan.FromDays(-365);
        public Sparkonto(ITime time) : base(time)
        {

        }

        public Sparkonto(int balance) : base(balance)
        {
            List<int> sparaGånger = new List<int>();
            if (gånger > 6 && resetTime == DateTime.Now)
            {
                //dra %1 från kontot
            }
        }


        public override bool Withdraw(int amount)
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
