﻿using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.entity;

public class CheatModuleInfiniteAmmoV2 : CheatModuleEntity
{
    public CheatModuleInfiniteAmmoV2(Key k) : base(k)
    {
    }

    public override string GetName()
    {
        return "InfiniteAmmoV2";
    }

    public override void HandleCheat(Player_move_c t)
    {
        if (!IsEnabled()) return;
        if (t.field_Internal_PlayerDamageable_0 == null) return;
        t.field_Internal_PlayerDamageable_0.AddAmmoFromWeaponOnline(99999f);
    }
}