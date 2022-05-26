using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WebApplication2.Data;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class User : IdentityUser
    {
        //[Key]
        public string? Mood { get; set; }
    }
}
