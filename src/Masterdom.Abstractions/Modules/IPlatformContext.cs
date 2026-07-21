namespace Masterdom.Abstractions.Modules;

/// <summary>
/// Provides access to platform services available to modules.
/// </summary>
public interface IPlatformContext
{
    IModuleCatalog Modules { get; }
}
