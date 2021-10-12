using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public abstract class BankKonto
    {
        protected int Balance;
        private ITime tid;
        protected BankKonto(int balance)
        {
            Balance = balance;
        }

        protected BankKonto(int balance,ITime time)
        {
            Balance = balance;
            tid = time;
        }

       public abstract bool CanTakeOutMoney(int amount);
       
    }
}
