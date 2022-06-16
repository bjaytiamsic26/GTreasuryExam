using System;
using Xunit;
using GTreasury.Core.Logic;
using GTreasury.Core.Model;

namespace GTreasury_Test
{
    public class NpvTest
    {
        private Calculate calc = new Calculate();
        private NPV npvTest = new NPV
        {
            LowerBoundDR = 5,
            UpperBoundDR = 10,
            CashFlow = 10000,
            DiscountRateIncrement = 0.5,
        };

        [Fact]
        public async void CalculateTotalNpv()
        {
            //Arrange
            await calc.CollectCashflow(npvTest);
            var totalNpv = calc.TotalNpv(npvTest.NpvList).Result;


            //Act
            double total = 82687.98;

            //Assert
            Assert.Equal(total.ToString(), totalNpv.ToString());
        }

        [Fact]
        public async void CountNpvList()
        {
            //Arrange
            await calc.CollectCashflow(npvTest);

            //Assert
            Assert.True(npvTest.NpvList.Count == 13);
        }
    }
}
