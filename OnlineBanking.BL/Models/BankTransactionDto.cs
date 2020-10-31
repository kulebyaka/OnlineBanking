using System;
using System.Collections.Generic;

namespace OnlineBanking.BL.Models
{
    public partial class BankTransactionDto
    {
        public int              TransactionId  { get; set; }
        public DateTime         TxDate         { get; set; }
        public int              Amount         { get; set; }
        public GeoCoordinateDto GeoCoordinate  { get; set; }
        public string           Brand          { get; set; }
        public ECategory        Category       { get; set; }
        public List<string> ShopTags           { get; set; }
        public int ClientId                    { get; set; }
        public EGender ClientGender            { get; set; }      
        public int ClientYearOfBirth           { get; set; }            
        public string MerchantUid              { get; set; }      
        public string ShopUid                  { get; set; }          
        public int ShopTypeId                  { get; set; }          
        

            
        
         
         
         
         
        
          
         
         
         
        
         
         
    }
}

