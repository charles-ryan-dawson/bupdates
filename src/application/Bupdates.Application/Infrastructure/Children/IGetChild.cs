using Bupdates.Application.Common.Entities;

namespace Bupdates.Application.Infrastructure.Children;

public interface IGetChild
{
    Task<Child> ByIdAsync(int childId);
}