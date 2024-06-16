using OpenQA.Selenium;
using Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;

namespace Web.App.xUnit.Gherkin.Tests.Support.Model.LaunchMode;
internal class LaunchLocalManagedBrowser(string browserVersion) : LaunchBrowser
{
    public override IWebDriver BrowserDriver => DriverBuilder.GetType() == typeof(SafariBrowser)
        ? DriverBuilder.BuildLocalBrowser(""): DriverBuilder.BuildLocalSeleniumBrowser(browserVersion)!;
}
