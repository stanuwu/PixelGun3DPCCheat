using Il2CppSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using Logger = BepInEx.Logging.Logger;

namespace PixelGunCheat.modules.impl.entity
{
    public class CheatModuleBhop : CheatModuleEntity
    {
        public CheatModuleBhop(KeyCode k, bool enabled = false) : base(k, enabled)
        {
        }

        public override string GetName()
        {
            return "BunnyHop";
        }

        public override void HandleCheat(Player_move_c t)
        {
            if (!IsEnabled()) return;
            CharacterController characterController = t.GetComponentInParent<CharacterController>();
            if (characterController == null) return;

            var velVec = characterController.velocity;
            
            if (Mathf.Abs(velVec.x) != 0f || Mathf.Abs(velVec.z) != 0f) 
            {
                characterController.Move(new Vector3(0, 10f * Time.fixedDeltaTime, 0));
            }
            
            characterController.Move(new Vector3(velVec.x * Time.fixedDeltaTime * 1.25f, velVec.y * Time.fixedDeltaTime, velVec.z * Time.fixedDeltaTime * 1.25f));
        }
    }
}