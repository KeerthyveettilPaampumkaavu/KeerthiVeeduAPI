using KeerthiveeduAPI.DTOs;
using KeerthiveeduAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeerthiveeduAPI.Interfaces
{
    public interface IParameterRepository
    {
        void Update(Parameters parameter);
        Task<bool> SaveAllAsync();
        Task<ParameterDto> GetParameterByIdAsync(int id);
        Task<IEnumerable<ParameterDto>> GetParameterListAsync();
        Task<IEnumerable<Parameters>> GetParameterTypesListAsync();
    }
}
