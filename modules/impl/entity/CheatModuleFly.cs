using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.entity
{
    public class CheatModuleFly : CheatModuleEntity
    {
        public CheatModuleFly(KeyCode k, bool enabled = false) : base(k, enabled)
        {
        }

        public override string GetName()
        {
            return "Fly";
        }

        public override void HandleCheat(Player_move_c t)
        {
            if (!IsEnabled()) return;
            CharacterController characterController = t.GetComponentInParent<CharacterController>();
            if (characterController == null) return;
            if (Input.GetKey(KeyCode.Space))
            {
                characterController.Move(new Vector3(0, 0.5f, 0));
            }
        }
    }
}