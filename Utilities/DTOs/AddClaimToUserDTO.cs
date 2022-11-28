﻿using System.ComponentModel.DataAnnotations;

namespace Utilities.DTOs
{
    public class AddClaimToUserDTO
    {
        [Required]
        public string UserId { get; set; }
        public Guid ClaimId { get; set; }
    }
}
