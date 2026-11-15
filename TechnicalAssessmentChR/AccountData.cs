using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalAssessmentChR
{
    public struct AccountData
    {

        #region Properties

        public string AccountName { get; }

        public float TotalAssetsValue { get; private set; }
        public Dictionary<Asset, DataForAsset> Assets { get; private set; }

        #endregion

        #region Constructors

        public AccountData(string accountName, float totalAssetsValue, Dictionary<Asset, DataForAsset> assets)
        {
            this.AccountName = accountName;
            this.TotalAssetsValue = totalAssetsValue;
            this.Assets = assets;
        }

        #endregion

        #region Methods

        public void SetTotalAssetsValue(float newTotalAssetsValue)
        {
            this.TotalAssetsValue = newTotalAssetsValue;
        }

        #endregion

    }
}
