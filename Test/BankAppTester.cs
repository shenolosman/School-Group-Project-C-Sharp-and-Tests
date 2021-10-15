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
        private MockTime _time;
        public BankAppTester()
        {
            _time = new MockTime();
        }
        [Fact]
        public void Test_InvesmentAccountWithrawMoneyOnceAYear()
        {
            var account = new InvestmentAccount(_time = new MockTime());

            _time.time = 1;

            account.Deposit(5000);

            var withdraw = account.Withdraw(500);
            Assert.True(withdraw);

            withdraw = account.Withdraw(200);
            Assert.False(withdraw);

            _time.time = Time.YearInMilisec + 100;

            withdraw = account.Withdraw(200);
            Assert.True(withdraw);
        }
        [Fact]
        public void Test_CreditAccountLimit()
        {
            var account = new CreditAccount(1000, 1000);

            var Withdraw = account.Withdraw(1000);
            Assert.True(Withdraw);

            Withdraw = account.Withdraw(600);
            Assert.True(Withdraw);

            Withdraw = account.Withdraw(500);
            Assert.False(Withdraw);
        }
        [Fact]
        public void Test_SalaryAccountDepositAndWithdraw()
        {
            var account = new SalaryAccount(_time = new MockTime());

            var insert = account.Deposit(5000);

            var Withdraw = account.Withdraw(600);
            Assert.True(Withdraw);

            Withdraw = account.Withdraw(500);
            Assert.True(Withdraw);

            Withdraw = account.Withdraw(4000);
            Assert.False(Withdraw);
        }
        [Fact]
        public void Test_SalaryAccount_MinusValue()
        {
            var account = new SalaryAccount(_time = new MockTime());

            var insert = account.Deposit(-5000);
            Assert.False(insert);
        }
        [Fact]
        public void Test_SalaryAccountMaxValue()
        {
            var account = new SalaryAccount(_time = new MockTime());

            var insert = account.Deposit(5000);
            insert = account.Deposit(5000);
            insert = account.Deposit(5000);
            Assert.True(insert);

            insert = account.Deposit(5000);
            Assert.False(insert);

        }
        [Fact]
        public void Test_SalaryAccountCheckTime()
        {
            var account = new SalaryAccount(_time = new MockTime());
            _time.time = 1;

            var insert = account.Deposit(5000);
            insert = account.Deposit(5000);
            insert = account.Deposit(5000);
            Assert.True(insert);

            _time.time = Time.DayInMillisec + 2;

            insert = account.Deposit(5000);
            Assert.True(insert);
        }
        [Fact]
        public void Test_SaveAccountRateInAYear()
        {
            var account = new SaveAccount(_time = new MockTime());
            var insert = account.Deposit(10000);

            var Withdraw = account.Withdraw(1000);
            Withdraw = account.Withdraw(1000);
            Withdraw = account.Withdraw(1000);
            Withdraw = account.Withdraw(1000);
            Withdraw = account.Withdraw(1000);

            Assert.True(Withdraw);

            Withdraw = account.Withdraw(1000);
            Assert.Equal(3990, account.Balance);
        }
        [Fact]
        public void Test_SaveAccountRateAfterOneYear()
        {
            var account = new SaveAccount(_time = new MockTime());
            _time.time = 1;

            var insert = account.Deposit(10000);
            var Withdraw = account.Withdraw(1000);
            Withdraw = account.Withdraw(1000);
            Withdraw = account.Withdraw(1000);
            Withdraw = account.Withdraw(1000);
            Withdraw = account.Withdraw(1000);
            _time.time = Time.YearInMilisec + 10;

            Withdraw = account.Withdraw(1000);
            Assert.Equal(4000, account.Balance);
        }
    }
}
