﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationView.DataModel.Migrations
{
    public partial class modifylotandproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Lots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 538, DateTimeKind.Local).AddTicks(2135));

            migrationBuilder.UpdateData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: "de07358c-3a51-42fb-8690-c383b91b5844",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 543, DateTimeKind.Local).AddTicks(5578));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "07dd4e15-386e-44c7-8f63-801c1dddeb1a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(5456));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "087aa814-3f3d-4cfb-83ef-e11256d6ecdb",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(5444));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "13e20bf2-8bff-4201-b3bf-30cf7e2cdb12",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(5453));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "21fcbb68-3e40-4550-b142-a302fc264a47",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(5461));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "27d5e91e-1229-49cd-964b-cc812a81faeb",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(5466));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4444da14-84ac-48de-a7da-a4f4ddd28858",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(5420));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4af6f8b7-b1a5-4375-8319-079e3d8487fe",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(5432));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "96e050b3-4f1c-4280-8ce0-1f32b6af87f1",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(5427));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "9cb3d8c8-226e-4f1a-b04d-258db3329c75",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(5468));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "9fc02177-e0ba-42cf-bc95-cd2f7abc4418",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(5458));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "b296430c-42de-41f8-8fc2-3f7fadb44218",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(5441));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "c0f96f74-96cf-438a-b89f-0888182b3e75",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(5439));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "db2ca371-5ba5-49d9-81cf-f04f49a61b0e",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(5464));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "e7c4059e-04a1-4f4a-b5c9-b86da231147f",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(5434));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "eeb60ffd-ff0d-4367-afc6-e28bef23f1ef",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(5429));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f350cdda-f912-4fd3-85c9-f99863ab6c2e",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(5437));

            migrationBuilder.UpdateData(
                table: "ModuleAccounts",
                keyColumn: "Id",
                keyValue: "6bd7fbf4-13b7-4dbc-a64f-caf40bb131fc",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(1285));

            migrationBuilder.UpdateData(
                table: "ModuleAccounts",
                keyColumn: "Id",
                keyValue: "7151993b-b219-4e22-80f2-0ec8002e4b3f",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(1247));

            migrationBuilder.UpdateData(
                table: "ModuleAccounts",
                keyColumn: "Id",
                keyValue: "826e202c-ef1a-4be0-95eb-7eab6388f878",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "ModuleAccounts",
                keyColumn: "Id",
                keyValue: "a2585d96-d782-45c2-b8be-1edbfaaa160e",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(1289));

            migrationBuilder.UpdateData(
                table: "ModuleAccounts",
                keyColumn: "Id",
                keyValue: "b871ccf3-2421-4861-b7a0-3ed6b070a3c3",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(1287));

            migrationBuilder.UpdateData(
                table: "ModuleAccounts",
                keyColumn: "Id",
                keyValue: "e30a699e-51c2-4f06-b1bc-7c076824db44",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(1296));

            migrationBuilder.UpdateData(
                table: "ModuleAccounts",
                keyColumn: "Id",
                keyValue: "ff020261-95e7-4695-90a0-a16f380aa2f7",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(1291));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "5017aded-60ac-45cc-89b1-993703cd91ab",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(9708));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "8178794d-5f0c-4255-b234-8f0f683e74dd",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(9700));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "a9315906-f7bf-49eb-808e-d24cb39a04ba",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(9703));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "dc09b3c4-58ff-4483-91b7-89ed479e6d1a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(9684));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "e64ac6a7-bf12-4d14-815f-e52cb8252878",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(9706));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "efa9e573-4308-4d88-99cf-d2c51c85cd54",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "f01ea86d-5d66-493d-9df2-4fe211bc8509",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "1535f60d-2db1-4c65-90bc-c1ded55b07aa",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(1778));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "3700a7b3-0e1b-49e2-87ce-490d06d2512c",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "4c1ffed9-2f0c-4294-8b82-d236da387b39",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(1769));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "50e82295-a08f-42fa-aae0-26813bc261db",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "876d4600-b062-4e84-937d-8a79f88c1e47",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(1781));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "b9d03d21-52ed-486f-8b60-bd871505e6b5",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(1790));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "c3eb2f61-7bd0-47ed-8a16-98e1b7d24b44",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "da40a532-f06a-4fff-8f66-a7563fef8941",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(1785));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "db3de6dc-b1f3-44f1-bb24-648e6eb9e65a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(1792));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "f5f737fd-860c-485b-972a-927d385f4ab5",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 545, DateTimeKind.Local).AddTicks(1760));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0ac46b16-ef03-452c-9586-ba4251496b3f",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 544, DateTimeKind.Local).AddTicks(8209));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "66e3d763-3f6c-49f1-ad72-3b64051c4879",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 544, DateTimeKind.Local).AddTicks(8206));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "82a0bec6-8266-443a-84a2-af85ad69348b",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 544, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "005dc5af-61c1-4b54-9266-03407ca75d10",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(341));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "07735a2d-1e10-404d-8ae4-28c05bab0e6b",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(362));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "08bf4c2a-55b9-4449-ba44-7a18e61157fa",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(717));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "09e77b14-a1c5-4094-8ae2-5af32ab26d5d",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(586));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "0be5b0f7-62f6-4411-b540-82b51abc865a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(484));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "0c64e944-3a0b-49f4-a323-6edccc48ba35",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(427));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "0c64f205-d9ca-4a4b-90ec-eac98fbf523c",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(798));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "0c71411a-1acc-44ce-b5ba-c2bb01fac508",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(500));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "0d2d3a77-64c7-4fb3-aee0-366d262d3ce3",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(646));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "0d54b411-6a42-49b1-8a8a-ee2ac22aa1be",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(835));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "0dee8e1a-a3a8-411a-864a-542bf690fb34",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "0e59c12d-d29f-4667-a3af-c1060d16ae94",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(481));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "10db0819-5466-420d-acca-5ecaa864ec0a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(662));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "1174d492-edd1-4f9c-b7cf-ce8a6f68abc3",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(592));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "11ae28fa-b2e2-44fb-8d65-aba73b937ead",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "13722a31-d37e-4c44-9226-fef2dd6ab09e",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(358));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "14348004-c92e-45b9-8cd4-c82060d3f291",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(620));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "1579c57f-cf33-4645-bfcc-4d09f92a70a3",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(331));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "19634b95-60be-45ec-8ca8-e508e273af05",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(827));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "198c65d6-cb58-4d3f-be56-f1bc93fc0277",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(644));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "19fe7044-5f20-4720-9bf3-9214b1d9fbef",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(631));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "1a27fb1d-7b20-41a2-9c53-43e5afa27698",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(404));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "1a3985b7-65b2-4fc3-bf00-7d5764bd59f2",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(337));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "1bc53107-6800-4b35-b4f3-c3363fb89a19",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(372));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "1d5721d3-a787-4b8d-9d6f-ffb5d5262b21",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(423));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "1faacaec-d09a-4fb5-ab7f-3ca55c754ccd",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(520));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "208b7941-a0a1-47bb-8b6c-5108c0f4cc2b",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "20db2648-207a-474b-a97d-d53451152de3",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(550));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "2267271b-d123-4f63-8e8e-c1719a4ad20d",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "247700b0-7887-45b1-b670-4e97c0b90b44",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(406));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "24a39fa6-79d3-47c7-9e55-180bf92c2d89",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(851));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "24a73edb-d737-42fa-a380-b2fdddd9ef44",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(334));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "25202d3f-46e2-4706-aa39-f1100063aeca",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(389));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "25bb2d73-56d5-4479-bce5-a63aa1ca63d6",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(582));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "2cd8ebea-b8e5-408e-b098-4a6f635bc6bd",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(379));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "30c5ec35-19f7-4d52-aaa1-cfcf21987603",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(391));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "35532f1d-0adf-460a-ad91-63e270f7a4db",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(441));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "3861c055-4277-4c56-8114-5f2c1b898f5c",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(445));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "3b2730ed-eee3-4d6a-b7e2-46934dd2cd25",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(818));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "3ba56596-8256-46a0-85b1-fcedb255c8a2",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(823));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "3e237426-d168-4f88-bdd5-44236546870a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(434));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "410e6eda-1fb4-4ced-84d2-3542b87ada40",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(443));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "41e9e143-03db-4b0f-a51b-6b9160d357fc",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(354));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "422edf4a-d9e6-40f4-9cc1-9b0dcd0756ac",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(803));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "42496afc-b727-48cb-ae26-eb20c859bba7",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(366));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "4636fd58-00ad-4f6c-ab97-6a91a2a6e210",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(820));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "46c73d3e-d21b-4914-87a9-ebac432901e7",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(454));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "4b799d8f-ee08-4e8e-930e-ab8403392c4b",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(530));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "4ba4eaad-c72c-4bf4-8715-2d1d58f1901b",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "4c1f4d08-7a4b-43d3-beca-4959700e41bc",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(780));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "4d85744f-add3-4f9e-88c8-2c34ab4f815a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(664));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "51858237-ae9b-4731-88c2-f19a2d344c3c",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(300));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "524bbae4-38ca-4f9b-9603-aebcd65ecf84",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(348));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "52cd0e99-22b0-4e17-ba9f-ad448b3b8766",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(492));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "530edb0d-938c-4ae4-869a-567bf6bb529c",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(568));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "55136ca5-1c33-4e44-9e4d-34a06c6086f8",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(400));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "5656e6aa-f9cb-4add-99cb-a9f2696480a0",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(548));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "591bac37-162a-4314-b0ae-46e9db02f691",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(841));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "5c19e99c-2b96-49cc-a968-7e5d270b1201",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(457));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "5df74c33-8b66-4999-a511-6aecc01faa33",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(552));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "60366d57-cfe4-473a-a473-6e58fce5c928",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(849));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "62433dfd-835e-4651-99f5-78ea6eefec3f",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(853));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "62664ce7-b8a0-4531-bfb9-932595f7d7a4",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(436));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "6399abe6-056a-425c-a41e-371e7f135bce",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(449));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "63eaca83-cacf-4d84-9b29-2fa454a9c206",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "63efd264-3e31-480b-b86c-27c500705826",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(546));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "6557a6d3-5317-44c2-98fd-333064c87b13",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(601));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "65749701-c848-42a3-8549-b90938b0a98f",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(719));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "65ade45e-c4b5-4b7d-9d71-2cfae455fe31",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(651));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "65bb2650-2d2a-46b4-841b-39bc67d3b132",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(759));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "66c6219a-a5eb-49d5-9a73-d36bb76d821a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(805));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "6ad37caa-6ee5-4f73-ab41-ea2be3d77828",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(394));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "6c9aa2b5-8cef-4621-b526-d94b08c17e46",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(310));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "6cf0328c-d542-43be-baed-72af19417433",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(539));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "6d2eac00-615c-4802-8706-ed8f3b339e26",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(431));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "6d5403fe-eb3b-4e6a-b66f-5584d61c75d5",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(561));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "6eea4362-7ae5-4631-b3ca-571d523b3176",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(816));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "6f9c9a1a-7ea6-40a2-9a50-feaa658493c7",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(425));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "7002138f-f7fb-4a43-a880-060188703c09",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "7027f120-3478-4896-81cf-21bcff739315",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(398));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "70bc49ab-7e64-461a-a350-d18323fe6743",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(683));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "74bd441c-c526-4aa8-9948-467be87158e6",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(579));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "76ac4c24-9bc2-4897-a9a2-60529d306a14",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "77c79cbb-b53e-40aa-aa80-043d4f221bec",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(321));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "77e2ee32-b9fc-4600-b28b-1ec5b0190e7d",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(604));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "796cfb96-7b0d-4558-a4a9-08a9fed29071",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(674));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "7b3bdb7e-f9d4-4bfc-ab00-ad75b1e32185",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(570));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "7be30abf-7504-480b-b0af-580ccc0be9ec",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(747));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "7e36389e-2514-4c1a-9b02-956cccb72b7a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "7fc35ef8-08f5-4504-b578-012b873574d9",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(350));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "8126f485-7a77-49c9-a3cb-de1be3b682bd",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(676));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "81806b92-46ce-4177-bcad-3c572857aec5",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(276));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "82305cb1-de65-4b90-8734-87c5a768e7b3",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(461));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "82fe357c-af4b-436b-b648-983a6092aa65",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(352));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "84990688-e3f9-45af-8f22-03c77262c614",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(314));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "84bb56bb-c36d-4117-a4cf-e768990761eb",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(345));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "85bb728e-2c64-4d40-9189-735313307bf8",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(678));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "86775899-0796-4ede-b76f-b2fb4b30aced",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(517));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "88cfed2e-4469-4d95-8f08-252ce4f74e8f",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(625));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "8a195233-1a00-4dbf-a41d-3c4c0d18b574",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(599));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "8ac143dd-a639-4bad-9243-5706bf358ae1",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(633));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "8aee87a6-643f-4197-abe7-ee9956cfe636",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(671));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "8bac1ef3-473c-41a7-95a3-209fbea0c9b7",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(488));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "8c066537-f8d7-4031-9172-872081e1d0a3",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(839));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "8ef9734c-7ed8-4ce0-9899-d96b3da864eb",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(807));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "8efb933d-b689-4110-8cff-4a4e20f46104",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(658));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "8f762c3f-368d-412b-bd04-3090847b30ea",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(554));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "90bb3117-ea6e-4868-9fc3-7504f685c03e",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(356));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "933336aa-5883-46b4-b6af-3f5c89b5b973",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "9538e426-3d8a-4575-aaeb-671bfadfcf4c",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(811));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "95dc66d1-1de1-46de-a588-a5080f197aae",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(505));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "98a5dd90-ba52-4534-998f-5da2e95e38b4",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(845));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "995a74e1-98b5-4489-977d-f84113df2bc1",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(327));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "9a15a184-1821-4b06-9b6d-8624e62f42fb",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(305));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "9ba0b0c7-d09a-42e5-920d-fac472cfdad9",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(667));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "9c8dde52-8d6c-4b7c-9651-fef58287be61",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(383));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "9cdba6b6-d54a-467c-ae55-baa752ec67c7",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(507));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "9d6c9083-6b73-45c9-a61b-28800cfc5d0a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(368));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "9f8fff37-92e9-465b-ae5d-8940ae1e1cd3",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(642));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a055a422-56d0-4852-ac24-5a5925002c35",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(606));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a1746970-5277-4100-87fb-27843e3e7572",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(560));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a2a399bc-e461-40b5-85e0-dddc7b5ddea4",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(736));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a37d971a-c292-4b59-8883-04362047cb2f",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(496));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a39c1fd6-2a60-4b29-8ba9-3e263406caf2",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(532));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a4d3cc0d-8e39-460c-a02d-18fc2dced014",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(307));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a5b8701d-c62c-476e-b22f-e666def4152a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a64360a1-d91a-4405-9996-56ef3a89e32c",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(544));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a77e5bf6-0d96-4922-999e-09b4909ebae5",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(724));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a8e6b961-8f12-4679-a05c-0d72fdb4f755",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(749));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a8f90356-989c-47a5-a6f6-ab338f283018",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(364));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a93bf77b-505b-46f8-8442-795bd47d83b2",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(490));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a93e6d6a-fe84-4977-88f9-9eb5dac3c7e4",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(615));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "aae444bc-4a86-4e9f-bfbd-71ad73da07a2",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(830));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "ad74e8ce-c6cf-4f0d-a7c3-0b86a5690808",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(439));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "ad774f0a-e895-47c4-8b7e-9593c5d37f8e",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(635));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "add2357f-a4bd-480d-9652-df476b521e4c",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b0848172-c1be-469b-b874-5143c420a137",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(446));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b0a7966c-e4ab-426c-8628-c86106fbf3fe",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(744));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b0c6bb87-7bb1-43d4-b6fa-43eb67694604",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b1aac6b6-1e84-45a6-ac41-52e14a8ea1fa",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(825));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b21274b8-1f85-4034-aa24-f47ae1f46d00",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(317));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b3ae5bf6-5836-4e90-9c69-637afde26bd7",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(655));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b4f45ffb-8b76-4304-bd06-706a228b5b10",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b71dd199-bb0d-44d2-98a1-71466e29b4ae",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(680));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b83339e8-ec1b-44a4-8045-cb6e22905cd7",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(761));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b94e325c-2fa5-4c2e-ae97-66c53f7f23b1",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(565));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b9d66a36-38d6-4d57-bad3-b0e949a5a574",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(714));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "bb40a622-9e9e-4c19-ae9f-545dc86bef0d",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(787));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "bb789c84-5913-4a64-984b-20ad85a99de1",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(536));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "bc0083b3-7fce-4fb2-92df-9d6be798366a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(459));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "bca46483-d119-4a9a-a72b-676d761ebb6a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(408));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "bd91bd5a-4f03-48d5-ab41-ff3900b3b566",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(518));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "c3165ffb-7ad1-4730-8b00-a335edac1cc5",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(381));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "c31961f5-e6ab-4f1f-a398-04ff4c7c2368",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(660));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "c346edb2-02df-4453-9ba6-a8c718d671bd",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(528));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "c4a81f89-6f44-4c1c-bfd6-adf1f0a312e3",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(286));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "c5ebff6a-ea3a-426c-a06c-38cfdf3fcc31",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(584));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "c7296d61-4b18-46e9-8e26-7a809e636cb8",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(653));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "c7b90037-1c6d-4ad4-8397-5f04014ba97f",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(420));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "c8cb23d4-2d87-41ec-a592-9535d366f9db",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(502));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "c90a0767-fb77-4136-ab65-7719945e803a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(722));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "cb924254-4f5b-4e25-aafc-b3c6e51a26a7",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(726));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "cdea20ca-087d-4fb5-8553-105c1e2d9a84",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(789));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "ce775a23-82b1-4cdf-9736-a378cdb88c8c",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "cf17f4d4-cfc1-4c06-9f6a-6eac5062ede9",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(396));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "d295440a-24c8-4a8f-879a-41f9c883fa4b",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(756));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "d571e083-40cd-41db-8448-f55d4cc16780",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "d6d038ac-c428-4761-8d24-dc0703e8e4c2",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(763));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "d75240b2-f901-46af-80be-fcb9a7bd174b",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(429));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "d8fa7bc2-e8b5-44c4-b4ee-79f0db884832",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(556));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "dbcc02e0-7b1e-406e-b3e0-a0f333b0062e",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(486));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "dc85f186-d18b-4a8b-a504-698fda19a9b6",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(303));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "dca0c0d8-69a7-451c-bbe3-db4e4237daaf",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(495));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "dd2d472b-252b-4963-a802-6e615657df04",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(410));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "dd56fb2d-90d1-404d-bf33-3a2163a6fc20",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(402));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "def25cbf-86db-4ae4-ae45-7a63a8d71c6c",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(414));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "df953e9b-49b2-4c98-bf43-c0b89ffd2671",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(814));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "dfce1885-ecbe-432e-9148-8a2d34809082",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(843));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "e06b976c-4745-4368-a615-3d011811589e",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(590));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "e28f8d28-5cb6-4f56-918e-c822a0060452",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(452));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "e3a46fc4-de62-41cc-8a11-305cbbf77ebb",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(370));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "e5bc3319-2a58-4df3-89bd-17edc123cc0a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(621));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "e5eab8bf-d214-4bb2-a42a-e73d6c8890d8",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "e7af707d-2029-4d1d-a10b-9a5c55d98ca2",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(732));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "eb4ed592-7499-4ea3-9c4d-aea95c4a86b1",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(498));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "ed6b2c4a-bcf3-4d0b-8e98-83ddd98653b6",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(648));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "ee9c7eb3-842a-4671-a046-96facfb2bcb6",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "f467869a-bbb7-4647-bb04-82e7bfd07eb5",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(524));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "f586c0df-265a-46d3-9f7d-1219f269c2d6",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(573));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "f66ac072-f4db-4bae-9ad3-25afe5d653b8",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(800));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "f7f2a895-0a64-4e47-bbab-9bd914eaa86e",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(754));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "fa7b0ef7-a5b5-48a8-80dd-bdbb51b3827a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(588));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "fb894ec4-3008-46d0-bcbd-10c66df049af",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(809));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "fd74c75f-db36-4101-bcd4-9b5d672f2c5a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(312));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "fec5fe83-b884-4d56-a5fe-6d7ab2156574",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(734));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "fef25062-8fc1-4006-8514-e234bfa63a05",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(416));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "fefb0f12-c610-44ba-a425-b58344af0a3c",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(637));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "11895374-db00-46fd-bc8c-aedc69810376",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1789));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "13087490-c400-42eb-a3ea-0f0daac2617d",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1792));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "14b05783-0b18-4652-97e7-fa2c1c437fef",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1763));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "3e1ba887-d615-4958-9bdc-ce7b39bcf6a7",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "41e9f11b-7959-40c2-99b3-f3fdf96a6c73",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1689));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "42a06f1e-8f39-4b14-9558-135fb275e68b",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "433e441e-a77d-4dfd-a44e-7aea8e5725e3",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "57fbf086-6818-4b5c-9fcf-c9848b000077",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1808));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "5ab48144-1d40-44de-89c0-8813fa07520d",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1685));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "6f618dbe-15aa-4b0e-9019-5f68b3b1d914",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1796));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "74297990-eb30-48c9-bb4c-c0893e7b90fd",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1751));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "791397f9-efd2-42e5-bc31-e9128f511e5a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1754));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "884e424a-b544-4bfc-bfc2-61bf3bf5109e",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "8eed93e8-914c-440b-8eff-8a458f728318",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1687));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "90feb00a-2728-4020-8f81-eb4cfe85e240",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "9d7dc8da-f0eb-4b75-8a05-81c9ea040117",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1805));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "9ee127bc-5fe2-4514-95f8-f4b8dc807956",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1752));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "a10c5462-b220-4453-b9e4-dc8e8df48f01",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1693));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "a7ce0400-31e8-4c80-9ee5-7ed9d45437f6",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1760));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "af91cf42-e548-4642-8d30-cd485d4ea24b",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1787));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "bd812379-dc7b-4439-b116-24467fd0b31c",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1647));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "ca8743fd-6fed-4289-94d9-de8db265282a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1681));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "e1106fb8-3cb6-4c2a-99ca-ecabc7cf3d3c",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1691));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "eb7b9771-c370-4db8-adc1-b81ad53d7fa0",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1761));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "f2ac551e-c290-4639-ab53-6fdc47cf686d",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1794));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "f377f371-8c13-4d50-b314-045ad65188d8",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1769));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "f4cf1430-114a-4b41-9ef0-105740a49a4a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1758));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "f83429b9-1691-4637-acf4-aa4801c8a746",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 549, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "0081ef4d-6b18-4e83-a443-b3b85abc6c47",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6717));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "023b4db0-a094-4fd8-b215-0f1941a5223f",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6782));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "08968b7c-3fc1-4bcc-9ff2-41336219ec69",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "0f44982b-bc5c-4ff8-a4cd-fc518baa3457",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6784));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "1774917c-fb76-492f-9adc-846886d9ed0e",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "25a434b6-674f-47de-95ba-904c6b867318",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "27d6db63-5a85-438d-98f7-63c744059223",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6786));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "34c3d045-9e99-470c-822b-aa8caa9cdfe2",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6731));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "371d3ef5-916f-4c5a-9bdb-4208febf7813",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6715));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "44f91259-af42-431f-be8e-bea98a9bf6eb",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6772));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "4a6f84a3-779c-4d2e-841a-88546fcdc0f1",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "56672d96-1e2e-409e-b01f-f47d978fd286",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6763));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "7d3afe88-1c0a-48f8-a9ca-90b9e76783ea",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "83824e9f-6d83-462b-b2a4-592502af5d60",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6777));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "9a3f1169-10b8-4d41-89ad-a6c24e917b52",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "a0379995-cae9-47c6-95d0-4109dd6437e8",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "a89f3ce0-000f-4525-8be6-48d417718f4c",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6738));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "ad3aa3aa-0f57-4f6e-9d20-72a247a9abe7",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6757));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "b269ec21-d373-4698-8acc-f6c47d501987",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6741));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "b6960d25-b1d3-4a16-88b9-56ad9d8bd212",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6712));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "c6139ff7-4b03-450c-8abc-457620c4714a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6774));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "cb364518-b564-4336-98d4-349c67f35531",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6779));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "d4e2445b-c66a-4b70-9f4d-6c1cbbfdca40",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6726));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "d8ca7cbe-0ace-4d44-b74f-e0bac19c7770",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "db88181b-478e-4523-8f75-3ca66afba611",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6748));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "dbb0673c-3589-4e98-a42a-103cb44697d9",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6721));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "ee090c50-f4a4-4877-8df7-0a05abeaf1c8",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "fc374362-3c46-4600-b533-7854526353ec",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 548, DateTimeKind.Local).AddTicks(6765));

            migrationBuilder.UpdateData(
                table: "Turns",
                keyColumn: "Id",
                keyValue: "7a57db1f-3f77-4a25-8107-b73e668ab65a",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(3954));

            migrationBuilder.UpdateData(
                table: "Turns",
                keyColumn: "Id",
                keyValue: "c0ba7b4c-d292-48c7-9f78-8a2e83973053",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 546, DateTimeKind.Local).AddTicks(3945));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "362c2637-2ad9-449a-9498-dbd74be87ee8",
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 1, 44, 29, 544, DateTimeKind.Local).AddTicks(2899));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Lots");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: "3e67c8f7-24ce-4f2e-bada-8344f5d0f8ca",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 913, DateTimeKind.Local).AddTicks(8491));

            migrationBuilder.UpdateData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: "de07358c-3a51-42fb-8690-c383b91b5844",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 921, DateTimeKind.Local).AddTicks(8383));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "07dd4e15-386e-44c7-8f63-801c1dddeb1a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 924, DateTimeKind.Local).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "087aa814-3f3d-4cfb-83ef-e11256d6ecdb",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 924, DateTimeKind.Local).AddTicks(2358));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "13e20bf2-8bff-4201-b3bf-30cf7e2cdb12",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 924, DateTimeKind.Local).AddTicks(2362));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "21fcbb68-3e40-4550-b142-a302fc264a47",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 924, DateTimeKind.Local).AddTicks(2394));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "27d5e91e-1229-49cd-964b-cc812a81faeb",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 924, DateTimeKind.Local).AddTicks(2402));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4444da14-84ac-48de-a7da-a4f4ddd28858",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 924, DateTimeKind.Local).AddTicks(2320));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4af6f8b7-b1a5-4375-8319-079e3d8487fe",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 924, DateTimeKind.Local).AddTicks(2337));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "96e050b3-4f1c-4280-8ce0-1f32b6af87f1",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 924, DateTimeKind.Local).AddTicks(2329));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "9cb3d8c8-226e-4f1a-b04d-258db3329c75",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 924, DateTimeKind.Local).AddTicks(2406));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "9fc02177-e0ba-42cf-bc95-cd2f7abc4418",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 924, DateTimeKind.Local).AddTicks(2390));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "b296430c-42de-41f8-8fc2-3f7fadb44218",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 924, DateTimeKind.Local).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "c0f96f74-96cf-438a-b89f-0888182b3e75",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 924, DateTimeKind.Local).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "db2ca371-5ba5-49d9-81cf-f04f49a61b0e",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 924, DateTimeKind.Local).AddTicks(2398));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "e7c4059e-04a1-4f4a-b5c9-b86da231147f",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 924, DateTimeKind.Local).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "eeb60ffd-ff0d-4367-afc6-e28bef23f1ef",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 924, DateTimeKind.Local).AddTicks(2333));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f350cdda-f912-4fd3-85c9-f99863ab6c2e",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 924, DateTimeKind.Local).AddTicks(2345));

            migrationBuilder.UpdateData(
                table: "ModuleAccounts",
                keyColumn: "Id",
                keyValue: "6bd7fbf4-13b7-4dbc-a64f-caf40bb131fc",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 926, DateTimeKind.Local).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "ModuleAccounts",
                keyColumn: "Id",
                keyValue: "7151993b-b219-4e22-80f2-0ec8002e4b3f",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 926, DateTimeKind.Local).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "ModuleAccounts",
                keyColumn: "Id",
                keyValue: "826e202c-ef1a-4be0-95eb-7eab6388f878",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 926, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "ModuleAccounts",
                keyColumn: "Id",
                keyValue: "a2585d96-d782-45c2-b8be-1edbfaaa160e",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 926, DateTimeKind.Local).AddTicks(8190));

            migrationBuilder.UpdateData(
                table: "ModuleAccounts",
                keyColumn: "Id",
                keyValue: "b871ccf3-2421-4861-b7a0-3ed6b070a3c3",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 926, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "ModuleAccounts",
                keyColumn: "Id",
                keyValue: "e30a699e-51c2-4f06-b1bc-7c076824db44",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 926, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "ModuleAccounts",
                keyColumn: "Id",
                keyValue: "ff020261-95e7-4695-90a0-a16f380aa2f7",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 926, DateTimeKind.Local).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "5017aded-60ac-45cc-89b1-993703cd91ab",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(9790));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "8178794d-5f0c-4255-b234-8f0f683e74dd",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(9782));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "a9315906-f7bf-49eb-808e-d24cb39a04ba",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(9785));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "dc09b3c4-58ff-4483-91b7-89ed479e6d1a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(9772));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "e64ac6a7-bf12-4d14-815f-e52cb8252878",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "efa9e573-4308-4d88-99cf-d2c51c85cd54",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(9795));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "f01ea86d-5d66-493d-9df2-4fe211bc8509",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(9793));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "1535f60d-2db1-4c65-90bc-c1ded55b07aa",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 923, DateTimeKind.Local).AddTicks(7460));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "3700a7b3-0e1b-49e2-87ce-490d06d2512c",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 923, DateTimeKind.Local).AddTicks(7452));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "4c1ffed9-2f0c-4294-8b82-d236da387b39",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 923, DateTimeKind.Local).AddTicks(7448));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "50e82295-a08f-42fa-aae0-26813bc261db",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 923, DateTimeKind.Local).AddTicks(7456));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "876d4600-b062-4e84-937d-8a79f88c1e47",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 923, DateTimeKind.Local).AddTicks(7464));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "b9d03d21-52ed-486f-8b60-bd871505e6b5",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 923, DateTimeKind.Local).AddTicks(7493));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "c3eb2f61-7bd0-47ed-8a16-98e1b7d24b44",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 923, DateTimeKind.Local).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "da40a532-f06a-4fff-8f66-a7563fef8941",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 923, DateTimeKind.Local).AddTicks(7472));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "db3de6dc-b1f3-44f1-bb24-648e6eb9e65a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 923, DateTimeKind.Local).AddTicks(7498));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "f5f737fd-860c-485b-972a-927d385f4ab5",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 923, DateTimeKind.Local).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0ac46b16-ef03-452c-9586-ba4251496b3f",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 923, DateTimeKind.Local).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "66e3d763-3f6c-49f1-ad72-3b64051c4879",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 923, DateTimeKind.Local).AddTicks(3095));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "82a0bec6-8266-443a-84a2-af85ad69348b",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 923, DateTimeKind.Local).AddTicks(3085));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "005dc5af-61c1-4b54-9266-03407ca75d10",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(798));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "07735a2d-1e10-404d-8ae4-28c05bab0e6b",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(817));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "08bf4c2a-55b9-4449-ba44-7a18e61157fa",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "09e77b14-a1c5-4094-8ae2-5af32ab26d5d",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1026));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "0be5b0f7-62f6-4411-b540-82b51abc865a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(932));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "0c64e944-3a0b-49f4-a323-6edccc48ba35",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(893));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "0c64f205-d9ca-4a4b-90ec-eac98fbf523c",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1182));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "0c71411a-1acc-44ce-b5ba-c2bb01fac508",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(950));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "0d2d3a77-64c7-4fb3-aee0-366d262d3ce3",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1079));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "0d54b411-6a42-49b1-8a8a-ee2ac22aa1be",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1215));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "0dee8e1a-a3a8-411a-864a-542bf690fb34",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1158));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "0e59c12d-d29f-4667-a3af-c1060d16ae94",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(930));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "10db0819-5466-420d-acca-5ecaa864ec0a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "1174d492-edd1-4f9c-b7cf-ce8a6f68abc3",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1033));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "11ae28fa-b2e2-44fb-8d65-aba73b937ead",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "13722a31-d37e-4c44-9226-fef2dd6ab09e",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(815));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "14348004-c92e-45b9-8cd4-c82060d3f291",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1047));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "1579c57f-cf33-4645-bfcc-4d09f92a70a3",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(790));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "19634b95-60be-45ec-8ca8-e508e273af05",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "198c65d6-cb58-4d3f-be56-f1bc93fc0277",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1077));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "19fe7044-5f20-4720-9bf3-9214b1d9fbef",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1066));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "1a27fb1d-7b20-41a2-9c53-43e5afa27698",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(872));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "1a3985b7-65b2-4fc3-bf00-7d5764bd59f2",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(794));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "1bc53107-6800-4b35-b4f3-c3363fb89a19",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(829));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "1d5721d3-a787-4b8d-9d6f-ffb5d5262b21",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(889));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "1faacaec-d09a-4fb5-ab7f-3ca55c754ccd",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(969));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "208b7941-a0a1-47bb-8b6c-5108c0f4cc2b",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "20db2648-207a-474b-a97d-d53451152de3",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(994));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "2267271b-d123-4f63-8e8e-c1719a4ad20d",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1167));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "247700b0-7887-45b1-b670-4e97c0b90b44",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(874));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "24a39fa6-79d3-47c7-9e55-180bf92c2d89",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1227));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "24a73edb-d737-42fa-a380-b2fdddd9ef44",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(792));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "25202d3f-46e2-4706-aa39-f1100063aeca",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "25bb2d73-56d5-4479-bce5-a63aa1ca63d6",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1022));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "2cd8ebea-b8e5-408e-b098-4a6f635bc6bd",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(831));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "30c5ec35-19f7-4d52-aaa1-cfcf21987603",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(840));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "35532f1d-0adf-460a-ad91-63e270f7a4db",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(907));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "3861c055-4277-4c56-8114-5f2c1b898f5c",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(911));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "3b2730ed-eee3-4d6a-b7e2-46934dd2cd25",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1202));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "3ba56596-8256-46a0-85b1-fcedb255c8a2",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1206));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "3e237426-d168-4f88-bdd5-44236546870a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(900));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "410e6eda-1fb4-4ced-84d2-3542b87ada40",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(909));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "41e9e143-03db-4b0f-a51b-6b9160d357fc",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(810));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "422edf4a-d9e6-40f4-9cc1-9b0dcd0756ac",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1186));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "42496afc-b727-48cb-ae26-eb20c859bba7",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(822));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "4636fd58-00ad-4f6c-ab97-6a91a2a6e210",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1204));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "46c73d3e-d21b-4914-87a9-ebac432901e7",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(921));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "4b799d8f-ee08-4e8e-930e-ab8403392c4b",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(976));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "4ba4eaad-c72c-4bf4-8715-2d1d58f1901b",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(959));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "4c1f4d08-7a4b-43d3-beca-4959700e41bc",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "4d85744f-add3-4f9e-88c8-2c34ab4f815a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "51858237-ae9b-4731-88c2-f19a2d344c3c",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(763));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "524bbae4-38ca-4f9b-9603-aebcd65ecf84",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(803));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "52cd0e99-22b0-4e17-ba9f-ad448b3b8766",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(941));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "530edb0d-938c-4ae4-869a-567bf6bb529c",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1010));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "55136ca5-1c33-4e44-9e4d-34a06c6086f8",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(849));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "5656e6aa-f9cb-4add-99cb-a9f2696480a0",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(992));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "591bac37-162a-4314-b0ae-46e9db02f691",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "5c19e99c-2b96-49cc-a968-7e5d270b1201",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(923));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "5df74c33-8b66-4999-a511-6aecc01faa33",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(997));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "60366d57-cfe4-473a-a473-6e58fce5c928",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1225));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "62433dfd-835e-4651-99f5-78ea6eefec3f",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1229));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "62664ce7-b8a0-4531-bfb9-932595f7d7a4",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(902));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "6399abe6-056a-425c-a41e-371e7f135bce",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(916));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "63eaca83-cacf-4d84-9b29-2fa454a9c206",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1163));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "63efd264-3e31-480b-b86c-27c500705826",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(989));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "6557a6d3-5317-44c2-98fd-333064c87b13",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1037));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "65749701-c848-42a3-8549-b90938b0a98f",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "65ade45e-c4b5-4b7d-9d71-2cfae455fe31",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1084));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "65bb2650-2d2a-46b4-841b-39bc67d3b132",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1152));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "66c6219a-a5eb-49d5-9a73-d36bb76d821a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1188));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "6ad37caa-6ee5-4f73-ab41-ea2be3d77828",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(842));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "6c9aa2b5-8cef-4621-b526-d94b08c17e46",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(772));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "6cf0328c-d542-43be-baed-72af19417433",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(982));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "6d2eac00-615c-4802-8706-ed8f3b339e26",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(898));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "6d5403fe-eb3b-4e6a-b66f-5584d61c75d5",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1005));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "6eea4362-7ae5-4631-b3ca-571d523b3176",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "6f9c9a1a-7ea6-40a2-9a50-feaa658493c7",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(891));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "7002138f-f7fb-4a43-a880-060188703c09",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1016));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "7027f120-3478-4896-81cf-21bcff739315",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(846));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "70bc49ab-7e64-461a-a350-d18323fe6743",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "74bd441c-c526-4aa8-9948-467be87158e6",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1018));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "76ac4c24-9bc2-4897-a9a2-60529d306a14",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1160));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "77c79cbb-b53e-40aa-aa80-043d4f221bec",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "77e2ee32-b9fc-4600-b28b-1ec5b0190e7d",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1039));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "796cfb96-7b0d-4558-a4a9-08a9fed29071",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1106));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "7b3bdb7e-f9d4-4bfc-ab00-ad75b1e32185",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1012));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "7be30abf-7504-480b-b0af-580ccc0be9ec",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "7e36389e-2514-4c1a-9b02-956cccb72b7a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "7fc35ef8-08f5-4504-b578-012b873574d9",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(805));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "8126f485-7a77-49c9-a3cb-de1be3b682bd",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1109));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "81806b92-46ce-4177-bcad-3c572857aec5",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "82305cb1-de65-4b90-8734-87c5a768e7b3",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(927));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "82fe357c-af4b-436b-b648-983a6092aa65",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(808));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "84990688-e3f9-45af-8f22-03c77262c614",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "84bb56bb-c36d-4117-a4cf-e768990761eb",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(801));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "85bb728e-2c64-4d40-9189-735313307bf8",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1111));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "86775899-0796-4ede-b76f-b2fb4b30aced",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(965));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "88cfed2e-4469-4d95-8f08-252ce4f74e8f",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "8a195233-1a00-4dbf-a41d-3c4c0d18b574",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1035));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "8ac143dd-a639-4bad-9243-5706bf358ae1",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "8aee87a6-643f-4197-abe7-ee9956cfe636",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1104));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "8bac1ef3-473c-41a7-95a3-209fbea0c9b7",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(937));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "8c066537-f8d7-4031-9172-872081e1d0a3",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "8ef9734c-7ed8-4ce0-9899-d96b3da864eb",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "8efb933d-b689-4110-8cff-4a4e20f46104",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1090));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "8f762c3f-368d-412b-bd04-3090847b30ea",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(999));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "90bb3117-ea6e-4868-9fc3-7504f685c03e",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(812));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "933336aa-5883-46b4-b6af-3f5c89b5b973",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1102));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "9538e426-3d8a-4575-aaeb-671bfadfcf4c",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1196));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "95dc66d1-1de1-46de-a588-a5080f197aae",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(955));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "98a5dd90-ba52-4534-998f-5da2e95e38b4",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "995a74e1-98b5-4489-977d-f84113df2bc1",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(787));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "9a15a184-1821-4b06-9b6d-8624e62f42fb",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(767));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "9ba0b0c7-d09a-42e5-920d-fac472cfdad9",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1100));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "9c8dde52-8d6c-4b7c-9651-fef58287be61",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(836));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "9cdba6b6-d54a-467c-ae55-baa752ec67c7",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(957));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "9d6c9083-6b73-45c9-a61b-28800cfc5d0a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(825));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "9f8fff37-92e9-465b-ae5d-8940ae1e1cd3",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1075));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a055a422-56d0-4852-ac24-5a5925002c35",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1043));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a1746970-5277-4100-87fb-27843e3e7572",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1003));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a2a399bc-e461-40b5-85e0-dddc7b5ddea4",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a37d971a-c292-4b59-8883-04362047cb2f",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(945));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a39c1fd6-2a60-4b29-8ba9-3e263406caf2",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(978));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a4d3cc0d-8e39-460c-a02d-18fc2dced014",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a5b8701d-c62c-476e-b22f-e666def4152a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a64360a1-d91a-4405-9996-56ef3a89e32c",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(987));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a77e5bf6-0d96-4922-999e-09b4909ebae5",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1128));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a8e6b961-8f12-4679-a05c-0d72fdb4f755",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1143));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a8f90356-989c-47a5-a6f6-ab338f283018",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(819));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a93bf77b-505b-46f8-8442-795bd47d83b2",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(939));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "a93e6d6a-fe84-4977-88f9-9eb5dac3c7e4",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1045));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "aae444bc-4a86-4e9f-bfbd-71ad73da07a2",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "ad74e8ce-c6cf-4f0d-a7c3-0b86a5690808",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(904));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "ad774f0a-e895-47c4-8b7e-9593c5d37f8e",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1071));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "add2357f-a4bd-480d-9652-df476b521e4c",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1175));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b0848172-c1be-469b-b874-5143c420a137",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(914));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b0a7966c-e4ab-426c-8628-c86106fbf3fe",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b0c6bb87-7bb1-43d4-b6fa-43eb67694604",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1169));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b1aac6b6-1e84-45a6-ac41-52e14a8ea1fa",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b21274b8-1f85-4034-aa24-f47ae1f46d00",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(780));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b3ae5bf6-5836-4e90-9c69-637afde26bd7",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1088));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b4f45ffb-8b76-4304-bd06-706a228b5b10",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b71dd199-bb0d-44d2-98a1-71466e29b4ae",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1113));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b83339e8-ec1b-44a4-8045-cb6e22905cd7",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b94e325c-2fa5-4c2e-ae97-66c53f7f23b1",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1007));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "b9d66a36-38d6-4d57-bad3-b0e949a5a574",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "bb40a622-9e9e-4c19-ae9f-545dc86bef0d",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1171));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "bb789c84-5913-4a64-984b-20ad85a99de1",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(980));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "bc0083b3-7fce-4fb2-92df-9d6be798366a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(925));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "bca46483-d119-4a9a-a72b-676d761ebb6a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(876));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "bd91bd5a-4f03-48d5-ab41-ff3900b3b566",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(967));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "c3165ffb-7ad1-4730-8b00-a335edac1cc5",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(834));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "c31961f5-e6ab-4f1f-a398-04ff4c7c2368",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "c346edb2-02df-4453-9ba6-a8c718d671bd",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(974));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "c4a81f89-6f44-4c1c-bfd6-adf1f0a312e3",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(760));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "c5ebff6a-ea3a-426c-a06c-38cfdf3fcc31",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1024));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "c7296d61-4b18-46e9-8e26-7a809e636cb8",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1086));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "c7b90037-1c6d-4ad4-8397-5f04014ba97f",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(887));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "c8cb23d4-2d87-41ec-a592-9535d366f9db",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(953));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "c90a0767-fb77-4136-ab65-7719945e803a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1126));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "cb924254-4f5b-4e25-aafc-b3c6e51a26a7",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1130));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "cdea20ca-087d-4fb5-8553-105c1e2d9a84",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1173));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "ce775a23-82b1-4cdf-9736-a378cdb88c8c",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(985));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "cf17f4d4-cfc1-4c06-9f6a-6eac5062ede9",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(844));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "d295440a-24c8-4a8f-879a-41f9c883fa4b",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1150));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "d571e083-40cd-41db-8448-f55d4cc16780",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(963));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "d6d038ac-c428-4761-8d24-dc0703e8e4c2",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1156));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "d75240b2-f901-46af-80be-fcb9a7bd174b",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(895));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "d8fa7bc2-e8b5-44c4-b4ee-79f0db884832",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1001));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "dbcc02e0-7b1e-406e-b3e0-a0f333b0062e",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(934));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "dc85f186-d18b-4a8b-a504-698fda19a9b6",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "dca0c0d8-69a7-451c-bbe3-db4e4237daaf",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(943));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "dd2d472b-252b-4963-a802-6e615657df04",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(878));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "dd56fb2d-90d1-404d-bf33-3a2163a6fc20",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(851));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "def25cbf-86db-4ae4-ae45-7a63a8d71c6c",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(882));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "df953e9b-49b2-4c98-bf43-c0b89ffd2671",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1198));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "dfce1885-ecbe-432e-9148-8a2d34809082",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1221));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "e06b976c-4745-4368-a615-3d011811589e",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1031));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "e28f8d28-5cb6-4f56-918e-c822a0060452",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(918));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "e3a46fc4-de62-41cc-8a11-305cbbf77ebb",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(827));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "e5bc3319-2a58-4df3-89bd-17edc123cc0a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1049));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "e5eab8bf-d214-4bb2-a42a-e73d6c8890d8",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "e7af707d-2029-4d1d-a10b-9a5c55d98ca2",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1132));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "eb4ed592-7499-4ea3-9c4d-aea95c4a86b1",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(948));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "ed6b2c4a-bcf3-4d0b-8e98-83ddd98653b6",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "ee9c7eb3-842a-4671-a046-96facfb2bcb6",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1064));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "f467869a-bbb7-4647-bb04-82e7bfd07eb5",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(972));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "f586c0df-265a-46d3-9f7d-1219f269c2d6",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1014));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "f66ac072-f4db-4bae-9ad3-25afe5d653b8",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1184));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "f7f2a895-0a64-4e47-bbab-9bd914eaa86e",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "fa7b0ef7-a5b5-48a8-80dd-bdbb51b3827a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1028));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "fb894ec4-3008-46d0-bcbd-10c66df049af",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1192));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "fd74c75f-db36-4101-bcd4-9b5d672f2c5a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "fec5fe83-b884-4d56-a5fe-6d7ab2156574",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1134));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "fef25062-8fc1-4006-8514-e234bfa63a05",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(885));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: "fefb0f12-c610-44ba-a425-b58344af0a3c",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "11895374-db00-46fd-bc8c-aedc69810376",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5860));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "13087490-c400-42eb-a3ea-0f0daac2617d",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5863));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "14b05783-0b18-4652-97e7-fa2c1c437fef",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5843));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "3e1ba887-d615-4958-9bdc-ce7b39bcf6a7",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5849));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "41e9f11b-7959-40c2-99b3-f3fdf96a6c73",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5814));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "42a06f1e-8f39-4b14-9558-135fb275e68b",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5833));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "433e441e-a77d-4dfd-a44e-7aea8e5725e3",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5873));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "57fbf086-6818-4b5c-9fcf-c9848b000077",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5876));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "5ab48144-1d40-44de-89c0-8813fa07520d",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5808));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "6f618dbe-15aa-4b0e-9019-5f68b3b1d914",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "74297990-eb30-48c9-bb4c-c0893e7b90fd",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5825));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "791397f9-efd2-42e5-bc31-e9128f511e5a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "884e424a-b544-4bfc-bfc2-61bf3bf5109e",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5822));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "8eed93e8-914c-440b-8eff-8a458f728318",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5811));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "90feb00a-2728-4020-8f81-eb4cfe85e240",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "9d7dc8da-f0eb-4b75-8a05-81c9ea040117",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5871));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "9ee127bc-5fe2-4514-95f8-f4b8dc807956",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5828));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "a10c5462-b220-4453-b9e4-dc8e8df48f01",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5820));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "a7ce0400-31e8-4c80-9ee5-7ed9d45437f6",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "af91cf42-e548-4642-8d30-cd485d4ea24b",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5858));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "bd812379-dc7b-4439-b116-24467fd0b31c",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5800));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "ca8743fd-6fed-4289-94d9-de8db265282a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "e1106fb8-3cb6-4c2a-99ca-ecabc7cf3d3c",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5817));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "eb7b9771-c370-4db8-adc1-b81ad53d7fa0",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5841));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "f2ac551e-c290-4639-ab53-6fdc47cf686d",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5865));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "f377f371-8c13-4d50-b314-045ad65188d8",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "f4cf1430-114a-4b41-9ef0-105740a49a4a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "SubModuleAccounts",
                keyColumn: "Id",
                keyValue: "f83429b9-1691-4637-acf4-aa4801c8a746",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(5852));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "0081ef4d-6b18-4e83-a443-b3b85abc6c47",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2721));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "023b4db0-a094-4fd8-b215-0f1941a5223f",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2798));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "08968b7c-3fc1-4bcc-9ff2-41336219ec69",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2766));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "0f44982b-bc5c-4ff8-a4cd-fc518baa3457",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "1774917c-fb76-492f-9adc-846886d9ed0e",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2752));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "25a434b6-674f-47de-95ba-904c6b867318",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "27d6db63-5a85-438d-98f7-63c744059223",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2805));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "34c3d045-9e99-470c-822b-aa8caa9cdfe2",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2735));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "371d3ef5-916f-4c5a-9bdb-4208febf7813",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2717));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "44f91259-af42-431f-be8e-bea98a9bf6eb",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2783));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "4a6f84a3-779c-4d2e-841a-88546fcdc0f1",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2728));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "56672d96-1e2e-409e-b01f-f47d978fd286",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2769));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "7d3afe88-1c0a-48f8-a9ca-90b9e76783ea",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "83824e9f-6d83-462b-b2a4-592502af5d60",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2791));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "9a3f1169-10b8-4d41-89ad-a6c24e917b52",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2756));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "a0379995-cae9-47c6-95d0-4109dd6437e8",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2739));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "a89f3ce0-000f-4525-8be6-48d417718f4c",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "ad3aa3aa-0f57-4f6e-9d20-72a247a9abe7",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2762));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "b269ec21-d373-4698-8acc-f6c47d501987",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2745));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "b6960d25-b1d3-4a16-88b9-56ad9d8bd212",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2714));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "c6139ff7-4b03-450c-8abc-457620c4714a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "cb364518-b564-4336-98d4-349c67f35531",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "d4e2445b-c66a-4b70-9f4d-6c1cbbfdca40",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2731));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "d8ca7cbe-0ace-4d44-b74f-e0bac19c7770",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2759));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "db88181b-478e-4523-8f75-3ca66afba611",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2749));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "dbb0673c-3589-4e98-a42a-103cb44697d9",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2724));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "ee090c50-f4a4-4877-8df7-0a05abeaf1c8",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2705));

            migrationBuilder.UpdateData(
                table: "SubModules",
                keyColumn: "Id",
                keyValue: "fc374362-3c46-4600-b533-7854526353ec",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 927, DateTimeKind.Local).AddTicks(2773));

            migrationBuilder.UpdateData(
                table: "Turns",
                keyColumn: "Id",
                keyValue: "7a57db1f-3f77-4a25-8107-b73e668ab65a",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(4336));

            migrationBuilder.UpdateData(
                table: "Turns",
                keyColumn: "Id",
                keyValue: "c0ba7b4c-d292-48c7-9f78-8a2e83973053",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 925, DateTimeKind.Local).AddTicks(4322));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "362c2637-2ad9-449a-9498-dbd74be87ee8",
                column: "CreatedDate",
                value: new DateTime(2023, 6, 23, 0, 14, 18, 922, DateTimeKind.Local).AddTicks(8592));
        }
    }
}
