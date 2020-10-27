using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleClass2020.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public decimal UnitPrice { get; set; }
        public int AddedBy { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
