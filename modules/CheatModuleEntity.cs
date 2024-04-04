using UnityEngine.InputSystem;

namespace PixelGunCheat.modules;

public abstract class CheatModuleEntity : CheatModule<Player_move_c>
{
    protected CheatModuleEntity(Key k, bool enabled = false) : base(k, enabled)
    {
    }

    public abstract override void HandleCheat(Player_move_c t);
}