﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PieShopApp.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        [Required(ErrorMessage ="Please enter your first name")]
        [DisplayName("First name")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your last name")]
        [DisplayName("Last name")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your address")]
        [DisplayName("Address line 1")]
        [StringLength(100)]
        public string AddressLine1 { get; set; } = string.Empty;

        [DisplayName("Address line 2")]
        [StringLength(100)]
        public string? AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter your zip code")]
        [DisplayName("Zip code")]
        [StringLength(10)]
        public string ZipCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your city")]
        [DisplayName("City")]
        [StringLength(50)]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your country")]
        [DisplayName("Country")]
        [StringLength(50)]
        public string Country { get; set; } = string.Empty;

        [DisplayName("State")]
        [StringLength(50)]
        public string? State { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [DisplayName("Phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(25)]
        public string PhoneNumber { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please enter your email address")]
        [DisplayName("Email address")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; } = string.Empty;
        [BindNever]
        public decimal OrderTotal { get; set; }
        [BindNever]
        public DateTime CreatedDate { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
    }
}
