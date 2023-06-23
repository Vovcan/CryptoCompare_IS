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
    internal class News
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string? Title { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
        [JsonProperty("content")]
        public string? Content { get; set; }
        [JsonProperty("url")]
        public string? Url { get; set; }
        [JsonProperty("publishedAt")]
        [Column("published_at")]
        public string? PublishedAt { get; set; }
        //public string Image { get; set; }
        //public string PublishedAt { get; set; }
        //public string Source { get; set; }

    }
}
