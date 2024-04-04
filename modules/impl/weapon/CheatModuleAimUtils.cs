using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.weapon;

public class CheatModuleAimUtils : CheatModuleWeapon
{
    public CheatModuleAimUtils(Key k) : base(k, true)
    {
    }

    public override string GetName()
    {
        return "BetterADS";
    }

    public override void HandleCheat(WeaponSounds t)
    {
        if (!IsEnabled()) return;
        t.scopeSpeed = 0;
        t.zoomXray = true;
    }
}