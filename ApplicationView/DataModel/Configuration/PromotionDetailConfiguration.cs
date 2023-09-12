using ApplicationView.DataModel.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationView.DataModel.Configuration
{
    public class PromotionDetailConfiguration
    {
        public PromotionDetailConfiguration(EntityTypeBuilder<PromotionDetail> entityBuilder)
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.ProductId).IsRequired();
            entityBuilder.Property(u => u.PromotionId).IsRequired();
        }
    }
}
