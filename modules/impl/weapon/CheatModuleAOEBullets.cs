using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.weapon;

public class CheatModuleAOEBullets : CheatModuleWeapon
{
    public CheatModuleAOEBullets(KeyCode k) : base(k)
    {
    }

    public override string GetName()
    {
        return "AOEBullets";
    }

    public override void HandleCheat(WeaponSounds t)
    {
        if (!IsEnabled()) return;
        t.isSectorsAOE = true;
        t.flamethrower = false;
        t.railgun = false;
        t.bazooka = false;
        t.harpoon = false;
        t.sectorsAOEAngleBack = 360;
        t.sectorsAOEAngleFront = 360;
        t.sectorsAOEDamageMultiplierBack = 5f;
        t.sectorsAOEDamageMultiplierFront = 5f;
        t.sectorsAOEDamageMultiplierSide = 5f;
        t.sectorsAOERadiusSectorsAoE = 99999f;
    }
}