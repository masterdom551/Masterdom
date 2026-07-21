using Masterdom.Platform.Core;
using Masterdom.Platform.Modules;

namespace Masterdom.TestKit.Platform;

/// <summary>
/// Minimal platform context for unit tests.
/// </summary>
public sealed class FakePlatformContext : IPlatformContext
{
    public required IModuleCatalog Modules { get; init; }
}
