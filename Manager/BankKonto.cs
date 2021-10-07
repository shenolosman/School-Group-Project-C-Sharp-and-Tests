using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class BankKonto
    {
        public class SalleryAccount
        {
            private int _pengar;

            public SalleryAccount(int cash)
            {
                this._pengar = cash;
            }

            public bool AcceptWithrawMoney(int v)
            {
                throw new NotImplementedException();
            }
        }
    }
}
