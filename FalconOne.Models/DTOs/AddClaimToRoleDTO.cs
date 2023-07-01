﻿using System.ComponentModel.DataAnnotations;

namespace FalconOne.Models.DTOs
{
    public class AddClaimToRoleDto
    {
        [Required]
        public string RoleId { get; set; }
        public Guid ClaimId { get; set; }
    }
}
