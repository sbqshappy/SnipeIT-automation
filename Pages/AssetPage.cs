using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;

namespace SnipeIT.UI.Tests.Pages;

public class AssetPage(IPage page, IConfiguration configuration) : BasePage(page, configuration)
{
    // Locator for the header of the asset page, identifying by regex match for "View Asset".
    public ILocator Header()
    {
        return Page.GetByRole(AriaRole.Heading, new() { NameRegex = new Regex("^View Asset") });
    }
}