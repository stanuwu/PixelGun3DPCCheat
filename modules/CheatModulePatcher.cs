using HarmonyLib;
using UnityEngine;

namespace PixelGunCheat.modules
{
    public abstract class CheatModulePatcher : CheatModule<MonoBehaviour>
    {
        public CheatModulePatcher(KeyCode k, bool enabled = false) : base(k, enabled)
        {
            Harmony.CreateAndPatchAll(GetType()); 
        }

        public abstract override void HandleCheat(MonoBehaviour t = null);
    }
}