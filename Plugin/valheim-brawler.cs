using BepInEx;
using HarmonyLib;
using JotunnLib.Entities;
using JotunnLib.Managers;
using JotunnLib.Utils;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using valheimbrawler.Prefabs;

namespace valheimbrawler
{
    [BepInPlugin("zarboz.valheim-brawler", "valheim-brawler", "1.0.1")]
    [BepInDependency(JotunnLib.JotunnLib.ModGuid)]
    

    public class valheimbrawler : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("zarboz.valheim-brawler");
        public static GameObject BMCestus { get; private set; }
        public static GameObject BCestus { get; private set; }
        public static GameObject ICestus { get; private set; }
        public static GameObject SCestus { get; private set; }
        public static GameObject SKnucks { get; private set; }
        public static GameObject WKnucks { get; private set; }
        public static GameObject Keyblade { get; private set; }

          
        private void Awake()
        {
            AssetBundle assetBundle = AssetBundleHelper.GetAssetBundleFromResources("valheim-brawler");

            valheimbrawler.BMCestus = assetBundle.LoadAsset<GameObject>("BlackMetalCestus");
            valheimbrawler.BCestus = assetBundle.LoadAsset<GameObject>("BronzeCestus");
            valheimbrawler.ICestus = assetBundle.LoadAsset<GameObject>("IronCestus");
            valheimbrawler.SCestus = assetBundle.LoadAsset<GameObject>("SilverCestus");
            valheimbrawler.SKnucks = assetBundle.LoadAsset<GameObject>("StuddedKnuckles");
            valheimbrawler.WKnucks = assetBundle.LoadAsset<GameObject>("WoodKnuckles");


            ObjectManager.Instance.ObjectRegister += InitObjects;
            PrefabManager.Instance.PrefabRegister += RegisterPrefabs;
            
        }

        void OnDestroy()
        {
            harmony.UnpatchSelf();
          
        }

        private void RegisterPrefabs(object sender, EventArgs e)
        {
            PrefabManager.Instance.RegisterPrefab(valheimbrawler.BMCestus, "BlackMetalCestus");
            PrefabManager.Instance.RegisterPrefab(valheimbrawler.BCestus, "BronzeCestus");
            PrefabManager.Instance.RegisterPrefab(valheimbrawler.ICestus, "IronCestus");
            PrefabManager.Instance.RegisterPrefab(valheimbrawler.SCestus, "SilverCestus");
            PrefabManager.Instance.RegisterPrefab(valheimbrawler.SKnucks, "StuddedKnuckles");
            PrefabManager.Instance.RegisterPrefab(valheimbrawler.WKnucks, "WoodKnuckles");
            PrefabManager.Instance.RegisterPrefab(new Chainprefab());

        }

        private void InitObjects(object sender, EventArgs e)
        {

            ObjectManager.Instance.RegisterItem("BlackMetalCestus");
            ObjectManager.Instance.RegisterItem("BronzeCestus");
            ObjectManager.Instance.RegisterItem("IronCestus");
            ObjectManager.Instance.RegisterItem("SilverCestus");
            ObjectManager.Instance.RegisterItem("StuddedKnuckles");
            ObjectManager.Instance.RegisterItem("WoodKnuckles");
            ObjectManager.Instance.RegisterItem("Iron_Chain");


            ObjectManager.Instance.RegisterRecipe(new RecipeConfig()
            {

                Name = "Recipe_BlackMetalCestus",
                Item = "BlackMetalCestus",
                Amount = 1,
                MinStationLevel = 4,
                CraftingStation = "forge",
                RepairStation = "forge",
                Requirements = new PieceRequirementConfig[]
               {
                    new PieceRequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "BlackMetal",
                        Amount = 10
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "Iron_Chain",
                        Amount = 5
                    },
               },
            });
            ObjectManager.Instance.RegisterRecipe(new RecipeConfig()
            {

                Name = "Recipe_BronzeCestus",
                Item = "BronzeCestus",
                Amount = 1,
                MinStationLevel = 4,
                CraftingStation = "forge",
                RepairStation = "forge",
                Requirements = new PieceRequirementConfig[]
               {
                    new PieceRequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "Bronze",
                        Amount = 10
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "Tin",
                        Amount = 5
                    },
               },
            });
            ObjectManager.Instance.RegisterRecipe(new RecipeConfig()
            {

                Name = "Recipe_IronCestus",
                Item = "IronCestus",
                Amount = 1,
                MinStationLevel = 4,
                CraftingStation = "forge",
                RepairStation = "forge",
                Requirements = new PieceRequirementConfig[]
               {
                    new PieceRequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "Iron",
                        Amount = 10
                    }
               },
            });
            ObjectManager.Instance.RegisterRecipe(new RecipeConfig()
            {

                Name = "Recipe_SilverCestus",
                Item = "SilverCestus",
                Amount = 1,
                MinStationLevel = 4,
                CraftingStation = "forge",
                RepairStation = "forge",
                Requirements = new PieceRequirementConfig[]
               {
                    new PieceRequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "Silver",
                        Amount = 15
                    }
               },
            });
            ObjectManager.Instance.RegisterRecipe(new RecipeConfig()
            {

                Name = "Recipe_StuddedKnuckles",
                Item = "StuddedKnuckles",
                Amount = 1,
                MinStationLevel = 1,
                CraftingStation = "piece_workbench",
                RepairStation = "piece_workbench",
                Requirements = new PieceRequirementConfig[]
               {
                    new PieceRequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "BoneFragments",
                        Amount = 5
                    }
               },
            });
            ObjectManager.Instance.RegisterRecipe(new RecipeConfig()
            {

                Name = "Recipe_WoodKnuckles",
                Item = "WoodKnuckles",
                Amount = 1,
                MinStationLevel = 1,
                CraftingStation = "piece_workbench",
                RepairStation = "piece_workbench",
                Requirements = new PieceRequirementConfig[]
               {
                    new PieceRequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 2
                    }
               },
            });

            ObjectManager.Instance.RegisterRecipe(new RecipeConfig()
            {

                Name = "Recipe_IronChain",
                Item = "Iron_Chain",
                Amount = 1,
                MinStationLevel = 2,
                CraftingStation = "forge",
                RepairStation = "forge",
                Requirements = new PieceRequirementConfig[]
               {
                    new PieceRequirementConfig()
                    {
                        Item = "Iron",
                        Amount = 5
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "Coal",
                        Amount = 2
                    }
               },
            });

            



        }

        class AssetBundleHelper
        {
            public static AssetBundle GetAssetBundleFromResources(string fileName)
            {
                var execAssembly = Assembly.GetExecutingAssembly();

                var resourceName = execAssembly.GetManifestResourceNames()
                    .Single(str => str.EndsWith(fileName));

                AssetBundle assetBundle;
                using (var stream = execAssembly.GetManifestResourceStream(resourceName))
                {
                    assetBundle = AssetBundle.LoadFromStream(stream);
                }

                return assetBundle;
            }
        }
    }
}
