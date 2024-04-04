using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.weapon;

public class CheatModuleInfiniteAmmo : CheatModuleWeapon
{
    public CheatModuleInfiniteAmmo(Key k) : base(k, true)
    {
    }

    public override string GetName()
    {
        return "InfiniteAmmo";
    }

    public override void HandleCheat(WeaponSounds t)
    {
        if (!IsEnabled()) return;
        var itemRecord = t.prop_ItemRecord_0;
                
        if (itemRecord != null)
        {
            itemRecord.isUnlimitedAmmo = true;
            itemRecord.modulesClipAmmoModifier = 99999;
        }
    }
}