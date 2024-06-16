using Web.App.xUnit.Gherkin.Tests.Support.Model.Browser;

namespace Web.App.xUnit.Gherkin.Tests.Support.Application.WebApplication;
internal interface IDeviceBrowserBuilderFactory
{
    public abstract EdgeBrowserDriverBuilder GetEdgeBrowserDriverBuilder();
    public abstract SafariBrowserDriverBuilder GetSafariBrowserDriverBuilder();
    public abstract ChromeBrowserDriverBuilder GetChromeBrowserDriverBuilder();
    public abstract FirefoxBrowserDriverBuilder GetFirefoxBrowserDriverBuilder();
}