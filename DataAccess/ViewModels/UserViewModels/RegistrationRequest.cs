using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.UserViewModels
{
    public class RegistrationRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\w{8,}$", ErrorMessage = "Password must be at least 8 characters and contain a-z, A-Z, 0-9, and underscore characters")]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        [RegularExpression(@"(+84|0[3|5|7|8|9])+([0-9]{8})\b", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Affiliation { get; set; }
        public int CountryId { get; set; }
    }
}
