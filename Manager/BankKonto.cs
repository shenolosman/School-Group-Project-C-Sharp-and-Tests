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
        protected int withdrawLimit;
        protected long withdrawTime;

        protected BankKonto(ITime time, int balance)
        {
            tid = time;
            depositLimit = 15000;
            Balance = balance;
        }

        public BankKonto(ITime time) {
            tid = time;
            Balance = 0;
            depositLimit = 15000;
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
        public abstract bool Withdraw(int amount);
    }
    public class Investeringskonto : BankKonto
    {
        public Investeringskonto(ITime time) : base(time)
        {
            withdrawLimit = 1;
        }

        public override bool Withdraw(int amount)
        {
            if (amount <= 0 || amount > Balance)
                return false;

            if (tid.GetTime() > withdrawTime + Time.YearInMilisec)
            {
                withdrawLimit = 1;
                withdrawTime = tid.GetTime();
            }

            if (withdrawLimit <= 0)
            {
                return false;
            }

            withdrawLimit--;
            Balance -= amount;
            return true;
        }
        
    }
    public class KreditKonto : BankKonto
    {
        private int _credit;
        public KreditKonto(int balance, int credit) : base(null, balance) {
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
        public Lönekonto(ITime time) : base(time)
        {
            depositLimit = 15000;
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
    public class Sparkonto : BankKonto
    {
        public Sparkonto(ITime time) : base(time)
        {
            withdrawLimit = 5;
        }
        public override bool Withdraw(int amount)
        {
            if (amount <= 0 || amount > Balance)
                return false;

            if (tid.GetTime() > withdrawTime + Time.YearInMilisec)
            {
                withdrawLimit = 5;
                withdrawTime = tid.GetTime();
            }

            if (withdrawLimit <= 0) {
                // casting
                Balance -= (int) Math.Ceiling(((double) amount * 0.01));
            }
            withdrawLimit--;
            Balance -= amount;
            return true;
        }
    }
}
