using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EProjectSEMIII.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerPolicy>().HasOne<BillingInformation>(c => c.BillingInformation).WithOne(b => b.CustomerPolicy).HasForeignKey<BillingInformation>(b => b.CustomerPolicyId);
        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<BillingInformation> BillingInformation { get; set; }
        public DbSet<ClaimDetail> ClaimDetail { get; set; }
        public DbSet<CompanyExpense> CompanyExpense { get; set; }
        public DbSet<CustomerRecord> CustomerRecord { get; set; }
        public DbSet<CustomerPolicy> CustomerPolicy { get; set; }
        public DbSet<Estimate> Estimate { get; set; }
        public DbSet<InsideVehicleType> InsideVehicleType { get; set; }
        public DbSet<VehicleInfomation> VehicleInfomation { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<InsuranceType> InsuranceType { get; set; }
        public DbSet<Sitemap> Sitemaps { get; set; }
        public DbSet<CustomerSupport> CustomerSupports { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
