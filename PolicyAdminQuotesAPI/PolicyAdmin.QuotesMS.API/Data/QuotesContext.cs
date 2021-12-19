using Microsoft.EntityFrameworkCore;
using PolicyAdmin.QuotesMS.API.Models;
using PolicyAdmin.QuotesMS.API.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAdmin.QuotesMS.API.Data
{
    public class QuotesContext : DbContext
    {
        public DbSet<QuoteMaster> QuotesMaster { get; set; }

        public QuotesContext(DbContextOptions<QuotesContext> options) : base(options)
        {
        }

     
    }
}
