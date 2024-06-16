using OpenQA.Selenium;

namespace Web.App.xUnit.Gherkin.Tests.Support;
internal interface IWebAppFactory
{
    public IWebDriver OpenApp();
}
