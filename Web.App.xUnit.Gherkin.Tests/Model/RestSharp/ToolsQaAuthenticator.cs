using RestSharp;
using RestSharp.Authenticators;

namespace Web.App.xUnit.Gherkin.Tests.Model.RestSharpClient;

internal class ToolsQaAuthenticator(string Username, string Password) : AuthenticatorBase(string.Empty)
{
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
        using var client = new RestClient(ToolsQaClient.DemoQaBaseUrl);
        var jwtToken = await ToolsQaApiDefinition.PerformLogin(client, Username, Password);
        ToolsQaClient.LoggedInUserId = jwtToken.UserId;
        return $"Bearer {jwtToken.Token}";
    }
}
