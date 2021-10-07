using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Manager.BankKonto;

namespace Test
{
    public class LönekontorTest
    {
        [Fact]
        public void SättaPengar()
        {
            var konto = new SalleryAccount(10000);

            var WithrawMoney = konto.AcceptWithrawMoney(5000);
            Assert.False(WithrawMoney);

        }
        [Fact]
        public void LöneTest()
        {
            var konto = new Lönekonto(1000);

            var Withdraw = konto.CanTakeOutMoney(600);
            Assert.True(Withdraw);

            Withdraw = konto.CanTakeOutMoney(500);
            Assert.False(Withdraw);
        }
    }
}
