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

            var withdraw = investera.Withdraw(500);
            Assert.True(withdraw);

            withdraw = investera.Withdraw(200);
            Assert.False(withdraw);
            ttime.time = Time.YearInMilisec + 100;

            withdraw = investera.Withdraw(200);
            Assert.True(withdraw);

        }
        [Fact]
        public void KreditKonto_test()
        {
            var konto = new KreditKonto(1000, 1000);

            var Withdraw = konto.Withdraw(1000);
            Assert.True(Withdraw);

            Withdraw = konto.Withdraw(600);
            Assert.True(Withdraw);

            Withdraw = konto.Withdraw(500);
            Assert.False(Withdraw);


        }

        [Fact]
        public void LöneTest()
        {
            var konto = new Lönekonto(ttime = new MockTime());

            var insert = konto.Deposit(5000);

            var Withdraw = konto.Withdraw(600);
            Assert.True(Withdraw);

            Withdraw = konto.Withdraw(500);
            Assert.True(Withdraw);

            Withdraw = konto.Withdraw(4000);
            Assert.False(Withdraw);

        }

        [Fact]
        public void LöneMax_Minus()
        {
            var konto = new Lönekonto(ttime = new MockTime());
            var insert = konto.Deposit(5000);

            insert = konto.Deposit(-5000);
            Assert.False(insert);

            insert = konto.Deposit(16000);
            Assert.False(insert);
        }
      
           
            
            [Fact]
        public void Test_DepositMoneyToAccount()
        {
            var konto = new Lönekonto(ttime = new MockTime());
            Assert.False(konto.Deposit(16000));
        }

    }
}
