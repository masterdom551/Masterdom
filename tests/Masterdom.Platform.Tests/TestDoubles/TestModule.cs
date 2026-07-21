using System;
using Masterdom.Platform.Core;
using Masterdom.Platform.Modules;

namespace Masterdom.Platform.Tests.TestDoubles;

/// <summary>
/// Test implementation of a platform module.
/// </summary>
public sealed class TestModule : ModuleBase
{
    public TestModule(string id)
        : base(new ModuleDescriptor
        {
            Id = id,
            Name = id,
            DisplayName = id,
            Version = "1.0.0",
            Description = "Test module"
        })
    {
    }

    public override void Initialize(IPlatformContext context)
    {
        base.Initialize(context);
    }

    public override void Shutdown(IPlatformContext context)
    {
        base.Shutdown(context);
    }
}
