using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class CurrencyModel
    {
        [Required]
        
        [Display(Name = "Convert From")]
        public string ConvertFrom { get; set; }
        [Required]

        public float Amount { get; set; }
        [Required]
        
        [Display(Name = "Convert To")]
        public string ConvertTo { get; set; }
        //public IEnumerable<SelectListItem> Items { get; set; } = new List<SelectListItem>
        //{
        //    new SelectListItem{Value = "USD", Text="USD"},
        //    new SelectListItem{Value = "EUR", Text="EUR"},
        //    new SelectListItem{Value = "NGN", Text="NGN"},
        //};
    }
}
