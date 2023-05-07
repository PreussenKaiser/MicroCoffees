using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MicroCoffees.Coffees.Infrastructure.Migrations;

/// <inheritdoc />
public partial class SeedCoffees : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "Coffees",
            columns: new[] { "Id", "Cost", "ImageUrl", "Name", "Quantity", "Roast" },
            values: new object[,]
            {
                { new Guid("04f5e8e1-da22-4757-9627-dcba35f20ee9"), 7.99m, "https://news.usc.edu/files/2016/04/20140425_Coffee_web.jpg", "Generic Coffee", 1, 0 },
                { new Guid("1d333d93-7628-4732-813d-adcab72aac69"), 7.99m, "https://eadn-wc04-202503.nxedge.io/cdn/wp-content/uploads/2013/03/coffee-clay-cup.jpg", "Eight Bitter", 8, 0 },
                { new Guid("24826eab-bb54-4a8a-987f-a91fbbd807e4"), 19.99m, "https://i.pinimg.com/736x/7d/5e/d8/7d5ed89982c309ac9bd993e5b0e70e15.jpg", "Funk Oriented", 2, 0 },
                { new Guid("2fded802-eae5-4227-9cb0-09ce0b47315c"), 2.99m, "https://i.pinimg.com/originals/dd/af/b5/ddafb54b7c1544f34236017df5928f0b.jpg", "AbstractCoffeeFactorySingleton", 2, 1 },
                { new Guid("55f8d8f3-517f-4c60-9eb8-d2626bdf9d65"), 0.99m, "https://thumbs.dreamstime.com/b/fire-hot-coffee-white-cup-33390113.jpg", "Null Reference Exception", 6, 2 },
                { new Guid("5ca784a3-04a0-4f71-b451-e7a736b457d4"), 99.99m, "https://fastly.4sqi.net/img/general/600x600/PMT3R1OBRPE45IPDSSYF1XCIGM3QN10JPT1N5RI0DV1CBJG4.jpg", "Imposter Syndrome", 1, 2 },
                { new Guid("618f71cd-a4e4-4c02-9014-0e5cb38bee06"), 9.99m, "https://farm6.staticflickr.com/5254/5438241040_b85e8556ff_n.jpg", "10x Coffee", 1, 0 },
                { new Guid("6cd81e45-8ab2-46ac-9581-015c3b3edbed"), 14.99m, "https://thumbs.dreamstime.com/z/coffee-ornate-china-cup-8144721.jpg", "The Oriental Object", 1, 1 },
                { new Guid("952485a9-8597-4812-88c5-732cb8947eef"), 4.99m, "https://c2.staticflickr.com/8/7087/7213400040_8a548668d6_b.jpg", "Integer Overflow", 5, 0 },
                { new Guid("a404a34a-80f3-4c6c-8c88-9cd575a233e0"), 9.99m, "https://thecoffeevine.com/wp-content/uploads/2013/05/img_4869-500x375.jpg", "Monad Monster", 2, 1 },
                { new Guid("ad5cc35a-cd71-4b34-8e29-0a87f9356dd4"), 31.99m, "https://bestcoffeespan.com/wp-content/uploads/2021/01/aged-coffee-scaled.jpg", "Line Three", 3, 0 },
                { new Guid("dedd14bb-e9b0-478f-829d-aa5d3ad872f2"), 12.99m, "https://cdn.wallpapersafari.com/18/52/4lg2Ow.jpg", "The Breakpoint", 3, 2 }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "Coffees",
            keyColumn: "Id",
            keyValue: new Guid("04f5e8e1-da22-4757-9627-dcba35f20ee9"));

        migrationBuilder.DeleteData(
            table: "Coffees",
            keyColumn: "Id",
            keyValue: new Guid("1d333d93-7628-4732-813d-adcab72aac69"));

        migrationBuilder.DeleteData(
            table: "Coffees",
            keyColumn: "Id",
            keyValue: new Guid("24826eab-bb54-4a8a-987f-a91fbbd807e4"));

        migrationBuilder.DeleteData(
            table: "Coffees",
            keyColumn: "Id",
            keyValue: new Guid("2fded802-eae5-4227-9cb0-09ce0b47315c"));

        migrationBuilder.DeleteData(
            table: "Coffees",
            keyColumn: "Id",
            keyValue: new Guid("55f8d8f3-517f-4c60-9eb8-d2626bdf9d65"));

        migrationBuilder.DeleteData(
            table: "Coffees",
            keyColumn: "Id",
            keyValue: new Guid("5ca784a3-04a0-4f71-b451-e7a736b457d4"));

        migrationBuilder.DeleteData(
            table: "Coffees",
            keyColumn: "Id",
            keyValue: new Guid("618f71cd-a4e4-4c02-9014-0e5cb38bee06"));

        migrationBuilder.DeleteData(
            table: "Coffees",
            keyColumn: "Id",
            keyValue: new Guid("6cd81e45-8ab2-46ac-9581-015c3b3edbed"));

        migrationBuilder.DeleteData(
            table: "Coffees",
            keyColumn: "Id",
            keyValue: new Guid("952485a9-8597-4812-88c5-732cb8947eef"));

        migrationBuilder.DeleteData(
            table: "Coffees",
            keyColumn: "Id",
            keyValue: new Guid("a404a34a-80f3-4c6c-8c88-9cd575a233e0"));

        migrationBuilder.DeleteData(
            table: "Coffees",
            keyColumn: "Id",
            keyValue: new Guid("ad5cc35a-cd71-4b34-8e29-0a87f9356dd4"));

        migrationBuilder.DeleteData(
            table: "Coffees",
            keyColumn: "Id",
            keyValue: new Guid("dedd14bb-e9b0-478f-829d-aa5d3ad872f2"));
    }
}
