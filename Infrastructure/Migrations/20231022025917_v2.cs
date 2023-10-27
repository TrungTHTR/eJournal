using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Affiliation",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
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

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CountryId",
                table: "Accounts",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Country_CountryId",
                table: "Accounts",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Country_CountryId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CountryId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Affiliation",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Accounts");
        }
    }
}
