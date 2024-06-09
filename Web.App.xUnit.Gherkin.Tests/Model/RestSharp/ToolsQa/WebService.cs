using RestSharp;
using RestSharp.Authenticators;
using Web.App.xUnit.Gherkin.Tests.Web.Model;

namespace Web.App.xUnit.Gherkin.Tests.Model.RestSharp.ToolsQa;

internal sealed class WebService : IWebService, IDisposable
{
    private readonly RestClient _restClient;
    public const string DemoQaBaseUrl = "https://demoqa.com";

    public WebService(AuthenticatorBase authenticator)
    {
        var options = new RestClientOptions(DemoQaBaseUrl) { Authenticator = authenticator };
        _restClient = new RestClient(options);
    }

    public async Task<BookIsbn> BorrowBooksFromStore(IList<BookIsbn> collectionOfIsbn)
    {
        var response = await _restClient.PostJsonAsync<BookRequest, BookIsbn>(
            "BookStore/v1/Books",
            new BookRequest(Authenticator.LoggedInUserId!, collectionOfIsbn)
        );
        return response!;
    }

    public async Task<BorrowedBooks> GetBooksLoanedToUser()
    {
        var request = new RestRequest("Account/v1/User/{UUID}")
            .AddUrlSegment("UUID", Authenticator.LoggedInUserId!);
        var response = await _restClient.GetAsync<BorrowedBooks>(request);
        return response!;
    }

    public async Task<ReturnBookResponse> ReturnBook(string bookIsbn)
    {
        var request = new RestRequest("BookStore/v1/Book", Method.Delete)
            .AddJsonBody<ReturnBookRequest>(new(Authenticator.LoggedInUserId!, bookIsbn));
        var response = await _restClient.ExecuteAsync<ReturnBookResponse>(request);
        return response.Data!;
    }

    public void Dispose()
    {
        _restClient.Dispose();
        GC.SuppressFinalize(this);
    }
}
