using RestSharp;
using Web.App.xUnit.Gherkin.Tests.Web.Model;

namespace Web.App.xUnit.Gherkin.Tests.Model.RestSharp.ToolsQa;

internal sealed class WebService : IWebService, IDisposable
{
    private readonly RestClient _restClient;
    private const string DemoQaBaseUrl = "https://demoqa.com";

    public WebService(string username, string password)
    {
        var options = new RestClientOptions(DemoQaBaseUrl)
        {
            Authenticator = new Authenticator(DemoQaBaseUrl, username, password)
        };
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
        var request = new RestRequest("BookStore/v1/Book")
            .AddJsonBody<ReturnBookRequest>(new(Authenticator.LoggedInUserId!, bookIsbn));
        var response = await _restClient.DeleteAsync<ReturnBookResponse>(request);
        return response!;
    }

    public void Dispose()
    {
        _restClient.Dispose();
        GC.SuppressFinalize(this);
    }
}
