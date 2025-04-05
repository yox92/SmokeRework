using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace SmokeRework
{
    [BepInPlugin("com.spt.smokerework", "SmokeRework", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource LogSource;

        public static ConfigEntry<bool> DisableFlashMuzzle;
        public static ConfigEntry<float> LightIntensityMultiplier;
        
        public static ConfigEntry<int> CanonSmokeMultiplier;
        public static ConfigEntry<int> ResidualSmokeMultiplier;
        
        private void Awake()
        {
            LogSource = Logger;

            DisableFlashMuzzle = Config.Bind("Light", "Muzzle Flash", false, "Disable flash effect from the muzzle when no muzzle break");
            LightIntensityMultiplier = Config.Bind("Light", "Light Emission", 1.0f,
                new ConfigDescription("Adjusts the brightness of the Light Emission when firing indoors", new AcceptableValueRange<float>(0.01f, 10f)));
            
            ResidualSmokeMultiplier = Config.Bind(
                "Smoke", 
                "Smoke Residual Intensity", 
                100,
                new ConfigDescription("Controls the lingering smoke cloud in front of you after firing", new AcceptableValueRange<int>(1, 500)));

            CanonSmokeMultiplier = Config.Bind(
                "Smoke", 
                "Controls smoke expelled from the barrel upon firing", 
                100, 
                new ConfigDescription("", new AcceptableValueRange<int>(1, 500)));
            var harmony = new Harmony("com.spt.smokerework");
            harmony.PatchAll();
            LogSource.LogInfo("🔧 SmokeRework chargé avec succès.");
        }
    }
}