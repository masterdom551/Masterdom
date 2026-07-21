namespace Masterdom.Abstractions.Modules;

/// <summary>
/// Represents a platform module.
/// </summary>
public interface IModule
{
    /// <summary>
    /// Gets the unique module identifier.
    /// </summary>
    string Id { get; }

    /// <summary>
    /// Gets the display name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the module version.
    /// </summary>
    Version Version { get; }
}
