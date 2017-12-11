using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaApp.Models
{
    public class Movie
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Director required")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Stars required")]
        public string Stars { get; set; }

        [Required(ErrorMessage = "Information required")]
        public string Information { get; set; }

        [Required(ErrorMessage ="Released Date required")]
        public DateTime ReleasedDate { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public byte[] Image { get; set; }

        [Required(ErrorMessage = "Price Required")]
        public int Price { get; set; }

        public string Time1 { get; set; }
        public string Time2 { get; set; }
        public string Time3 { get; set; }

        public string ScreenLinkTime1 { get; set; }
        public string ScreenLinkTime2 { get; set; }
        public string ScreenLinkTime3 { get; set; }
    }
}