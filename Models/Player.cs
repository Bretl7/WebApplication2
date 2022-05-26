﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.Models
{
    public class Player
    {
        [Key]
        public Guid Id { get; set; }


        public string Name { get; set; }


        public string Email { get; set; }

        public string Taco { get; set; }
    }
}
