using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController: BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenservices _tokenServices;
        public AccountController(DataContext context,ITokenservices tokenServices)
        {
            _tokenServices = tokenServices;
            
            _context = context;
            
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDataTo>> Register(RegisterDataTO registerDto)
        {
            if(await UserExists(registerDto.Username)) return BadRequest("UserName Taken");
            using var hmac=new HMACSHA512();
            var user=new AppUserClass
            {
                UserName=registerDto.Username.ToLower(),
                PasswordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.password)),
                PasswordSalt=hmac.Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDataTo
            {
                Username=user.UserName,
                Token=_tokenServices.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDataTo>> Login(LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x=>
            x.UserName==loginDto.Username);

            if(user==null) return Unauthorized("Invalid User");

            using var hmac=new HMACSHA512(user.PasswordSalt);

            var computedHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.password));

            for(int i=0;i<computedHash.Length;i++)
            {
                if(computedHash[i] != user.PasswordHash[i]) return Unauthorized("invalid password");
            }

            return new UserDataTo
            {
                Username=user.UserName,
                Token=_tokenServices.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync( x=> x.UserName == username.ToLower());
        }

    }
}