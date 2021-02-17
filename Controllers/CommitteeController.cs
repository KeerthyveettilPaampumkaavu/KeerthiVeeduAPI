using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KeerthiveeduAPI.DTOs;
using KeerthiveeduAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KeerthiveeduAPI.Controllers
{
   
    public class CommitteeController : BaseApiController
    {
        private readonly ICommitteRepositoy committeeRepository;
        private readonly IMapper mapper;

        public CommitteeController(ICommitteRepositoy committeeRepository, IMapper mapper)
        {
            this.committeeRepository = committeeRepository;
            this.mapper = mapper;
        }
        [Authorize]
        [HttpGet("GetCommitteeList")]
        public async Task<ActionResult<IEnumerable<CommitteeDto>>> GetCommitteeList()
        {
            var committees = await committeeRepository.GetCommitteeListAsync();
            var committeetoReturn = mapper.Map<IEnumerable<CommitteeDto>>(committees);
            return Ok(committeetoReturn);
        }

        [Authorize]
        [HttpGet("{Id}")]
        public async Task<ActionResult<CommitteeDto>> GetCommitteeDetails(long id)
        {
            var committee = await committeeRepository.GetCommitteDetailsAsync(id);
            var committeetoReturn = mapper.Map<CommitteeDto>(committee);
            return Ok(committeetoReturn);
        }
    }
}