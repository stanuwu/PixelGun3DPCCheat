using System;
using System.Collections.Generic;
using PickUpObjectSystem;
using Rilisoft;
using UnityEngine;
using UnityEngine.InputSystem;
using Logger = BepInEx.Logging.Logger;
using Object = UnityEngine.Object;

namespace PixelGunCheat.modules.impl.entity
{
    public class CheatModuleDropTeleport : CheatModuleEntity
    {
        public CheatModuleDropTeleport(KeyCode k) : base(k, true)
        {
        }

        public override string GetName()
        {
            return "DropTeleport";
        }

        public override void HandleCheat(Player_move_c t)
        {
            if (!IsEnabled()) return;
            foreach (var coinBonus in Object.FindObjectsOfType<CoinBonus>())
            {
                coinBonus.transform.position = t.transform.position;
            }
            foreach (var armorBonus in Object.FindObjectsOfType<ArmorBonus>())
            {
                armorBonus.transform.position = t.transform.position;
            }
            foreach (var itemBonus in Object.FindObjectsOfType<BonusItem>())
            {
                itemBonus.transform.position = t.transform.position;
            }
            foreach (var weaponBonus in Object.FindObjectsOfType<WeaponBonus>())
            {
                weaponBonus.transform.position = t.transform.position;
            }
            foreach (var pickupBonus in Object.FindObjectsOfType<BonusPickup>())
            {
                pickupBonus.transform.position = t.transform.position;
            }
            foreach (var key in Object.FindObjectsOfType<KeyDungeonObject>())
            {
                key.transform.position = t.transform.position;
            }
            foreach (var flask in Object.FindObjectsOfType<FlasksDungeonObject>())
            {
                flask.transform.position = t.transform.position;
            }
        }
    }
}