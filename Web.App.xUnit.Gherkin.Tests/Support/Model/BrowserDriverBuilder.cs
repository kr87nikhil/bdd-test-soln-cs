using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Web.App.xUnit.Gherkin.Tests.Support.Model;
internal abstract class BrowserDriverBuilder(DriverOptions DriverOptions)
{
    protected abstract string DRIVEREXECUTABLE { get; }

    public BrowserDriverBuilder SetPageLoadTimeout(TimeSpan timeout)
    {
        DriverOptions.PageLoadTimeout = timeout;
        return this;
    }

    public BrowserDriverBuilder SetUpRemoteExecution()
    {
        DriverOptions.EnableDownloads = true;
        DriverOptions.AcceptInsecureCertificates = true;
        return this;
    }

    /// <summary>
    /// Use downloaded driver to launch Browser
    /// </summary>
    /// <param name="driverExecutablePath">Binary driver executable directory</param>
    public abstract IWebDriver BuildLocalBrowser(string driverExecutablePath);

    /// <summary>
    /// Get browser/driver/both downloaded via Selenium Manager.
    /// </summary>
    /// <param name="browserVersion"></param>
    /// <returns>null; Safari browser does not support browser/driver download as of this writing</returns>
    public virtual IWebDriver? BuildLocalSeleniumBrowser(string browserVersion = "beta")
    {
        return null;
    }
    public IWebDriver BuildRemoteBrowser(Uri seleniumGridUrl, string browserVersion = "stable")
    {
        DriverOptions.BrowserVersion = browserVersion;
        return string.IsNullOrEmpty(seleniumGridUrl.ToString())
            ? new RemoteWebDriver(DriverOptions) : new RemoteWebDriver(seleniumGridUrl, DriverOptions);
    }
}
