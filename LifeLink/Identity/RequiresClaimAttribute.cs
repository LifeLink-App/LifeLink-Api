using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LifeLink.Identity;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class RequiresClaimAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _claimName;
    private readonly string[] _claimValues;


    public RequiresClaimAttribute(string claimName, string claimValue)
    {
        _claimName = claimName;
        _claimValues = [claimValue];
    }

    public RequiresClaimAttribute(string claimName, string[] claimValues)
    {
        _claimName = claimName;
        _claimValues = claimValues;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        bool hasClaimValue = _claimValues.Any(claimValue => user.HasClaim(_claimName, claimValue));

        if (!hasClaimValue)
        {
            context.Result = new ForbidResult();
        }
    }
}
