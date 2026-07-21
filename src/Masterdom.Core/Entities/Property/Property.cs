using Masterdom.Core.Primitives;

namespace Masterdom.Core.Entities.Property;

/// <summary>
/// Represents a managed property within the Masterdom platform.
/// </summary>
public sealed class Property : AggregateRoot<PropertyId>
{
    private readonly List<Building> _buildings = [];

    private Property(
        PropertyId id,
        PropertyCode code,
        string name,
        PropertyType type,
        PropertyStatus status)
        : base(id)
    {
        Code = code;
        Name = name;
        Type = type;
        Status = status;
    }

    /// <summary>
    /// Creates a new property.
    /// </summary>
    public static Property Create(
        PropertyCode code,
        string name,
        PropertyType type)
    {
        ArgumentNullException.ThrowIfNull(code);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        return new Property(
            PropertyId.New(),
            code,
            name.Trim(),
            type,
            PropertyStatus.Active);
    }

    /// <summary>
    /// Gets the business code.
    /// </summary>
    public PropertyCode Code { get; }

    /// <summary>
    /// Gets the display name.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the property type.
    /// </summary>
    public PropertyType Type { get; private set; }

    /// <summary>
    /// Gets the current status.
    /// </summary>
    public PropertyStatus Status { get; private set; }

    /// <summary>
    /// Gets the buildings belonging to this property.
    /// </summary>
    public IReadOnlyCollection<Building> Buildings => _buildings;

    /// <summary>
    /// Renames the property.
    /// </summary>
    public void Rename(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Name = name.Trim();
    }

    /// <summary>
    /// Changes the property type.
    /// </summary>
    public void ChangeType(PropertyType type)
    {
        Type = type;
    }

    /// <summary>
    /// Activates the property.
    /// </summary>
    public void Activate()
    {
        Status = PropertyStatus.Active;
    }

    /// <summary>
    /// Deactivates the property.
    /// </summary>
    public void Deactivate()
    {
        Status = PropertyStatus.Inactive;
    }

    /// <summary>
    /// Archives the property.
    /// </summary>
    public void Archive()
    {
        Status = PropertyStatus.Archived;
    }

    /// <summary>
    /// Adds a building to the property.
    /// </summary>
    public void AddBuilding(Building building)
    {
        ArgumentNullException.ThrowIfNull(building);

        if (_buildings.Any(x => x.Id == building.Id))
        {
            return;
        }

        _buildings.Add(building);
    }

    /// <summary>
    /// Removes a building from the property.
    /// </summary>
    public bool RemoveBuilding(BuildingId buildingId)
    {
        var building = _buildings.FirstOrDefault(x => x.Id == buildingId);

        if (building is null)
        {
            return false;
        }

        _buildings.Remove(building);

        return true;
    }
}
