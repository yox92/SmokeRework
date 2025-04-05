using HarmonyLib;

namespace SmokeRework.Patches
{
    [HarmonyPatch(typeof(MuzzleManager), nameof(MuzzleManager.Shot))]
    public static class MuzzleManagerShotPatch
    {
        [HarmonyPrefix]
        public static void BeforeShot()
        {
            ReworkContext.IsFromMuzzleManagerShot = true;
        }

        [HarmonyPostfix]
        public static void AfterShot()
        {
            ReworkContext.IsFromMuzzleManagerShot = false;
        }
    }
    
}