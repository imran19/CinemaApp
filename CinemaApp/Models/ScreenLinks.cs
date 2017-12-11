using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaApp.Models
{
    public class ScreenLinks
    {
        [Key]
        public int Id { get; set; }

        public string ScreenLink { get; set; }
    }
}