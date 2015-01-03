using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyBoni.Models
{
    public class Restaurant
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "coordinates")]
        public float[] Coordinates { get; set; }

        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }

        public double? Rating { get; set; }
    }
}