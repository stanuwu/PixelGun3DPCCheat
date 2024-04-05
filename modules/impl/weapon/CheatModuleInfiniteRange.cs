using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.weapon;

public class CheatModuleInfiniteRange : CheatModuleWeapon
{
    public CheatModuleInfiniteRange(KeyCode k) : base(k, true)
    {
    }

    public override string GetName()
    {
        return "Reach";
    }

    public override void HandleCheat(WeaponSounds t)
    {
        if (!IsEnabled()) return;
        t.range = 999999f;
        t.damageRange = new Vector2(999999, 999999);
    }
}