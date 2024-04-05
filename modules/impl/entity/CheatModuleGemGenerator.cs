using Rilisoft;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.entity
{
    public class CheatModuleGemGenerator : CheatModuleEntity
    {
        public CheatModuleGemGenerator(KeyCode k) : base(k)
        {
        }

        public override string GetName()
        {
            return "GemGenerator";
        }

        public override void HandleCheat(Player_move_c t)
        {
            if(!IsEnabled()) return;
            for (int i = 1; i >= 0; i--)
            {
                GameObject gameObject = new GameObject();
                CoinBonus cb = gameObject.AddComponent<CoinBonus>();
                cb.player = t.gameObject;
                cb.field_Private_Player_move_c_0 = t;
                cb.CoinItemUpAudioClip = new AudioClip();
                cb.prop_EnumPublicSealedvaNoCoGe5vCoUnique_0 = EnumPublicSealedvaNoCoGe5vCoUnique.Gem;
                cb.field_Private_EnumPublicSealedvaNoCoGe5vCoUnique_0 = EnumPublicSealedvaNoCoGe5vCoUnique.Gem;
                cb.enabled = true;
                cb.SetPlayer();
                cb.Update();
                cb.Method_Private_Void_0();
            }
        }
    }
}