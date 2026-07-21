namespace Masterdom.Abstractions.Modules;

/// <summary>
/// Discovers and loads platform modules.
/// </summary>
public interface IModuleLoader
{
    IModuleCatalog Load();
}
