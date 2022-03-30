using HarmonyLib;
using System.Collections.Generic;

class CookingPatches
{
    public static void TweakFoodValues()
    {
        TUNING.FOOD.FOOD_TYPES.COOKED_MEAT.Quality = 2;
        TUNING.FOOD.FOOD_TYPES.FISH_MEAT.Quality = 1;
        TUNING.FOOD.FOOD_TYPES.COOKED_FISH.Quality = 3; // even though cooked fish is already quality 3
    }

    [HarmonyPatch(typeof(MicrobeMusherConfig), nameof(MicrobeMusherConfig.CreateBuildingDef))]
    class MicrobeMusherConfig_CreateBuildingDef_Patch
    {

        public static void Postfix(BuildingDef __result)
        {
            __result.EnergyConsumptionWhenActive = 60f;
        }
    }
    
    [HarmonyPatch(typeof(CookingStationConfig), nameof(CookingStationConfig.CreateBuildingDef))]
    class ElectricGrillConfig_CreateBuildingDef_Patch
    {
        public static void Postfix(BuildingDef __result)
        {
            __result.EnergyConsumptionWhenActive = 120f;
        }
    }
}