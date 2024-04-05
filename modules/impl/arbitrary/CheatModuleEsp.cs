using System;
using System.Collections.Generic;
using System.Linq;
using PixelGunCheat.util;
using UnityEngine;
using UnityEngine.InputSystem;
using Renderer = PixelGunCheat.util.Renderer;

namespace PixelGunCheat.modules.impl.arbitrary
{
    public class CheatModuleEsp : CheatModuleArbitrary
    {
        private List<Player_move_c> playerList = new();
        private HSVColor _gay = HSVColor.FromRGB(1, 0, 0);
        private Camera main = null;
        
        public CheatModuleEsp(KeyCode k) : base(k, true)
        {
        }

        public override string GetName()
        {
            return "ESP";
        }

        public override void HandleCheat(GameObject g = null)
        {
            _gay.Hue+=0.1f;
            if (_gay.Hue > 360) _gay.Hue = 0;
            
            if (!IsEnabled()) return;
            if (main == null) return;
            if (playerList.Count < 1) return;
            foreach (var playerMoveC in playerList.OrderByDescending(p => {
                         if (p == null) return 0;
                         return Vector3.Distance(p.transform.position, main.transform.position);
                     }))
            {
                try
                {
                    if (playerMoveC.nickLabel == null) continue;
                    if (playerMoveC == null) continue;
                    if (playerMoveC.nickLabel.text == "1111") continue;
                    Vector3 position = playerMoveC.transform.position;
                    Vector3 topWorld = position + new Vector3(0, 2, 0);
                    

                    Vector3 screenPos = PlayerUtil.WorldToScreenPoint(main, position);
                    Vector3 topScreen = PlayerUtil.WorldToScreenPoint(main, topWorld);

                    if (screenPos.z < 0) continue;

                    if (!PlayerUtil.IsVisible(screenPos)) continue;
                    float scaledDist = screenPos.y - topScreen.y;

                    Renderer.SetFontSize(Renderer.ScaleValInt(16));
                    var content = new GUIContent(playerMoveC.nickLabel.text);
                    var size = Renderer.StringStyle.CalcSize(content);
                    Renderer.DrawStringShadow(screenPos + new Vector3(0, (scaledDist * 1.5f) / 2 + 25), playerMoveC.nickLabel.text,  playerMoveC.nickLabel.color == Color.red ? _gay.AsARGB(1) : Color.gray, true);
                    Renderer.DrawCenteredBoxShadow(screenPos, new Vector2(scaledDist, scaledDist * 1.5f),
                        playerMoveC.nickLabel.color == Color.red ? _gay.AsARGB(1) : Color.gray, 2);
                }
                catch (Exception)
                {
                    // uhhhhh no transform? L?
                }
            }
        }
        
        public void UpdatePlayerList(List<Player_move_c> pList, Camera main)
        {
            if (!IsEnabled()) return;
            playerList = pList;
            this.main = main;
        }
    }
}