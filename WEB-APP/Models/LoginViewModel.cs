﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB_APP.Models {
    public class LoginViewModel {
        
        public string Username { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Email { get; set; }
    }
}