using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;

namespace SnipeIT.UI.Tests.Pages;

// Abstract base class for page objects, defining shared properties and methods.
public abstract class BasePage(IPage page, IConfiguration configuration)
{
    private protected readonly string BaseUrl = configuration["baseUrl"] ?? throw new InvalidOperationException();    // Base URL retrieved from the configuration.                    
    // Username and password retrieved from the configuration.
    private protected readonly string Username = configuration["username"] ?? throw new InvalidOperationException();
    private protected readonly string Password = configuration["password"] ?? throw new InvalidOperationException();

    public IPage Page { get; set; } = page; // Page instance for interacting with the browser.

}