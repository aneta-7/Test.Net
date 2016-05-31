using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryMVC.Models
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MinLength(3)]
        [MaxLength(60)]
        [Required]
        public string Name { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        [Required]
        public string Surname { get; set; }

     
    }
}