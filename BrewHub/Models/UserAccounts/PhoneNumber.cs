﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrewOS.Models.UserAccounts
{
    public class PhoneNumber
    {
        [Key]
        public string AreaCode { get; set; }
        [Key]
        public string Prefix { get; set; }
        [Key]
        public string Extension { get; set; }
    }
}
