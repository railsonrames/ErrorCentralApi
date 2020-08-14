using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ErrorCentralApi.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;

namespace ErrorCentralApi.Services
{
    public class UserProfileService : IProfileService
    {
        private readonly ErrorCentralDataContext _dbContext;
        public UserProfileService(ErrorCentralDataContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var request = context.ValidatedRequest as ValidatedTokenRequest;
            if (request != null)
            {
                User user = _dbContext.Users.FirstOrDefault(x => x.Email == request.UserName);

                if (user != null)
                    context.IssuedClaims = GetUserClaims(user)
                        .Where(x => context.RequestedClaimTypes.Contains(x.Type))
                        .ToList();
            }

            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }

        public static Claim[] GetUserClaims(User user)
        {
            string role = "User";
            if (user.Email == "tegglestone9@blog.com")
                role = "Admin";

            return new []
            {
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim(ClaimTypes.Role, role)
            };
        }
    }
}