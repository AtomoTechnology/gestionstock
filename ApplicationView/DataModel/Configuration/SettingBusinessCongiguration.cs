using ApplicationView.DataModel.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationView.DataModel.Configuration
{
    public class SettingBusinessCongiguration
    {
        public SettingBusinessCongiguration(EntityTypeBuilder<SettingBusiness> entityBuilder)
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.BusinessId).IsRequired();
            entityBuilder.Property(u => u.DateFrom).IsRequired();
            entityBuilder.Property(u => u.DateTo).IsRequired();
        }
    }
}
