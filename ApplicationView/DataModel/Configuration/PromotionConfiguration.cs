using ApplicationView.DataModel.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ApplicationView.DataModel.Configuration
{
    public class PromotionConfiguration
    {
        public PromotionConfiguration(EntityTypeBuilder<Promotion> entityBuilder)
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.PromoCode).IsRequired().HasMaxLength(250);
            entityBuilder.Property(u => u.PromoName).IsRequired().HasMaxLength(250);
            entityBuilder.Property(u => u.Price).IsRequired();

            entityBuilder.HasMany(e => e.PromotionDetails).WithOne(e => e.Promotion).HasForeignKey(e => e.PromotionId).IsRequired();
        }
    }
}
