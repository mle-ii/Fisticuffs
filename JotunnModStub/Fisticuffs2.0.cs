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
        public const string PluginName = "Fisticuffs";
        public const string PluginVersion = "0.0.1";
        public static new Jotunn.Logger Logger;
        private AssetBundle fisticuffsassets;

        private void Awake()
        {
            LoadAssets();
            BlackMetal();
            BronzeCestus();
            SilverCestus();
            IronCestus();
            BoneKnuckle();
            WoodKnuckle();
            IronChain();
        }

        private void LoadAssets()
        {
            Jotunn.Logger.LogInfo($"Embedded resources: {string.Join(",", Assembly.GetExecutingAssembly().GetManifestResourceNames())}");
            fisticuffsassets = AssetUtils.LoadAssetBundleFromResources("valheim-brawler", Assembly.GetExecutingAssembly());
        }
        private void BlackMetal()
        {
            var bmetal_fab = fisticuffsassets.LoadAsset<GameObject>("BlackMetalCestus");
            var bmetal = new CustomItem(bmetal_fab, fixReference: true,
                new ItemConfig
                {
                    Amount = 1,
                    CraftingStation = "forge",
                    MinStationLevel = 2,
                    RepairStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "LeatherScraps", Amount = 1, AmountPerLevel = 5},
                        new RequirementConfig { Item = "BlackMetal", Amount = 1, AmountPerLevel = 5},
                        new RequirementConfig { Item = "Iron_Chain", Amount = 3, AmountPerLevel = 10}
                    }
                });
            ItemManager.Instance.AddItem(bmetal);


        }
        private void BronzeCestus()
        {

            var bcestus_prefab = fisticuffsassets.LoadAsset<GameObject>("BronzeCestus");
            var bcestus = new CustomItem(bcestus_prefab, fixReference: true,
                new ItemConfig
                {
                    Amount = 1,
                    CraftingStation = "forge",
                    MinStationLevel = 2,
                    RepairStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig {Item = "Bronze", Amount = 10, AmountPerLevel = 3},
                        new RequirementConfig {Item = "LeatherScraps", Amount = 5, AmountPerLevel = 4},
                        new RequirementConfig {Item = "Tin", Amount = 5, AmountPerLevel = 2}
                    }


                });
            ItemManager.Instance.AddItem(bcestus);
        }
        private void SilverCestus()
        {

            var silver_prefab = fisticuffsassets.LoadAsset<GameObject>("SilverCestus");
            var silvercestus = new CustomItem(silver_prefab, fixReference: true,
                new ItemConfig
                {
                    Amount = 1,
                    CraftingStation = "forge",
                    MinStationLevel = 2,
                    RepairStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig {Item = "LeatherScraps", Amount = 1, AmountPerLevel = 2},
                        new RequirementConfig {Item = "Silver", Amount = 15, AmountPerLevel = 10}
                    }


                });
            ItemManager.Instance.AddItem(silvercestus);
        }
        private void IronCestus()
        {

            var iron_prefab = fisticuffsassets.LoadAsset<GameObject>("IronCestus");
            var ironcestus = new CustomItem(iron_prefab, fixReference: true,
                new ItemConfig
                {
                    Amount = 1,
                    CraftingStation = "forge",
                    MinStationLevel = 2,
                    RepairStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig {Item = "Iron", Amount = 10, AmountPerLevel = 5},
                        new RequirementConfig {Item = "LeatherScraps", Amount = 5, AmountPerLevel = 5}
                    }


                });
            ItemManager.Instance.AddItem(ironcestus);
        }
        private void BoneKnuckle()
        {

            var bone_prefab = fisticuffsassets.LoadAsset<GameObject>("StuddedKnuckles");
            var boneknuck = new CustomItem(bone_prefab, fixReference: true,
                new ItemConfig
                {
                    Amount = 1,
                    CraftingStation = "forge",
                    MinStationLevel = 2,
                    RepairStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig {Item = "LeatherScarps", Amount = 5, AmountPerLevel = 2},
                        new RequirementConfig {Item = "BoneFragments", Amount = 5, AmountPerLevel = 2}
                    }


                });
            ItemManager.Instance.AddItem(boneknuck);
        }
        private void WoodKnuckle()
        {

            var twig_fab = fisticuffsassets.LoadAsset<GameObject>("WoodKnuckles");
            var twig = new CustomItem(twig_fab, fixReference: true,
                new ItemConfig
                {
                    Amount = 1,
                    CraftingStation = "forge",
                    MinStationLevel = 2,
                    RepairStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig {Item = "LeatherScraps", Amount = 1},
                        new RequirementConfig {Item = "Wood", Amount = 1}
                    }


                });
            ItemManager.Instance.AddItem(twig);
        }
        private void IronChain()
        {
            CustomRecipe IronChain = new CustomRecipe(new RecipeConfig()
            {
                Item = "Chain",
                Name = "Iron Chain",
                CraftingStation = "forge",
                RepairStation = "forge",
                MinStationLevel = 1,
                Amount = 5,
                Requirements = new[]
                {
                    new RequirementConfig {Item = "Iron", Amount = 5},
                    new RequirementConfig {Item = "Caol", Amount = 2}
                }
            });
            ItemManager.Instance.AddRecipe(IronChain);

        }

 
    }
}