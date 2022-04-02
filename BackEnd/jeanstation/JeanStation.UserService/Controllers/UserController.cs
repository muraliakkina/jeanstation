using JeanStation.UserService.Models;
using JeanStation.UserService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;

namespace JeanStation.UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;
        public UserController(IUserServices userServices)
        {
            this._userService = userServices;
        }

        [HttpPost("AddUser")]
        public IActionResult AddNewUser([FromBody] User user)
        {
            try
            {
                User userData = _userService.AddNewUser(user);
                if (userData == null)
                {
                    return StatusCode(statusCode: 404,"Email Already Exists ");
                }
                else 
                {
                    return StatusCode(statusCode: 201, userData);
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        
        [HttpGet]
        public IActionResult CheckUser(string username)
        {
            try
            {
                bool check = _userService.CheckUser(username);
                return Ok(check);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        //[Authorize(Roles = "User")]
        [HttpGet("{userId}")]
        public IActionResult GetUser(int userId)
        {
            try
            {
                User user = _userService.GetUser(userId);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        //[Authorize(Roles = "User")]
        [HttpPost("AddAdress")]
        public IActionResult AddNewUserAddress([FromBody] UserAddress userAddress)
        {
            try
            {
                UserAddress userAddress1 = _userService.AddNewUserAddress(userAddress);
                if (userAddress1 == null)
                {
                    return StatusCode(statusCode: 500);
                }
                else
                {
                    return StatusCode(statusCode: 201, userAddress1);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private string GetToken(User user)
        {
            var _config = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json").Build();
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials
        (securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                   {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                   }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        //[Authorize(Roles = "User")]
        [HttpDelete("GetByAdressId/{addressid}")]
        public IActionResult DeleteUserAddress(int addressid)
        {
            try
            {
                bool check = _userService.DeleteUserAddress(addressid);
                return check ? StatusCode(statusCode: 200,check) : StatusCode(statusCode: 404);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        //[Authorize(Roles = "User")]
        [HttpPut("GetByUserId/{id}")]
        public IActionResult EditUSer(int id,[FromBody]User user)
        {
            try
            {
                User user1 = _userService.EditUser(id, user);
                if (user1 == null)
                {
                    return StatusCode(statusCode: 404);
                }
                else
                {
                    return StatusCode(statusCode: 201, user1);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        //[Authorize(Roles = "User")]
        [HttpPut("UpdateByAdressId/{addressId}")]
        public IActionResult EditUserAddress(int addressId,  UserAddress userAddress)
        {
            try
            {
                UserAddress user1 = _userService.EditUserAddress(addressId, userAddress);
                if (user1 == null)
                {
                    return StatusCode(statusCode: 404);
                }
                else
                {
                    return StatusCode(statusCode: 201, user1);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        //[Authorize(Roles = "User")]
        [HttpPut("UpdateByUserId/email")]
        public IActionResult EditPassword(string email, [FromBody] string pass)
        {
            try
            {
                bool check = _userService.UserPasswordReset(email, pass);
                return check ? StatusCode(statusCode: 200, check) : StatusCode(statusCode: 404);
            }
            catch (System.Exception)
            {

                throw;
            }
        }


       // [Authorize(Roles = "User")]
        [HttpGet("getaddress/by/userid/{userId}")]
        public IActionResult GetUserAddressByUserId(int userId)
        {
            try
            {
                List<UserAddress> addresses = _userService.GetUserAddressByUserId(userId);
                if(addresses == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(addresses);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        //[Authorize(Roles = "User")]
        [HttpGet("getaddress/by/addressid/unique/{addressId}")]
        public IActionResult GetUserAddressByAddressId(int addressId)
        {
            try
            {
                UserAddress addresses = _userService.GetNewUserAddress(addressId);
                if (addresses == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(addresses);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Login login)
        {
            try
            {
                AuthUser authUser = null;
                User user = _userService.Login(login);
                if (user != null)
                {
                    authUser = new AuthUser()
                    {
                        UserId = user.UserId,
                        Name = user.UserName,
                        Token = GetToken(user),
                        Role = user.Role
                    };
                }

                return Ok(authUser);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }
    }

}

