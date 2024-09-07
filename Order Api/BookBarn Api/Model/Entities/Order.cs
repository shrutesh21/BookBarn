using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookBarn_Api.Model.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int userId { get; set; }

        [Required]
        [ForeignKey("CartId")]
        public int CartId { get; set; }  // Reference to the Book microservice (no direct relationship)

        [Required]
        [StringLength(20, ErrorMessage = "Order status can't be longer than 20 characters.")]
        public string OrderStatus { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be a positive value.")]
        public double TotalAmount { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Shipping address can't be longer than 200 characters.")]
        public string ShippingAddress { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Payment method can't be longer than 50 characters.")]
        public string PaymentMethod { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
    }
}
