using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelGunCheat.modules;

public abstract class CheatModuleWeapon : CheatModule<WeaponSounds>
{
    protected CheatModuleWeapon(KeyCode k, bool enabled = false) : base(k, enabled)
    {
    }
    
    public abstract override void HandleCheat(WeaponSounds t);
}