using HarmonyLib;
using System;

class ArtDecorPatches
{
    [HarmonyPatch(typeof(Artable.Stage), MethodType.Constructor, new Type[] { typeof(string), typeof(string), typeof(string), typeof(int), typeof(bool), typeof(Artable.Status) })]
    class ArtableStage_Constructor_Patch
    {
        static void Prefix(ref int decor_value)
        {
            if (decor_value > 0)
            {
                decor_value += 5;
            }
        }
    }

    [HarmonyPatch(typeof(PixelPackConfig), nameof(PixelPackConfig.CreateBuildingDef))]
    class PixelPackConfig_BuildingDef_Patch
    {
        static void Postfix(BuildingDef __result)
        {
            __result.BaseDecor = 5;
            __result.BaseDecorRadius = 2;
        }
    }
}