
using System;
using System.Collections.Generic;
using System.Text;

#region Additional Namespace
using Microsoft.EntityFrameworkCore;
#endregion

namespace ConsoleApp.DAL
{
    public class SchoolCatalogContext : DbContext
    {
        const string ConnectionString =
           "Data Source=.;Initial Catalog=SchoolCatalog;Integrated Security=true;";

        public DbSet<Models.Course> Courses { get; set; }
        public DbSet<Models.Term> Terms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
