using StayFit.StayFit_Data.Extension;
using StayFit.StayFit_Data.Model.UserDTO;
using StayFit.StayFit_Data.Entity;
using StayFit.StayFit_Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using StayFit.StayFit_Data.Extensions;

namespace StayFit.StayFit_Data.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
   

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        
    }

    

    public async Task<List<UserViewDto>> ListUsers()
    {
        return (await _userRepository.GetAll())
            .Select(user => user.ToUserView())
            .ToList();
    } 

    public async Task<UserViewDto> NewUser(UserCreateDto newUser)
    {
        var userEntity = newUser.ToUserEntity();
        await _userRepository.Add(userEntity);
        return userEntity.ToUserView();
    }

    public async Task<UserViewDto> GetById(int userId) => (await _userRepository.Get(userId)).ToUserView();
    
    
    public async Task<UserLoginDto> GetLoginDtoByUserName(string username)
    {
        var user = await _userRepository.GetByUserName(username);
        /*var functionId = await GetFunctionId(user);*/
        return user.ToUserLoginDto();
    } 

    public async Task DeleteById(int userId) => await _userRepository.Delete(userId);

    public async Task<UserViewDto> UpdateUser(UserUpdateDto updatedUser)
    {
        return (await _userRepository.Update(updatedUser.ToUserEntity())).ToUserView();
    }

    /*private async Task<int?> GetFunctionId(User user)
    {
        if (user.Role == UserRole.Customer)
        {
            var customers = await _customerRepository.GetAll();
            return customers.Single(customer => customer.User.Id == user.Id)?.Id;
        }
        
        if (user.Role == UserRole.Partner)
        {
            var partners = await _partnerRepository.GetAll();
            return partners.Single(partner => partner.User.Id == user.Id)?.Id;
        }
     
        return null;
    }*/
}