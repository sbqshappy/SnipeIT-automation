using Bogus;
using Microsoft.Playwright;
using SnipeIT.UI.Tests.Fixtures;
using SnipeIT.UI.Tests.Pages;
using System.Globalization;

namespace SnipeIT.UI.Tests.TestCases;
internal class AssetsTests : TestBase
{
    // Test to create an asset in the system and verify it exists after creation
    [Test]
    public async Task ShouldCreateAsset()
    {
        // Initialize page objects for each page in the flow
        var dashboardPage = new DashboardPage(Page, Configuration);
        var loginPage = new LoginPage(Page, Configuration);
        var allAssetsPage = new AllAssetsPage(Page, Configuration);
        var createAssetPage = new CreateAssetPage(Page, Configuration);
        var assetPage = new AssetPage(Page, Configuration);

        // Define test data to be used for asset creation
        const string model = "Apple Macbook Pro 13";
        const string status = "Ready To Deploy";

        // Use Bogus library to generate random test data
        var faker = new Faker();
        var serial = faker.Random.AlphaNumeric(10);
        var notes = faker.Lorem.Sentence();
        var orderNumber = faker.Random.AlphaNumeric(10);
        var purchaseCost = faker.Random.Number(1, 1000).ToString(CultureInfo.InvariantCulture);

        // Navigate through the flow: login, create an asset, and verify it
        await dashboardPage.GoToAsync();
        await Expect(Page).ToHaveURLAsync(loginPage.Url);
        await loginPage.LoginAsync();
        await Expect(Page).ToHaveURLAsync(dashboardPage.Url);
        await dashboardPage.AssetsNavLink.ClickAsync();
        await Expect(Page).ToHaveURLAsync(allAssetsPage.Url);
        await allAssetsPage.CreateNewLink.ClickAsync();
        await Expect(Page).ToHaveURLAsync(createAssetPage.Url);
        await createAssetPage.SelectCompany();
        var assetTag = await createAssetPage.AssetTagField.InputValueAsync();
        await createAssetPage.SerialField.FillAsync(serial);
        await createAssetPage.SelectModel(model);
        await createAssetPage.SelectStatus(status);
        await createAssetPage.SelectCheckoutTo();
        await createAssetPage.NotesField.FillAsync(notes);
        await createAssetPage.SelectDefaultLocation();
        await createAssetPage.RequestableCheckbox.CheckAsync();
        await createAssetPage.ExpandOrderInformation();
        await createAssetPage.OrderNumberField.FillAsync(orderNumber);
        await createAssetPage.SelectSupplier();
        await createAssetPage.PurchaseCostField.FillAsync(purchaseCost);
        await createAssetPage.SaveButtonField.ClickAsync();
        await allAssetsPage.GoToAsync();
        await allAssetsPage.SearchAsync(assetTag);
        await Expect(assetPage.Header()).ToContainTextAsync(assetTag);

        //Navigate to the asset page and validate the "History" tab
        var historyTabLocator = Page.GetByRole(AriaRole.Tab, new() { Name = "History" });
        await historyTabLocator.ClickAsync();

        //Validate details in the "History" tab
        var historyDetails = Page.Locator("#history-details"); // Adjust the selector as per the actual structure
        await Expect(historyDetails).ToContainTextAsync(assetTag);
        await Expect(historyDetails).ToContainTextAsync(model);
        await Expect(historyDetails).ToContainTextAsync(status);

    }
}