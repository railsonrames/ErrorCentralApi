using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4.Test;
using System.Security.Claims;
using IdentityServer4;

namespace ErrorCentralApi
{
    public static class IdentityConfiguration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId()              
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>() { 
                new ApiResource("CentralErro")
            };            
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>() { 
                new Client
                {
                    ClientId = "centralerror.api_client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = {
                        new Secret("centralerror.api_secret".Sha256())
                    },
                    AllowedScopes = {  
                        IdentityServerConstants.StandardScopes.OpenId,
                        "centralerror"
                    },
                    AlwaysIncludeUserClaimsInIdToken = true
                }
            };
        }

        public static List<TestUser> GetUsers()
        {            
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password",
                    Claims = new [] { 
                        new Claim(ClaimTypes.Role, "admin"), 
                        new Claim(ClaimTypes.Email, "alice@mail.com")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password",
                    Claims = new [] { 
                        new Claim(ClaimTypes.Role, "user"), 
                        new Claim(ClaimTypes.Email, "bob@mail.com")
                    }
                }
            };
        }
    }
}
