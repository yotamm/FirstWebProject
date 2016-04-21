using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attempt1.Models
{
    public class UvCheckViewModel
    {
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        public double? Data { get; set; }
    }
}