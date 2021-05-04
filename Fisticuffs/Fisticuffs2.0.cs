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
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Major)]
    internal class JotunnModStub : BaseUnityPlugin
    {
        public const string PluginGUID = "org.zarboz.fisticuffs";
        public const string PluginName = "Fisticuffs";
        public const string PluginVersion = "1.1.2";
        public static new Jotunn.Logger Logger;
        private AssetBundle fisticuffsassets;
        private ConfigEntry<bool> configBlackmetal;
        private ConfigEntry<int> Blackmetalcost;
        private ConfigEntry<bool> configBronze;
        private ConfigEntry<bool> configIron;
        private ConfigEntry<bool> configSilver;
        private ConfigEntry<bool> configBone;
        private ConfigEntry<bool> configwood;
        private ConfigEntry<int> Chainironcost;
        private ConfigEntry<int> NexusID;

        private void Awake()
        {
            CreateConfigs();
            LoadAssets();
            BlackMetal();
            BronzeCestus();
            SilverCestus();
            IronCestus();
            BoneKnuckle();
            WoodKnuckle();
            IronChain();
        }

        private void CreateConfigs()
        {
            Config.SaveOnConfigSet = true;

            NexusID = Config.Bind("FisticuffsConf", "NexusID", 1080, new ConfigDescription("NexusID", new AcceptableValueList<int>(1080), new ConfigurationManagerAttributes { IsAdminOnly = true }));
            configBlackmetal = Config.Bind("FisticuffsConf", "BlackMetalEnabled", true, new ConfigDescription("Setting To Enable Black Metal Cestus",null, new ConfigurationManagerAttributes { IsAdminOnly = true }));
            Blackmetalcost = Config.Bind("FisticuffsConf", "Chain Cost", 4, new ConfigDescription("Chain Cost for Black Metal Cestus",new AcceptableValueRange<int>(0,4), new ConfigurationManagerAttributes { IsAdminOnly = true }));
            configBronze = Config.Bind("FisticuffsConf", "BronzeCuffEnabled", true, new ConfigDescription("Setting To Enable Bronze Cestus", null, new ConfigurationManagerAttributes { IsAdminOnly = true }));
            configIron = Config.Bind("FisticuffsConf", "IronCuffEnabled", true, new ConfigDescription("Setting To Enable Iron Cestus", null, new ConfigurationManagerAttributes { IsAdminOnly = true }));
            configSilver = Config.Bind("FisticuffsConf", "SilverCuffEnabled", true, new ConfigDescription("Setting To Enable Silver Cestus", null, new ConfigurationManagerAttributes { IsAdminOnly = true }));
            configBone = Config.Bind("FisticuffsConf", "BoneCuffEnabled", true, new ConfigDescription("Setting To Enable Bone Knuckles", null, new ConfigurationManagerAttributes { IsAdminOnly = true }));
            configwood = Config.Bind("FisticuffsConf", "twigEnabled", true, new ConfigDescription("Setting To Enable Twig", null, new ConfigurationManagerAttributes { IsAdminOnly = true }));
            Chainironcost = Config.Bind("FisticuffsConf", "Chain Iron Cost", 5, new ConfigDescription("Iron Cost for Chain", new AcceptableValueRange<int>(0, 10), new ConfigurationManagerAttributes { IsAdminOnly = true }));
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
                    Enabled = (bool)configBlackmetal.BoxedValue,
                    CraftingStation = "forge",
                    MinStationLevel = 4,
                    RepairStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "LeatherScraps", Amount = 1, AmountPerLevel = 5},
                        new RequirementConfig { Item = "BlackMetal", Amount = 1, AmountPerLevel = 5},
                        new RequirementConfig { Item = "Iron_Chain", Amount = (int)Blackmetalcost.BoxedValue, AmountPerLevel = 10}
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
                    Enabled = (bool)configBronze.BoxedValue,
                    CraftingStation = "forge",
                    MinStationLevel = 3,
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
                    Enabled = (bool)configSilver.BoxedValue,
                    CraftingStation = "forge",
                    MinStationLevel = 4,
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
                    Enabled = (bool)configIron.BoxedValue,
                    CraftingStation = "forge",
                    MinStationLevel = 4,
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
                    Enabled = (bool)configBone.BoxedValue,
                    CraftingStation = "piece_workbench",
                    MinStationLevel = 2,
                    RepairStation = "piece_workbench",
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
                    Enabled = (bool)configwood.BoxedValue,
                    CraftingStation = null,
                    MinStationLevel = 2,
                    RepairStation = "piece_workbench",
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
                    new RequirementConfig {Item = "Iron", Amount = (int)Chainironcost.BoxedValue},
                    new RequirementConfig {Item = "Caol", Amount = 2}
                }
            });
            ItemManager.Instance.AddRecipe(IronChain);

        }


    }
}