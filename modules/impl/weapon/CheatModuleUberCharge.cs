using UnityEngine;

namespace PixelGunCheat.modules.impl.weapon;

public class CheatModuleUberCharge : CheatModuleWeapon
{
    public CheatModuleUberCharge(KeyCode k, bool enabled = false) : base(k, enabled)
    {
    }

    public override string GetName()
    {
        return "UberCharge";
    }

    public override void HandleCheat(WeaponSounds t)
    {
        if (!IsEnabled()) return;
        t.chargeLoop = true;
        t.chargeMax = 0;
        t.chargeTime = 0f;
        t.isCharging = false;
    }
}