using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SpaceWalk.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainForums",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    nameimage = table.Column<string>(name: "name_image", type: "text", nullable: false),
                    urlimage = table.Column<string>(name: "url_image", type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    createdBy = table.Column<string>(type: "text", nullable: false),
                    createdTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastModifiedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainForums", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstName = table.Column<string>(type: "text", nullable: false),
                    lastName = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    passwordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    passwordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    urlImage = table.Column<string>(type: "text", nullable: false),
                    bio = table.Column<string>(type: "text", nullable: false),
                    github = table.Column<string>(type: "text", nullable: false),
                    whatsapp = table.Column<string>(type: "text", nullable: false),
                    linkedin = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    hobies = table.Column<string>(type: "text", nullable: false),
                    birth = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SubForums",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    judul = table.Column<string>(type: "text", nullable: false),
                    nameimage = table.Column<string>(name: "name_image", type: "text", nullable: false),
                    urlimage = table.Column<string>(name: "url_image", type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    mainid = table.Column<int>(name: "main_id", type: "integer", nullable: false),
                    createdBy = table.Column<string>(type: "text", nullable: false),
                    createdTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastModifiedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubForums", x => x.id);
                    table.ForeignKey(
                        name: "FK_SubForums_MainForums_main_id",
                        column: x => x.mainid,
                        principalTable: "MainForums",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Threads",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    nameimage = table.Column<string>(name: "name_image", type: "text", nullable: false),
                    urlimage = table.Column<string>(name: "url_image", type: "text", nullable: false),
                    view = table.Column<int>(type: "integer", nullable: false),
                    liked = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    subid = table.Column<int>(name: "sub_id", type: "integer", nullable: false),
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false),
                    createdBy = table.Column<string>(type: "text", nullable: false),
                    createdTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastModifiedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threads", x => x.id);
                    table.ForeignKey(
                        name: "FK_Threads_SubForums_sub_id",
                        column: x => x.subid,
                        principalTable: "SubForums",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Threads_Users_user_id",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    content = table.Column<string>(type: "text", nullable: false),
                    threadid = table.Column<int>(name: "thread_id", type: "integer", nullable: false),
                    Threadsid = table.Column<int>(type: "integer", nullable: false),
                    createdBy = table.Column<string>(type: "text", nullable: false),
                    createdTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastModifiedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_Threads_Threadsid",
                        column: x => x.Threadsid,
                        principalTable: "Threads",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLikes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    threadid = table.Column<int>(name: "thread_id", type: "integer", nullable: false),
                    Threadsid = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false),
                    createdBy = table.Column<string>(type: "text", nullable: false),
                    createdTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lastModifiedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikes", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserLikes_Threads_Threadsid",
                        column: x => x.Threadsid,
                        principalTable: "Threads",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLikes_Users_user_id",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Threadsid",
                table: "Comments",
                column: "Threadsid");

            migrationBuilder.CreateIndex(
                name: "IX_SubForums_main_id",
                table: "SubForums",
                column: "main_id");

            migrationBuilder.CreateIndex(
                name: "IX_Threads_sub_id",
                table: "Threads",
                column: "sub_id");

            migrationBuilder.CreateIndex(
                name: "IX_Threads_user_id",
                table: "Threads",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikes_Threadsid",
                table: "UserLikes",
                column: "Threadsid");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikes_user_id",
                table: "UserLikes",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "UserLikes");

            migrationBuilder.DropTable(
                name: "Threads");

            migrationBuilder.DropTable(
                name: "SubForums");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MainForums");
        }
    }
}
