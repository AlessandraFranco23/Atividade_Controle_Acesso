using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_Controle.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    senha = table.Column<string>(nullable: false),
                    perfil = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sessao",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Sessao_id = table.Column<int>(nullable: true),
                    token = table.Column<string>(nullable: false),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    data_expiracao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessao", x => x.id);
                    table.ForeignKey(
                        name: "FK_sessao_Usuario_Sessao_id",
                        column: x => x.Sessao_id,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sessao_Sessao_id",
                table: "sessao",
                column: "Sessao_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sessao");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
