using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleClass2020.Models
{
    public class Product
    {
        [Key]
        public int ProdId { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage ="Maxlength allowed is 30")]
        public string ProductName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int UserId { get; set; }
        public User AddedBy { get; set; }
        public string Photo { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;


    }
}
