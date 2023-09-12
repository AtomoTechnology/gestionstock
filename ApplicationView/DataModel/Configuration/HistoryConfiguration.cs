using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicationView.DataModel.Entities;

namespace ApplicationView.DataModel.Configuration
{
    public class HistoryConfiguration
    {
        public HistoryConfiguration(EntityTypeBuilder<History> entityBuilder)
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.AccountId).IsRequired();
            entityBuilder.Property(u => u.TypeId).IsRequired();
            entityBuilder.Property(u => u.Action).IsRequired().HasMaxLength(250);
            entityBuilder.Property(u => u.ModuleAction).IsRequired().HasMaxLength(250);
            entityBuilder.Property(u => u.OptionId).IsRequired();
        }
    }
}
