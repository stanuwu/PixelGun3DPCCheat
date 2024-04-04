using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.weapon;

public class CheatModuleUberCharge : CheatModuleWeapon
{
    public CheatModuleUberCharge(Key k, bool enabled = false) : base(k, enabled)
    {
    }

    public override string GetName()
    {
        return "UberCharge";
    }

    public override void HandleCheat(WeaponSounds t)
    {
        t.chargeLoop = true;
        t.chargeMax = 0;
        t.chargeTime = 0f;
        t.isCharging = false;
    }
}