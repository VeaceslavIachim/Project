using BundesligaDomain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BundesligaEF
{
    public class BundesligaIdentityContext:IdentityDbContext<ApplicationUser>
    {
        public BundesligaIdentityContext(DbContextOptions<BundesligaIdentityContext> options):base(options)
        {

        }

    }
}
