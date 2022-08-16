using System.ComponentModel.DataAnnotations;

namespace SabaTest.Data.Model
{
    public class Customer
    {
        [Required(ErrorMessage = "First name is required."), MaxLength(20)]
        [Display(Name = "First Number")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required."), MaxLength(20)]
        [Display(Name = "Last Number")]
        public string LastName { get; set; }
    }
}
