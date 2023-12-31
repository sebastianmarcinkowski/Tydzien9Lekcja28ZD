﻿using InvoiceManager.Models.Domains;
using System.ComponentModel.DataAnnotations;

namespace InvoiceManager.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Pole E-mail jes wymagane.")]
        [EmailAddress(ErrorMessage = "Wprowadzony E-mail jest niepoprawny.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pole Hasło jest wymagane.")]
        [StringLength(100, ErrorMessage = "{0} musi posiadać co najmniej {2} znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Hasła się nie zgadzają.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "NIP")]
        public string Nip { get; set; }

        public Address Address { get; set; }
    }
}