using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;

namespace SnipeIT.UI.Tests.Pages;

// Page object representing the "All Assets" page.
public class AllAssetsPage(IPage page, IConfiguration configuration) : BasePage(page, configuration)
{
    public string Url => $"{BaseUrl}hardware";
    public ILocator CreateNewLink => Page.GetByRole(AriaRole.Link, new() { Name = "Create New" });
    public ILocator AssetTagSearchField => Page.GetByPlaceholder("Lookup by Asset Tag");
    public ILocator AssetTagSearchButton => Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Search", Exact = true });

    public async Task GoToAsync()     // Navigate to the "All Assets" page.
    {
        await Page.GotoAsync(Url);
    }

    public async Task SearchAsync(string searchTerm) // Perform a search on the page by filling the search field and clicking the search button.
    {
        await AssetTagSearchField.FillAsync(searchTerm);
        await AssetTagSearchButton.ClickAsync();
    }
}