using ApplicationView.DataModel.Entities;
using ApplicationView.Resolver.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ApplicationView.DataModel.Configuration
{
    public class ModuleAccountConfiguration
    {
        public ModuleAccountConfiguration(EntityTypeBuilder<ModuleAccount> entityBuilder)
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.ModuleId).IsRequired();
            entityBuilder.Property(u => u.AccountId).IsRequired();

            entityBuilder.HasData(
                #region Admin
                 new ModuleAccount()
                 {
                     Id = "7151993b-b219-4e22-80f2-0ec8002e4b3f",
                     AccountId = "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca",
                     ModuleId = "dc09b3c4-58ff-4483-91b7-89ed479e6d1a",//Sale
                     CreatedDate = System.DateTime.Now,
                     state = (Int32)StateEnum.Activeted
                 },
                new ModuleAccount()
                {
                    Id = "6bd7fbf4-13b7-4dbc-a64f-caf40bb131fc",
                    AccountId = "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca",
                    ModuleId = "8178794d-5f0c-4255-b234-8f0f683e74dd",//Product
                    CreatedDate = System.DateTime.Now,
                    state = (Int32)StateEnum.Activeted
                },
                new ModuleAccount()
                {
                    Id = "b871ccf3-2421-4861-b7a0-3ed6b070a3c3",
                    AccountId = "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca",
                    ModuleId = "a9315906-f7bf-49eb-808e-d24cb39a04ba",//Provider
                    CreatedDate = System.DateTime.Now,
                    state = (Int32)StateEnum.Activeted
                },
                new ModuleAccount()
                {
                    Id = "a2585d96-d782-45c2-b8be-1edbfaaa160e",
                    AccountId = "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca",
                    ModuleId = "e64ac6a7-bf12-4d14-815f-e52cb8252878",//Report
                    CreatedDate = System.DateTime.Now,
                    state = (Int32)StateEnum.Activeted
                },
                new ModuleAccount()
                {
                    Id = "ff020261-95e7-4695-90a0-a16f380aa2f7",
                    AccountId = "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca",
                    ModuleId = "5017aded-60ac-45cc-89b1-993703cd91ab",//User Management
                    CreatedDate = System.DateTime.Now,
                    state = (Int32)StateEnum.Activeted
                },
                new ModuleAccount()
                {
                    Id = "826e202c-ef1a-4be0-95eb-7eab6388f878",
                    AccountId = "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca",
                    ModuleId = "f01ea86d-5d66-493d-9df2-4fe211bc8509",//Mouvement
                    CreatedDate = System.DateTime.Now,
                    state = (Int32)StateEnum.Activeted
                },
                new ModuleAccount()
                {
                    Id = "e30a699e-51c2-4f06-b1bc-7c076824db44",
                    AccountId = "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca",
                    ModuleId = "efa9e573-4308-4d88-99cf-d2c51c85cd54",//Security
                    CreatedDate = System.DateTime.Now,
                    state = (Int32)StateEnum.Activeted
                }
                #endregion
            );

            entityBuilder.HasMany(e => e.SubModuleAccounts).WithOne(e => e.ModuleAccount).HasForeignKey(e => e.ModuleAccountId).IsRequired();
        }
    }
}
