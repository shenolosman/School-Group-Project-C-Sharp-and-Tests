using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager;
using Xunit;

namespace Test
{
    public class InvesteringkontoTest
    {
        private MockTime ttime;

        public InvesteringkontoTest()
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

    }
}
