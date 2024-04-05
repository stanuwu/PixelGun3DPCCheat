using System.Collections.Generic;
using System.Linq;
using BepInEx.Logging;
using PixelGunCheat.modules.impl.arbitrary;
using PixelGunCheat.modules.impl.weapon;
using PixelGunCheat.modules.impl.entity;
using UnityEngine;
using UnityEngine.InputSystem;
using Logger = BepInEx.Logging.Logger;
using Renderer = PixelGunCheat.util.Renderer;

namespace PixelGunCheat
{
    public class CheatManager : MonoBehaviour
    {
        private readonly CheatModuleNoRecoil _modNoRecoil = new(Key.None);
        private readonly CheatModuleAllFullAuto _modAllFullAuto = new(Key.None);
        private readonly CheatModuleInfiniteRange _modInfRange = new(Key.None);
        private readonly CheatModuleAimUtils _modAimUtils = new(Key.None);
        private readonly CheatModuleScoreModifier _modScoreModif = new(Key.None);
        private readonly CheatModuleAlwaysDropCoin _modCoinDrop = new(Key.None);
        private readonly CheatModuleIceSwordGlobalAura _modIceSwordAura = new(Key.None);
        private readonly CheatModuleAOEBullets _modAOEBullet = new(Key.None);
        private readonly CheatModuleForceCriticals _modForceCrit = new(Key.None);
        private readonly CheatModuleInfiniteAmmo _modInfAmmo = new(Key.None);
        private readonly CheatModuleForceCancer _modEffectSpam = new(Key.None);
        private readonly CheatModuleDropTeleport _modDropTeleport = new(Key.None);
        private readonly CheatModuleInvisibility _modInvis = new(Key.None);
        private readonly CheatModuleAutoHeal _modAutoHeal = new(Key.None);
        private readonly CheatModuleSpeed _modSpeed = new(Key.None);
        private readonly CheatModuleAimBot _modAimBot = new(Key.None);
        private readonly CheatModuleEsp _modEsp = new(Key.None);
        private readonly CheatModuleMotionBlur _modMotionBlur = new(Key.None);
        private readonly CheatModuleGemGenerator _modGemGenerator = new(Key.None);
        private readonly CheatModuleCoinGenerator _modCoinGenerator = new(Key.None);
        private readonly CheatModuleUberCharge _modUberCharge = new(Key.None);
        
        private readonly CheatModuleHud _modHud = new(Key.None);
        
        private readonly CheatModuleTest _modTest = new(Key.None);

        private List<Player_move_c> playerList = new();
        private long tickCount = 0;
        private long fixedTickCount = 0;
        private GameController gameController;
        private Player_move_c player;
        private bool _initMat = false;
        private ManualLogSource logger = Logger.CreateLogSource("Cheat");
        private Camera main = null;

        private void Awake()
        {
            Debug.Log("Loaded Cheat");
            gameObject.hideFlags = HideFlags.HideAndDontSave;
            _modHud.registerModules(_modNoRecoil, _modAllFullAuto, _modUberCharge, _modInfRange, _modAimUtils, _modScoreModif, _modCoinDrop, _modIceSwordAura, _modAOEBullet, _modForceCrit, _modInfAmmo, _modEffectSpam, _modDropTeleport, _modSpeed, _modAimBot, _modEsp, _modMotionBlur, _modInvis, _modAutoHeal, _modGemGenerator, _modCoinGenerator);
        }

        private void OnDestroy()
        {
            Debug.Log("Destroyed Cheat");
        }

        private void Update()
        {
            tickCount++;
            
            if (tickCount % 60 == 0)
            {
                main = Camera.main;
                if (main == null) return;
                gameController = FindObjectOfType<GameController>();
                playerList = FindObjectsOfType<Player_move_c>().ToList();
                _modAimBot.UpdatePlayerList(playerList, main);
                _modEsp.UpdatePlayerList(playerList, main);
                if (playerList.Count < 1) return;
                player = playerList.Find(p => p.nickLabel.text == "1111");
            }

            if (gameController == null || player == null) return;
            
            // Test Module
            _modTest.HandleCheat();

            // Motion Blur
            if (tickCount % 600 == 0)
            {
                _modMotionBlur.HandleCheat();
            }

            // Ammo and Reloads
            WeaponSounds weaponSounds = FindObjectsOfType<WeaponSounds>().ToList().Find(s =>
            {
                if (s.prop_Player_move_c_0 == null) return false;
                return s.prop_Player_move_c_0.nickLabel.text == player.nickLabel.text;
            });
            
            if (weaponSounds != null)
            {
                // No Recoil
                _modNoRecoil.HandleCheat(weaponSounds);
                
                // Max Speed + Full Auto
                _modAllFullAuto.HandleCheat(weaponSounds);
                
                // Insta Max Charge Auto Shoot
                _modUberCharge.HandleCheat(weaponSounds);

                // Instant ADS and XRAY
                _modAimUtils.HandleCheat(weaponSounds);
                
                // Range Test
                _modInfRange.HandleCheat(weaponSounds);
                
                // Kill Score Modifier
                _modScoreModif.HandleCheat(weaponSounds);

                // Force Critical Hits
                _modForceCrit.HandleCheat(weaponSounds);

                // AOE Bullet Damage
                _modAOEBullet.HandleCheat(weaponSounds);
                
                // Ice Sword Aura
                _modIceSwordAura.HandleCheat(weaponSounds);
                
                // Coin Generator
                _modCoinDrop.HandleCheat(weaponSounds);

                // Unlimited Ammo
                _modInfAmmo.HandleCheat(weaponSounds);
                
                // Unlimited Ammo
                _modInfAmmo.HandleCheat(weaponSounds);
                
                // Gives Target All Effects (or at least tries to)
                _modEffectSpam.HandleCheat(weaponSounds);
            }

            // Invisibility
            _modInvis.HandleCheat(player);
            
            // Auto Heal Player When Possible
            _modAutoHeal.HandleCheat(player);
            
            // Aim Bot
            _modAimBot.HandleCheat();
        }

        private void OnGUI()
        {
            if (!_initMat)
            {
                Renderer.InitMat();
                _initMat = true;
            }

            _modHud.HandleCheat();
            
            _modEsp.HandleCheat();            

            _modAimBot.DrawTargetMarker();
        }
        
        private void FixedUpdate()
        {
            fixedTickCount++;
            
            if (player == null) return;

            if (fixedTickCount % 25 == 0)
            {
                // Drop TP
                _modDropTeleport.HandleCheat(player);
            }
            
            if (fixedTickCount % 100 == 0)
            {
                // Currency Generator
                _modGemGenerator.HandleCheat(player);
                _modCoinGenerator.HandleCheat(player);
            }
            
            // Speed Hack
            _modSpeed.HandleCheat(player);
        }
    }
}