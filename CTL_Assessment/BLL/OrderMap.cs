using CsvHelper.Configuration;
using CTL_Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTL_Assessment.BLL
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Map(m => m.OrderId).Name("OrderId");
            Map(m => m.FirstName).Name("FirstName");
            Map(m => m.LastName).Name("LastName");
            Map(m => m.Addr1).Name("Addr1");
            Map(m => m.City).Name("City");
            Map(m => m.State).Name("State");
            Map(m => m.Postal).Name("Postal");
            Map(m => m.SKU).Name("SKU", "Sku");
            Map(m => m.Quantity).Name("Quantity");
        }
    }
}
