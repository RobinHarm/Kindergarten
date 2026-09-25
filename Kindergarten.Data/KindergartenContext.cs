using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Kindergarten.Core.Domain;

namespace Kindergarten.Data
{
    public class KindergartenContext : DbContext
    {
        public KindergartenContext(DbContextOptions<KindergartenContext> options)
            : base(options)
        {
        }

        public DbSet<Children> Childrens { get; set; }
    }
}
