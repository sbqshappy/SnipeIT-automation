using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;

namespace SnipeIT.UI.Tests.Pages;

public class DashboardPage(IPage page, IConfiguration configuration) : BasePage(page, configuration)
{
    public string Url => $"{BaseUrl}"; // URL of the Dashboard page

    public ILocator AssetsNavLink => Page.GetByRole(AriaRole.Link, new() { NameString = "Assets" });

    // Navigates to the Dashboard page
    public async Task GoToAsync()
    {
        await Page.GotoAsync(Url);
    }
}