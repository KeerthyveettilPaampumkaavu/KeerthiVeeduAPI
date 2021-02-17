using KeerthiveeduAPI.DTOs;
using KeerthiveeduAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeerthiveeduAPI.Interfaces
{
   public interface ICommitteRepositoy
    {
        void Update(Committee committee);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Committee>> GetCommitteeAsync();
        Task<AppUser> GetCommitteeByIdAsync(long id);
        Task<IEnumerable<CommitteeDto>> GetCommitteeListAsync();
        Task<CommitteeDto> GetCommitteDetailsAsync(long id);

    }
}
