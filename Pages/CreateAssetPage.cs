using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;

namespace SnipeIT.UI.Tests.Pages;

public class CreateAssetPage(IPage page, IConfiguration configuration) : BasePage(page, configuration)
{

    // Locators for various fields and dropdowns on the page.
    public string Url => $"{BaseUrl}hardware/create";
    public ILocator Select2OptionsList => Page.Locator("ul.select2-results__options");
    public ILocator Select2OptionItem => Page.Locator("li.select2-results__option");
    public ILocator Select2SearchBox => Page.GetByRole(AriaRole.Searchbox);
    public ILocator CompanyDropdown => Page.GetByLabel("Select Company");
    public ILocator AssetTagField => Page.GetByLabel("Asset Tag", new() {Exact = true});
    public ILocator SerialField => Page.GetByLabel("Serial");
    public ILocator ModelDropdown => Page.GetByLabel("Select a Model");
    public ILocator StatusDropdown => Page.GetByLabel("Select Status");
    public ILocator CheckoutToDropDown => Page.GetByLabel("Select a User");
    public ILocator NotesField => Page.GetByLabel("notes");
    public ILocator DefaultLocationDropdown => Page.GetByRole(AriaRole.Combobox, new() { Name = "Select a Location" });
    public ILocator RequestableCheckbox => Page.GetByLabel("Requestable");
    public ILocator OrderInformationFormGroup => Page.Locator("#order_info");
    public ILocator OrderNumberField => Page.GetByLabel("order_number");
    public ILocator SupplierDropdown => Page.GetByLabel("Select a Supplier");
    public ILocator PurchaseCostField => Page.GetByLabel("purchase_cost");
    public ILocator SaveButtonField => Page.GetByRole(AriaRole.Button, new() { Name = "Save" }).Nth(1);

    // Helper methods for interacting with specific fields and dropdowns.
    public async Task SelectCompany()
    {
        await CompanyDropdown.ClickAsync();
        await Select2OptionsList.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
        await Select2OptionItem.First.ClickAsync();
    }

    public async Task SelectModel(string model)
    {
        await ModelDropdown.ClickAsync();
        await Select2SearchBox.FillAsync(model);
        await Select2OptionsList.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
        await Select2OptionItem.First.ClickAsync();
    }

    public async Task SelectStatus(string status)
    {
        await StatusDropdown.ClickAsync();
        await Select2SearchBox.FillAsync(status);
        await Select2OptionsList.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
        await Select2OptionItem.First.ClickAsync();
    }

    public async Task SelectCheckoutTo()
    {
        await CheckoutToDropDown.ClickAsync();
        await Select2OptionsList.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
        await Select2OptionItem.First.ClickAsync();
    }

    public async Task SelectDefaultLocation()
    {
        await DefaultLocationDropdown.ClickAsync();
        await Select2OptionsList.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
        await Select2OptionItem.First.ClickAsync();
    }

    public async Task SelectSupplier()
    {
        await SupplierDropdown.ClickAsync();
        await Select2OptionsList.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
        await Select2OptionItem.First.ClickAsync();
    }

    public async Task ExpandOrderInformation()
    {
        await OrderInformationFormGroup.ClickAsync();
    }
}