﻿using System.ComponentModel.DataAnnotations;

namespace BethenyPieShopAdmin.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string AddressLine1 { get; set; } = string.Empty;

        public string? AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter your zip code")]
        public string ZipCode { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string? State { get; set; }

        public string Country { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public decimal OrderTotal { get; set; }

        public DateTime OrderPlaced { get; set; }
    }
}
