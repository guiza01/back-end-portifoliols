using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Data.Map;

namespace WebApplication1.Data
{
    public class ProjectPortfolioDBContext : DbContext
    {
        public ProjectPortfolioDBContext(DbContextOptions<ProjectPortfolioDBContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectModels> Projects { get; set; }
        public DbSet<PlatformModels> Platforms { get; set; }
        public DbSet<SegmentModels> Segments { get; set; }
        public DbSet<LanguageModels> Languages { get; set; }
        public DbSet<LanguageProjectModels> LanguageProjects { get; set; }
        public DbSet<PlatformProjectModels> PlatformProjects { get; set; }
        public DbSet<SegmentProjectModels> SegmentProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectMap());
            modelBuilder.ApplyConfiguration(new SegmentMap());
            modelBuilder.ApplyConfiguration(new LanguageMap());
            modelBuilder.ApplyConfiguration(new PlatformMap());

            //LANGUAGE-----------------------------------
            modelBuilder.Entity<LanguageProjectModels>()
                .HasKey(lp => new { lp.LanguageId, lp.ProjectId });

            modelBuilder.Entity<LanguageProjectModels>()
                .HasOne(lp => lp.Language)
                .WithMany(l => l.LanguageProjects)
                .HasForeignKey(lp => lp.LanguageId);

            modelBuilder.Entity<LanguageProjectModels>()
                .HasOne(lp => lp.Project)
                .WithMany(p => p.LanguageProjects)
                .HasForeignKey(lp => lp.ProjectId);

            //PLATFORM-----------------------------------
            modelBuilder.Entity<PlatformProjectModels>()
                .HasKey(pp => new { pp.PlatformId, pp.ProjectId });

            modelBuilder.Entity<PlatformProjectModels>()
                .HasOne(pp => pp.Platform)
                .WithMany(p => p.PlatformProjects)
                .HasForeignKey(pp => pp.PlatformId);

            modelBuilder.Entity<PlatformProjectModels>()
                .HasOne(pp => pp.Project)
                .WithMany(p => p.PlatformProjects)
                .HasForeignKey(pp => pp.ProjectId);

            //SEGMENT--------------------------------------
            modelBuilder.Entity<SegmentProjectModels>()
                .HasKey(sp => new { sp.SegmentId, sp.ProjectId });

            modelBuilder.Entity<SegmentProjectModels>()
                .HasOne(sp => sp.Segment)
                .WithMany(s => s.SegmentProjects)
                .HasForeignKey(sp => sp.SegmentId);

            modelBuilder.Entity<SegmentProjectModels>()
                .HasOne(sp => sp.Project)
                .WithMany(p => p.SegmentProjects)
                .HasForeignKey(sp => sp.ProjectId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
