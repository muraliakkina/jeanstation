using JeanStation.UserService.DAL;
using JeanStation.UserService.Models;
using System.Collections.Generic;

namespace JeanStation.UserService.Services
{
    public class UserServices: IUserServices
    {
        // dependency constructor injection of IAccountRepository
        private readonly IUserRepository _repo;

        public UserServices(IUserRepository userRepository)
        {
            this._repo = userRepository;
        }

        public User AddNewUser(User user)
        {
            try
            {
                return _repo.AddNewUser(user);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public UserAddress AddNewUserAddress(UserAddress address)
        {
            try
            {
                return _repo.AddNewUserAddress(address);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public bool CheckUser(string email)
        {
            try
            {
                return _repo.CheckUser(email);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public bool DeleteUserAddress(int addressId)
        {
            try
            {
                return _repo.DeleteUserAddress(addressId);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public User EditUser(int UserId, User user)
        {
            try
            {
                return _repo.EditUser(UserId, user);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public UserAddress EditUserAddress(int addressId, UserAddress address)
        {
            try
            {
                return _repo.EditUserAddress(addressId, address);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public UserAddress GetNewUserAddress(int addressId)
        {
            try
            {
                return _repo.GetNewUserAddress(addressId);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public User GetUser(int UserId)
        {
            try
            {
                return _repo.GetUser(UserId);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public List<UserAddress> GetUserAddressByUserId(int userId)
        {
            try
            {
                return _repo.GetUserAddressByUserId(userId);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public bool UserPasswordReset(string email, string pass)
        {
            try
            {
                return _repo.UserPasswordReset(email, pass);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public User Login(Login login)
        {
            try
            {
                return _repo.Login(login);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }
}
