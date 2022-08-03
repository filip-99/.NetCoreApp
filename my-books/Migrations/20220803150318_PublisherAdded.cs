using Microsoft.EntityFrameworkCore.Migrations;

namespace my_books.Migrations
{
    // Kreirana je klasa koja ima isti naziv kao i migracija, koju smo izvršili u NuGet Package Manager Consoli
    // Ova klasa je nasledila model klasu za mikraciju
    public partial class PublisherAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Na početku imamo dodavanje nove kolone u tabeli Books
            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // U ovom delu imamo kreiranje nove tabele Publisher
            migrationBuilder.CreateTable(
                name: "Publisher",
                // Imaćemo 2 kolone Id i Name
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            // Ovde se vrši referenciranje ID-a u tabeli Publishers i IdPublisher u tabeli Books (FOREIGN KEY)
            migrationBuilder.AddForeignKey(
                // Naziv primarnog ključa
                name: "FK_Books_Publisher_PublisherId",
                // Vidimo da je za tabelu Books preneseni ključ (FOREIGN KEY) PublisherId
                table: "Books",
                column: "PublisherId",
                // Ovde je navedeno da je za tabelu Publisher kolona Id primarni ključ (PRIMARY KEY)
                principalTable: "Publisher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publisher_PublisherId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_Books_PublisherId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Books");
        }
    }
}
