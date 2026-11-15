namespace TechnicalAssessmentChR
{
    public class DataForAsset
    {
        public float Target { get; set; }
        public float Current { get; set; }
        public float Variance { get => Current - Target; }

        public DataForAsset(float target, float current)
        {
            this.Target = target;
            this.Current = current;
        }

        public float GetOutput(float totalAssetsValue, Asset asset)
        {
            return (totalAssetsValue * (Math.Abs(Variance) / 100)) / asset.UnitPrice;
        }
    }
}