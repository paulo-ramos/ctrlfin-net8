using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ramos.Core.Models;

namespace Ramos.Api.Data.Mappings;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        
        builder.Property(c => c.Title).IsRequired(true).HasColumnType("NVARCHAR").HasMaxLength(80);
        builder.Property(c => c.Description).IsRequired(false).HasColumnType("NVARCHAR").HasMaxLength(255);
        builder.Property(c => c.UserId).IsRequired(true).HasColumnType("NVARCHAR").HasMaxLength(160);
    }
}