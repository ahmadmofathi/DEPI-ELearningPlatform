﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LearningPlatform.DataAccess.ViewModels
{
    public class RegisterVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string Name { get; set; }
        public string fristName {  get; set; }
        public string lastName {  get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
