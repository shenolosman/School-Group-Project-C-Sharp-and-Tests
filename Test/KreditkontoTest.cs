using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class Kreditkontotest
    {
        [Fact]
        public void KreditKonto_test()
        {
            var konto = new KreditKonto(1000, 1000);

            var Withdraw = konto.CanTakeOutMoney(1000);
            Assert.True(Withdraw);

            Withdraw = konto.CanTakeOutMoney(600);
            Assert.True(Withdraw);

            Withdraw = konto.CanTakeOutMoney(500);
            Assert.False(Withdraw);
        }
    }
}
