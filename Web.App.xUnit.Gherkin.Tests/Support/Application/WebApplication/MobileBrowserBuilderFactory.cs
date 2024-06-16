using Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;

namespace Web.App.xUnit.Gherkin.Tests.Support.Application.WebApplication;
internal class MobileBrowserBuilderFactory : IDeviceBrowserBuilderFactory
{
    public EdgeBrowserDriverBuilder GetEdgeBrowserDriverBuilder() => throw new NotImplementedException();
    public SafariBrowserDriverBuilder GetSafariBrowserDriverBuilder() => throw new NotImplementedException();
    public ChromeBrowserDriverBuilder GetChromeBrowserDriverBuilder() => throw new NotImplementedException();
    public FirefoxBrowserDriverBuilder GetFirefoxBrowserDriverBuilder() => throw new NotImplementedException();
}
