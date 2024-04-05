using Photon;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelGunCheat.modules;

public abstract class CheatModule<T> : ICheatModule
{
    protected CheatModule(KeyCode k, bool enabled = false)
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
    
    public KeyCode GetKey()
    {
        return Keybind;
    }

    public abstract void HandleCheat(T t);
    
    private KeyCode Keybind { get; set; }
    private bool Enabled { get; set; }
}