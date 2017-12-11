using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Birthday required")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Place of Birth required")]
        public string PlaceOfBirth { get; set; }

        [Required(ErrorMessage = "Email required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Not a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telephone required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3,4})$", ErrorMessage = "Not a valid Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Address required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Username required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Salary required")]
        [RegularExpression(@"\d+(,\d{1,2})?", ErrorMessage = "Not a valid Salary")]
        public int Salary { get; set; }

        public DateTime StartedDate { get; set; }

        public bool Active { get; set; }

        public int Role { get; set; }

        public UserAccount()
        {
            StartedDate = DateTime.Now;
        }


    }
}