// JotunnModStub
// a Valheim mod skeleton using JötunnLib
// 
// File:    JotunnModStub.cs
// Project: JotunnModStub

using BepInEx;
using UnityEngine;
using BepInEx.Configuration;
using Jotunn.Utils;
using System.Reflection;
using Jotunn.Entities;
using Jotunn.Configs;
using Jotunn.Managers;

namespace JotunnModStub
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    //[NetworkCompatibilty(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class JotunnModStub : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.jotunnmodstub";
        public const string PluginName = "JotunnModStub";
        public const string PluginVersion = "0.0.1";
        public static new Jotunn.Logger Logger;
        private AssetBundle embeddedResourceBundle;

        public GameObject turnipburgerfab { get; private set; }

        private void Awake()
        {

            LoadAssets();
            CreateThing();
        }


        private void Update()
        {
  
        }


        private void LoadAssets()
        {
            Jotunn.Logger.LogInfo($"Embedded resources: {string.Join(",", Assembly.GetExecutingAssembly().GetManifestResourceNames())}");
            embeddedResourceBundle = AssetUtils.LoadAssetBundleFromResources("bow", Assembly.GetExecutingAssembly());
            //insert prefabs here
            //turnipburgerfab = embeddedResourceBundle.LoadAsset<GameObject>("Assets/Weaponsssets/BowBryan.prefab");


        }

        private void CreateThing()
        {
            var burger_prefab = embeddedResourceBundle.LoadAsset<GameObject>("BowZarboz");
            var burger = new CustomItem(burger_prefab, fixReference: true,
                new ItemConfig
                {
                    Amount = 1,
                    CraftingStation = "forge",
                    MinStationLevel = 2,
                    RepairStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Honey", Amount = 1},
                        new RequirementConfig { Item = "DragonTear", Amount = 1},
                        new RequirementConfig { Item = "Brass", Amount = 3, AmountPerLevel = 10}
                    }
                });
            ItemManager.Instance.AddItem(burger);
            //PrefabManager.Instance.AddPrefab(burger_prefab);

        }

        //can clone a prefab from game with this but it duplicates CreateFood() in a non working way
        private void Foodrecipes()
        {
            CustomRecipe turnipburger = new CustomRecipe(new RecipeConfig()
            {
                Item = "turnipburger",
                CraftingStation = "piece_cauldron",
                Amount = 1,
                Requirements = new[]
                {
                    new RequirementConfig {Item = "Honey", Amount = 1}
                }
            });
            ItemManager.Instance.AddRecipe(turnipburger);

        }
    }
}