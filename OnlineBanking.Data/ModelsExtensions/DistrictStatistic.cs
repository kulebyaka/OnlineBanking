using Newtonsoft.Json;

namespace OnlineBanking.Data.Models
{
    public class DistrictStatistic
    {
        [JsonProperty("num")]
        public int Num { get; set; } 

        [JsonProperty("mean_amount")]
        public double MeanAmount { get; set; } 

        [JsonProperty("median_amount")]
        public double MedianAmount { get; set; } 

        [JsonProperty("mean_user_amount")]
        public double MeanUserAmount { get; set; } 
    }
}