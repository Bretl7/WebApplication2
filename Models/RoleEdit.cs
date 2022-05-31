using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Models
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<Player> Members { get; set; }
        public IEnumerable<Player> NonMembers { get; set; }
    }
}
