using System.Collections.Generic;
using IdentityServer4.Models;

namespace krabs.SSO.Config
{
    public static class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            return new Client[]
            {
                new Client()
                {
                    ClientId = "mvc",
                    ClientName = "MVC Demo",
                    RequireConsent = false,
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    ClientSecrets = {new Secret("secret".Sha256())},
                    RedirectUris = {"http://localhost:5123/signin-oidc"},
                    FrontChannelLogoutUri = "http://localhost:5123/signout-oidc",
                    PostLogoutRedirectUris = {"http://localhost:5123/signout-callback-oidc"},
                    AllowedScopes = {"openid", "profile", "email", "office", "api1"},
                    AlwaysIncludeUserClaimsInIdToken = true,
                    // RequireConsent = false
                },
                new Client
                {
                    ClientId = "spa",
                    ClientName = "SinglePage",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = true,
                    AccessTokenLifetime = 3600, //Seconds
                    RedirectUris =
                    {
                        "http://localhost:5100/callback",
                        "http://localhost:5100/silent_renew.html",
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:5000/account/login"
                    },
                    AllowedCorsOrigins = { "http://localhost:5100" },
                    AllowedScopes =
                    {
                        "openid",
                        "profile",
                        "email",
                        "api1"
                    }
                },
                new Client()
                {
                    ClientId = "gateway",
                    ClientName = "BasentGateway",
                    ClientSecrets = {new Secret("gateway".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedScopes =
                    {
                        "openid",
                        "profile",
                        "email",
                        "api1"
                    }
                },
                new Client
                {
                    ClientId = "demo_api_swagger",
                    ClientName = "Swagger UI for demo_api",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = {"http://localhost:5010/oauth2-redirect.html", "https://localhost:5011/oauth2-redirect.html"},
                    AllowedScopes = { "demo_api", "api1" }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "office",
                    DisplayName = "Your office info",
                    UserClaims = {"office_number"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("api1", "My Api Demo app"),
                new ApiResource("demo_api", "My Swagger app"), 
            };
        }
    }
}