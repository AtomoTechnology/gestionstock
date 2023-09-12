using ApplicationView.DataModel.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationView.DataModel.Configuration
{
    public class OpenWorkTurnConfiguration
    {
        public OpenWorkTurnConfiguration(EntityTypeBuilder<OpenWorkTurn> entityBuilder)
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.StartingQuantity).IsRequired();
            entityBuilder.Property(u => u.AccountId).IsRequired();
            entityBuilder.Property(u => u.TurnId).IsRequired();
        }
    }
}
