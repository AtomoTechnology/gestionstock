using ApplicationView.DataModel.Entities;
using ApplicationView.Resolver.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ApplicationView.DataModel.Configuration
{
    public  class TurnsConfiguration
    {
        public TurnsConfiguration(EntityTypeBuilder<Turns> entityBuilder)
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.AccountId).IsRequired();
            entityBuilder.Property(u => u.BusinessId).IsRequired();
            entityBuilder.Property(u => u.TurnName).IsRequired().HasMaxLength(250);
            entityBuilder.Property(u => u.DateFrom).IsRequired();
            entityBuilder.Property(u => u.DateTo).IsRequired();
            entityBuilder.Property(u => u.Description).HasMaxLength(500);

            entityBuilder.HasData(
                new Turns()
                {
                    Id = "c0ba7b4c-d292-48c7-9f78-8a2e83973053",
                    TurnName = "Mañana",
                    AccountId = "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca",
                    BusinessId = "de07358c-3a51-42fb-8690-c383b91b5844",
                    DateFrom = 8,
                    DateTo =  14,
                    CreatedDate = DateTime.Now,
                    Description = "Se encarga de iniciar el dia",
                    state = (Int32)StateEnum.Activeted
                },
                 new Turns()
                 {
                     Id = "7a57db1f-3f77-4a25-8107-b73e668ab65a",
                     TurnName = "Tarde",
                     AccountId = "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca",
                     BusinessId = "de07358c-3a51-42fb-8690-c383b91b5844",
                     DateFrom = 14,
                     DateTo = 22,
                     CreatedDate = DateTime.Now,
                     Description = "Se encarga de iniciar el dia",
                     state = (Int32)StateEnum.Activeted
                 }
            );

            entityBuilder.HasMany(e => e.OpenWorkShifts).WithOne(e => e.Turn).HasForeignKey(e => e.TurnId).IsRequired().OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
