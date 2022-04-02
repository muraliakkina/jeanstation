using JeanStation.UserService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JeanStation.UserService.DAL
{
    public class UserRepository : IUserRepository
    {
        // dependency constructor injection of Context Class 
        private readonly UserDbContext _dbContext;
        public UserRepository(UserDbContext jeanStationDbContext)
        {
            this._dbContext = jeanStationDbContext;
        }

        // Adding New User through Registration
        public User AddNewUser(User user)
        {
            try
            {
                User user1 = _dbContext.Users.Where(s=>s.Email == user.Email).SingleOrDefault(); 
                if(user1 == null)
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    _dbContext.Users.Add(user);
                    _dbContext.SaveChanges();
                    return user;
                }
                else
                {
                    return null;
                }
                
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // Adding New Address for a User
        public UserAddress AddNewUserAddress(UserAddress userAddress)
        {
            try
            {
               /* User user = _dbContext.Users.Find(userId);
                userAddress.User = user;*/
               
                _dbContext.UserAddresses.Add(userAddress);
                _dbContext.SaveChanges();
                return userAddress;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // To Delete a User Address
        public bool DeleteUserAddress(int addressId)
        {
            try
            {
                // Getting the Full User Address 
                UserAddress userAddress = _dbContext.UserAddresses.Find(addressId);
                if (userAddress == null)
                {
                    return false;
                }
                else
                {
                    _dbContext.UserAddresses.Remove(userAddress);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // Editing the details of User
        public User EditUser(int UserID,User user)
        {
            try
            {
                // getting the user details
                User user1 = _dbContext.Users.Find(UserID);
                if (user1 == null)
                {
                    return null;
                }
                else
                {
                    user1.UserName = user.UserName;
                    user1.Email = user.Email;
                    user1.MobileNo = user.MobileNo;
                    _dbContext.Users.Update(user1);
                    _dbContext.SaveChanges();
                    return user1;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // Editing the address of the User
        public UserAddress EditUserAddress(int addressId, UserAddress userAddress)
        {
            try
            {
                UserAddress userAddress1 = _dbContext.UserAddresses.Find(addressId);
                if(userAddress1 == null)
                {
                    return null ;
                }
                else
                {
                    userAddress1.District = userAddress.District;
                    userAddress1.State = userAddress.State;
                    userAddress1.Pincode = userAddress.Pincode;
                    userAddress1.StreetName = userAddress.StreetName;
                    userAddress1.City = userAddress.City;   
                    userAddress1.DoorNo = userAddress.DoorNo;
                    userAddress1.Locality = userAddress.Locality;
                    _dbContext.UserAddresses.Update(userAddress1);
                    _dbContext.SaveChanges();
                    return userAddress1;
                }
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
                User user = _dbContext.Users.SingleOrDefault(s => s.Email == email);
                if(user == null )
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public bool UserPasswordReset(string email,string pass)
        {
            try
            {
                User user = _dbContext.Users.SingleOrDefault(x => x.Email == email);
                if(user == null)
                {
                    return false;
                }
                else
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(pass);
                    _dbContext.Users.Update(user);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public User GetUser(int userId)
        {
            try
            {
               return _dbContext.Users.Find(userId);
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
                return _dbContext.UserAddresses.Where(s => s.UserId == userId).ToList();
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
                return _dbContext.UserAddresses.Find(addressId);
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
                
                var user =  _dbContext.Users.SingleOrDefault(u => u.Email == login.Email);
                bool passwordValidation = BCrypt.Net.BCrypt.Verify(login.Password,user.Password);
                if (passwordValidation)
                {
                    return user;
                }
                return null;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
