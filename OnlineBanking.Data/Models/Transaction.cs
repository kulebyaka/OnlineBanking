using System;
using System.Collections.Generic;

namespace OnlineBanking.Data.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public DateTime TxDate { get; set; }
        public int ClientId { get; set; }
        public int ClientGender { get; set; }
        public int? ClientYearOfBirth { get; set; }
        public long Amount { get; set; }
        public string MerchantUid { get; set; }
        public int MerchantCategory { get; set; }
        public string ShopTags { get; set; }
        public string ShopUid { get; set; }
        public string ShopType { get; set; }
    }
}
