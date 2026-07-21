using Masterdom.Core.Identity;

namespace Masterdom.Core.Entities.Property;

/// <summary>
/// Represents the unique identifier of a property.
/// </summary>
public sealed record PropertyId(Guid Value)
    : StronglyTypedId<Guid>(Value)
{
    public static PropertyId New() => new(Guid.CreateVersion7());
}
