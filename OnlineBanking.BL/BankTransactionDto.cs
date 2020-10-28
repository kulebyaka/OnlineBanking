using System;

namespace OnlineBanking.BL
{
    public class BankTransactionDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Change { get; set; }
        public string Currency { get; set; }
        public string Summary { get; set; }
    }
}