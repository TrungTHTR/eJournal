using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.UserViewModels
{
    public  class UserViewAllModel
    {
        [Key]
        public Guid? Id { get; set; }    
        public string Email { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string PhoneNumber { get; set; }
        public string? RefreshToken { get; set; }
        public string Address { get; set; }
        public string Affiliation { get; set; }
      

        public string RoleName { get; set; }
       

        public string CountryName { get; set; }
    }
}
