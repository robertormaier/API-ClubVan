using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace club.van.api.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPRESA",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NOME = table.Column<string>(maxLength: 200, nullable: true),
                    RAZAO_SOCIAL = table.Column<string>(maxLength: 200, nullable: true),
                    CNPJ = table.Column<string>(maxLength: 200, nullable: true),
                    ATIVO = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPRESA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PERFIL",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NOME = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFIL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VEICULO",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PLACA = table.Column<string>(maxLength: 50, nullable: true),
                    MODELO = table.Column<string>(maxLength: 50, nullable: true),
                    DESCRICAO = table.Column<string>(maxLength: 50, nullable: true),
                    EMPRESA_ID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEICULO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VEICULO_EMPRESA_EMPRESA_ID",
                        column: x => x.EMPRESA_ID,
                        principalTable: "EMPRESA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ROTA",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NOME = table.Column<string>(maxLength: 50, nullable: true),
                    VEICULO_ID = table.Column<Guid>(nullable: true),
                    EMPRESA_ID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROTA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ROTA_EMPRESA_EMPRESA_ID",
                        column: x => x.EMPRESA_ID,
                        principalTable: "EMPRESA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ROTA_VEICULO_VEICULO_ID",
                        column: x => x.VEICULO_ID,
                        principalTable: "VEICULO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NOME = table.Column<string>(maxLength: 200, nullable: true),
                    CPF = table.Column<string>(maxLength: 200, nullable: true),
                    EMAIL = table.Column<string>(maxLength: 200, nullable: true),
                    PERFIL_ID = table.Column<Guid>(nullable: true),
                    ATIVO = table.Column<bool>(nullable: false),
                    SENHA = table.Column<string>(maxLength: 200, nullable: true),
                    EMPRESA_ID = table.Column<Guid>(nullable: true),
                    BAIRRO = table.Column<string>(nullable: true),
                    RUA = table.Column<string>(nullable: true),
                    CIDADE = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    ROTA_ID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USUARIO_EMPRESA_EMPRESA_ID",
                        column: x => x.EMPRESA_ID,
                        principalTable: "EMPRESA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USUARIO_PERFIL_PERFIL_ID",
                        column: x => x.PERFIL_ID,
                        principalTable: "PERFIL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USUARIO_ROTA_ROTA_ID",
                        column: x => x.ROTA_ID,
                        principalTable: "ROTA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VIAGEM_DIA",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NUMERO_SEMANA = table.Column<int>(nullable: false),
                    SEGUNDA_FEIRA = table.Column<bool>(nullable: false),
                    TERCA_FEIRA = table.Column<bool>(nullable: false),
                    QUARTA_FEIRA = table.Column<bool>(nullable: false),
                    QUINTA_FEIRA = table.Column<bool>(nullable: false),
                    SEXTA_FEIRA = table.Column<bool>(nullable: false),
                    SABADO = table.Column<bool>(nullable: false),
                    DOMINGO = table.Column<bool>(nullable: false),
                    ROTA_ID = table.Column<Guid>(nullable: true),
                    USUARIO_ID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIAGEM_DIA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VIAGEM_DIA_ROTA_ROTA_ID",
                        column: x => x.ROTA_ID,
                        principalTable: "ROTA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VIAGEM_DIA_USUARIO_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ROTA_EMPRESA_ID",
                table: "ROTA",
                column: "EMPRESA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ROTA_VEICULO_ID",
                table: "ROTA",
                column: "VEICULO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_EMPRESA_ID",
                table: "USUARIO",
                column: "EMPRESA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_PERFIL_ID",
                table: "USUARIO",
                column: "PERFIL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_ROTA_ID",
                table: "USUARIO",
                column: "ROTA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VEICULO_EMPRESA_ID",
                table: "VEICULO",
                column: "EMPRESA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VIAGEM_DIA_ROTA_ID",
                table: "VIAGEM_DIA",
                column: "ROTA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VIAGEM_DIA_USUARIO_ID",
                table: "VIAGEM_DIA",
                column: "USUARIO_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VIAGEM_DIA");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "PERFIL");

            migrationBuilder.DropTable(
                name: "ROTA");

            migrationBuilder.DropTable(
                name: "VEICULO");

            migrationBuilder.DropTable(
                name: "EMPRESA");
        }
    }
}
