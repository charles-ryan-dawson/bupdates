using Bupdates.Application.Common.Entities;

namespace Bupdates.Application.Guardians.AddGuardianToChild;
public record AddGuardianToChildResponse
{
    public record Success(Guardian Guardian) : AddGuardianToChildResponse;
    public record MissingChild() : AddGuardianToChildResponse;
    public record GuardianExistsForChild() : AddGuardianToChildResponse;
    public record Error(string Message) : AddGuardianToChildResponse;
}