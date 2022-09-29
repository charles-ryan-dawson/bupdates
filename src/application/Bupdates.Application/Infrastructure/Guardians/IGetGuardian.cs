using Bupdates.Application.Common.Entities;

namespace Bupdates.Application.Infrastructure.Guardians;

public interface IGetGuardian
{
    Task<Guardian> ByIdAsync(int guardianId);
    Task<Guardian> ByEmailAddressAAsync(string emailAddress);
}