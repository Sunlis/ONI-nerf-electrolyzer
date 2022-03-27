using HarmonyLib;

class CritterTrapsAndBaitPatches
{
    [HarmonyPatch(typeof(FlyingCreatureBaitConfig), nameof(FlyingCreatureBaitConfig.CreateBuildingDef))]
    class AirborneCritterBait_CreateBuildingDef_Patch
    {
        public static void Postfix(BuildingDef __result)
        {
            __result.MaterialCategory[0] = TUNING.MATERIALS.BUILDABLERAW;
        }
    }

    [HarmonyPatch(typeof(CreatureTrapConfig), nameof(CreatureTrapConfig.CreateBuildingDef))]
    class CritterTrap_CreateBuildingDef_Patch
    {
        public static void Postfix(BuildingDef __result)
        {
            __result.MaterialCategory = TUNING.MATERIALS.ALL_MINERALS;
        }
    }

    [HarmonyPatch(typeof(FishTrapConfig), nameof(FishTrapConfig.CreateBuildingDef))]
    class FishTrap_CreateBuildingDef_Patch
    {
        public static void Postfix(BuildingDef __result)
        {
            __result.MaterialCategory = TUNING.MATERIALS.ALL_MINERALS;
        }
    }
}
