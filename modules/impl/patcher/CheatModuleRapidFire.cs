using HarmonyLib;
using UnityEngine;

namespace PixelGunCheat.modules.impl.patcher
{
    public class CheatModuleRapidFire : CheatModulePatcher
    {
        public static bool isEnabled = false;

        public CheatModuleRapidFire(KeyCode k, bool enabled = false) : base(k, enabled)
        {
        }

        public override string GetName()
        {
            return "RapidFire";
        }

        public override void HandleCheat(MonoBehaviour t = null)
        {
            isEnabled = IsEnabled();
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(BalanceController), "Method_Internal_Static_Single_Int32_6")]
        static bool Method_Internal_Static_Single_Int32_6Prefix(ref float __result)
        {
            if (isEnabled)
            {
                __result = 99999;
                return false;
            }

            return true;
        }
    }
}