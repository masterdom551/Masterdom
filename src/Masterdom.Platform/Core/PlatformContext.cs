using System;
using Masterdom.Platform.Modules;

namespace Masterdom.Platform.Core;

/// <summary>
/// Represents the platform context that is shared with modules.
/// </summary>
public sealed class PlatformContext : IPlatformContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PlatformContext"/> class.
    /// </summary>
    /// <param name="modules">The platform module catalog.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="modules"/> is <see langword="null"/>.
    /// </exception>
    public PlatformContext(IModuleCatalog modules)
    {
        Modules = modules ?? throw new ArgumentNullException(nameof(modules));
    }

    /// <inheritdoc/>
    public IModuleCatalog Modules { get; }
}