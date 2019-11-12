using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContactsBook.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [StringLength(255)]
        [Required]
        [RegularExpression("^[a-zA-Z\\s]*$", ErrorMessage = "No numbers are allowed in this field.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(255)]
        [Required]
        [RegularExpression("^[a-zA-Z\\s]*$", ErrorMessage = "No numbers are allowed in this field.")]
        public string LastName { get; set; }
    }
}