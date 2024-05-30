using RestSharp;
using Web.App.xUnit.Gherkin.Tests.Web.Model;

namespace Web.App.xUnit.Gherkin.Tests.Model.RestSharpClient;
    
internal abstract class ToolsQaApiDefinition
{
    public abstract Task<BookIsbn> BorrowBooksFromStore(IList<BookIsbn> collectionOfIsbn);
    public abstract Task<BorrowedBooks> GetBooksLoanedToUser();

    internal static async Task<GeneratedToken> PerformLogin(RestClient restClient, string username, string password)
    {
        var response = await restClient.PostJsonAsync<Login, GeneratedToken>(
            "Account/v1/Login",
            new Login(username, password)
        );
        return response!;
    }
}
