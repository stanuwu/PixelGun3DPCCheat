using UnityEngine.InputSystem;

namespace PixelGunCheat.modules;

public abstract class CheatModuleWeapon : CheatModule<WeaponSounds>
{
    protected CheatModuleWeapon(Key k, bool enabled = false) : base(k, enabled)
    {
    }
    
    public abstract override void HandleCheat(WeaponSounds t);
}