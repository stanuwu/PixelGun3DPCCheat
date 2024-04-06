using System.Collections.Generic;
using HarmonyLib;
using Rilisoft;
using UnityEngine;
using Logger = BepInEx.Logging.Logger;

namespace PixelGunCheat.modules.impl.patcher
{
    public class InfiniteGemClaim : CheatModulePatcher
    {
        public static bool isEnabled = false;
        public InfiniteGemClaim(KeyCode k, bool enabled = false) : base(k, enabled)
        {
        }

        public override string GetName()
        {
            return "InfiniteGemClaim";
        }

        public override void HandleCheat(MonoBehaviour t = null)
        {
            isEnabled = IsEnabled();
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ObjectPrivateAc1AcObLi1ObStAlAcUnique), "Method_Internal_Static_Boolean_Object1PrivateSealedItObCaItInObInItUnique_1")]
        static bool Method_Internal_Static_Boolean_Object1PrivateSealedItObCaItInObInItUnique_1Prefix(ref bool __result)
        {
            if (isEnabled)
            {
                __result = true;
                return false;
            }

            return true;
        }
    }
}