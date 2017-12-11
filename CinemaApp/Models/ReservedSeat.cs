using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaApp.Models
{
    public class ReservedSeat
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname Required")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Time Required")]
        public string Time { get; set; }
        [Required(ErrorMessage = "Date Required")]
        public string Date { get; set; }
        [Required(ErrorMessage = "Seat number(s) Required")]
        public string ReservedSeats { get; set; }
    }
}