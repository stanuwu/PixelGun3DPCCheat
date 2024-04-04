using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.weapon;

public class CheatModuleForceCriticals : CheatModuleWeapon
{
    public CheatModuleForceCriticals(Key k) : base(k, true)
    {
    }

    public override string GetName()
    {
        return "Criticals";
    }

    public override void HandleCheat(WeaponSounds t)
    {
        if (!IsEnabled()) return;
        t.firstKillCritical = true;
        t.SetNextHitCritical(true);
    }
}