using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Map
{
    public class ProjectMap : IEntityTypeConfiguration<ProjectModels>
    {
        public void Configure(EntityTypeBuilder<ProjectModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Link).HasMaxLength(150);
        }
    }
}
