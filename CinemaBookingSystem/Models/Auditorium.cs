using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Models
{
    public class Auditorium
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        [Required]
        public int BookedSeats { get; set; }
        
        public IList<Screening> Screenings { get; set; }
    }
}
