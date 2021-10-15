using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public abstract class BankAccount
    {
        public int Balance;
        protected ITime Time;
        protected long DepositTime;
        protected int DepositLimit;
        protected int WithdrawLimit;
        protected long WithdrawTime;

        protected BankAccount(int balance)
        {
            DepositLimit = 15000;
            Balance = balance;
        }
        protected BankAccount(ITime time)
        {
            Time = time;
            Balance = 0;
            DepositLimit = 15000;
        }
        public bool Deposit(int amount)
        {
            if (amount <= 0)
                return false;

            if (Time.GetTime() > DepositTime + Manager.Time.DayInMillisec)
            {
                DepositLimit = 15000;
                DepositTime = Time.GetTime();
            }
            if (amount > DepositLimit)
                return false;
            DepositLimit -= amount;
            Balance += amount;
            return true;
        }
        public abstract bool Withdraw(int amount);
    }
    public class InvestmentAccount : BankAccount
    {
        public InvestmentAccount(ITime time) : base(time)
        {
            WithdrawLimit = 1;
        }
        public override bool Withdraw(int amount)
        {
            if (amount <= 0 || amount > Balance)
                return false;

            if (Time.GetTime() > WithdrawTime + Manager.Time.YearInMilisec)
            {
                WithdrawLimit = 1;
                WithdrawTime = Time.GetTime();
            }
            if (WithdrawLimit <= 0)
                return false;
            WithdrawLimit--;
            Balance -= amount;
            return true;
        }
    }
    public class CreditAccount : BankAccount
    {
        private int _credit;
        public CreditAccount(int balance, int credit) : base(balance)
        {
            _credit = credit;
        }
        public override bool Withdraw(int amount)
        {
            var takeOutMoney = amount <= (Balance + _credit);
            if (takeOutMoney)
            {
                if (Balance < amount)
                {
                    amount -= Balance;
                    Balance = 0;
                    _credit -= amount;
                }
                else
                    Balance -= amount;
            }
            return takeOutMoney;
        }
    }
    public class SalaryAccount : BankAccount
    {
        public SalaryAccount(ITime time) : base(time)
        {
        }
        public override bool Withdraw(int amount)
        {
            var takeOutMoney = amount <= Balance;

            if (takeOutMoney)
            {
                Balance -= amount;
            }
            return takeOutMoney;
        }
    }
    public class SaveAccount : BankAccount
    {
        public SaveAccount(ITime time) : base(time)
        {
            WithdrawLimit = 5;
        }
        public override bool Withdraw(int amount)
        {
            if (amount <= 0 || amount > Balance)
                return false;
            if (Time.GetTime() > WithdrawTime + Manager.Time.YearInMilisec)
            {
                WithdrawLimit = 5;
                WithdrawTime = Time.GetTime();
            }
            if (WithdrawLimit <= 0)
                Balance -= (int)Math.Ceiling(((double)amount * 0.01));
            WithdrawLimit--;
            Balance -= amount;
            return true;
        }
    }
}
