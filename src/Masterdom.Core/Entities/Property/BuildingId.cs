using Masterdom.Core.Identity;

namespace Masterdom.Core.Entities.Property;

/// <summary>
/// Represents the unique identifier of a building.
/// </summary>
public sealed record BuildingId(Guid Value)
    : StronglyTypedId<Guid>(Value)
{
    public static BuildingId New() => new(Guid.CreateVersion7());
}
