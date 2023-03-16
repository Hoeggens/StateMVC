using System.ComponentModel.DataAnnotations;


namespace StateMVC.Views.States
{
    public class IndexVM
    {

        [Display(Name = "Support E-mail")]
        [Required(ErrorMessage = "You must enter an Email")]
        [EmailAddress(ErrorMessage = "Enter a valid E-mail address")]
        public string SupportEmail { get; set; }


        [Display(Name = "Company name")]
        [Required(ErrorMessage = "You must enter a Company name")]

        public string CompanyName { get; set; }
    }
}
