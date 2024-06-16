using Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;

namespace Web.App.xUnit.Gherkin.Tests.Support.Application.WebApplication;
internal interface IDeviceBrowserBuilderFactory
{
    public abstract EdgeBrowser GetEdgeBrowserBuilder();
    public abstract SafariBrowser GetSafariBrowserBuilder();
    public abstract ChromeBrowser GetChromeBrowserBuilder();
    public abstract FirefoxBrowser GetFirefoxBrowserBuilder();
}