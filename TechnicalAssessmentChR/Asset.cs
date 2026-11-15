using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalAssessmentChR
{
    public class Asset
    {

        #region Properties

        public string AssetSecurity { get; }
        public float UnitPrice { get; private set; }

        #endregion

        #region Constructors

        public Asset(string assetSecurity, float unitPrice)
        {
            this.AssetSecurity = assetSecurity;
            this.UnitPrice = unitPrice;
        }

        #endregion

        #region Methods

        public void UpdateUnitPrice(float newUnitPrice)
        {
            this.UnitPrice = newUnitPrice;
        }

        #endregion

    }
}
