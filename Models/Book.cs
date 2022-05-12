using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4_MVC.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int Pages { get; set; }

        [Required]
        [StringLength(40)]
        public string Author { get; set; }

        public virtual ICollection<CustomerBook> CustomerBooks { get; set; }
    }
}
