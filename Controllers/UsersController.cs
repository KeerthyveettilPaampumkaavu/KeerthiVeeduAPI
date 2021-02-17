using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KeerthiveeduAPI.Data;
using KeerthiveeduAPI.DTOs;
using KeerthiveeduAPI.Entities;
using KeerthiveeduAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeerthiveeduAPI.Controllers
{
    public class UsersController : BaseApiController
    {
        
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepository,IMapper mapper)
        {   
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        [Authorize]
        [HttpGet("GetMemberList")]
        //[AllowAnonymous]

        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users =await userRepository.GetUsersAsync();
            var userstoReturn = mapper.Map<IEnumerable<MemberDto>>(users);
            return Ok(userstoReturn);
        }
        [Authorize]
        [HttpGet("{Id}")]
        public async Task<ActionResult<MemberDto>> GetUser(long id)
        {
            return await userRepository.GetMemberAsync(id);
           // return mapper.Map<MemberDto>(user);
            //return await userRepository.GetUserByIdAsync(id);

        }
    }
}