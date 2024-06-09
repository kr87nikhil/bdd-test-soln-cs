using OpenQA.Selenium;

namespace Web.App.xUnit.Gherkin.Tests.Support.Model.LaunchMode;
internal interface IBrowserLaunchMode
{
    public IWebDriver Browser { get; }
}
