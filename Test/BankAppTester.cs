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
        private MockTime time;

        public BankAppTester()
        {
            time = new MockTime();
        }
        [Fact]
        public void Test_InvesteringTid()
        {
            var konto = new Investeringskonto(time = new MockTime());
            time.time = 1;
            var insert = konto.Deposit(5000);
            var withdraw = konto.Withdraw(500);
            Assert.True(withdraw);

            withdraw = konto.Withdraw(200);
            Assert.False(withdraw);
            time.time = Time.YearInMilisec + 100;

            withdraw = konto.Withdraw(200);
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
            var konto = new Lönekonto(time = new MockTime());

            var insert = konto.Deposit(5000);

            var Withdraw = konto.Withdraw(600);
            Assert.True(Withdraw);

            Withdraw = konto.Withdraw(500);
            Assert.True(Withdraw);

            Withdraw = konto.Withdraw(4000);
            Assert.False(Withdraw);

        }

        [Fact]
        public void LönekontoMinus()
        {
            var konto = new Lönekonto(time = new MockTime());
            
            var insert = konto.Deposit(-5000);
            Assert.False(insert);

            insert = konto.Deposit(16000);
            Assert.False(insert);
        }

        [Fact]
        public void Lönekontomax15000()
        {
            var konto = new Lönekonto(time = new MockTime());

            var insert = konto.Deposit(5000);
            insert = konto.Deposit(5000);
            insert = konto.Deposit(5000);
            Assert.True(insert);

            insert = konto.Deposit(5000);
            Assert.False(insert);

        }
        [Fact]
        public void LönekontoTid()
        {
            var konto = new Lönekonto(time = new MockTime());
            time.time = 1;
            var insert = konto.Deposit(5000);
            insert = konto.Deposit(5000);
            insert = konto.Deposit(5000);
            Assert.True(insert);
            time.time = Time.DayInMillisec + 2;

            insert = konto.Deposit(5000);
            Assert.True(insert);

        }



        [Fact]
        public void Sparkonto5Utag()
        {
            var konto = new Sparkonto(time = new MockTime());
            var insert = konto.Deposit(10000);

            var Withdraw = konto.Withdraw(1000);
             Withdraw = konto.Withdraw(1000);
             Withdraw = konto.Withdraw(1000);
             Withdraw = konto.Withdraw(1000);
             Withdraw = konto.Withdraw(1000);

            Assert.True(Withdraw);

            Withdraw = konto.Withdraw(1000);
            Assert.Equal(3990,konto.Balance);

        }

        [Fact]
        public void Sparkonto_5_utag_1_år()
        {
            var konto = new Sparkonto(time = new MockTime());
            time.time = 1;

            var insert = konto.Deposit(10000);
            var Withdraw = konto.Withdraw(1000);
            Withdraw = konto.Withdraw(1000);
            Withdraw = konto.Withdraw(1000);
            Withdraw = konto.Withdraw(1000);
            Withdraw = konto.Withdraw(1000);
            time.time = Time.YearInMilisec + 10;

            Withdraw = konto.Withdraw(1000);
            Assert.Equal(4000, konto.Balance);

        }

    }
}
