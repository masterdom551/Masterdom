using Masterdom.Platform.Modules;
using Masterdom.TestKit.Platform;
using Xunit;

namespace Masterdom.Platform.Tests.Kernel;

/// <summary>
/// Tests for <see cref="ModuleRegistry"/>.
/// </summary>
public sealed class ModuleRegistryTests
{
    [Fact]
    public void Register_ShouldIncreaseCount()
    {
        // Arrange
        var registry = new ModuleRegistry();

        // Act
        registry.Register(new TestModule("people"));

        // Assert
        Assert.Equal(1, registry.Count);
    }
}
