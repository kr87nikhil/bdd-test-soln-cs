using OpenQA.Selenium;

namespace Web.App.xUnit.Gherkin.Tests.Support.Model.LaunchMode;
internal class LaunchRemoteBrowser(Uri SeleniumGridUrl) : LaunchBrowser
{
    public override IWebDriver BrowserDriver =>
        DriverBuilder.SetUpRemoteExecution().BuildRemoteBrowser(SeleniumGridUrl);
}
