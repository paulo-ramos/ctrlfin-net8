using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ramos.Core.Models;

namespace Ramos.Api.Data.Mappings;

public class TransactionMapping :IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transaction");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        
        builder.Property(c => c.Title).IsRequired(true).HasColumnType("NVARCHAR").HasMaxLength(80);
        builder.Property(c => c.Type).IsRequired(true).HasColumnType("SMALLINT");
        builder.Property(c => c.Amount).IsRequired(true).HasColumnType("MONEY");
        builder.Property(c => c.CreatedAt).IsRequired(true);
        builder.Property(c => c.PaidOrReceiveAt).IsRequired(false);
        builder.Property(c => c.UserId).IsRequired(true).HasColumnType("NVARCHAR").HasMaxLength(160);
    }
}