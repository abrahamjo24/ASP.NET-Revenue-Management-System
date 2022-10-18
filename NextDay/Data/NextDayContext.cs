using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NextDay.Models;

namespace NextDay.Data
{
    public class NextDayContext : DbContext
    {
        public NextDayContext (DbContextOptions<NextDayContext> options)
            : base(options)
        {
        }

        public DbSet<NextDay.Models.Revenue> Revenue { get; set; } = default!;
    }
}
