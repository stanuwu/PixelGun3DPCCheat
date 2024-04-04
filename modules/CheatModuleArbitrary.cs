using Il2CppSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelGunCheat.modules;

public abstract class CheatModuleArbitrary : CheatModule<GameObject>
{
    protected CheatModuleArbitrary(Key k, bool enabled = false) : base(k, enabled)
    {
    }

    public abstract override void HandleCheat(GameObject g = null);
}
