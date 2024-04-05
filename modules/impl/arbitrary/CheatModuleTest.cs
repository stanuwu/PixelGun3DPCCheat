using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

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