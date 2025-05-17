using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using REPOLib.Modules;
using UnityEngine;

namespace LoLPings
{
    [BepInPlugin("VanillaBlanket.LoLPings", "LoLPings", "1.0")]
    [BepInDependency(REPOLib.MyPluginInfo.PLUGIN_GUID, BepInDependency.DependencyFlags.HardDependency)]
    public class LoLPings : BaseUnityPlugin
    {
        internal static LoLPings Instance { get; private set; } = null!;
        internal new static ManualLogSource Logger => Instance._logger;
        private ManualLogSource _logger => base.Logger;
        internal Harmony? Harmony { get; set; }

        private void Awake()
        {
            Instance = this;

            // Prevent the plugin from being deleted
            this.gameObject.transform.parent = null;
            this.gameObject.hideFlags = HideFlags.HideAndDontSave;

            Patch();
            
            Logger.LogInfo($"{Info.Metadata.GUID} v{Info.Metadata.Version} has loaded!");
        }

        internal void Patch()
        {
            Harmony ??= new Harmony(Info.Metadata.GUID);
            Harmony.PatchAll();
        }

        internal void Unpatch()
        {
            Harmony?.UnpatchSelf();
        }

        private static void LoadAssets()
        {
            AssetBundle lolPingsAssetBundle = LoadAssetBundle("");
        }

        public static AssetBundle LoadAssetBundle(string name)
        {
            Logger.LogDebug("Loasing Asset Bundle: " + name);
            AssetBundle bundle = null;

            return bundle;
        }

        private void Update()
        {
            // Code that runs every frame goes here
            if (Input.GetKeyDown(KeyCode.G))
            {
                Logger.LogInfo("G key was pressed.");
            }
        }
    }
}