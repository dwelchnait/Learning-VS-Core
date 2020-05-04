using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    public class Product
    {
        [JsonPropertyName("Id")]
        public string ProductId { get; set; }
        public string Maker { get; set; }
       
        public string Title { get; set; }
        public string Description { get; set; }
        public int[] Ratings { get; set; }

        //public override string ToString()
        //{
        //    return JsonSerializer.Serialize<Product>(this);
        //}

        public override string ToString() => JsonSerializer.Serialize<Product>(this);
        
    }
}
