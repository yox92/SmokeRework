using HarmonyLib;

namespace SmokeRework.Patches
{
    [HarmonyPatch(typeof(MuzzleFume), nameof(MuzzleFume.Emit))]
    public static class SmokeTypeFilter
    {
        [HarmonyPrefix]
        public static void DetectFumeType(MuzzleFume __instance)
        {
            bool isCanon = __instance.Speed > 7f && __instance.ConusSize > 0.1f;
            ReworkContext.IsCanonFume = isCanon;
        }
    }
}