using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics;


namespace Test
{
    public class LönekontorTest
    {
        private MockTime time;

        [Fact]
        public void SättaPengar()
        {
            //var konto = new SalleryAccount(10000);

            //var WithrawMoney = konto.AcceptWithrawMoney(5000);
            //Assert.False(WithrawMoney);

        }
        [Fact]
        public void LöneTest()
        {
            var konto = new Lönekonto(time = new MockTime());

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
            time = new MockTime();
            Lönekonto konto = new Lönekonto(time = new MockTime());


            Assert.True(konto.CanPutInMoney(10000));


        }
    }
}
