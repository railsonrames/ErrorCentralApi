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
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()              
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>() { 
                new ApiResource(
                    name: "centralerror", 
                    displayName: "Central de Erros API v1"
                )
            };            
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>() { 
                new Client
                {
                    ClientId = "wizcodenation",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = {
                        new Secret("wizcodenation".Sha256())
                    },
                    AllowedScopes = {  
                        IdentityServerConstants.StandardScopes.OpenId
                    },
                    AlwaysIncludeUserClaimsInIdToken = true
                }
            };
        }
    }
}
