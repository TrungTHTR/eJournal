using Application.Utils;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers
{
    public class UserMappingProfile: Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegistrationRequest, Account>()
                .ForMember(nameof(Account.PasswordHash), config => config.Ignore())
                .ForMember(nameof(Account.PasswordSalt), config => config.Ignore())
                .AfterMap((src, dest) =>
                {
                    EncryptionUtils.Encrypt(src.Password, out byte[] salt, out byte[] hash);
                    dest.PasswordSalt = salt;
                    dest.PasswordHash = hash;
                    dest.RoleId = 5;
                })
                .ForAllMembers(config => config.Condition((src, dest, value) => value != null));
        }
    }
}
