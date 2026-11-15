using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalAssessmentChR
{
    public struct AccountData
    {

        #region Properties

        public string AccountName { get; }
        public List<Asset> Assets { get; set; }

        #endregion

        #region Constructors

        public AccountData(string accountName, List<Asset> assets)
        {
            AccountName = accountName;
            Assets = assets;
        }

        #endregion

    }
}
