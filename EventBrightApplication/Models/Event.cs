using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventBrightApplication.Models
{
    public class Event : IValidatableObject
    {
        [Key]
        public virtual int EventId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Event Type")]
        public virtual EventType TypeName { get; set; }

        [Required]
        [StringLength(50)]
        public virtual string Title { get; set; }

        [StringLength(150)]
        public virtual string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [greaterThanNow(ErrorMessage = "Date must be greater or equal to today's date.")]
        public virtual DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public virtual DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public virtual DateTime EndDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public virtual DateTime EndTime { get; set; }

        [Required]
        public virtual string Location { get; set; }

        [Display(Name = "Event Type Id")]
        public virtual EventType TypeId { get; set; }

        [Required]
        [Display(Name = "Organizer Name")]
        public virtual string OrganizerName { get; set; }

        [Display(Name = "Organizer Information")]
        public virtual string OrganizerInfo { get; set; }

        [Required]
        [Display(Name = "Maximum Tickets")]
        [notZero(0)]
        public virtual int MaxTickets { get; set; }
        [Required]
        [Display(Name = "Available Tickets")]
        [notZero(0)]
        public virtual int AvailableTickets { get; set; }

        [Required]
        public virtual string City { get; set; }

        [Required]
        public virtual string State { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            if (EndDate < StartDate)
            {
                yield return (new ValidationResult("End Date must be greater then the Start Date."));
            }            
        }
    }

}