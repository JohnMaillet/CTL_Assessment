using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using CsvHelper;
using CTL_Assessment.BLL;
using CTL_Assessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CTL_Assessment.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IConfiguration _configuration;
        public OrdersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            List<Order> orders = await ProcessOrders.ReadOrders(file);            
            OrderUploadDTO dto = new OrderUploadDTO
            {
                message = "Data Uploaded Successfully!",
                orders = orders
            };
            JsonResult jsonResult = Json(dto);
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Progress()
        {
            return this.Content(Startup.Progress.ToString());
        }


        [HttpPost]
        public ActionResult Confirmation(string orders)
        {  
            try {
                IList<Order> listOrders = JsonConvert.DeserializeObject<List<Order>>(orders);
                //IList<Order> listOrders = JsonSerializer.Deserialize<IList<Order>>(orders);
                return View(listOrders);
            } catch (Exception e)
            {
                return null;
            }
        }
        [HttpPost]
        public ActionResult Process()
        {
            return View();
        }
    }
}

