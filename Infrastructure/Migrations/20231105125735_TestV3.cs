using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class TestV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         /*   migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Volumn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRelease = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    MajorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rolename = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });
*/
            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    TopicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.TopicId);
                });
            /*
                        migrationBuilder.CreateTable(
                            name: "Specializations",
                            columns: table => new
                            {
                                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                                SpecializationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                MajorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                                CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                                CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                                ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                                ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                                IsDelete = table.Column<bool>(type: "bit", nullable: true),
                                DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                                DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_Specializations", x => x.Id);
                                table.ForeignKey(
                                    name: "FK_Specializations_Majors_MajorId",
                                    column: x => x.MajorId,
                                    principalTable: "Majors",
                                    principalColumn: "Id",
                                    onDelete: ReferentialAction.Cascade);
                            });

                        migrationBuilder.CreateTable(
                            name: "Accounts",
                            columns: table => new
                            {
                                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                                Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                                UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                                PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                                PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                                Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Affiliation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                RoleId = table.Column<int>(type: "int", nullable: false),
                                CountryId = table.Column<int>(type: "int", nullable: false),
                                CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                                CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                                ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                                ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                                IsDelete = table.Column<bool>(type: "bit", nullable: true),
                                DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                                DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_Accounts", x => x.Id);
                                table.ForeignKey(
                                    name: "FK_Accounts_Country_CountryId",
                                    column: x => x.CountryId,
                                    principalTable: "Country",
                                    principalColumn: "CountryId",
                                    onDelete: ReferentialAction.Cascade);
                                table.ForeignKey(
                                    name: "FK_Accounts_Roles_RoleId",
                                    column: x => x.RoleId,
                                    principalTable: "Roles",
                                    principalColumn: "RoleId",
                                    onDelete: ReferentialAction.Cascade);
                            });

                        migrationBuilder.CreateTable(
                            name: "Articles",
                            columns: table => new
                            {
                                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                                Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                ArticleFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                                Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                IssueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                                TopicId = table.Column<int>(type: "int", nullable: false),
                                CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                                CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                                ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                                ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                                IsDelete = table.Column<bool>(type: "bit", nullable: true),
                                DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                                DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_Articles", x => x.Id);
                                table.ForeignKey(
                                    name: "FK_Articles_Issue_IssueId",
                                    column: x => x.IssueId,
                                    principalTable: "Issue",
                                    principalColumn: "Id");
                                table.ForeignKey(
                                    name: "FK_Articles_Topic_TopicId",
                                    column: x => x.TopicId,
                                    principalTable: "Topic",
                                    principalColumn: "TopicId",
                                    onDelete: ReferentialAction.Cascade);
                            });

                        migrationBuilder.CreateTable(
                            name: "AccountSpecializations",
                            columns: table => new
                            {
                                AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                                SpecializationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                                ConfidentLevel = table.Column<int>(type: "int", nullable: false),
                                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                                CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                                CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                                ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                                ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                                IsDelete = table.Column<bool>(type: "bit", nullable: true),
                                DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                                DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_AccountSpecializations", x => new { x.AccountId, x.SpecializationId });
                                table.ForeignKey(
                                    name: "FK_AccountSpecializations_Accounts_AccountId",
                                    column: x => x.AccountId,
                                    principalTable: "Accounts",
                                    principalColumn: "Id",
                                    onDelete: ReferentialAction.Cascade);
                                table.ForeignKey(
                                    name: "FK_AccountSpecializations_Specializations_SpecializationId",
                                    column: x => x.SpecializationId,
                                    principalTable: "Specializations",
                                    principalColumn: "Id",
                                    onDelete: ReferentialAction.Cascade);
                            });

                        migrationBuilder.CreateTable(
                            name: "Author",
                            columns: table => new
                            {
                                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                                AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                IdentityCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_Author", x => x.Id);
                                table.ForeignKey(
                                    name: "FK_Author_Accounts_AccountId",
                                    column: x => x.AccountId,
                                    principalTable: "Accounts",
                                    principalColumn: "Id");
                            });

                        migrationBuilder.CreateTable(
                            name: "RequestReviews",
                            columns: table => new
                            {
                                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                                RequestTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                                ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                                CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                                CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                                ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                                ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                                IsDelete = table.Column<bool>(type: "bit", nullable: true),
                                DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                                DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_RequestReviews", x => x.Id);
                                table.ForeignKey(
                                    name: "FK_RequestReviews_Articles_ArticleId",
                                    column: x => x.ArticleId,
                                    principalTable: "Articles",
                                    principalColumn: "Id",
                                    onDelete: ReferentialAction.Cascade);
                            });

                        migrationBuilder.CreateTable(
                            name: "ArticleAuthor",
                            columns: table => new
                            {
                                ArticlesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                                AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_ArticleAuthor", x => new { x.ArticlesId, x.AuthorId });
                                table.ForeignKey(
                                    name: "FK_ArticleAuthor_Articles_ArticlesId",
                                    column: x => x.ArticlesId,
                                    principalTable: "Articles",
                                    principalColumn: "Id",
                                    onDelete: ReferentialAction.Cascade);
                                table.ForeignKey(
                                    name: "FK_ArticleAuthor_Author_AuthorId",
                                    column: x => x.AuthorId,
                                    principalTable: "Author",
                                    principalColumn: "Id",
                                    onDelete: ReferentialAction.Cascade);
                            });

                        migrationBuilder.CreateTable(
                            name: "RequestDetails",
                            columns: table => new
                            {
                                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                                Status = table.Column<int>(type: "int", nullable: false),
                                Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                                RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                                AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                                CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                                CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                                ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                                ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                                IsDelete = table.Column<bool>(type: "bit", nullable: true),
                                DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                                DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_RequestDetails", x => x.Id);
                                table.ForeignKey(
                                    name: "FK_RequestDetails_Accounts_AccountId",
                                    column: x => x.AccountId,
                                    principalTable: "Accounts",
                                    principalColumn: "Id",
                                    onDelete: ReferentialAction.Cascade);
                                table.ForeignKey(
                                    name: "FK_RequestDetails_RequestReviews_RequestId",
                                    column: x => x.RequestId,
                                    principalTable: "RequestReviews",
                                    principalColumn: "Id",
                                    onDelete: ReferentialAction.Cascade);
                            });

                        migrationBuilder.InsertData(
                            table: "Country",
                            columns: new[] { "CountryId", "CountryName" },
                            values: new object[,]
                            {
                                { 1, "Andorra" },
                                { 2, "United Arab Emirates" },
                                { 3, "Afghanistan" },
                                { 4, "Antigua and Barbuda" },
                                { 5, "Anguilla" },
                                { 6, "Albania" },
                                { 7, "Armenia" },
                                { 8, "Angola" },
                                { 9, "Antarctica" },
                                { 10, "Argentina" },
                                { 11, "American Samoa" },
                                { 12, "Austria" },
                                { 13, "Australia" },
                                { 14, "Aruba" },
                                { 15, "Åland" },
                                { 16, "Azerbaijan" },
                                { 17, "Bosnia and Herzegovina" },
                                { 18, "Barbados" },
                                { 19, "Bangladesh" },
                                { 20, "Belgium" },
                                { 21, "Burkina Faso" },
                                { 22, "Bulgaria" },
                                { 23, "Bahrain" },
                                { 24, "Burundi" },
                                { 25, "Benin" },
                                { 26, "Saint Barthélemy" },
                                { 27, "Bermuda" },
                                { 28, "Brunei" },
                                { 29, "Bolivia" },
                                { 30, "Bonaire, Sint Eustatius, and Saba" },
                                { 31, "Brazil" },
                                { 32, "Bahamas" },
                                { 33, "Bhutan" },
                                { 34, "Bouvet Island" },
                                { 35, "Botswana" },
                                { 36, "Belarus" },
                                { 37, "Belize" },
                                { 38, "Canada" },
                                { 39, "Cocos (Keeling) Islands" },
                                { 40, "DR Congo" },
                                { 41, "Central African Republic" },
                                { 42, "Congo Republic" }
                            });

                        migrationBuilder.InsertData(
                            table: "Country",
                            columns: new[] { "CountryId", "CountryName" },
                            values: new object[,]
                            {
                                { 43, "Switzerland" },
                                { 44, "Ivory Coast" },
                                { 45, "Cook Islands" },
                                { 46, "Chile" },
                                { 47, "Cameroon" },
                                { 48, "China" },
                                { 49, "Colombia" },
                                { 50, "Costa Rica" },
                                { 51, "Cuba" },
                                { 52, "Cabo Verde" },
                                { 53, "Curaçao" },
                                { 54, "Christmas Island" },
                                { 55, "Cyprus" },
                                { 56, "Czechia" },
                                { 57, "Germany" },
                                { 58, "Djibouti" },
                                { 59, "Denmark" },
                                { 60, "Dominica" },
                                { 61, "Dominican Republic" },
                                { 62, "Algeria" },
                                { 63, "Ecuador" },
                                { 64, "Estonia" },
                                { 65, "Egypt" },
                                { 66, "Western Sahara" },
                                { 67, "Eritrea" },
                                { 68, "Spain" },
                                { 69, "Ethiopia" },
                                { 70, "Finland" },
                                { 71, "Fiji" },
                                { 72, "Falkland Islands" },
                                { 73, "Micronesia" },
                                { 74, "Faroe Islands" },
                                { 75, "France" },
                                { 76, "Gabon" },
                                { 77, "United Kingdom" },
                                { 78, "Grenada" },
                                { 79, "Georgia" },
                                { 80, "French Guiana" },
                                { 81, "Guernsey" },
                                { 82, "Ghana" },
                                { 83, "Gibraltar" },
                                { 84, "Greenland" }
                            });

                        migrationBuilder.InsertData(
                            table: "Country",
                            columns: new[] { "CountryId", "CountryName" },
                            values: new object[,]
                            {
                                { 85, "The Gambia" },
                                { 86, "Guinea" },
                                { 87, "Guadeloupe" },
                                { 88, "Equatorial Guinea" },
                                { 89, "Greece" },
                                { 90, "South Georgia and South Sandwich Islands" },
                                { 91, "Guatemala" },
                                { 92, "Guam" },
                                { 93, "Guinea-Bissau" },
                                { 94, "Guyana" },
                                { 95, "Hong Kong" },
                                { 96, "Heard and McDonald Islands" },
                                { 97, "Honduras" },
                                { 98, "Croatia" },
                                { 99, "Haiti" },
                                { 100, "Hungary" },
                                { 101, "Indonesia" },
                                { 102, "Ireland" },
                                { 103, "Israel" },
                                { 104, "Isle of Man" },
                                { 105, "India" },
                                { 106, "British Indian Ocean Territory" },
                                { 107, "Iraq" },
                                { 108, "Iran" },
                                { 109, "Iceland" },
                                { 110, "Italy" },
                                { 111, "Jersey" },
                                { 112, "Jamaica" },
                                { 113, "Jordan" },
                                { 114, "Japan" },
                                { 115, "Kenya" },
                                { 116, "Kyrgyzstan" },
                                { 117, "Cambodia" },
                                { 118, "Kiribati" },
                                { 119, "Comoros" },
                                { 120, "St Kitts and Nevis" },
                                { 121, "North Korea" },
                                { 122, "South Korea" },
                                { 123, "Kuwait" },
                                { 124, "Cayman Islands" },
                                { 125, "Kazakhstan" },
                                { 126, "Laos" }
                            });

                        migrationBuilder.InsertData(
                            table: "Country",
                            columns: new[] { "CountryId", "CountryName" },
                            values: new object[,]
                            {
                                { 127, "Lebanon" },
                                { 128, "Saint Lucia" },
                                { 129, "Liechtenstein" },
                                { 130, "Sri Lanka" },
                                { 131, "Liberia" },
                                { 132, "Lesotho" },
                                { 133, "Lithuania" },
                                { 134, "Luxembourg" },
                                { 135, "Latvia" },
                                { 136, "Libya" },
                                { 137, "Morocco" },
                                { 138, "Monaco" },
                                { 139, "Moldova" },
                                { 140, "Montenegro" },
                                { 141, "Saint Martin" },
                                { 142, "Madagascar" },
                                { 143, "Marshall Islands" },
                                { 144, "North Macedonia" },
                                { 145, "Mali" },
                                { 146, "Myanmar" },
                                { 147, "Mongolia" },
                                { 148, "Macao" },
                                { 149, "Northern Mariana Islands" },
                                { 150, "Martinique" },
                                { 151, "Mauritania" },
                                { 152, "Montserrat" },
                                { 153, "Malta" },
                                { 154, "Mauritius" },
                                { 155, "Maldives" },
                                { 156, "Malawi" },
                                { 157, "Mexico" },
                                { 158, "Malaysia" },
                                { 159, "Mozambique" },
                                { 160, "Namibia" },
                                { 161, "New Caledonia" },
                                { 162, "Niger" },
                                { 163, "Norfolk Island" },
                                { 164, "Nigeria" },
                                { 165, "Nicaragua" },
                                { 166, "Netherlands" },
                                { 167, "Norway" },
                                { 168, "Nepal" }
                            });

                        migrationBuilder.InsertData(
                            table: "Country",
                            columns: new[] { "CountryId", "CountryName" },
                            values: new object[,]
                            {
                                { 169, "Nauru" },
                                { 170, "Niue" },
                                { 171, "New Zealand" },
                                { 172, "Oman" },
                                { 173, "Panama" },
                                { 174, "Peru" },
                                { 175, "French Polynesia" },
                                { 176, "Papua New Guinea" },
                                { 177, "Philippines" },
                                { 178, "Pakistan" },
                                { 179, "Poland" },
                                { 180, "Saint Pierre and Miquelon" },
                                { 181, "Pitcairn Islands" },
                                { 182, "Puerto Rico" },
                                { 183, "Palestine" },
                                { 184, "Portugal" },
                                { 185, "Palau" },
                                { 186, "Paraguay" },
                                { 187, "Qatar" },
                                { 188, "Réunion" },
                                { 189, "Romania" },
                                { 190, "Serbia" },
                                { 191, "Russia" },
                                { 192, "Rwanda" },
                                { 193, "Saudi Arabia" },
                                { 194, "Solomon Islands" },
                                { 195, "Seychelles" },
                                { 196, "Sudan" },
                                { 197, "Sweden" },
                                { 198, "Singapore" },
                                { 199, "Saint Helena" },
                                { 200, "Slovenia" },
                                { 201, "Svalbard and Jan Mayen" },
                                { 202, "Slovakia" },
                                { 203, "Sierra Leone" },
                                { 204, "San Marino" },
                                { 205, "Senegal" },
                                { 206, "Somalia" },
                                { 207, "Suriname" },
                                { 208, "South Sudan" },
                                { 209, "São Tomé and Príncipe" },
                                { 210, "El Salvador" }
                            });

                        migrationBuilder.InsertData(
                            table: "Country",
                            columns: new[] { "CountryId", "CountryName" },
                            values: new object[,]
                            {
                                { 211, "Sint Maarten" },
                                { 212, "Syria" },
                                { 213, "Eswatini" },
                                { 214, "Turks and Caicos Islands" },
                                { 215, "Chad" },
                                { 216, "French Southern Territories" },
                                { 217, "Togo" },
                                { 218, "Thailand" },
                                { 219, "Tajikistan" },
                                { 220, "Tokelau" },
                                { 221, "Timor-Leste" },
                                { 222, "Turkmenistan" },
                                { 223, "Tunisia" },
                                { 224, "Tonga" },
                                { 225, "Turkey" },
                                { 226, "Trinidad and Tobago" },
                                { 227, "Tuvalu" },
                                { 228, "Taiwan" },
                                { 229, "Tanzania" },
                                { 230, "Ukraine" },
                                { 231, "Uganda" },
                                { 232, "U.S. Outlying Islands" },
                                { 233, "United States" },
                                { 234, "Uruguay" },
                                { 235, "Uzbekistan" },
                                { 236, "Vatican City" },
                                { 237, "St Vincent and Grenadines" },
                                { 238, "Venezuela" },
                                { 239, "British Virgin Islands" },
                                { 240, "U.S. Virgin Islands" },
                                { 241, "Vietnam" },
                                { 242, "Vanuatu" },
                                { 243, "Wallis and Futuna" },
                                { 244, "Samoa" },
                                { 245, "Kosovo" },
                                { 246, "Yemen" },
                                { 247, "Mayotte" },
                                { 248, "South Africa" },
                                { 249, "Zambia" },
                                { 250, "Zimbabwe" }
                            });

                        migrationBuilder.InsertData(
                            table: "Roles",
                            columns: new[] { "RoleId", "Rolename" },
                            values: new object[,]
                            {
                                { 1, "Director" },
                                { 2, "Staff" }
                            });

                        migrationBuilder.InsertData(
                            table: "Roles",
                            columns: new[] { "RoleId", "Rolename" },
                            values: new object[] { 3, "Reviewer" });

                        migrationBuilder.InsertData(
                            table: "Roles",
                            columns: new[] { "RoleId", "Rolename" },
                            values: new object[] { 4, "Author" });

                        migrationBuilder.InsertData(
                            table: "Roles",
                            columns: new[] { "RoleId", "Rolename" },
                            values: new object[] { 5, "User" });

                        migrationBuilder.CreateIndex(
                            name: "IX_Accounts_CountryId",
                            table: "Accounts",
                            column: "CountryId");

                        migrationBuilder.CreateIndex(
                            name: "IX_Accounts_Email",
                            table: "Accounts",
                            column: "Email",
                            unique: true);

                        migrationBuilder.CreateIndex(
                            name: "IX_Accounts_RoleId",
                            table: "Accounts",
                            column: "RoleId");

                        migrationBuilder.CreateIndex(
                            name: "IX_AccountSpecializations_SpecializationId",
                            table: "AccountSpecializations",
                            column: "SpecializationId");

                        migrationBuilder.CreateIndex(
                            name: "IX_ArticleAuthor_AuthorId",
                            table: "ArticleAuthor",
                            column: "AuthorId");

                        migrationBuilder.CreateIndex(
                            name: "IX_Articles_IssueId",
                            table: "Articles",
                            column: "IssueId");

                        migrationBuilder.CreateIndex(
                            name: "IX_Articles_TopicId",
                            table: "Articles",
                            column: "TopicId");

                        migrationBuilder.CreateIndex(
                            name: "IX_Author_AccountId",
                            table: "Author",
                            column: "AccountId",
                            unique: true,
                            filter: "[AccountId] IS NOT NULL");

                        migrationBuilder.CreateIndex(
                            name: "IX_RequestDetails_AccountId",
                            table: "RequestDetails",
                            column: "AccountId");

                        migrationBuilder.CreateIndex(
                            name: "IX_RequestDetails_RequestId",
                            table: "RequestDetails",
                            column: "RequestId");

                        migrationBuilder.CreateIndex(
                            name: "IX_RequestReviews_ArticleId",
                            table: "RequestReviews",
                            column: "ArticleId");

                        migrationBuilder.CreateIndex(
                            name: "IX_Specializations_MajorId",
                            table: "Specializations",
                            column: "MajorId");*/
            migrationBuilder.CreateIndex(
                         name: "IX_Articles_TopicId",
                         table: "Articles",
                         column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountSpecializations");

            migrationBuilder.DropTable(
                name: "ArticleAuthor");

            migrationBuilder.DropTable(
                name: "RequestDetails");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "RequestReviews");

            migrationBuilder.DropTable(
                name: "Majors");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Issue");

            migrationBuilder.DropTable(
                name: "Topic");
        }
    }
}
