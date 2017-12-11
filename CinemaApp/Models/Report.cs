using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaApp.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }

        public int ReceptionistId { get; set; }
        public string ReceptionistName { get; set; }
        public string ReceptionistSurname { get; set; }
        public bool isSolved { get; set; }

        [Required(ErrorMessage ="Write the issue!")]
        public string Issue { get; set; }

    }
}