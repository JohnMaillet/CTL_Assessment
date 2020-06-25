using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTL_Assessment.Models
{
    public class Order
    {
        [Key]
        [DisplayName("Order Id")]
        [JsonProperty("orderId")]
        public int OrderId { get; set; }
        [DisplayName("First Name")]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [DisplayName("Address")]
        [JsonProperty("addr1")]
        public string Addr1 { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("postal")]
        public string Postal { get; set; }
        [JsonProperty("sku")]
        public string SKU { get; set; }
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }
        
    }
}
