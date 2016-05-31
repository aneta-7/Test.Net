using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryMVC.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string ISBN { get; set; }

    }
}