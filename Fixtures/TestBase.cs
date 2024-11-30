using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;

namespace SnipeIT.UI.Tests.Fixtures;

// Base test class for all tests, utilizing Playwright's PageTest.
[TestFixture]
internal class TestBase : PageTest
{
    private protected IConfiguration Configuration;

    private IBrowser _browser;
    private IBrowserContext _context;
    private IPage _page;

    // Setup method runs before each test.
    [SetUp]
    public async Task SetUp()
    {
        // Load configuration from config.json.
        Configuration = new ConfigurationBuilder().AddJsonFile("config.json").Build();

        // Launch the browser and create a context with specific viewport size.
        _browser = await BrowserType.LaunchAsync();
        _context = await _browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = new ViewportSize
            {
                Width = 1920, 
                Height = 1080
            }
        });
        _page = await _context.NewPageAsync();
    }

    // TearDown method runs after each test to clean up resources.
    [TearDown]
    public async Task TearDown()
    {
        await _page.CloseAsync();
        await _context.CloseAsync();
        await _browser.CloseAsync();
    }
}