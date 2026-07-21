using Masterdom.Host.Modules;
using Masterdom.Platform.Core;

namespace Masterdom.Host;

/// <summary>
/// Bootstraps the Masterdom platform.
/// </summary>
public sealed class Bootstrapper
{
    private readonly Kernel _kernel;

    public Bootstrapper()
    {
        _kernel = new Kernel();
    }

    public void Start()
    {
        _kernel.LoadModule(new TestModule());
        _kernel.Start();
    }

    public void Stop()
    {
        _kernel.Stop();
    }
}