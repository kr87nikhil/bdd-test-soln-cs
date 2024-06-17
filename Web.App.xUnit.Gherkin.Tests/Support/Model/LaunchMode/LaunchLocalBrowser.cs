using OpenQA.Selenium;

namespace Web.App.xUnit.Gherkin.Tests.Support.Model.LaunchMode;
internal class LaunchLocalBrowser(string DriverExecutablePath) : LaunchBrowser
{
    public override IWebDriver BrowserDriver =>
        DriverBuilder?.BuildLocalBrowser(DriverExecutablePath)!;
}
