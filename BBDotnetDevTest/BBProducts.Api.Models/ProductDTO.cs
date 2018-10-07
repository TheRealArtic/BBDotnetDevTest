using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace BBProducts.Api.Models
{
    public class ProductDTO
    {
        [JsonProperty(PropertyName = "id", Order = 1)]
        public long ID { get; set; }

        [JsonProperty(PropertyName ="name", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "quantity", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
        public int? Quantity { get; set; }

        [JsonProperty(PropertyName = "sale_amount", Order = 4, NullValueHandling = NullValueHandling.Ignore)]
        public double? SaleAmount { get; set; }
    }
}