using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASM.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "danhMucs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_danhMucs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nguoiDungs",
                columns: table => new
                {
                    NguoiDungId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MatKhau = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nguoiDungs", x => x.NguoiDungId);
                });

            migrationBuilder.CreateTable(
                name: "monAns",
                columns: table => new
                {
                    MaMon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMon = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Gia = table.Column<float>(type: "real", nullable: false),
                    Hinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monAns", x => x.MaMon);
                    table.ForeignKey(
                        name: "FK_monAns_danhMucs_Id",
                        column: x => x.Id,
                        principalTable: "danhMucs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "donHangs",
                columns: table => new
                {
                    DonhangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tongtien = table.Column<double>(type: "float", nullable: false),
                    TrangthaiDonhang = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donHangs", x => x.DonhangId);
                    table.ForeignKey(
                        name: "FK_donHangs_nguoiDungs_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "nguoiDungs",
                        principalColumn: "NguoiDungId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "donhangChitiets",
                columns: table => new
                {
                    ChitietId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonhangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaMon = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Thanhtien = table.Column<double>(type: "float", nullable: false),
                    GhiChu = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donhangChitiets", x => x.ChitietId);
                    table.ForeignKey(
                        name: "FK_donhangChitiets_donHangs_DonhangId",
                        column: x => x.DonhangId,
                        principalTable: "donHangs",
                        principalColumn: "DonhangId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_donhangChitiets_monAns_MaMon",
                        column: x => x.MaMon,
                        principalTable: "monAns",
                        principalColumn: "MaMon",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_donhangChitiets_DonhangId",
                table: "donhangChitiets",
                column: "DonhangId");

            migrationBuilder.CreateIndex(
                name: "IX_donhangChitiets_MaMon",
                table: "donhangChitiets",
                column: "MaMon");

            migrationBuilder.CreateIndex(
                name: "IX_donHangs_NguoiDungId",
                table: "donHangs",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_monAns_Id",
                table: "monAns",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "donhangChitiets");

            migrationBuilder.DropTable(
                name: "donHangs");

            migrationBuilder.DropTable(
                name: "monAns");

            migrationBuilder.DropTable(
                name: "nguoiDungs");

            migrationBuilder.DropTable(
                name: "danhMucs");
        }
    }
}
