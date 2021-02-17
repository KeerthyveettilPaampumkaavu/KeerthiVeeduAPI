using KeerthiveeduAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeerthiveeduAPI.DTOs
{
    public class MemberDto
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string FamilyGroupName { get; set; }
        public int FamilyGroupId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedDttm { get; set; }
        public long VerifiedUserId { get; set; }
        public DateTime VerifiedDttm { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
