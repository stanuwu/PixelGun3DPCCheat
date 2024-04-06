using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx.Logging;
using PixelGunCheat.modules.impl.arbitrary;
using PixelGunCheat.modules.impl.weapon;
using PixelGunCheat.modules.impl.entity;
using PixelGunCheat.modules.impl.patcher;
using UnityEngine;
using Logger = BepInEx.Logging.Logger;
using Renderer = PixelGunCheat.util.Renderer;

namespace PixelGunCheat
{
    public class CheatManager : MonoBehaviour
    {
        private readonly CheatModuleNoRecoil _modNoRecoil = new(KeyCode.None);
        private readonly CheatModuleAllFullAuto _modAllFullAuto = new(KeyCode.None);
        private readonly CheatModuleInfiniteRange _modInfRange = new(KeyCode.None);
        private readonly CheatModuleAimUtils _modAimUtils = new(KeyCode.None);
        private readonly CheatModuleScoreModifier _modScoreModif = new(KeyCode.None);
        private readonly CheatModuleAlwaysDropCoin _modCoinDrop = new(KeyCode.None);
        private readonly CheatModuleIceSwordGlobalAura _modIceSwordAura = new(KeyCode.None);
        private readonly CheatModuleAOEBullets _modAOEBullet = new(KeyCode.None);
        private readonly CheatModuleForceCriticals _modForceCrit = new(KeyCode.None);
        private readonly CheatModuleInfiniteAmmoV2 _modInfAmmoV2 = new(KeyCode.None);
        private readonly CheatModuleForceCancer _modEffectSpam = new(KeyCode.None);
        private readonly CheatModuleDropTeleport _modDropTeleport = new(KeyCode.None);
        private readonly CheatModuleInvisibility _modInvis = new(KeyCode.None);
        private readonly CheatModuleAutoHeal _modAutoHeal = new(KeyCode.None);
        private readonly CheatModuleSpeed _modSpeed = new(KeyCode.None);
        private readonly CheatModuleBhop _modBhop = new(KeyCode.None);
        private readonly CheatModuleAimBot _modAimBot = new(KeyCode.None);
        private readonly CheatModuleEsp _modEsp = new(KeyCode.None);
        private readonly CheatModuleGemGenerator _modGemGenerator = new(KeyCode.None);
        private readonly CheatModuleCoinGenerator _modCoinGenerator = new(KeyCode.None);
        private readonly CheatModuleUberCharge _modUberCharge = new(KeyCode.None);
        private readonly CheatModuleFly _modFly = new(KeyCode.None);
        private readonly CheatModuleRapidFire _modRapidFire = new(KeyCode.None);
        private readonly InfiniteGemClaim _modInfiniteGemClaim = new(KeyCode.None);

        // "Buttons"
        private readonly CheatModuleSkipLoading _modSkipLoading = new(KeyCode.None);

        private readonly CheatModuleHud _modHud = new(KeyCode.None);
        
        private readonly CheatModuleTest _modTest = new(KeyCode.None);

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
            _modHud.registerModules(_modNoRecoil, _modAllFullAuto, _modUberCharge, _modInfRange, _modAimUtils, _modIceSwordAura, _modAOEBullet, _modForceCrit, _modInfAmmoV2, _modEffectSpam, _modDropTeleport, _modSpeed, _modBhop, _modAimBot, _modEsp, _modInvis, _modAutoHeal, _modFly, _modSkipLoading, _modRapidFire, _modInfiniteGemClaim);
        }

        private void OnDestroy()
        {
            Debug.Log("Destroyed Cheat");
        }

        private void Update()
        {
            tickCount++;
            
            // do none see none
            _modRapidFire.HandleCheat();
            _modInfiniteGemClaim.HandleCheat();
            
            if (tickCount % 60 == 0)
            {
                main = Camera.allCameras.ToList().Find(camera => camera.enabled);
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
                
                // Gives Target All Effects (or at least tries to)
                _modEffectSpam.HandleCheat(weaponSounds);
            }

            // Invisibility
            _modInvis.HandleCheat(player);
            
            // Auto Heal Player When Possible
            _modAutoHeal.HandleCheat(player);
            
            // Infinite Ammo V2
            _modInfAmmoV2.HandleCheat(player);
            
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

            if (main != null)
            {
                _modAimBot.DrawTargetMarker(main);
            }
        }
        
        private void FixedUpdate()
        {
            fixedTickCount++;
            
            if (fixedTickCount % 25 == 0)
            {
                // Skip Loading
                _modSkipLoading.HandleCheat();
            }
            
            if (player == null) return;

            if (fixedTickCount % 25 == 0)
            {
                // Drop TP
                _modDropTeleport.HandleCheat(player);
            }
            
            if (_modGemGenerator.IsEnabled() && _modGemGenerator.IsEnabled())
            {
                if (fixedTickCount % 100 == 0)
                {
                    // Currency Generator
                    _modGemGenerator.HandleCheat(player);
                    _modCoinGenerator.HandleCheat(player);
                }
            }
            else
            {
                if (_modGemGenerator.IsEnabled())
                {
                    if (fixedTickCount % 50 == 0)
                    {
                        _modGemGenerator.HandleCheat(player);
                    }
                }
                
                if (_modCoinGenerator.IsEnabled())
                {
                    if (fixedTickCount % 50 == 0)
                    {
                        _modCoinGenerator.HandleCheat(player);
                    }
                }
            }
            
            // Speed Hack
            _modSpeed.HandleCheat(player);
            
            // Bhop Hack
            _modBhop.HandleCheat(player);
            
            // Fly Hack
            _modFly.HandleCheat(player);
        }
    }
}