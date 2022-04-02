using JeanStation.UserService.Models;
using System.Collections.Generic;

namespace JeanStation.UserService.DAL
{
    public interface IUserRepository
    {
        // Functions to perform the neccessary changes in User and Address Tables in the database 
        User AddNewUser(User user);
        User EditUser(int UserId,User user);
        bool UserPasswordReset(string email,string pass);
        UserAddress AddNewUserAddress(UserAddress address);
        UserAddress EditUserAddress(int addressId, UserAddress address );
        bool DeleteUserAddress(int addressId);
        bool CheckUser(string email);
        User GetUser(int userId);

        List<UserAddress> GetUserAddressByUserId(int userId);

        UserAddress GetNewUserAddress(int addressId);

        User Login(Login login);
    }
}
