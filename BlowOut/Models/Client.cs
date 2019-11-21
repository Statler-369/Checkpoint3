using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int Client_ID { get; set; }

        [Required(ErrorMessage ="First name is required")]
        [Display(Name ="First name")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last name")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Display(Name = "State")]
        public string State {get; set;}

        [Required(ErrorMessage = "Zipcode is required")]
        [Display(Name = "Zipcode")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone_Number { get; set; }
    }
}