using System.Linq;
using System.Threading.Tasks;
using ErrorCentralApi.Models;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace ErrorCentralApi.Services
{
    public class PasswordValidatorService : IResourceOwnerPasswordValidator
    {
    
        private readonly ErrorCentralDataContext _dbContext;
        public PasswordValidatorService(ErrorCentralDataContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {   
            var user = _dbContext
                .Users.FirstOrDefault(u => u.Email.Equals(context.UserName));
            if (user != null && user.Password.Equals(context.Password.Sha256()))
            {
                context.Result = new GrantValidationResult(
                    subject: user.Id.ToString(),
                    authenticationMethod: "custom",
                    claims: UserProfileService.GetUserClaims(user)
                );
            }
            else
            {
                context.Result = new GrantValidationResult(
                TokenRequestErrors.InvalidGrant, "Invalid username or password");
            }
            return Task.CompletedTask;

        }
     
    }
}