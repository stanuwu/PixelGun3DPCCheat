using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.weapon;

public class CheatModuleAllFullAuto :  CheatModuleWeapon
{
    public CheatModuleAllFullAuto(KeyCode k) : base(k, true)
    {
    }

    public override string GetName()
    {
        return "AllFullAuto";
    }

    public override void HandleCheat(WeaponSounds t)
    {
        if (!IsEnabled()) return;
        t.shootDelay = 0.000001f;
        t.bulletDelay = 0.000001f;
        t.delayInBurstShooting = 0.000001f;
        t.chargeTime = 0.000001f;
    }
}