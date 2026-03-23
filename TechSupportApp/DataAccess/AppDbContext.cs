using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using TechSupportApp.Models;

namespace TechSupportApp.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Request> Requests { get; set; }

        public AppDbContext() : base("name=AppDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasRequired(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Request>()
                .HasRequired(r => r.EquipmentType)
                .WithMany(et => et.Requests)
                .HasForeignKey(r => r.EquipmentTypeId);

            modelBuilder.Entity<Request>()
                .HasRequired(r => r.Priority)
                .WithMany(p => p.Requests)
                .HasForeignKey(r => r.PriorityId);

            modelBuilder.Entity<Request>()
                .HasRequired(r => r.Status)
                .WithMany(s => s.Requests)
                .HasForeignKey(r => r.StatusId);

            modelBuilder.Entity<Request>()
                .HasOptional(r => r.AssignedToUser)
                .WithMany(u => u.AssignedRequests)
                .HasForeignKey(r => r.AssignedToUserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}