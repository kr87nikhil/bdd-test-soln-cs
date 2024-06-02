using RestSharp;
using RestSharp.Authenticators;
using Web.App.xUnit.Gherkin.Tests.Web.Model;

namespace Web.App.xUnit.Gherkin.Tests.Model.RestSharpClient;

internal class ToolsQaAuthenticator(string BaseUrl, string Username, string Password) : AuthenticatorBase(string.Empty)
{
    internal static string? LoggedInUserId { get; set; }

    protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
    {
        Token = string.IsNullOrEmpty(accessToken) ? await GetToken() : Token;
        return new HeaderParameter(KnownHeaders.Authorization, Token);
    }

    /// <summary>
    /// Generate token for ToolQaClient
    /// </summary>
    /// <returns>Bearer Token</returns>
    private async Task<string> GetToken()
    {
        using var client = new RestClient(BaseUrl);
        var jwtTokenResponse = await client.PostJsonAsync<Login, GeneratedToken>(
            "Account/v1/Login", new Login(Username, Password)
        );
        LoggedInUserId = jwtTokenResponse!.UserId;
        return $"Bearer {jwtTokenResponse.Token}";
    }
}
