using Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;

namespace Web.App.xUnit.Gherkin.Tests.Support.Application.WebApplication;
internal class MobileBrowserBuilderFactory : IDeviceBrowserBuilderFactory
{
    public EdgeBrowser GetEdgeBrowserBuilder() => throw new NotImplementedException();
    public SafariBrowser GetSafariBrowserBuilder() => throw new NotImplementedException();
    public ChromeBrowser GetChromeBrowserBuilder() => throw new NotImplementedException();
    public FirefoxBrowser GetFirefoxBrowserBuilder() => throw new NotImplementedException();
}
