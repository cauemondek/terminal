using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TerminaldotNET.Models;

namespace TerminaldotNET.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Command> Commands { get; set; }
        public DbSet<Archive> Archives { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}