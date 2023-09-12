﻿using ApplicationView.DataModel.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationView.DataModel.Configuration
{
    public class IncreasePriceAfterTwelveConfiguration
    {
        public IncreasePriceAfterTwelveConfiguration(EntityTypeBuilder<IncreasePriceAfterTwelve> entityBuilder)
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.AccountId).IsRequired();
            entityBuilder.Property(u => u.HourFrom).IsRequired();
            entityBuilder.Property(u => u.HourTo).IsRequired();
            entityBuilder.Property(u => u.Porcent).IsRequired();
            entityBuilder.Property(u => u.IsActive).IsRequired();
        }
    }
}
