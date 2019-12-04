using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventBrightApplication.Models
{
    public class Orders
    {
        [Key]
        [Display(Name = "Order Number")]
        public virtual int OrderNumber { get; set; }


        [Required]
        [Display(Name = "Number of Tickets")]
        [notZero(0)]
        public virtual int NumberOfTickets { get; set; }


        [Required]
        [Display(Name = "Date Ordered")]
        [DataType(DataType.Date)]
        [greaterThanNow(ErrorMessage = "Date must be greater or equal to today's date.")]
        public virtual DateTime DateOrdered { get; set; }


        [Required]
        [Display(Name = "Event Id")]
        public virtual Event EventId { get; set; }
    }
}