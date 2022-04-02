using JeanStation.UserService.Models;
using System.Collections.Generic;

namespace JeanStation.UserService.Services
{
    public interface IUserServices
    {
        User AddNewUser(User user);
        User EditUser(int UserId, User user);
        bool UserPasswordReset(string email, string pass);
        UserAddress AddNewUserAddress(UserAddress address);
        UserAddress EditUserAddress(int addressId, UserAddress address);
        bool DeleteUserAddress(int addressId);
        bool CheckUser(string email);
        User GetUser(int UserId);
        List<UserAddress> GetUserAddressByUserId(int userId);

        UserAddress GetNewUserAddress(int addressId);

        User Login(Login login);
    }
}
