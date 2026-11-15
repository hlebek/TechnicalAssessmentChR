using System;
using System.Collections.Generic;
using System.Text;
using TechnicalAssessmentChR;

namespace Tests
{
    public class TargetSumPositive
    {
        [Fact]
        public void TargetSumEqualTo100()
        {
            AccountData mockAccountData = TestData.GetAccountData();
            float expectedTargetSum = 100f;

            Assert.Equal(expectedTargetSum, mockAccountData.Assets.Sum(a => a.Target));
        }
    }
}
