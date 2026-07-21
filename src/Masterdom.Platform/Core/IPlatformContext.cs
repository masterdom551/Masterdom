using Masterdom.Platform.Modules;

namespace Masterdom.Platform.Core;

/// <summary>
/// Provides access to platform services available to modules.
/// </summary>
public interface IPlatformContext
{
    /// <summary>
    /// Gets the read-only catalog of loaded modules.
    /// </summary>
    IModuleCatalog Modules { get; }
}