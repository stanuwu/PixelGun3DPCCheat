using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.weapon;

/**
 * A testing class for new modules and miscellaneous cheats that don't deserve a separate module 
 */
public class CheatModuleDevMisc : CheatModuleWeapon
{
    public CheatModuleDevMisc(KeyCode k) : base(k)
    {
    }

    public override string GetName()
    {
        return "WeaponMisc";
    }

    public override void HandleCheat(WeaponSounds t)
    {
        if (!IsEnabled()) return;
        t.Probability = 100;
    }
}