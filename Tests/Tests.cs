using System;
using System.Collections.Generic;
using System.Text;
using TechnicalAssessmentChR;

namespace Tests
{
    public class Tests
    {
        static TestData testData = new TestData();
        private AccountData accountData { get => testData.accountData; }
        private List<Asset> accountAssets { get => new List<Asset>(accountData.Assets.Keys); }
        private List<DataForAsset> accountAssetsData { get => new List<DataForAsset>(accountData.Assets.Values); }

        [Fact]
        public void TargetSumEqualTo100()
        {
            float expectedTargetSum = 100f;

            Assert.Equal(expectedTargetSum, accountAssetsData.Sum(a => a.Target));
        }

        [Fact]
        public void CurrentSumEqualTo100()
        {
            float expectedCurrentSum = 100f;

            Assert.Equal(expectedCurrentSum, accountAssetsData.Sum(a => a.Current));
        }

        [Fact]
        public void VarianceSumEqualToZero()
        {
            float expectedVarianceSum = 0f;

            Assert.Equal(expectedVarianceSum, accountAssetsData.Sum(a => a.Variance));
        }

        [Fact]
        public void TargetValuesPositive()
        {
            Assert.All(accountAssetsData, a => Assert.True(a.Target > 0));
        }

        [Fact]
        public void TargetLessThan100()
        {
            Assert.All(accountAssetsData, a => Assert.True(a.Target <= 100));
        }

        [Fact]
        public void CurrentValuesPositive()
        {
            Assert.All(accountAssetsData, a => Assert.True(a.Current >= 0));
        }

        [Fact]
        public void CurrentLessThan100()
        {
            Assert.All(accountAssetsData, a => Assert.True(a.Current <= 100));
        }

        [Fact]
        public void VarianceInRange()
        {
            Assert.All(accountAssetsData, a => Assert.True(a.Variance >= -100 && a.Variance <= 100));
        }

        [Fact]
        public void UnitePricePositive()
        {
            Assert.All(accountAssets, a => Assert.True(a.UnitPrice > 0));
        }

        [Fact]
        public void UniqueSecurity()
        {
            List<string> assetSecurities = accountAssets.Select(a => a.AssetSecurity).ToList();

            Assert.Distinct(assetSecurities);
        }

        [Fact]
        public void TestOutput()
        {
            List<string> assetSecurities = accountAssets.Select(a => a.AssetSecurity).ToList();

            Assert.Distinct(assetSecurities);
        }
    }
}
