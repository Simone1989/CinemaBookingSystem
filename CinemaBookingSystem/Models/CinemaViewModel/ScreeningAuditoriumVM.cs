using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Models.CinemaViewModel
{
    public class ScreeningAuditoriumVM
    {
        public IList<Screening> Screenings { get; set; }
        public IList<Auditorium> Auditoriums { get; set; }


    }
}
