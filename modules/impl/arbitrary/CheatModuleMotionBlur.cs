using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;

namespace PixelGunCheat.modules.impl.arbitrary;

public class CheatModuleMotionBlur : CheatModuleArbitrary
{
    public CheatModuleMotionBlur(Key k) : base(k, true)
    {
    }

    public override string GetName()
    {
        return "NoMotionBlur";
    }

    public override void HandleCheat(GameObject g = null)
    {
        foreach (PostProcessVolume postProcessVolume in Object.FindObjectsOfType<PostProcessVolume>())
        {
            if (postProcessVolume == null || postProcessVolume.m_InternalProfile == null) continue;
            foreach (PostProcessEffectSettings postProcessEffectSettings in postProcessVolume.m_InternalProfile.settings)
            {
                if (postProcessEffectSettings == null) continue;
                if (postProcessEffectSettings.name.Contains("blur") ||
                    postProcessEffectSettings.name.Contains("Blur"))
                {
                    postProcessEffectSettings.active = !IsEnabled();
                }
            }
        }
    }
}