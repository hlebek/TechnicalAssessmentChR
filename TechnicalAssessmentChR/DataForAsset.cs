namespace TechnicalAssessmentChR
{
    public class DataForAsset
    {

        #region Properties

        public float Target { get; set; }
        public float Current { get; set; }
        public float Variance { get => Current - Target; }

        #endregion

        #region Constructors

        public DataForAsset(float target, float current)
        {
            this.Target = target;
            this.Current = current;
        }

        #endregion

        #region Methods

        public float GetOutput(float totalAssetsValue, Asset asset)
        {
            return (totalAssetsValue * (Variance / 100)) / asset.UnitPrice;
        }

        #endregion

    }
}
