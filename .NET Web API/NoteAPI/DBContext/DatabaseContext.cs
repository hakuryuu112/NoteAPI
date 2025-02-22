using Microsoft.EntityFrameworkCore;
using NoteAPI.Models;
using System.Collections.Generic;

namespace NoteAPI.DBContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<NoteModel> Notes { get; set; }
    }
}
