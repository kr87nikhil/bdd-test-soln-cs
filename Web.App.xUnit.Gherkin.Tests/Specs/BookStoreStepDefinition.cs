using Xunit.Gherkin.Quick;

namespace Web.App.xUnit.Gherkin.Tests.Specs;

[FeatureFile(@"./Features/BookStore.feature")]
public sealed class BookStoreStepDefinition: BaseStepDefinition, IDisposable
{
    [Given(@"I logged in as a standard user")]
    public void GivenILoggedInAsAStandardUser()
    {
        throw new NotImplementedException();
    }

    [Given(@"([\w ]*) book is issued to User")]
    public void GivenBookIsIssuedToUser(string title)
    {
        throw new NotImplementedException();
    }

    [When(@"I open (\w*) section of ([\w ]*) to view issued books")]
    public void WhenIOpenSectionToViewIssuedBooks(string section, string group)
    {
        throw new NotImplementedException();
    }

    [When(@"I return book with title ([\w ]*)")]
    public void WhenIReturnBookWithTitle(string title)
    {
        throw new NotImplementedException();
    }

    [Then(@"([ \w.]*)'s book ([\w ]*) should (be|not be) available")]
    public void ThenBookShouldOrShouldNotBeAvailable(string author, string title, string conditionalCheck)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
