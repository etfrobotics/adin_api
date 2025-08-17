using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace adin_api.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    component_name = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Safety_Tool",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    safety_tool_name = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Safety_Tool", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StepImage",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    image = table.Column<string>(type: "VARCHAR(8000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepImage", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    task_description = table.Column<string>(type: "VARCHAR(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tool_name = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    step_number = table.Column<int>(type: "integer", nullable: false),
                    instructions = table.Column<string>(type: "VARCHAR(1000)", nullable: true),
                    task_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.id);
                    table.ForeignKey(
                        name: "FK_Steps_Tasks_task_id",
                        column: x => x.task_id,
                        principalTable: "Tasks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Step_Component",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    step_id = table.Column<int>(type: "integer", nullable: false),
                    component_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step_Component", x => x.id);
                    table.ForeignKey(
                        name: "FK_Step_Component_Components_component_id",
                        column: x => x.component_id,
                        principalTable: "Components",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Step_Component_Steps_step_id",
                        column: x => x.step_id,
                        principalTable: "Steps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Step_Images",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    step_id = table.Column<int>(type: "integer", nullable: false),
                    stepimage_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step_Images", x => x.id);
                    table.ForeignKey(
                        name: "FK_Step_Images_StepImage_stepimage_id",
                        column: x => x.stepimage_id,
                        principalTable: "StepImage",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Step_Images_Steps_step_id",
                        column: x => x.step_id,
                        principalTable: "Steps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Step_Safety_Tools",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    step_id = table.Column<int>(type: "integer", nullable: false),
                    safety_tool_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step_Safety_Tools", x => x.id);
                    table.ForeignKey(
                        name: "FK_Step_Safety_Tools_Safety_Tool_safety_tool_id",
                        column: x => x.safety_tool_id,
                        principalTable: "Safety_Tool",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Step_Safety_Tools_Steps_step_id",
                        column: x => x.step_id,
                        principalTable: "Steps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Step_Tools",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    step_id = table.Column<int>(type: "integer", nullable: false),
                    tool_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step_Tools", x => x.id);
                    table.ForeignKey(
                        name: "FK_Step_Tools_Steps_step_id",
                        column: x => x.step_id,
                        principalTable: "Steps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Step_Tools_Tools_tool_id",
                        column: x => x.tool_id,
                        principalTable: "Tools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8d5f4c90-f0fc-46ad-9413-afe0d3701531", "574435dd-6390-4342-99f9-d8d2670d2c30", "User", "USER" },
                    { "8872b296-a5d8-4113-b3c0-6f58a3da25b2", "2a76a28f-d9d8-4292-aa46-a992005765d2", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "862fbcc9-5a69-4703-b466-ef1758171234", 0, "e2268302-4e9f-4492-95ea-73de44697263", "User", "knezevic@etf.rs", false, "Nikola", "Knežević", false, null, "KNEZEVIC@ETF.RS", "KNEZEVIC@ETF.RS", "AQAAAAEAACcQAAAAELLbUJfcY2AhemC+IeRr8wCXLCAZnfz4AOyavyLGsin2sx3Nc4eimdzlvKdciKS3PQ==", null, false, "53284f7f-3b8a-4854-9ac7-fc530723fdfa", false, "knezevic@etf.rs" });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "id", "component_name" },
                values: new object[,]
                {
                    { 2, "Component 2" },
                    { 3, "Component 3" },
                    { 4, "Component 4" },
                    { 5, "Component 5" },
                    { 1, "Component 1" }
                });

            migrationBuilder.InsertData(
                table: "Safety_Tool",
                columns: new[] { "id", "safety_tool_name" },
                values: new object[,]
                {
                    { 2, "Safety tool 2" },
                    { 1, "Safety tool 1" },
                    { 3, "Safety tool 3" }
                });

            migrationBuilder.InsertData(
                table: "StepImage",
                columns: new[] { "id", "image", "name" },
                values: new object[,]
                {
                    { 2, "https://mobileimages.lowes.com/productimages/8d4b8c73-1811-464f-9b22-d29608f151f0/00617143.jpg", "Drill" },
                    { 1, "https://m.media-amazon.com/images/I/71VcbZYF0hL._AC_SX466_.jpg", "Hammer" },
                    { 3, "https://www.vigor-equipment.com/media/image/96/11/d6/v3613ErzzIwdipftMQ.jpg", "Screwdriver" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "id", "task_description" },
                values: new object[,]
                {
                    { 2, "Task 2" },
                    { 3, "Task 3" },
                    { 4, "Task 4" },
                    { 5, "Task 5" },
                    { 6, "Task 6" },
                    { 1, "Task 1" }
                });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "id", "tool_name" },
                values: new object[,]
                {
                    { 5, "Tool 5" },
                    { 1, "Tool 1" },
                    { 2, "Tool 2" },
                    { 3, "Tool 3" },
                    { 4, "Tool 4" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8872b296-a5d8-4113-b3c0-6f58a3da25b2", "862fbcc9-5a69-4703-b466-ef1758171234" });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "id", "instructions", "step_number", "task_id","rack_id" },
                values: new object[,]
                {
                    { 1, "Step 1 of task 1", 1, 1, 1},
                    { 2, "Step 2 of task 1", 2, 1, 2},
                    { 3, "Step 3 of task 1", 3, 1, 3},
                    { 4, "Step 1 of task 2", 1, 2, 4},
                    { 5, "Step 1 of task 3", 1, 3, 5},
                    { 6, "Step 2 of task 3", 2, 3, 6}
                });

            migrationBuilder.InsertData(
                table: "Step_Component",
                columns: new[] { "id", "component_id", "step_id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 8, 5, 6 },
                    { 7, 3, 5 },
                    { 6, 2, 5 },
                    { 5, 5, 4 },
                    { 4, 4, 3 },
                    { 2, 2, 1 },
                    { 3, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Step_Images",
                columns: new[] { "id", "stepimage_id", "step_id" },
                values: new object[,]
                {
                    { 3, 3, 2 },
                    { 2, 2, 1 },
                    { 1, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Step_Safety_Tools",
                columns: new[] { "id", "safety_tool_id", "step_id" },
                values: new object[,]
                {
                    { 1, 3, 2 },
                    { 3, 1, 6 },
                    { 2, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Step_Tools",
                columns: new[] { "id", "step_id", "tool_id" },
                values: new object[,]
                {
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 1, 1, 1 },
                    { 4, 4, 2 },
                    { 5, 5, 3 },
                    { 6, 6, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Step_Component_component_id",
                table: "Step_Component",
                column: "component_id");

            migrationBuilder.CreateIndex(
                name: "IX_Step_Component_step_id",
                table: "Step_Component",
                column: "step_id");

            migrationBuilder.CreateIndex(
                name: "IX_Step_Images_step_id",
                table: "Step_Images",
                column: "step_id");

            migrationBuilder.CreateIndex(
                name: "IX_Step_Images_stepimage_id",
                table: "Step_Images",
                column: "stepimage_id");

            migrationBuilder.CreateIndex(
                name: "IX_Step_Safety_Tools_safety_tool_id",
                table: "Step_Safety_Tools",
                column: "safety_tool_id");

            migrationBuilder.CreateIndex(
                name: "IX_Step_Safety_Tools_step_id",
                table: "Step_Safety_Tools",
                column: "step_id");

            migrationBuilder.CreateIndex(
                name: "IX_Step_Tools_step_id",
                table: "Step_Tools",
                column: "step_id");

            migrationBuilder.CreateIndex(
                name: "IX_Step_Tools_tool_id",
                table: "Step_Tools",
                column: "tool_id");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_task_id",
                table: "Steps",
                column: "task_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Step_Component");

            migrationBuilder.DropTable(
                name: "Step_Images");

            migrationBuilder.DropTable(
                name: "Step_Safety_Tools");

            migrationBuilder.DropTable(
                name: "Step_Tools");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "StepImage");

            migrationBuilder.DropTable(
                name: "Safety_Tool");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
