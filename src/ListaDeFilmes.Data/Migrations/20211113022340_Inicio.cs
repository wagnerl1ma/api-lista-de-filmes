using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListaDeFilmes.Data.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Atores",
                columns: table => new
                {
                    Id_Ator = table.Column<Guid>(nullable: false),
                    Nome_Ator = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Atores", x => x.Id_Ator);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Diretores",
                columns: table => new
                {
                    Id_Diretor = table.Column<Guid>(nullable: false),
                    Nome_Diretor = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Diretores", x => x.Id_Diretor);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Generos",
                columns: table => new
                {
                    Id_Genero = table.Column<Guid>(nullable: false),
                    Nome_Genero = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Generos", x => x.Id_Genero);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Produtoras",
                columns: table => new
                {
                    Id_Produtora = table.Column<Guid>(nullable: false),
                    Nome_Produtora = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Produtoras", x => x.Id_Produtora);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Filmes",
                columns: table => new
                {
                    Id_Filme = table.Column<Guid>(nullable: false),
                    Nome_Filmes = table.Column<string>(type: "varchar(100)", nullable: false),
                    Data_Cadastro = table.Column<DateTime>(nullable: true),
                    Classificacao_Filme = table.Column<string>(type: "varchar(5)", nullable: false),
                    Ano_Filme = table.Column<int>(type: "int", nullable: true),
                    Comentarios_Filme = table.Column<string>(type: "varchar(300)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Id_Genero = table.Column<Guid>(nullable: false),
                    Id_Diretor = table.Column<Guid>(nullable: true),
                    Id_Produtora = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Filmes", x => x.Id_Filme);
                    table.ForeignKey(
                        name: "FK_Tb_Filmes_Tb_Diretores_Id_Diretor",
                        column: x => x.Id_Diretor,
                        principalTable: "Tb_Diretores",
                        principalColumn: "Id_Diretor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_Filmes_Tb_Generos_Id_Genero",
                        column: x => x.Id_Genero,
                        principalTable: "Tb_Generos",
                        principalColumn: "Id_Genero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_Filmes_Tb_Produtoras_Id_Produtora",
                        column: x => x.Id_Produtora,
                        principalTable: "Tb_Produtoras",
                        principalColumn: "Id_Produtora",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tb_FilmesAtores",
                columns: table => new
                {
                    Id_Filme = table.Column<Guid>(nullable: false),
                    Id_Ator = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_FilmesAtores", x => new { x.Id_Filme, x.Id_Ator });
                    table.ForeignKey(
                        name: "FK_Tb_FilmesAtores_Tb_Atores_Id_Ator",
                        column: x => x.Id_Ator,
                        principalTable: "Tb_Atores",
                        principalColumn: "Id_Ator",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_FilmesAtores_Tb_Filmes_Id_Filme",
                        column: x => x.Id_Filme,
                        principalTable: "Tb_Filmes",
                        principalColumn: "Id_Filme",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Filmes_Id_Diretor",
                table: "Tb_Filmes",
                column: "Id_Diretor");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Filmes_Id_Genero",
                table: "Tb_Filmes",
                column: "Id_Genero");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Filmes_Id_Produtora",
                table: "Tb_Filmes",
                column: "Id_Produtora");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_FilmesAtores_Id_Ator",
                table: "Tb_FilmesAtores",
                column: "Id_Ator");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_FilmesAtores");

            migrationBuilder.DropTable(
                name: "Tb_Atores");

            migrationBuilder.DropTable(
                name: "Tb_Filmes");

            migrationBuilder.DropTable(
                name: "Tb_Diretores");

            migrationBuilder.DropTable(
                name: "Tb_Generos");

            migrationBuilder.DropTable(
                name: "Tb_Produtoras");
        }
    }
}
