using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventBrightApplication.Models
{
    public class EventType
    {
        [Key]
        [Display(Name = "Event Type Id")]
        public virtual int TypeId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Event Type")]
        public virtual string TypeName { get; set; }

        [StringLength(150)]
        [Display(Name = "Event Type Description")]
        public virtual string TypeDescription { get; set; }
    }
}