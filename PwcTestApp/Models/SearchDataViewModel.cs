using System.ComponentModel.DataAnnotations;

namespace PwcTestApp.Models
{
    public class SearchDataViewModel
    {
        [Required(ErrorMessage = "Please provide company name")]
        [Display(Name = "Company name")]
        public string SearchString { get; set; } 
    }
}