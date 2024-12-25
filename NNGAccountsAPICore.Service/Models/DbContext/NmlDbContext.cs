using Microsoft.EntityFrameworkCore;
using NNGAccountsAPICore.Service.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNGAccountsAPICore.Service.Models
{
    public class NmlDbContext : DbContext
    {
        public string TenantId { get; set; }
        private readonly ITenantService _tenantService;
        public NmlDbContext(DbContextOptions options, ITenantService tenantService) : base(options)
        {
            _tenantService = tenantService;
            TenantId = _tenantService.GetTenant()?.TID;
        }
        #region ----------------Model Setting----------------
        public virtual DbSet<MenuAssign> MenuAssigns { get; set; } = null!;
        public virtual DbSet<MenuMaster> MenuMasters { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserProject> UserProjects { get; set; } = null!;
      
        public virtual DbSet<GLMst> GLMsts { get; set; } = null!;
        public virtual DbSet<LGMst> LGMsts { get; set; } = null!;
        public virtual DbSet<CategoryClass> Categorys { get; set; } = null!;
        public virtual DbSet<Reference> References { get; set; } = null!;
        public virtual DbSet<CompanyDate> CompanyDates { get; set; } = null!;
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
           
            modelBuilder.Entity<MenuMaster>().ToTable("MenuMaster");
            modelBuilder.Entity<MenuAssign>().ToTable("MenuAssign");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<UserProject>().ToTable("UserProject");
            modelBuilder.Entity<GLMst>().ToTable("tblGLMst");
            modelBuilder.Entity<LGMst>().ToTable("tblLGMst");
            modelBuilder.Entity<CategoryClass>().ToTable("tblCategory");
            modelBuilder.Entity<Reference>().ToTable("tblReference");
            modelBuilder.Entity<CompanyDate>().ToTable("tblCompanyDate");

            // modelBuilder.Entity<GLMst>().HasQueryFilter(a => a.TenantId == TenantId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tenantConnectionString = _tenantService.GetConnectionString();
            if (!string.IsNullOrEmpty(tenantConnectionString))
            {
                //var DBProvider = _tenantService.GetDatabaseProvider();
                //if (DBProvider.ToLower() == "mssql")
                //{
                //    optionsBuilder.UseSqlServer(_tenantService.GetConnectionString());
                //}
                optionsBuilder.UseSqlServer(_tenantService.GetConnectionString());
            }
        }
        public override int SaveChanges()
        {
            var now = DateTime.Now;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is Base entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDt = now;
                            entity.UpdatedDt = now;
                            entity.IsActive = true;
                            //entity.CreatedBy = CurrentUser.GetUsername();
                            //entity.UpdatedBy = CurrentUser.GetUsername();
                            break;
                        case EntityState.Modified:
                            Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                            Entry(entity).Property(x => x.CreatedDt).IsModified = false;
                            entity.UpdatedDt = now;
                            //entity.IsActive = true;
                            //entity.UpdatedBy = CurrentUser.GetUsername();
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

    }
}
