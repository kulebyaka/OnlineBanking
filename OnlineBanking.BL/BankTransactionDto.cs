using System;

namespace OnlineBanking.BL
{
    public class BankTransactionDto
    {
        public int              Id             { get; set; }
        public DateTime         Date           { get; set; }
        public decimal          Change         { get; set; }
        public string           Currency       { get; set; }
        public GeoCoordinateDto GeoCoordinate  { get; set; }
        public string           Brand          { get; set; }
        public string           Category       { get; set; }
        public int              CategoryId     { get; set; }
        public string           Note           { get; set; }

    }
}