using FinancialControl.Domain.Models.Expensies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialControl.Infrastructure.Data.EntityConfigurations
{
    public class ExpenseEntityTypeConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable(nameof(Expense));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Category).IsRequired().HasMaxLength(Expense.CategoryMaxLength);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(Expense.DescriptionMaxLength);
            builder.Property(x => x.Value).IsRequired();
        }
    }
}