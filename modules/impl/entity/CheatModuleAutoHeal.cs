using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.entity;

public class CheatModuleAutoHeal : CheatModuleEntity
{
    public CheatModuleAutoHeal(KeyCode k) : base(k)
    {
    }

    public override string GetName()
    {
        return "AutoHeal";
    }

    public override void HandleCheat(Player_move_c t)
    {
        if (!IsEnabled()) return;
        if (t.field_Internal_PlayerDamageable_0 == null) return;
        t.field_Internal_PlayerDamageable_0.AddHealthFromWeaponOnline(99999f, "");
    }
}