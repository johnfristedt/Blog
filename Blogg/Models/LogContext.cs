using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blogg.Models
{
    public class LogContext : DbContext
    {
        public DbSet<Error> Errors { get; set; }

        public LogContext(string connection)
            : base(connection)
        {

        }
    }
}