using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data.Map
{
    public class PlatformMap : IEntityTypeConfiguration<PlatformModels>
    {
        public void Configure(EntityTypeBuilder<PlatformModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }

    }
}
