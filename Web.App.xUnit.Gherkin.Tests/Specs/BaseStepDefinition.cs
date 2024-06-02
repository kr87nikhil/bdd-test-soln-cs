using Xunit.Gherkin.Quick;

namespace Web.App.xUnit.Gherkin.Tests.Specs;

public abstract class BaseStepDefinition: Feature
{
    [Given(@"browser loaded (.*) page")]
    public void BrowserLoadedBookStorePage(string url)
    {
        throw new NotImplementedException();
    }
}
