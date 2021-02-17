using AutoMapper;
using AutoMapper.QueryableExtensions;
using KeerthiveeduAPI.DTOs;
using KeerthiveeduAPI.Entities;
using KeerthiveeduAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeerthiveeduAPI.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public UserRepository(DataContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<MemberDto> GetMemberAsync(long id)
        {
            return await context.Users.Where(x => x.Id == id)
               .ProjectTo<MemberDto>(mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await context.Users.Include(x => x.FamilyGroup)
                .ProjectTo<MemberDto>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(long id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await context.Users.Include(x=>x.FamilyGroup).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser appUser)
        {
            context.Entry(appUser).State = EntityState.Modified;
        }   
    }
}
