using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace TokenExWebDemo.Models
{
    public class IframeViewModel
    {
        public static IEnumerable<SelectListItem> Years => new SelectList(Utility.GenerateYears(), "key", "value");

        public static IEnumerable<SelectListItem> Months => new SelectList(Utility.GenerateMonths(), "key", "value");

        [Required]
        public string Token { get; set; } = string.Empty;

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public int ExpMonth { get; set; } = 0;

        [Required]
        public int ExpYear { get; set; } = 0;

        [Required]
        [DisplayName("CVV")]
        [Range(100, 9999, ErrorMessage = "CVV is Invalid")]
        public int CVV { get; set; } = 0;

        public string IframeData { get; set; } = string.Empty;
    }
}