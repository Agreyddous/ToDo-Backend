using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Domain.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddingIsHiddenFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "ToDoItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "ToDoItems");
        }
    }
}
