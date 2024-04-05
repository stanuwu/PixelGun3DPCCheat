using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.weapon;

public class CheatModuleNoRecoil : CheatModuleWeapon
{
    public CheatModuleNoRecoil(KeyCode k) : base(k, true)
    {
    }

    public override string GetName()
    {
        return "NoRecoil";
    }

    public override void HandleCheat(WeaponSounds t)
    {
        if (!IsEnabled()) return;
        t.recoilCoeff = 0;
        t.recoilCoeffZoom = 0;
        t.moveScatterCoeff = 0;
        t.moveScatterCoeffZoom = 0;
    }
}