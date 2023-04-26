using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StayFit.StayFit_Data.Model.UserDTO;
using StayFit.StayFit_Data.Entity;

namespace StayFit.StayFit_Data.Extensions
{
    public static class UserExtensions
    {
        public static User ToUserEntity(this UserCreateDto userCreateData)
        {
            
            return new User
            {
                Username = userCreateData.Username,
                FirstName = userCreateData.FirstName,
                LastName = userCreateData.LastName,
                HashedPassword = userCreateData.Password,
                UserRole =  userCreateData.UserRole,
                BodyType = userCreateData.BodyType,
                Email = userCreateData.Email,
                Payment = null!,
                
                
            };
        }
        
        public static User ToUserEntity(this UserUpdateDto userUpdateData)
        {
            return new User
            {
                Id = userUpdateData.Id,
                FirstName = userUpdateData.FirstName,
                LastName = userUpdateData.LastName,
                HashedPassword = userUpdateData.Password,
                UserRole =  userUpdateData.UserRole,
                BodyType = userUpdateData.BodyType,
                Email = userUpdateData.Email,
                
            };
        }

        public static UserViewDto ToUserView(this User user)
        {
            return new UserViewDto
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.UserRole.ToString(),
                UserRole =  user.UserRole,
                BodyType = user.BodyType,
                Email = user.Email,
                
            };
        }

        public static UserLoginDto ToUserLoginDto(this User user)
        {
            return new UserLoginDto
            {
                Id = user.Id,
                Role = user.UserRole,
                Username = user.Username,
                HashedPassword = user.HashedPassword,
                
            };
        }
    }
}