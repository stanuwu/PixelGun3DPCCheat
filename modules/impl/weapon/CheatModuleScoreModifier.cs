using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.weapon;

public class CheatModuleScoreModifier : CheatModuleWeapon
{
    public CheatModuleScoreModifier(KeyCode k) : base(k)
    {
    }

    public override string GetName()
    {
        return "ScoreMultiplier";
    }

    public override void HandleCheat(WeaponSounds t)
    {
        if (!IsEnabled()) return;
        t.isBuffPoints = true;
        t.buffPointsKillDesigner = true;
        t.buffPointsAssistDesigner = true;
        t.buffPointsRevengeDesigner = true;
        t.buffBonusPointsForKill = 9999f;
        t.buffBonusPointsForAssist = 9999f;
        t.buffPointsRevenge = 9999f;
    }
}