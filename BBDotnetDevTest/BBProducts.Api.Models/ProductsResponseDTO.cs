using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace BBProducts.Api.Models 
{
    public class ProductsResponseDTO
    {
        [JsonProperty(PropertyName = "id", Order = 1)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "timestamp", Order = 2)]
        public DateTime Timestamp { get; set; }

        [JsonProperty(PropertyName = "products", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
        public ProductDTO[] Products { get; set; }


    }
}