using Microsoft.EntityFrameworkCore;
using System;

namespace BHHC.Core
{
    public class ReasonContext : DbContext
    {
        public ReasonContext(DbContextOptions<ReasonContext> options) : base(options)
        {

        }

        public DbSet<Reason> Reasons { get; set; }
    }
}
