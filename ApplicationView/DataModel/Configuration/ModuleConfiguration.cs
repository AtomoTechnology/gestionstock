using ApplicationView.DataModel.Entities;
using ApplicationView.Resolver.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ApplicationView.DataModel.Configuration
{
    public class ModuleConfiguration
    {
        public ModuleConfiguration(EntityTypeBuilder<Module> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property<string>(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property<string>(x => x.Description).HasMaxLength(250);

            entityBuilder.HasData(
              new Module()
              {
                  Id = "dc09b3c4-58ff-4483-91b7-89ed479e6d1a",
                  Name ="Ventas",
                  ActionName = "btnSale",
                  Description ="Encarga la seguridad de las ventas, permisos, etc",
                  CreatedDate = System.DateTime.Now,
                  state = (Int32)StateEnum.Activeted
              },
              new Module()
              {
                  Id = "8178794d-5f0c-4255-b234-8f0f683e74dd",
                  Name = "Productos",
                  ActionName = "btnProduct",
                  Description ="Dar permiso",
                  CreatedDate = System.DateTime.Now,
                  state = (Int32)StateEnum.Activeted
              },
              new Module()
              {
                  Id = "a9315906-f7bf-49eb-808e-d24cb39a04ba",
                  Name = "Proveedores",
                  ActionName = "btnprovider",
                  Description = "Dar permiso",
                  CreatedDate = System.DateTime.Now,
                  state = (Int32)StateEnum.Activeted
              },
              new Module()
              {
                  Id = "e64ac6a7-bf12-4d14-815f-e52cb8252878",
                  Name = "Reportes",
                  ActionName = "btnReport",
                  Description = "Dar permiso",
                  CreatedDate = System.DateTime.Now,
                  state = (Int32)StateEnum.Activeted
              },
              new Module()
              {
                  Id = "5017aded-60ac-45cc-89b1-993703cd91ab",
                  Name = "Gestion de Usuarios",
                  ActionName = "btnUser",
                  Description = "Dar permiso",
                  CreatedDate = System.DateTime.Now,
                  state = (Int32)StateEnum.Activeted
              },
              new Module()
              {
                  Id = "f01ea86d-5d66-493d-9df2-4fe211bc8509",
                  Name = "Movimientos",
                  ActionName = "btnMovements",
                  Description = "Dar permiso",
                  CreatedDate = System.DateTime.Now,
                  state = (Int32)StateEnum.Activeted
              },
              new Module()
              {
                  Id = "efa9e573-4308-4d88-99cf-d2c51c85cd54",
                  Name = "Seguridades",
                  ActionName = "btnSecurity",
                  Description = "Dar permiso",
                  CreatedDate = System.DateTime.Now,
                  state = (Int32)StateEnum.Activeted
              }
            );

            entityBuilder.HasMany(e => e.ModuleAccounts).WithOne(e => e.Module).HasForeignKey(e => e.ModuleId).IsRequired();
            entityBuilder.HasMany(e => e.SubModules).WithOne(e => e.Module).HasForeignKey(e => e.ModuleId).IsRequired();
        }
    }
}
