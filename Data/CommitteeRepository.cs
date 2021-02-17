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
    public class CommitteeRepository : ICommitteRepositoy
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public CommitteeRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public Task<CommitteeDto> GetCommitteDetailsAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Committee>> GetCommitteeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetCommitteeByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CommitteeDto>> GetCommitteeListAsync()
        {
            return await context.Committees
                .Include(x => x.MemberPosition)
                .Include(x=>x.User)
    .ProjectTo<CommitteeDto>(mapper.ConfigurationProvider).ToListAsync();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Committee committee)
        {
            throw new NotImplementedException();
        }
    }
}
