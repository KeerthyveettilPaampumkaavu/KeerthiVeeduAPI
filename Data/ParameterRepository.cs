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
    public class ParameterRepository : IParameterRepository
    {
       
        private readonly DataContext context;
        private readonly IMapper mapper;

        public ParameterRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<ParameterDto> GetParameterByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ParameterDto>> GetParameterListAsync()
        {
            var parameters = await context.Parameters.ProjectTo<ParameterDto>(mapper.ConfigurationProvider).
                ToListAsync();
            return parameters;
        }

        public async Task<IEnumerable<Parameters>> GetParameterTypesListAsync()
        {
            var parameters = await context.Parameters.Where(x=>x.PrevId==0).ToListAsync();
            return parameters;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Update(Parameters parameter)
        {
            context.Entry(parameter).State = EntityState.Modified;
        }

      
    }
}
