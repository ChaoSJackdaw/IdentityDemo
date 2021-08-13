using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWithIs4
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScope=>
            new List<ApiScope> 
            { 
                new ApiScope("api1", "My Api")

            };

        public static IEnumerable<Client> clients =>
            new List<Client>
            { 
                // machine to machine client
                new Client
                {
                    ClientId = "mvc2",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Implicit,

                    // where to redirect to after login
                    RedirectUris = { "https://120.78.208.87:8081/signin-oidc" },
                    
                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://120.78.208.87:8081/signout-callback-oidc" },

                    //  RequireConsent = true,

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },
                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Implicit,

                    // where to redirect to after login
                    RedirectUris = { "https://120.78.208.87:8080/signin-oidc" },
                    
                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://120.78.208.87:8080/signout-callback-oidc" },

                    //  RequireConsent = true,

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };


    }
}
