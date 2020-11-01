using System;
using System.Collections.Generic;

namespace OnlineBanking.BL.Models
{
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Geometry    {
        public string type { get; set; } 
        public List<List<List<double>>> coordinates { get; set; } 
    }

    public class Properties    {
        public int OBJECTID { get; set; } 
        public string DAT_VZNIK { get; set; } 
        public string DAT_ZMENA { get; set; } 
        public double PLOCHA { get; set; } 
        public int ID { get; set; } // district id matches to our db
        public int KOD_MC { get; set; } 
        public string NAZEV_MC { get; set; } 
        public int KOD_MO { get; set; } 
        public string KOD_SO { get; set; } 
        public int TID_TMMESTSKECASTI_P { get; set; } 
        public string POSKYT { get; set; } 
        public int ID_POSKYT { get; set; } 
        public string STAV_ZMENA { get; set; }
        public int Value { get; set; } // value to be populated
        public string NAZEV_1 { get; set; } 
        public double Shape_Length { get; set; } 
        public double Shape_Area { get; set; } 
    }

    public class Feature    {
        public string type { get; set; } 
        public Geometry geometry { get; set; } 
        public Properties properties { get; set; } 
    }

    public class DistrictsDescriptionDto    {
        public string type { get; set; } 
        public string name { get; set; } 
        public List<Feature> features { get; set; } 
    }
}
