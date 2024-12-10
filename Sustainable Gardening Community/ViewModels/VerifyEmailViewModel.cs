﻿using System.ComponentModel.DataAnnotations;

namespace Sustainable_Gardening_Community.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}