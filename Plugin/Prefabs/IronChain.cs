using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using JotunnLib.Entities;
using JotunnLib.Utils;




namespace valheimbrawler.Prefabs
{
    
    public class Chainprefab : PrefabConfig
    {
        public Chainprefab() : base("Iron_Chain", "Chain")
        {
            
        }
    public override void Register()
    {
        // Configure item drop
        // ItemDrop is a component on GameObjects which determines info about the item when it's picked up in the inventory
        ItemDrop item = Prefab.GetComponent<ItemDrop>();
        item.m_itemData.m_shared.m_name = "Iron Chain";
        item.m_itemData.m_shared.m_description = "This is a short length of iron chain used to craft other things.";
        item.m_itemData.m_dropPrefab = Prefab;
        item.m_itemData.m_shared.m_weight = 1f;
        item.m_itemData.m_shared.m_maxStackSize = 5;
        item.m_itemData.m_shared.m_variants = 1;
        item.m_itemData.m_stack = 1;
        item.m_autoDestroy = true;
        item.m_autoPickup = true;      
    }
   }
}
