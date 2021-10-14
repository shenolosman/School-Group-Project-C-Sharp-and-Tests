using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager;
using Xunit;

namespace Test
{
    public class BankAppTester
    {
        private MockTime ttime;

        public BankAppTester()
        {
            ttime = new MockTime();
        }
        [Fact]
        public void Test_InvesteringTid()
        {
            ttime.time = 1;
            var investera = new Investeringskonto(1000);

            var withdraw = investera.CanTakeOutMoney(500);
            Assert.True(withdraw);

            withdraw = investera.CanTakeOutMoney(200);
            Assert.False(withdraw);
            ttime.time = Time.YearInMilisec + 100;

            withdraw = investera.CanTakeOutMoney(200);
            Assert.True(withdraw);

        }
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

        [Fact]
        public void LöneTest()
        {
            var konto = new Lönekonto(ttime = new MockTime());

            var insert = konto.CanPutInMoney(500);

            var Withdraw = konto.CanTakeOutMoney(600);
            Assert.True(Withdraw);

            Withdraw = konto.CanTakeOutMoney(500);
            Assert.True(Withdraw);

            Withdraw = konto.CanTakeOutMoney(1000);
            Assert.False(Withdraw);

        }
        [Fact]
        public void InSättningsTest()
        {
            Lönekonto konto = new Lönekonto(10000);


            Assert.False(konto.CanPutInMoney(16000));


        }

    }
}
