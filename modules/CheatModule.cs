using Photon;
using UnityEngine.InputSystem;

namespace PixelGunCheat.modules;

public abstract class CheatModule<T> : ICheatModule
{
    protected CheatModule(Key k, bool enabled = false)
    {
        Keybind = k;
        Enabled = enabled;
    }
    
    public void ToggleModule()
    {
        Enabled = !Enabled;
    }

    public bool IsEnabled()
    {
        return Enabled;
    }

    public abstract string GetName();

    public abstract void HandleCheat(T t);
    
    private Key Keybind { get; set; }
    private bool Enabled { get; set; }
}