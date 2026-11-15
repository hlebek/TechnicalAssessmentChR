using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalAssessmentChR
{
    public struct Asset
    {

        #region Properties

        public string AssetSecurity { get; }
        public float Target { get; }
        public float Current { get; }
        public float Deviation { get; }
        public float UnitPrice { get; }

        #endregion

        #region Constructors

        public Asset(string assetSecurity, float target, float current, float deviation, float unitPrice)
        {
            AssetSecurity = assetSecurity;
            Target = target;
            Current = current;
            Deviation = deviation;
            UnitPrice = unitPrice;
        }

        #endregion

    }
}
