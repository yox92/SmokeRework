using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace SmokeRework.Patches
{
    [HarmonyPatch(typeof(MuzzleFume), nameof(MuzzleFume.Emit))]
    public static class SmokeReworkTranspiler
    {
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> MultiplySpeedsAndLifetimes(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            var evaluateMethod = typeof(AnimationCurve).GetMethod(nameof(AnimationCurve.Evaluate));
            var conditionalMultiplier = AccessTools.Method(typeof(GetMultiplier), nameof(GetMultiplier.ApplyIfAllowed));
            int injectedCount = 0;
    
            for (int i = 0; i < codes.Count; i++)
            {
                
                if (codes[i].opcode == OpCodes.Callvirt &&
                    codes[i].operand is MethodInfo method &&
                    method == evaluateMethod)
                {
                    codes.Insert(i + 1, new CodeInstruction(OpCodes.Call, conditionalMultiplier));
                    i += 2; 
                }
            }
            return codes;
        }
    }
}