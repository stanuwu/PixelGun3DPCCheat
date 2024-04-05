using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.entity;

public class CheatModuleInvisibility : CheatModuleEntity
{
    public CheatModuleInvisibility(KeyCode k, bool enabled = false) : base(k, enabled)
    {
    }

    public override string GetName()
    {
        return "Invisibility";
    }

    public override void HandleCheat(Player_move_c t)
    {
        if (!IsEnabled()) return;
        t.MakeInvisibleForSeconds(5f);
        t.MakeInvisibleForSecondsRPC(5f);
    }
}