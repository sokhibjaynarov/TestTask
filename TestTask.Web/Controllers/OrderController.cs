using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestTask.Web.Data.IRepositories;
using TestTask.Web.Models;

namespace TestTask.Web.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> create(Order order)
        {
            try
            {
                await orderRepository.CreateAsync(order);
            }
            catch(Exception ex)
            {

            }
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        public async Task<JsonResult> getAll(string id)
        {
            List<Order> orders = new List<Order>();
            try
            {
                orders = (await orderRepository.GetAllAsync()).ToList();
            }
            catch(Exception ex)
            {

            }

            return Json(orders, JsonRequestBehavior.AllowGet);
        }
    }
}