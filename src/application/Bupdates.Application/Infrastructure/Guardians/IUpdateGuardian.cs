using Bupdates.Application.Common.Entities;

namespace Bupdates.Application.Infrastructure.Guardians;

public interface IUpdateGuardian
{
    Task<Guardian> ExecuteAsync(Guardian guardian);
}