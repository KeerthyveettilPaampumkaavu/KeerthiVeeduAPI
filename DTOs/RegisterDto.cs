using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KeerthiveeduAPI.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(12,MinimumLength =4)]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Mobile { get; set; }

        public string Address { get; set; }
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public int FamilyGroupId { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }


        [Required]
        [StringLength(12, MinimumLength = 4)]
        public string ConfirmPassword { get; set; }


    }
}
