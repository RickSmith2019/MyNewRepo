using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventBrightApplication.Models;

namespace EventBrightApplication.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            Tickets order = Tickets.GetOrder(this.HttpContext);

            OrderViewModel vm = new OrderViewModel()
            {
                OrderItems = order.GetOrderItems(),
                TicketTotal = order.GetOrderTotal()
            };

            return View(vm);
        }

        //GET: Orders/AddToOrder
        public ActionResult AddToOrder(int id)
        {
            Tickets order = Tickets.GetOrder(this.HttpContext);
            order.AddToOrder(id);
            return RedirectToAction("Index");
            
        }
        
        //POST: Orders/RemoveFromOrder
        [HttpPost]
        public ActionResult RemoveFromOrder()
        {
            throw new NotImplementedException();
        }
    }
}