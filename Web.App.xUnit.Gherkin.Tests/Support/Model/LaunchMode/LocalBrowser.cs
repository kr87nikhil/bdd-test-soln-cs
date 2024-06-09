using OpenQA.Selenium;

namespace Web.App.xUnit.Gherkin.Tests.Support.Model.LaunchMode;
internal class LocalBrowser(BrowserDriverBuilder DriverBuilder, string DriverExecutablePath) : IBrowserLaunchMode
{
    public IWebDriver Browser => DriverBuilder.BuildLocalBrowser(DriverExecutablePath);
}
