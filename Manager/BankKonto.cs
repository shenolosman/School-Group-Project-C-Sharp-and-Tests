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

        protected BankKonto(int balance)
        {
            Balance = balance;
        }

       public abstract bool CanTakeOutMoney(int amount);
       
    }
}
