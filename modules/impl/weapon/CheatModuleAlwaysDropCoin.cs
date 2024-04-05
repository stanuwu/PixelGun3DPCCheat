using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.weapon;

public class CheatModuleAlwaysDropCoin : CheatModuleWeapon
{
    public CheatModuleAlwaysDropCoin(KeyCode k) : base(k)
    {
    }

    public override string GetName()
    {
        return "CoinDrop";
    }

    public override void HandleCheat(WeaponSounds t)
    {
        if (!IsEnabled()) return;
        t.isCoinDrop = true;
        t.coinDropChance = float.MaxValue;
    }
}