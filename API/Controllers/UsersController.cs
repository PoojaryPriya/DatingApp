using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class UsersController :BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        
        public UsersController(IUserRepository userRepository,IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var user=await _userRepository.GetMembersAsync();

            return Ok(user);
        }

        [HttpGet("{username}")]


        public async Task<ActionResult<MemberDto>> getUser(string username)
        {
            return await _userRepository.GetMemberAsync(username);
        }

        // [HttpGet]
        // public async Task<ActionResult<AppUserClass>> getUserwithname(string name)
        // {
        //     return await _context.Users.FirstOrDefaultAsync(x=>x.UserName==name);
        // }
    }
}