using System;
using System.Collections.Generic;

namespace OnlineBanking.Data.Models
{
    public partial class Shop
    {
        public int Id { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string ShopUid { get; set; }
        public int PragueId { get; set; }
    }
}
