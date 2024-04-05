using System.Collections.Generic;
using PixelGunCheat.util;
using UnityEngine;
using UnityEngine.InputSystem;
using Renderer = PixelGunCheat.util.Renderer;

namespace PixelGunCheat.modules.impl.entity;

public class CheatModuleAimBot : CheatModuleArbitrary
{
    private List<Player_move_c> playerList = new();
    private Dictionary<string, Vector3> playerPosCache = new();
    private Vector3 aimedPos = Vector3.zero;
    private Camera main = null;
    
    public CheatModuleAimBot(KeyCode k) : base(k, true)
    {
    }

    public override string GetName()
    {
        return "AimBot";
    }

    public override void HandleCheat(GameObject t = null)
    {
        if (!IsEnabled()) return;
        if (main == null) return;
        
        Vector3 aimPos = main.transform.position;
        Vector3 prediction = Vector3.zero;
        Player_move_c target = null;
        double distance = double.MaxValue;
        
        foreach (var p in playerList)
        {
            if(p == null) continue;
            if(p.nickLabel == null) continue;
            if(p.nickLabel.text == "1111") continue;
            if(!(p.nickLabel.color.r == 1 && p.nickLabel.color.g == 0 && p.nickLabel.color.b == 0)) continue;
            if(!PlayerUtil.IsVisible(PlayerUtil.WorldToScreenPoint(main, p.transform.position))) continue;

            Vector3 velocity = Vector3.zero;
            
            if (playerPosCache.ContainsKey(p.nickLabel.text))
            {
                velocity = p.transform.position - playerPosCache[p.nickLabel.text];
            }

            playerPosCache[p.nickLabel.text] = p.transform.position;

            Vector3 headPos = p.transform.position + new Vector3(0, 0.75f, 0) + (velocity.normalized / 10);
                
            if(Vector3.Distance(headPos, aimPos) > 800) continue;

            Vector3 aimDirection = main.transform.rotation * new Vector3(1, 1, 1);
            Vector3 v = headPos - aimPos;
            float d = Vector3.Dot(v, aimDirection);
            Vector3 closestPoint = aimPos + aimDirection * d;

            float newDist = Vector3.Distance(closestPoint, headPos);
            if (!(distance > newDist)) continue;

            RaycastHit hit;
            if (Physics.Raycast(new Ray(aimPos, Vector3.Normalize(headPos - aimPos)), out hit, 600))
            {
                if (hit.colliderInstanceID != p.headCollider.GetInstanceID()) continue;
            }
            else
            {
                continue;
            }

            distance = newDist;
            target = p;
            prediction = velocity.normalized / 10;
        }
        
        if (target != null)
        {
            main.transform.LookAt(target.transform.position + new Vector3(0, 0.75f, 0) + prediction);
            aimedPos = target.transform.position + new Vector3(0, 0.75f, 0) + prediction;
        }
        else
        {
            aimedPos = Vector3.zero;
        }
    }
    
    public void UpdatePlayerList(List<Player_move_c> pList, Camera main)
    {
        if (!IsEnabled()) return;
        playerList = pList;
        this.main = main;
    }

    public void DrawTargetMarker(Camera cam)
    {
        if (!IsEnabled()) return;
        main = cam;
        if (main == null || aimedPos == Vector3.zero) return;
        Vector3 ap = PlayerUtil.WorldToScreenPoint(main, aimedPos);
        Renderer.DrawCenteredBoxShadow(ap, new Vector2(50, 50), Color.magenta, 2);
    }
}