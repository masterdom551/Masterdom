using Masterdom.Core.Identity;

namespace Masterdom.Core.Entities.Property;

/// <summary>
/// Represents the unique identifier of a floor.
/// </summary>
public sealed record FloorId(Guid Value)
    : StronglyTypedId<Guid>(Value)
{
    public static FloorId New() => new(Guid.CreateVersion7());
}
