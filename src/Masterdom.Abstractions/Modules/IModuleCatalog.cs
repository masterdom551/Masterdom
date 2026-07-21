namespace Masterdom.Abstractions.Modules;

/// <summary>
/// Represents a read-only collection of loaded modules.
/// </summary>
public interface IModuleCatalog : IReadOnlyCollection<IModule>
{
    bool Contains(string moduleId);

    IModule? Find(string moduleId);
}
