using BepInEx;
using BepInEx.Unity.IL2CPP;
using Il2CppInterop.Runtime.Injection;
using UnityEngine;

namespace PixelGunCheat;

[BepInPlugin("com.stanuwu.pixelguncheat", "PixelGunCheat", "1.0.0")]
public class Plugin : BasePlugin
{
    public GameObject ManagerHook;
    
    public override void Load()
    {
        Debug.Log("Hooking");
        ClassInjector.RegisterTypeInIl2Cpp<CheatManager>();
        ManagerHook = new GameObject("ManagerHook");
        ManagerHook.AddComponent<CheatManager>();
        Object.DontDestroyOnLoad(ManagerHook);
        Debug.Log("Hooked");
    }
}
