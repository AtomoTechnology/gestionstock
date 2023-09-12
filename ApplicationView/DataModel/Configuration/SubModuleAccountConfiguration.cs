using ApplicationView.DataModel.Entities;
using ApplicationView.Resolver.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ApplicationView.DataModel.Configuration
{
    public class SubModuleAccountConfiguration
    {
        public SubModuleAccountConfiguration(EntityTypeBuilder<SubModuleAccount> entityBuilder)
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.SubModuleId).IsRequired();
            entityBuilder.Property(u => u.ModuleAccountId).IsRequired();

            entityBuilder.HasData(
            #region Ventas
                new SubModuleAccount()
                {
                    Id = "bd812379-dc7b-4439-b116-24467fd0b31c",
                    ModuleAccountId = "7151993b-b219-4e22-80f2-0ec8002e4b3f",
                    SubModuleId = "ee090c50-f4a4-4877-8df7-0a05abeaf1c8",
                    CreatedDate = System.DateTime.Now,
                    state = (Int32)StateEnum.Activeted
                },
               new SubModuleAccount()
               {
                   Id = "ca8743fd-6fed-4289-94d9-de8db265282a",
                   ModuleAccountId = "7151993b-b219-4e22-80f2-0ec8002e4b3f",
                   SubModuleId = "b6960d25-b1d3-4a16-88b9-56ad9d8bd212",
                    CreatedDate = System.DateTime.Now,
                   state = (Int32)StateEnum.Activeted
               },
               new SubModuleAccount()
               {
                   Id = "5ab48144-1d40-44de-89c0-8813fa07520d",
                   ModuleAccountId = "7151993b-b219-4e22-80f2-0ec8002e4b3f",
                   SubModuleId = "371d3ef5-916f-4c5a-9bdb-4208febf7813",
                   CreatedDate = System.DateTime.Now,
                   state = (Int32)StateEnum.Activeted
               },
               new SubModuleAccount()
               {
                   Id = "8eed93e8-914c-440b-8eff-8a458f728318",
                   ModuleAccountId = "7151993b-b219-4e22-80f2-0ec8002e4b3f",
                   SubModuleId = "0081ef4d-6b18-4e83-a443-b3b85abc6c47",
                   CreatedDate = System.DateTime.Now,
                   state = (Int32)StateEnum.Activeted
               },
               new SubModuleAccount()
               {
                   Id = "90aa3aff-2601-44eb-80fc-cfa377c68376",
                   ModuleAccountId = "7151993b-b219-4e22-80f2-0ec8002e4b3f",
                   SubModuleId = "e29facaf-0fc6-418c-8cc5-d28504240c00",
                   CreatedDate = System.DateTime.Now,
                   state = (Int32)StateEnum.Activeted
               },
            #endregion

            #region Producto

            new SubModuleAccount()
            {
                Id = "41e9f11b-7959-40c2-99b3-f3fdf96a6c73",
                ModuleAccountId = "6bd7fbf4-13b7-4dbc-a64f-caf40bb131fc",
                SubModuleId = "dbb0673c-3589-4e98-a42a-103cb44697d9",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
            new SubModuleAccount()
            {
                Id = "e1106fb8-3cb6-4c2a-99ca-ecabc7cf3d3c",
                ModuleAccountId = "6bd7fbf4-13b7-4dbc-a64f-caf40bb131fc",
                SubModuleId = "4a6f84a3-779c-4d2e-841a-88546fcdc0f1",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
            new SubModuleAccount()
            {
                Id = "a10c5462-b220-4453-b9e4-dc8e8df48f01",
                ModuleAccountId = "6bd7fbf4-13b7-4dbc-a64f-caf40bb131fc",
                SubModuleId = "d4e2445b-c66a-4b70-9f4d-6c1cbbfdca40",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
            new SubModuleAccount()
            {
                Id = "884e424a-b544-4bfc-bfc2-61bf3bf5109e",
                ModuleAccountId = "6bd7fbf4-13b7-4dbc-a64f-caf40bb131fc",
                SubModuleId = "34c3d045-9e99-470c-822b-aa8caa9cdfe2",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
            new SubModuleAccount()
            {
                Id = "74297990-eb30-48c9-bb4c-c0893e7b90fd",
                ModuleAccountId = "6bd7fbf4-13b7-4dbc-a64f-caf40bb131fc",
                SubModuleId = "a0379995-cae9-47c6-95d0-4109dd6437e8",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
            #endregion

            #region Provider

            new SubModuleAccount()
            {
                Id = "9ee127bc-5fe2-4514-95f8-f4b8dc807956",
                ModuleAccountId = "b871ccf3-2421-4861-b7a0-3ed6b070a3c3",
                SubModuleId = "a89f3ce0-000f-4525-8be6-48d417718f4c",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
             new SubModuleAccount()
             {
                 Id = "791397f9-efd2-42e5-bc31-e9128f511e5a",
                 ModuleAccountId = "b871ccf3-2421-4861-b7a0-3ed6b070a3c3",
                 SubModuleId = "b269ec21-d373-4698-8acc-f6c47d501987",
                 CreatedDate = System.DateTime.Now,
                 state = (Int32)StateEnum.Activeted
             },
            #endregion

            #region Reporte

            new SubModuleAccount()
            {
                Id = "42a06f1e-8f39-4b14-9558-135fb275e68b",
                ModuleAccountId = "a2585d96-d782-45c2-b8be-1edbfaaa160e",
                SubModuleId = "db88181b-478e-4523-8f75-3ca66afba611",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
            new SubModuleAccount()
            {
                Id = "f4cf1430-114a-4b41-9ef0-105740a49a4a",
                ModuleAccountId = "a2585d96-d782-45c2-b8be-1edbfaaa160e",
                SubModuleId = "1774917c-fb76-492f-9adc-846886d9ed0e",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
            new SubModuleAccount()
            {
                Id = "a7ce0400-31e8-4c80-9ee5-7ed9d45437f6",
                ModuleAccountId = "a2585d96-d782-45c2-b8be-1edbfaaa160e",
                SubModuleId = "9a3f1169-10b8-4d41-89ad-a6c24e917b52",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
            #endregion

            #region Gestion de usuarios

            new SubModuleAccount()
            {
                Id = "eb7b9771-c370-4db8-adc1-b81ad53d7fa0",
                ModuleAccountId = "ff020261-95e7-4695-90a0-a16f380aa2f7",
                SubModuleId = "d8ca7cbe-0ace-4d44-b74f-e0bac19c7770",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
             new SubModuleAccount()
             {
                 Id = "14b05783-0b18-4652-97e7-fa2c1c437fef",
                 ModuleAccountId = "ff020261-95e7-4695-90a0-a16f380aa2f7",
                 SubModuleId = "ad3aa3aa-0f57-4f6e-9d20-72a247a9abe7",
                 CreatedDate = System.DateTime.Now,
                 state = (Int32)StateEnum.Activeted
             },
            #endregion

            #region Movimientos

            new SubModuleAccount()
            {
                Id = "f377f371-8c13-4d50-b314-045ad65188d8",
                ModuleAccountId = "826e202c-ef1a-4be0-95eb-7eab6388f878",
                SubModuleId = "08968b7c-3fc1-4bcc-9ff2-41336219ec69",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            }, 
            new SubModuleAccount()
            {
                Id = "3e1ba887-d615-4958-9bdc-ce7b39bcf6a7",
                ModuleAccountId = "826e202c-ef1a-4be0-95eb-7eab6388f878",
                SubModuleId = "56672d96-1e2e-409e-b01f-f47d978fd286",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
            #endregion

            #region Seguridad

            new SubModuleAccount()
            {
                Id = "f83429b9-1691-4637-acf4-aa4801c8a746",
                ModuleAccountId = "e30a699e-51c2-4f06-b1bc-7c076824db44",
                SubModuleId = "fc374362-3c46-4600-b533-7854526353ec",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
            new SubModuleAccount()
            {
                Id = "90feb00a-2728-4020-8f81-eb4cfe85e240",
                ModuleAccountId = "e30a699e-51c2-4f06-b1bc-7c076824db44",
                SubModuleId = "7d3afe88-1c0a-48f8-a9ca-90b9e76783ea",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
            new SubModuleAccount()
            {
                Id = "af91cf42-e548-4642-8d30-cd485d4ea24b",
                ModuleAccountId = "e30a699e-51c2-4f06-b1bc-7c076824db44",
                SubModuleId = "25a434b6-674f-47de-95ba-904c6b867318",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
            new SubModuleAccount()
            {
                Id = "11895374-db00-46fd-bc8c-aedc69810376",
                ModuleAccountId = "e30a699e-51c2-4f06-b1bc-7c076824db44",
                SubModuleId = "44f91259-af42-431f-be8e-bea98a9bf6eb",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
            new SubModuleAccount()
            {
                Id = "13087490-c400-42eb-a3ea-0f0daac2617d",
                ModuleAccountId = "e30a699e-51c2-4f06-b1bc-7c076824db44",
                SubModuleId = "c6139ff7-4b03-450c-8abc-457620c4714a",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
            new SubModuleAccount()
            {
                Id = "f2ac551e-c290-4639-ab53-6fdc47cf686d",
                ModuleAccountId = "e30a699e-51c2-4f06-b1bc-7c076824db44",
                SubModuleId = "83824e9f-6d83-462b-b2a4-592502af5d60",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
            new SubModuleAccount()
            {
                Id = "6f618dbe-15aa-4b0e-9019-5f68b3b1d914",
                ModuleAccountId = "e30a699e-51c2-4f06-b1bc-7c076824db44",
                SubModuleId = "cb364518-b564-4336-98d4-349c67f35531",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
            new SubModuleAccount()
            {
                Id = "9d7dc8da-f0eb-4b75-8a05-81c9ea040117",
                ModuleAccountId = "e30a699e-51c2-4f06-b1bc-7c076824db44",
                SubModuleId = "023b4db0-a094-4fd8-b215-0f1941a5223f",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
            new SubModuleAccount()
            {
                Id = "433e441e-a77d-4dfd-a44e-7aea8e5725e3",
                ModuleAccountId = "e30a699e-51c2-4f06-b1bc-7c076824db44",
                SubModuleId = "0f44982b-bc5c-4ff8-a4cd-fc518baa3457",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            },
            new SubModuleAccount()
            {
                Id = "57fbf086-6818-4b5c-9fcf-c9848b000077",
                ModuleAccountId = "e30a699e-51c2-4f06-b1bc-7c076824db44",
                SubModuleId = "27d6db63-5a85-438d-98f7-63c744059223",
                CreatedDate = System.DateTime.Now,
                state = (Int32)StateEnum.Activeted
            }

            #endregion

            );
        }
    }
}
