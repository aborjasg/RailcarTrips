using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailcarTrips.Migrations
{
    /// <inheritdoc />
    public partial class SeedEventCodes_and_Cities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO [dbo].[EventCodes] ([Id], [EventDescription], [LongDescription]) VALUES (N'A', N'Arrived', N'Railcar equipment arrives at a city on route')
                INSERT INTO [dbo].[EventCodes] ([Id], [EventDescription], [LongDescription]) VALUES (N'D', N'Departed', N'Railcar equipment departs from a city on route')
                INSERT INTO [dbo].[EventCodes] ([Id], [EventDescription], [LongDescription]) VALUES (N'W', N'Released', N'Railcar equipment is released from origin')
                INSERT INTO [dbo].[EventCodes] ([Id], [EventDescription], [LongDescription]) VALUES (N'Z', N'Placed', N'Railcar equipment is placed at destination')
            ");

            migrationBuilder.Sql(@"
                SET IDENTITY_INSERT [dbo].[Cities] ON
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (1, N'Vancouver', N'Pacific Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (2, N'Victoria', N'Pacific Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (3, N'Kelowna', N'Pacific Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (4, N'Kamloops', N'Pacific Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (5, N'Prince George', N'Pacific Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (6, N'Calgary', N'Mountain Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (7, N'Edmonton', N'Mountain Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (8, N'Lethbridge', N'Mountain Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (9, N'Red Deer', N'Mountain Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (10, N'Fort McMurray', N'Mountain Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (11, N'Regina', N'Canada Central Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (12, N'Saskatoon', N'Canada Central Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (13, N'Moose Jaw', N'Canada Central Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (14, N'Brandon', N'Central Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (15, N'Winnipeg', N'Central Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (16, N'Thunder Bay', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (17, N'Sault Ste. Marie', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (18, N'Sudbury', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (19, N'North Bay', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (20, N'Barrie', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (21, N'Toronto', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (22, N'Mississauga', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (23, N'Hamilton', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (24, N'London', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (25, N'Kitchener', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (26, N'Windsor', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (27, N'St. Catharines', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (28, N'Oshawa', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (29, N'Kingston', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (30, N'Ottawa', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (31, N'Gatineau', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (32, N'Montreal', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (33, N'Quebec City', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (34, N'Sherbrooke', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (35, N'Trois-RiviÃ¨res', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (36, N'Saguenay', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (37, N'Rimouski', N'Eastern Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (38, N'Edmundston', N'Atlantic Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (39, N'Fredericton', N'Atlantic Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (40, N'Moncton', N'Atlantic Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (41, N'Saint John', N'Atlantic Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (42, N'Bathurst', N'Atlantic Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (43, N'Charlottetown', N'Atlantic Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (44, N'Summerside', N'Atlantic Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (45, N'Sydney', N'Atlantic Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (46, N'Truro', N'Atlantic Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (47, N'New Glasgow', N'Atlantic Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (48, N'Dartmouth', N'Atlantic Standard Time')
                INSERT INTO [dbo].[Cities] ([Id], [Name], [TimeZone]) VALUES (49, N'Halifax', N'Atlantic Standard Time')
                SET IDENTITY_INSERT [dbo].[Cities] OFF
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop table EventCodes;");
            migrationBuilder.Sql(@"drop table Cities;");
        }
    }
}
