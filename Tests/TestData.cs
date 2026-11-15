using System;
using System.Collections.Generic;
using System.Text;
using TechnicalAssessmentChR;

namespace Tests
{
    public class TestData
    {

        #region Variables

        private string accountName = "ABC";
        private float totalAssetsValue = 100000f;
        private Dictionary<Asset, DataForAsset> assetsToTest = new Dictionary<Asset, DataForAsset> {
            { new Asset("IBM", 150f), new DataForAsset(20f, 10f) },
            { new Asset("MSFT", 90f), new DataForAsset(20f, 20f) },
            { new Asset("ORCL", 220f), new DataForAsset(20f, 30f) },
            { new Asset("AAPL", 450f), new DataForAsset(20f, 20f) },
            { new Asset("HD", 70f), new DataForAsset(20f, 20f) },
        };

        public AccountData accountData;

        #endregion

        #region Constructors

        public TestData()
        {
            accountData = new AccountData(accountName, totalAssetsValue, assetsToTest);
        }

        public TestData(string accountName)
        {
            accountData = new AccountData(accountName, totalAssetsValue, assetsToTest);
        }

        public TestData(string accountName, float totalAssetsValue)
        {
            accountData = new AccountData(accountName, totalAssetsValue, assetsToTest);
        }

        public TestData(string accountName, Dictionary<Asset, DataForAsset> assets)
        {
            accountData = new AccountData(accountName, totalAssetsValue, assets);
        }

        public TestData(string accountName, float totalAssetsValue, Dictionary<Asset, DataForAsset> assets)
        {
            accountData = new AccountData(accountName, totalAssetsValue, assets);
        }

        #endregion

    }
}
