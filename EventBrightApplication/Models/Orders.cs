using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EventBrightApplication.Models;

namespace EventBrightApplication.Models
{
    public class Orders
    {
        [Key]
        [Display(Name = "Order Number")]
        public virtual int OrderNumber { get; set; }
        
        public string OrderId { get; set; }


        [Required]
        [Display(Name = "Number of Tickets")]
        [notZero(0)]
        public virtual int NumberOfTickets { get; set; }


        [Required]
        [Display(Name = "Date Ordered")]
        [DataType(DataType.Date)]
        [greaterThanNow(ErrorMessage = "Date must be greater or equal to today's date.")]
        public DateTime DateOrdered { get; set; }


        [Required]
        [Display(Name = "Event Id")]
        public int EventId { get; set; }
        public Event Title { get; set; } 

        public string Status { get; set; } 

       // public virtual Event EventSelected { get; set; }
    }
}