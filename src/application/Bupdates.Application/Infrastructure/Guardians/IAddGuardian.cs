using Bupdates.Application.Common.Entities;

namespace Bupdates.Application.Infrastructure.Guardians;

public interface IAddGuardian
{
    Task<Guardian> ExecuteAsync(Guardian guardian);
}
