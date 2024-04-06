
using System;
using HarmonyLib;
using PGCompany;
using Progress;
using Rilisoft;
using UnityEngine;
using Object = UnityEngine.Object;


namespace PixelGunCheat.modules.impl.arbitrary
{
    public class CheatModuleTest : CheatModuleArbitrary
    {
        public CheatModuleTest(KeyCode k) : base(k)
        {
        }

        public override string GetName()
        {
            return "Test";
        }

        public override void HandleCheat(GameObject g = null)
        {
        }
    }
}