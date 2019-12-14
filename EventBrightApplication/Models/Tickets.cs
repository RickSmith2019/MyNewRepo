using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventBrightApplication.Models
{
    public class Tickets
    {
        public string TicketId;

        private EventBrightApplicationDB db = new EventBrightApplicationDB();
        
        public static Tickets GetOrder(HttpContextBase context)
        {
            Tickets order = new Tickets();
            order.TicketId = order.GetOrderId(context);
            return order;
        }

        private string GetOrderId(HttpContextBase context)
        {
            const string OrderSessionId = "OrderId";

            string orderId;

            if(context.Session[OrderSessionId] == null)
            {
                // Create a new order id
                orderId = Guid.NewGuid().ToString();

                // Save to the session date
                context.Session[OrderSessionId] = orderId;
            }
            else
            {
                // Return the existing order id
                orderId = context.Session[OrderSessionId].ToString();
            }

            return orderId;            
        }

        public List<Orders> GetOrderItems()
        {
            return db.Orders.Where(c => c.OrderId == this.TicketId).ToList();
        }

        public int GetOrderTotal()
        {
            int? total = (from ticketItem in db.Orders
                       where ticketItem.OrderId == this.TicketId
                       select (int?)ticketItem.NumberOfTickets).Sum();

            return total ?? 0;

        }

        public void AddToOrder(int eventId)
        {
            //Verify event id.
            Orders orderItem = db.Orders.SingleOrDefault(c => c.OrderId == this.TicketId && c.EventId == eventId);
            if(orderItem == null)
            {
                // item is not in order; add new cart item
                orderItem = new Orders()
                {
                    OrderId = this.TicketId,
                    EventId = eventId,
                    NumberOfTickets = 1,
                    DateOrdered = DateTime.Now
                };

                db.Orders.Add(orderItem);
            }
            else
            {
                orderItem.NumberOfTickets++;
              // Item is already in order; increase item count (quantity) 
            }

            db.SaveChanges();               
        }
    }    
}