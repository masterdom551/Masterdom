using Masterdom.Core.Identity;

namespace Masterdom.Core.Entities.Property;

/// <summary>
/// Represents the unique identifier of a unit.
/// </summary>
public sealed record UnitId(Guid Value)
    : StronglyTypedId<Guid>(Value)
{
    public static UnitId New() => new(Guid.CreateVersion7());
}
