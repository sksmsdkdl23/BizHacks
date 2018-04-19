using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BizHacks.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Displays",
                columns: table => new
                {
                    DisplayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BounceRate = table.Column<string>(nullable: true),
                    CTR = table.Column<string>(nullable: true),
                    CampaignName = table.Column<string>(nullable: true),
                    Clicks = table.Column<string>(nullable: true),
                    Cost = table.Column<string>(nullable: true),
                    FiscalMonth = table.Column<string>(nullable: true),
                    FiscalYear = table.Column<string>(nullable: true),
                    Impressions = table.Column<string>(nullable: true),
                    TotalOnlineOrders = table.Column<string>(nullable: true),
                    TotalOnlineRevenue = table.Column<string>(nullable: true),
                    Visit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Displays", x => x.DisplayId);
                });

            migrationBuilder.CreateTable(
                name: "Searches",
                columns: table => new
                {
                    SearchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BounceRate = table.Column<string>(nullable: true),
                    CTR = table.Column<string>(nullable: true),
                    CampaignName = table.Column<string>(nullable: true),
                    Clicks = table.Column<string>(nullable: true),
                    Cost = table.Column<string>(nullable: true),
                    FiscalMonth = table.Column<string>(nullable: true),
                    FiscalYear = table.Column<string>(nullable: true),
                    Impressions = table.Column<string>(nullable: true),
                    TotalOnlineOrders = table.Column<string>(nullable: true),
                    TotalOnlineRevenue = table.Column<string>(nullable: true),
                    Visit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Searches", x => x.SearchId);
                });

            migrationBuilder.CreateTable(
                name: "Socials",
                columns: table => new
                {
                    SocialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BounceRate = table.Column<string>(nullable: true),
                    CTR = table.Column<string>(nullable: true),
                    CampaignName = table.Column<string>(nullable: true),
                    Clicks = table.Column<string>(nullable: true),
                    Cost = table.Column<string>(nullable: true),
                    FiscalMonth = table.Column<string>(nullable: true),
                    FiscalYear = table.Column<string>(nullable: true),
                    Impressions = table.Column<string>(nullable: true),
                    TotalOnlineOrders = table.Column<string>(nullable: true),
                    TotalOnlineRevenue = table.Column<string>(nullable: true),
                    Visit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socials", x => x.SocialId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Displays");

            migrationBuilder.DropTable(
                name: "Searches");

            migrationBuilder.DropTable(
                name: "Socials");
        }
    }
}
