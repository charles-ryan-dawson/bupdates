namespace Bupdates.Application.Guardians.AddGuardianToChild;

public interface IAddGuardianToChildUseCase
{
    Task<AddGuardianToChildResponse> ExecuteAsync(AddGuardianToChildRequest request);
}