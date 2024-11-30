using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;

namespace SnipeIT.UI.Tests.Pages;

internal class LoginPage(IPage page, IConfiguration configuration) : BasePage(page, configuration)
{
    public string Url => $"{BaseUrl}login";

    // Locator for the "Login" button, username and password
    public ILocator LoginButton => Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
    public ILocator UserNameField => Page.GetByPlaceholder("Username");
    public ILocator PasswordField=> Page.GetByPlaceholder("Password");

    // Method to perform login
    public async Task LoginAsync()
    {
        await UserNameField.FillAsync(Username);
        await PasswordField.FillAsync(Password);
        await LoginButton.ClickAsync();
    }
}