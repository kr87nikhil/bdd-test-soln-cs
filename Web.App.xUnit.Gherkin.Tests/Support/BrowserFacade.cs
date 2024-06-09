using OpenQA.Selenium;
using Web.App.xUnit.Gherkin.Tests.Support.Application.WebApplication;

namespace Web.App.xUnit.Gherkin.Tests.Support;

public class BrowserFacade(string BrowserName, string BrowserVersion, bool HeadlessMode) : IAppFactory
{
    private IDeviceBrowserFactory BrowserDeviceFactory { get; set; }

    public void SetBrowserConfiguration(string browserType = "Web")
    {
        throw new NotImplementedException();
    }

    public IWebDriver OpenApp()
    {
        throw new NotImplementedException();
    }
}
