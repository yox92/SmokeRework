using HarmonyLib;

namespace SmokeRework.Patches
{
    public static class EffectFireMod
    {
        [HarmonyPatch(typeof(MuzzleJet), nameof(MuzzleJet.RandomizeMaterial))]
        public static class FlashOnMuzzle
        {
            [HarmonyPrefix]
            public static bool DisableFlashMuzzle()
            {
                return !Plugin.DisableFlashMuzzle.Value;
            }
        }

        [HarmonyPatch(typeof(MuzzleLight))]
        public static class PatchMuzzleLightIntensity
        {
            [HarmonyPatch(nameof(MuzzleLight.SetIntensity))]
            [HarmonyPrefix]
            public static bool ModifyIntensity(ref float intensity, MuzzleLight __instance)
            {
                float multiplier = Plugin.LightIntensityMultiplier.Value;
                intensity *= multiplier;
                return true;
            }
        }
    }
}