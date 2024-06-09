using OpenQA.Selenium;

namespace Web.App.xUnit.Gherkin.Tests.Support.Model.LaunchMode;
internal class RemoteBrowser(BrowserDriverBuilder DriverBuilder, Uri SeleniumGridUrl) : IBrowserLaunchMode
{
    public IWebDriver Browser => DriverBuilder.SetUpRemoteExecution().BuildRemoteBrowser(SeleniumGridUrl);
}
