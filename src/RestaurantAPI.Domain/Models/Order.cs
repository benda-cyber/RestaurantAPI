using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Domain.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public double TotalPrice { get; set; }

        public DateTime CreatedTime { get; set; }
        
        public bool IsPaid { get; set; }

        public ICollection<Dish> Dishes { get; set; }
    }
}