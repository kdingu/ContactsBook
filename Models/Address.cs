using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContactsBook.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Display(Name = "Address")]
        [StringLength(255)]
        [Required]
        public string ContactAddress { get; set; }

        public Contact Contact { get; set; }
        [ForeignKey("Contact")]
        public int ContactId { get; set; }
    }
}