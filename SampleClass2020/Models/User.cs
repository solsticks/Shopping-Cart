using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleClass2020.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage ="Maxlength allowed is 20 characters")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Maxlength allowed is 20 characters")]
        public string FirstName { get; set; }


    }
}
