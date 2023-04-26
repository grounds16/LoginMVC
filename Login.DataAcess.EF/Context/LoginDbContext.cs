using Login.DataAccess.EF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.DataAccess.EF.Context
{
    public class LoginDbContext : DbContext
    {

        public LoginDbContext(DbContextOptions<LoginDbContext> options)
: base(options)

        {
        }
        protected LoginDbContext()
        {
        }
        public virtual DbSet<LoginModel> loginModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginModel>(
                entity =>
                {
                    entity.HasKey(e => e.LoginID);
                    entity.Property(e => e.LoginID).HasColumnName("LoginID");
                    entity.Property(e => e.UserName);
                    entity.Property(e => e.Password);
                    entity.Property(e => e.IsLoginSuccessful);
                }
                );

        }
    }
}
