using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.entity
{
    public class CheatModuleSpeed : CheatModuleEntity
    {
        public CheatModuleSpeed(KeyCode k) : base(k)
        {
        }

        public override string GetName()
        {
            return "Speed";
        }

        public override void HandleCheat(Player_move_c t)
        {
            if (!IsEnabled()) return;
            CharacterController characterController = t.GetComponentInParent<CharacterController>();
            if (characterController == null) return;
            characterController.Move(characterController.velocity / 25);
        }
    }
}