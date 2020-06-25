using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTL_Assessment.Models
{
    public class OrderUploadDTO
    {
        public string message { get; set; }
        public List<Order> orders { get; set; }
    }
}
