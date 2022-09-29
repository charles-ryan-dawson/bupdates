using Bupdates.Application.Common.Entities;
using Bupdates.Application.Infrastructure.Children;
using Bupdates.Application.Infrastructure.Guardians;

namespace Bupdates.Application.Guardians.AddGuardianToChild;

public class AddGuardianToChildUseCase : IAddGuardianToChildUseCase
{
    private readonly IGetChild _getChild;
    private readonly IGetGuardian _getGuardian;
    private readonly IAddGuardian _addGuardian;
    private readonly IUpdateGuardian _updateGuardian;

    public AddGuardianToChildUseCase(
        IGetChild getChild,
        IGetGuardian getGuardian,
        IAddGuardian addGuardian,
        IUpdateGuardian updateGuardian)
    {
        _getChild = getChild;
        _getGuardian = getGuardian;
        _addGuardian = addGuardian;
        _updateGuardian = updateGuardian;
    }
    public async Task<AddGuardianToChildResponse> ExecuteAsync(AddGuardianToChildRequest request)
    {
        try
        {
            var child = await _getChild.ByIdAsync(request.ChildId);
            if (child == null)
            {
                return new AddGuardianToChildResponse.MissingChild();
            }

            var guardian = await _getGuardian.ByEmailAddressAAsync(request.EmailAddress);
            if (guardian != null)
            {
                if (guardian.Children.Any(c => c.Id == child.Id))
                {
                    return new AddGuardianToChildResponse.GuardianExistsForChild();
                }
                guardian.Children.Add(child);
                guardian = await _updateGuardian.ExecuteAsync(guardian);
            }
            else
            {
                guardian = new Guardian
                {
                    Email = request.EmailAddress,
                    Children = new List<Child> {child}
                };
                guardian = await _addGuardian.ExecuteAsync(guardian);
            }

            return new AddGuardianToChildResponse.Success(guardian);
        }
        catch (Exception ex)
        {
            return new AddGuardianToChildResponse.Error(ex.Message);
        }
    }
}