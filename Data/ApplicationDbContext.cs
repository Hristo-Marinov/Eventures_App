using Eventures.App_2._0.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Eventures.App_2._0.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Eventures.App_2._0.Data
{
    public class ApplicationDbContext : IdentityDbContext<EventuresUser>
    {
        public DbSet<Event> Events { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
