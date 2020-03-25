﻿using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.ViewModels
{
    public class CredentialsViewModel
    {
        [Required, EmailAddress]
        public string? Username { get; set; }

        [Required, MinLength(6)]
        public string? Password { get; set; }
    }
}
