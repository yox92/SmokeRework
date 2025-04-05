using System;

namespace SmokeRework
{
    public static class ReworkContext
    {
        [ThreadStatic] public static bool IsFromMuzzleManagerShot;
        [ThreadStatic] public static bool IsCanonFume;
    }

}