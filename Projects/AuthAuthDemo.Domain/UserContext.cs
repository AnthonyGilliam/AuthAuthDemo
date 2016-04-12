using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using WebMatrix.Data;
//using WebMatrix.WebData;

namespace AuthAuthDemo.Domain
{
    public class UserContext : DbContext
    {
        public void Initialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<UserContext>());
            Database.Initialize(true);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Membership> UserMemberships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("UserProfile");
            modelBuilder.Entity<User>()
                .HasKey(user => user.ID);
            modelBuilder.Entity<User>()
                .Property(user => user.ID).HasColumnName("UserId");
            modelBuilder.Entity<User>()
                .Property(user => user.EmailAddress).HasColumnName("Username");
            modelBuilder.Entity<User>()
                .Property(user => user.FirstName).HasColumnName("FirstName");
            modelBuilder.Entity<User>()
                .Property(user => user.LastName).HasColumnName("LastName");

            modelBuilder.Entity<Membership>()
                .ToTable("webpages_Membership");
            modelBuilder.Entity<Membership>()
                .HasKey(membership => membership.UserId);
            modelBuilder.Entity<Membership>()
                .Property(membership => membership.Password);

            modelBuilder.Entity<User>()
                .HasRequired(user => user.Membership)
                .WithOptional();

            WebMatrix.WebData.WebSecurity.InitializeDatabaseConnection("UserContext", "UserProfile", "UserId", "Username", true);
        }
    }
}
