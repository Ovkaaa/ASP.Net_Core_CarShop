using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int ID { get; set; }

        [Display(Name = "Enter name:")]
        [MinLength(1)]
        [Required(ErrorMessage = "Name is at least 1 characters long")]
        public string Name { get; set; }

        [Display(Name = "Enter Surname:")]
        [MinLength(1)]
        [Required(ErrorMessage = "Surname is at least 1 characters long")]
        public string Surname { get; set; }

        [Display(Name = "Your adress:")]
        [MinLength(5)]
        [Required(ErrorMessage = "Adress is at least 5 characters long")]
        public string Adress { get; set; }

        [Display(Name = "Enter phone number:")]
        [DataType(DataType.PhoneNumber)]
        [MinLength(10)]
        [Required(ErrorMessage = "Phone number is at least 10 characters long")]
        public string Phone { get; set; }

        [Display(Name = "Enter email:")]
        [DataType(DataType.EmailAddress)]
        [MinLength(5)]
        [Required(ErrorMessage = "Email is at least 5 characters long")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
