using UnityEngine;

namespace SmokeRework.Patches;

public static class GetMultiplier
{
    public static float ApplyIfAllowed(float value)
    {
        float factor = ReworkContext.IsCanonFume
            ? Mathf.Clamp(Plugin.CanonSmokeMultiplier.Value / 100f, 0.01f, 5f)
            : Mathf.Clamp(Plugin.ResidualSmokeMultiplier.Value / 100f, 0.01f, 5f);
        return value * factor;
    }
}