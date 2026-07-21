using System;
using System.Collections.Generic;
using Masterdom.Platform.Modules;

namespace Masterdom.Platform.Core;

/// <summary>
/// Represents the Masterdom platform kernel.
/// </summary>
public sealed class Kernel
{
    private readonly ModuleRegistry _moduleRegistry;
    private readonly ModuleLoader _moduleLoader;
    private readonly PlatformContext _platformContext;
    private readonly List<IModule> _initializedModules = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Kernel"/> class.
    /// </summary>
    public Kernel()
    {
        _moduleRegistry = new ModuleRegistry();
        _moduleLoader = new ModuleLoader();
        _platformContext = new PlatformContext(_moduleRegistry);

        State = KernelState.Created;
    }

    /// <summary>
    /// Gets the current kernel state.
    /// </summary>
    public KernelState State { get; private set; }

    /// <summary>
    /// Gets the platform context.
    /// </summary>
    public IPlatformContext Context => _platformContext;

    /// <summary>
    /// Loads a module into the platform.
    /// </summary>
    /// <param name="module">The module to load.</param>
    public void LoadModule(IModule module)
    {
        EnsureState(KernelState.Created);

        _moduleLoader.Load(module, _moduleRegistry);
    }

    /// <summary>
    /// Starts the platform kernel.
    /// </summary>
    public void Start()
    {
        EnsureState(KernelState.Created);

        State = KernelState.Starting;

        _initializedModules.Clear();

        try
        {
            foreach (var module in _moduleRegistry)
            {
                module.Initialize(_platformContext);
                _initializedModules.Add(module);
            }

            State = KernelState.Running;
        }
        catch
        {
            for (int i = _initializedModules.Count - 1; i >= 0; i--)
            {
                try
                {
                    _initializedModules[i].Shutdown(_platformContext);
                }
                catch
                {
                    // Ignore rollback failures.
                }
            }

            _initializedModules.Clear();

            State = KernelState.Faulted;

            throw;
        }
    }

    /// <summary>
    /// Stops the platform kernel.
    /// </summary>
    public void Stop()
    {
        EnsureState(KernelState.Running);

        State = KernelState.Stopping;

        for (int i = _initializedModules.Count - 1; i >= 0; i--)
        {
            try
            {
                _initializedModules[i].Shutdown(_platformContext);
            }
            catch
            {
                // Continue shutting down remaining modules.
            }
        }

        _initializedModules.Clear();

        State = KernelState.Stopped;
    }

    private void EnsureState(KernelState expectedState)
    {
        if (State != expectedState)
        {
            throw new InvalidOperationException(
                $"Kernel is in state '{State}' but expected '{expectedState}'.");
        }
    }
}