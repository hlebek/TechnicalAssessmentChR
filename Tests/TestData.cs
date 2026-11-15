using System;
using System.Collections.Generic;
using System.Text;
using TechnicalAssessmentChR;

namespace Tests
{
    public static class TestData
    {
        private static string accountName = "ABC";
        private static List<Asset> assets = new List<Asset> {
            new Asset("IBM", 20f, 10f, -10f, 150f),
            new Asset("MSFT", 20f, 20f, 0f, 90f),
            new Asset("ORCL", 20f, 30f, 10f, 220f),
            new Asset("AAPL", 20f, 20f, 0f, 450f),
            new Asset("HD", 20f, 20f, 0f, 70f),
        };

        private static AccountData accountData = new AccountData(accountName, assets);

        public static AccountData GetAccountData()
        {
            return accountData;
        }
    }
}
