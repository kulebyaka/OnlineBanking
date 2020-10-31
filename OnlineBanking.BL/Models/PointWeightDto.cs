namespace OnlineBanking.BL.Models
{
    public class PointWeightDto
    {
        public int Value { get; set; }
        public GeoCoordinateDto Point { get; set; }
    }
    
    public class DistrictWeightDto
    {
        public long Value { get; set; }
        public double Color { get; set; }
        public int DistrictId  { get; set; }
    }
}