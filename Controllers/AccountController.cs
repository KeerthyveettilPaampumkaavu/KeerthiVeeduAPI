using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using KeerthiveeduAPI.Data;
using KeerthiveeduAPI.DTOs;
using KeerthiveeduAPI.Entities;
using KeerthiveeduAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeerthiveeduAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly DataContext context;
        private readonly ITokenService tokenService;

        public AccountController(DataContext context,ITokenService tokenService)
        {
            this.context = context;
            this.tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<userDTO>> Register(RegisterDto registerDto)
        {
            if (await UserExistwithUserName(registerDto.UserName)) return BadRequest("User Name is already taken");
            if (await UserExistWithDetails(registerDto)) return BadRequest("User Already Registered with the Details.Please contact Administrators");
            var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = registerDto.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                Name = registerDto.Name,
                FamilyGroupId = registerDto.FamilyGroupId,
                Mobile = registerDto.Mobile,
                Address = registerDto.Address,
                EmailAddress = registerDto.EmailAddress,
                Gender = registerDto.Gender,
                CreatedDttm = DateTime.Now,
                DateOfBirth=registerDto.DateOfBirth
            };
             context.Users.Add(user);
            await context.SaveChangesAsync();
            bool isAdmin, isverified;
            isAdmin = false;
            isverified = false;
            UserRights adminuser = new UserRights();
             adminuser= await context.UserRights.SingleOrDefaultAsync(x => x.UserId == user.Id && x.RightsId == 1);
            if(adminuser!=null)
            {
                isAdmin = true;
            }
            UserRights verifieduser = new UserRights();
            verifieduser =await context.UserRights.SingleOrDefaultAsync(x => x.UserId == user.Id && x.RightsId == 2);
            if (verifieduser != null)
            {
                isverified = true;
            }
            return new userDTO
            {
                Username = user.UserName,
                Token = tokenService.createToken(user),
                isadmin=isAdmin,
                isverificationadmin=isverified

            };

        }

        [HttpPost("login")]
        public async Task<ActionResult<userDTO>> Login(LoginDto loginDto)
        {
            var user = await context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());
            if (user == null) return Unauthorized();
            var hmac = new HMACSHA512(user.PasswordSalt);
            var ComputeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for (int i = 0; i < ComputeHash.Length; i++)
            {
                if (ComputeHash[i] != user.PasswordHash[i]) return Unauthorized();
            }
            bool isAdmin, isverified;
            isAdmin = false;
            isverified = false;
            UserRights adminuser = new UserRights();
            adminuser = await context.UserRights.SingleOrDefaultAsync(x => x.UserId == user.Id && x.RightsId == 1);
            if (adminuser != null)
            {
                isAdmin = true;
            }
            UserRights verifieduser = new UserRights();
            verifieduser = await context.UserRights.SingleOrDefaultAsync(x => x.UserId == user.Id && x.RightsId == 2);
            if (verifieduser != null)
            {
                isverified = true;
            }
            return new userDTO
            {
                Username = user.UserName,
                Token = tokenService.createToken(user),
                isadmin = isAdmin,
                isverificationadmin = isverified
            };
        }

        private async Task<bool> UserExistwithUserName(string userName)
        {
            return await context.Users.AnyAsync(x => x.UserName == userName.ToLower());
        }
        private async Task<bool> UserExistWithDetails(RegisterDto register)
        {
            return await context.Users.AnyAsync(x => x.EmailAddress == register.EmailAddress && x.Name.ToLower() == register.Name.ToLower() && x.FamilyGroupId == register.FamilyGroupId);
        }
    }
}