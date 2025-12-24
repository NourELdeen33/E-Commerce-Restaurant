using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce.Migrations
{
    /// <inheritdoc />
    public partial class SeedingProductIngredientData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductIngerdients",
                columns: new[] { "Ingerdient_Id", "Product_Id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 10, 2 },
                    { 12, 2 },
                    { 1, 3 },
                    { 7, 3 },
                    { 1, 4 },
                    { 8, 4 },
                    { 10, 4 },
                    { 11, 4 },
                    { 1, 5 },
                    { 13, 5 },
                    { 14, 5 },
                    { 15, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductIngerdients",
                keyColumns: new[] { "Ingerdient_Id", "Product_Id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductIngerdients",
                keyColumns: new[] { "Ingerdient_Id", "Product_Id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductIngerdients",
                keyColumns: new[] { "Ingerdient_Id", "Product_Id" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ProductIngerdients",
                keyColumns: new[] { "Ingerdient_Id", "Product_Id" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ProductIngerdients",
                keyColumns: new[] { "Ingerdient_Id", "Product_Id" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "ProductIngerdients",
                keyColumns: new[] { "Ingerdient_Id", "Product_Id" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "ProductIngerdients",
                keyColumns: new[] { "Ingerdient_Id", "Product_Id" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ProductIngerdients",
                keyColumns: new[] { "Ingerdient_Id", "Product_Id" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "ProductIngerdients",
                keyColumns: new[] { "Ingerdient_Id", "Product_Id" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "ProductIngerdients",
                keyColumns: new[] { "Ingerdient_Id", "Product_Id" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "ProductIngerdients",
                keyColumns: new[] { "Ingerdient_Id", "Product_Id" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "ProductIngerdients",
                keyColumns: new[] { "Ingerdient_Id", "Product_Id" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "ProductIngerdients",
                keyColumns: new[] { "Ingerdient_Id", "Product_Id" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "ProductIngerdients",
                keyColumns: new[] { "Ingerdient_Id", "Product_Id" },
                keyValues: new object[] { 13, 5 });

            migrationBuilder.DeleteData(
                table: "ProductIngerdients",
                keyColumns: new[] { "Ingerdient_Id", "Product_Id" },
                keyValues: new object[] { 14, 5 });

            migrationBuilder.DeleteData(
                table: "ProductIngerdients",
                keyColumns: new[] { "Ingerdient_Id", "Product_Id" },
                keyValues: new object[] { 15, 5 });
        }
    }
}
