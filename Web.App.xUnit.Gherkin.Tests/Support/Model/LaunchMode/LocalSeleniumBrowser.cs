using OpenQA.Selenium;
using Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;

namespace Web.App.xUnit.Gherkin.Tests.Support.Model.LaunchMode;
internal class LocalSeleniumBrowser(BrowserDriverBuilder DriverBuilder, string browserVersion) : IBrowserLaunchMode
{
    public IWebDriver Browser => DriverBuilder.GetType() == typeof(SafariBrowser)
        ? DriverBuilder.BuildLocalBrowser(""): DriverBuilder.BuildLocalSeleniumBrowser(browserVersion)!;
}
