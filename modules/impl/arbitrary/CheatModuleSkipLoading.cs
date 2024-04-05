using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace PixelGunCheat.modules.impl.arbitrary
{
    public class CheatModuleSkipLoading : CheatModuleArbitrary
    {
        public CheatModuleSkipLoading(KeyCode k, bool enabled = false) : base(k, enabled)
        {
        }

        public override string GetName()
        {
            return "Skip Loading";
        }

        public override void HandleCheat(GameObject g = null)
        {
            if (!IsEnabled()) return;
            ToggleModule();
            SceneManager.LoadScene(2);
        }
    }
}