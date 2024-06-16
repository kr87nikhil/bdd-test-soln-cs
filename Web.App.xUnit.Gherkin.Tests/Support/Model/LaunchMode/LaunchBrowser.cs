using OpenQA.Selenium;

namespace Web.App.xUnit.Gherkin.Tests.Support.Model.LaunchMode;
public abstract class LaunchBrowser
{
    public required BrowserDriverBuilder DriverBuilder { get; set; }
    public virtual IWebDriver? BrowserDriver { get; }
}
