using ApplicationView.DataModel.Entities;
using ApplicationView.Resolver.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ApplicationView.DataModel.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.BusinessId).IsRequired();
            entityBuilder.Property(u => u.FirstName).HasMaxLength(250);
            entityBuilder.Property(u => u.LastName).HasMaxLength(250);
            entityBuilder.Property(u => u.Email).HasMaxLength(250);
            entityBuilder.Property(u => u.Phone).HasMaxLength(250);
            entityBuilder.Property(u => u.Address).HasMaxLength(250);

            entityBuilder.HasData(
                new User()
                {
                    Id = "362c2637-2ad9-449a-9498-dbd74be87ee8",
                    BusinessId = "de07358c-3a51-42fb-8690-c383b91b5844",
                    Address = "Argentina",
                    state = (Int32)StateEnum.Activeted,
                    Phone = "3416987542",
                    CreatedDate = DateTime.Now,
                    Email = "almacen@gmail.com",
                    FirstName = "Pepito",
                    LastName = "Juancito"
                }
            );
            entityBuilder.HasMany(e => e.Accounts).WithOne(e => e.User).HasForeignKey(e => e.UserId).IsRequired();
        }
    }
}
