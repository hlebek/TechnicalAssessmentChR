using TechnicalAssessmentChR;

namespace Tests
{
    public class UnitTest1
    {
        public string expectedAccountName = "ABC";

        [Fact]
        public void Test1()
        {
            Asset asset = new Asset("IBM", 20f, 10f, -10f, 150f);
            AccountData accountData = new AccountData("ABC", new List<Asset> { asset });

            Assert.Equal(expectedAccountName, accountData.AccountName);
        }
    }
}
