using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SMS.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Issue { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        
        public bool Active { get; set; } = true;

        // ticket owned by a student
        public int StudentId { get; set; }      // foreign key
        public Student Student { get; set; }    // navigation property
    } 
}
