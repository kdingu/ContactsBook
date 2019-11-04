﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContactsBook.Models
{
    public class Phone
    {
        public int Id { get; set; }

        [Display(Name = "Phone Number")]
        [StringLength(255)]
        [Required]
        public string PhoneNumber { get; set; }

        public Contact Contact { get; set; }
        [ForeignKey("Contact")]
        public int ContactId { get; set; }
    }
}