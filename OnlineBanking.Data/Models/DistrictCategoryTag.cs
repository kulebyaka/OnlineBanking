using System;
using System.Collections.Generic;

namespace OnlineBanking.Data.Models
{
    public partial class DistrictCategoryTag
    {
        public int? Num { get; set; }
        public int? UserNum { get; set; }
        public double? MeanAmount { get; set; }
        public double? MedianAmount { get; set; }
        public double? MeanUserAmount { get; set; }
        public int Id { get; set; }
        public int DistrictId { get; set; }
        public int TagId { get; set; }
    }
}
