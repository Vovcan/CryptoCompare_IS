using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binance_0._1
{
    internal class TokenData
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty("time")]
        public int Time { get; set; }
        [JsonProperty("high")]
        public double High { get; set; }
        [JsonProperty("low")]
        public double Low { get; set; }
        [JsonProperty("open")]
        public double Open { get; set; }
        [JsonProperty("close")]
        public double Close { get; set; }
        [JsonProperty("volumefrom")]
        [Column("volume_from")]
        public double VolumeFrom { get; set; }
        [JsonProperty("volumeto")]
        [Column("volume_to")]
        public double VolumeTo { get; set; }
        public string? Token { get; set; }
        

        /*
        [JsonProperty("conversiontype")]
        public string? ConversionType { get; set; }
        [JsonProperty("conversionsymbol")]
        public string? ConversionSymbol { get; set; }
        */
    }
}
