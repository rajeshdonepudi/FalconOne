﻿using System.ComponentModel.DataAnnotations;

namespace Utilities.DTOs
{
    public class AddClaimToRoleDTO
    {
        [Required]
        public string RoleId { get; set; }
        public Guid ClaimId { get; set; }
    }
}
