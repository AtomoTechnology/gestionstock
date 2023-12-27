using ApplicationView.DataModel.Entities;
using ApplicationView.Resolver.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ApplicationView.DataModel.Configuration
{
    public class SubModuleConfiguration
    {
        public SubModuleConfiguration( EntityTypeBuilder<SubModule> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.ModuleId).IsRequired();
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Description).HasMaxLength(250);

            entityBuilder.HasData(

                        #region Ventas
                            new SubModule()
                            {
                                Id = "ee090c50-f4a4-4877-8df7-0a05abeaf1c8",
                                ModuleId = "dc09b3c4-58ff-4483-91b7-89ed479e6d1a",
                                Name = "Iniciar venta",
                                ActionName = "btnstartsale",
                                Description = "Iniciar venta",
                                CreatedDate = System.DateTime.Now,
                                state = (Int32)StateEnum.Activeted
                            },
                            new SubModule()
                            {
                                Id = "b6960d25-b1d3-4a16-88b9-56ad9d8bd212",
                                ModuleId = "dc09b3c4-58ff-4483-91b7-89ed479e6d1a",
                                Name = "Consultar precio",
                                ActionName = "btnconsultantsale",
                                Description = "Consultar precio",
                                CreatedDate = System.DateTime.Now,
                                state = (Int32)StateEnum.Activeted
                            },
                            new SubModule()
                            {
                                Id = "371d3ef5-916f-4c5a-9bdb-4208febf7813",
                                ModuleId = "dc09b3c4-58ff-4483-91b7-89ed479e6d1a",
                                Name = "Consultar venta",
                                ActionName = "btnconsultantprize",
                                Description = "Consultar venta",
                                CreatedDate = System.DateTime.Now,
                                state = (Int32)StateEnum.Activeted
                            },
                            new SubModule()
                            {
                                Id = "0081ef4d-6b18-4e83-a443-b3b85abc6c47",
                                ModuleId = "dc09b3c4-58ff-4483-91b7-89ed479e6d1a",
                                Name = "Detalle Fiar",
                                ActionName = "btndetailfiar",
                                Description = "Detalle Fiar",
                                CreatedDate = System.DateTime.Now,
                                state = (Int32)StateEnum.Activeted
                            },
                            new SubModule()
                            {
                                Id = "e29facaf-0fc6-418c-8cc5-d28504240c00",
                                ModuleId = "dc09b3c4-58ff-4483-91b7-89ed479e6d1a",
                                Name = "Reimprimir tiket",
                                ActionName = "btnprinttiket",
                                Description = "Reimprimir tiket",
                                CreatedDate = System.DateTime.Now,
                                state = (Int32)StateEnum.Activeted
                            },                            
                        #endregion

                        #region Product
                                new SubModule()
                                {
                                    Id = "dbb0673c-3589-4e98-a42a-103cb44697d9",
                                    ModuleId = "8178794d-5f0c-4255-b234-8f0f683e74dd",
                                    Name = "ABM Producto",
                                    ActionName = "btnabmproduct",
                                    Description = "ABM Producto",
                                    CreatedDate = System.DateTime.Now,
                                    state = (Int32)StateEnum.Activeted
                                },
                                new SubModule()
                                {
                                    Id = "4a6f84a3-779c-4d2e-841a-88546fcdc0f1",
                                    ModuleId = "8178794d-5f0c-4255-b234-8f0f683e74dd",
                                    Name = "Consultar Vencimiento",
                                    ActionName = "btnconsultantdateexpired",
                                    Description = "Consultar Vencimiento",
                                    CreatedDate = System.DateTime.Now,
                                    state = (Int32)StateEnum.Activeted
                                },
                                new SubModule()
                                {
                                    Id = "d4e2445b-c66a-4b70-9f4d-6c1cbbfdca40",
                                    ModuleId = "8178794d-5f0c-4255-b234-8f0f683e74dd",
                                    Name = "Detalle Producto",
                                    ActionName = "btndetailproduct",
                                    Description = "Detalle Producto",
                                    CreatedDate = System.DateTime.Now,
                                    state = (Int32)StateEnum.Activeted
                                },
                                new SubModule()
                                {
                                    Id = "34c3d045-9e99-470c-822b-aa8caa9cdfe2",
                                    ModuleId = "8178794d-5f0c-4255-b234-8f0f683e74dd",
                                    Name = "Crear Oferta",
                                    ActionName = "btncreateoffer",
                                    Description = "Crear Oferta",
                                    CreatedDate = System.DateTime.Now,
                                    state = (Int32)StateEnum.Activeted
                                },
                                new SubModule()
                                {
                                    Id = "a0379995-cae9-47c6-95d0-4109dd6437e8",
                                    ModuleId = "8178794d-5f0c-4255-b234-8f0f683e74dd",
                                    Name = "Actualizar stock",
                                    ActionName = "btnupdateatock",
                                    Description = "Actualizar stock",
                                    CreatedDate = System.DateTime.Now,
                                    state = (Int32)StateEnum.Activeted
                                },
                        #endregion

                        #region Proveedor
                                new SubModule()
                                {
                                    Id = "a89f3ce0-000f-4525-8be6-48d417718f4c",
                                    ModuleId = "a9315906-f7bf-49eb-808e-d24cb39a04ba",
                                    Name = "ABM Proveedor",
                                    ActionName = "btnambproveedor",
                                    Description = "ABM Proveedor",
                                    CreatedDate = System.DateTime.Now,
                                    state = (Int32)StateEnum.Activeted
                                },
                                new SubModule()
                                {
                                    Id = "b269ec21-d373-4698-8acc-f6c47d501987",
                                    ModuleId = "a9315906-f7bf-49eb-808e-d24cb39a04ba",
                                    Name = "Consultar producto",
                                    ActionName = "btnconsultantproducto",
                                    Description = "Consultar producto",
                                    CreatedDate = System.DateTime.Now,
                                    state = (Int32)StateEnum.Activeted
                                },
                    #endregion

                        #region Reportes
                                 new SubModule()
                                 {
                                     Id = "db88181b-478e-4523-8f75-3ca66afba611",
                                     ModuleId = "e64ac6a7-bf12-4d14-815f-e52cb8252878",
                                     Name = "Ventas",
                                     ActionName = "btnsalereport",
                                     Description = "Ventas",
                                     CreatedDate = System.DateTime.Now,
                                     state = (Int32)StateEnum.Activeted
                                 },
                                 new SubModule()
                                 {
                                     Id = "1774917c-fb76-492f-9adc-846886d9ed0e",
                                     ModuleId = "e64ac6a7-bf12-4d14-815f-e52cb8252878",
                                     Name = "Productos",
                                     ActionName = "btnproductreport",
                                     Description = "Productos",
                                     CreatedDate = System.DateTime.Now,
                                     state = (Int32)StateEnum.Activeted
                                 },
                                 new SubModule()
                                 {
                                     Id = "9a3f1169-10b8-4d41-89ad-a6c24e917b52",
                                     ModuleId = "e64ac6a7-bf12-4d14-815f-e52cb8252878",
                                     Name = "Proveedores",
                                     ActionName = "btnproveedorreport",
                                     Description = "Proveedores",
                                     CreatedDate = System.DateTime.Now,
                                     state = (Int32)StateEnum.Activeted
                                 },
            #endregion

                        #region Gestion usuario

                                 new SubModule()
                                 {
                                     Id = "d8ca7cbe-0ace-4d44-b74f-e0bac19c7770",
                                     ModuleId = "5017aded-60ac-45cc-89b1-993703cd91ab",
                                     Name = "ABM Usuario",
                                     ActionName = "btnabmgestionuser",
                                     Description = "ABM Usuario",
                                     CreatedDate = System.DateTime.Now,
                                     state = (Int32)StateEnum.Activeted
                                 },
                                 new SubModule()
                                 {
                                     Id = "ad3aa3aa-0f57-4f6e-9d20-72a247a9abe7",
                                     ModuleId = "5017aded-60ac-45cc-89b1-993703cd91ab",
                                     Name = "Cambiar contraseña",
                                     ActionName = "btnchangepassword",
                                     Description = "Cambiar contraseña",
                                     CreatedDate = System.DateTime.Now,
                                     state = (Int32)StateEnum.Activeted
                                 },
                    #endregion

                        #region Movimientos
                                     new SubModule()
                                     {
                                         Id = "08968b7c-3fc1-4bcc-9ff2-41336219ec69",
                                         ModuleId = "f01ea86d-5d66-493d-9df2-4fe211bc8509",
                                         Name = "ABM movimiento",
                                         ActionName = "btnmouvment",
                                         Description = "ABM movimiento",
                                         CreatedDate = System.DateTime.Now,
                                         state = (Int32)StateEnum.Activeted
                                     },
                                     new SubModule()
                                     {
                                         Id = "56672d96-1e2e-409e-b01f-f47d978fd286",
                                         ModuleId = "f01ea86d-5d66-493d-9df2-4fe211bc8509",
                                         Name = "ABM tipo movimiento",
                                         ActionName = "btntypemouvment",
                                         Description = "ABM tipo movimiento",
                                         CreatedDate = System.DateTime.Now,
                                         state = (Int32)StateEnum.Activeted
                                     },
                    #endregion

                        #region Seguridad
                                new SubModule()
                                {
                                    Id = "fc374362-3c46-4600-b533-7854526353ec",
                                    ModuleId = "efa9e573-4308-4d88-99cf-d2c51c85cd54",
                                    Name = "ABM Permiso",
                                    ActionName = "button23",
                                    Description = "ABM Permiso",
                                    CreatedDate = System.DateTime.Now,
                                    state = (Int32)StateEnum.Activeted
                                },
                                 new SubModule()
                                 {
                                     Id = "7d3afe88-1c0a-48f8-a9ca-90b9e76783ea",
                                     ModuleId = "efa9e573-4308-4d88-99cf-d2c51c85cd54",
                                     Name = "ABM forma de pago",
                                     ActionName = "button22",
                                     Description = "ABM forma de pago",
                                     CreatedDate = System.DateTime.Now,
                                     state = (Int32)StateEnum.Activeted
                                 },
                                 new SubModule()
                                 {
                                     Id = "25a434b6-674f-47de-95ba-904c6b867318",
                                     ModuleId = "efa9e573-4308-4d88-99cf-d2c51c85cd54",
                                     Name = "Gestionar turno",
                                     ActionName = "button25",
                                     Description = "Gestionar turno",
                                     CreatedDate = System.DateTime.Now,
                                     state = (Int32)StateEnum.Activeted
                                 },
                                 new SubModule()
                                 {
                                     Id = "44f91259-af42-431f-be8e-bea98a9bf6eb",
                                     ModuleId = "efa9e573-4308-4d88-99cf-d2c51c85cd54",
                                     Name = "Incremento nocturno",
                                     ActionName = "button9",
                                     Description = "Incremento nocturno",
                                     CreatedDate = System.DateTime.Now,
                                     state = (Int32)StateEnum.Activeted
                                 },
                                 new SubModule()
                                 {
                                     Id = "c6139ff7-4b03-450c-8abc-457620c4714a",
                                     ModuleId = "efa9e573-4308-4d88-99cf-d2c51c85cd54",
                                     Name = "Actualizar precio",
                                     ActionName = "button27",
                                     Description = "Actualizar precio",
                                     CreatedDate = System.DateTime.Now,
                                     state = (Int32)StateEnum.Activeted
                                 },
                                 new SubModule()
                                 {
                                     Id = "83824e9f-6d83-462b-b2a4-592502af5d60",
                                     ModuleId = "efa9e573-4308-4d88-99cf-d2c51c85cd54",
                                     Name = "Abrir turno",
                                     ActionName = "button28",
                                     Description = "Abrir turno",
                                     CreatedDate = System.DateTime.Now,
                                     state = (Int32)StateEnum.Activeted
                                 },
                                 new SubModule()
                                 {
                                     Id = "cb364518-b564-4336-98d4-349c67f35531",
                                     ModuleId = "efa9e573-4308-4d88-99cf-d2c51c85cd54",
                                     Name = "Cerrar turno",
                                     ActionName = "button29",
                                     Description = "Cerrar turno",
                                     CreatedDate = System.DateTime.Now,
                                     state = (Int32)StateEnum.Activeted
                                 },
                                 new SubModule()
                                 {
                                     Id = "023b4db0-a094-4fd8-b215-0f1941a5223f",
                                     ModuleId = "efa9e573-4308-4d88-99cf-d2c51c85cd54",
                                     Name = "ABM categoria",
                                     ActionName = "button26",
                                     Description = "ABM categoria",
                                     CreatedDate = System.DateTime.Now,
                                     state = (Int32)StateEnum.Activeted
                                 },
                                 new SubModule()
                                 {
                                     Id = "0f44982b-bc5c-4ff8-a4cd-fc518baa3457",
                                     ModuleId = "efa9e573-4308-4d88-99cf-d2c51c85cd54",
                                     Name = "ABM Negocio",
                                     ActionName = "button30",
                                     Description = "Turno cerrado",
                                     CreatedDate = System.DateTime.Now,
                                     state = (Int32)StateEnum.Activeted
                                 },
                                 new SubModule()
                                 {
                                     Id = "27d6db63-5a85-438d-98f7-63c744059223",
                                     ModuleId = "efa9e573-4308-4d88-99cf-d2c51c85cd54",
                                     Name = "Modificar permiso",
                                     ActionName = "btnmodifyrol",
                                     Description = "Modificar",
                                     CreatedDate = System.DateTime.Now,
                                     state = (Int32)StateEnum.Activeted
                                 }
                                 #endregion

            );

            entityBuilder.HasMany(e => e.SubModuleAccounts).WithOne(e => e.SubModule).HasForeignKey(e => e.SubModuleId).IsRequired();
        }
    }
}
