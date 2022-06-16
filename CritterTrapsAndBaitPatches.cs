using HarmonyLib;
using Database;

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

    public static void TweakTrapTechs()
    {
        var ranching = Db.Get().Techs.Get("Ranching");
        var animalControl = Db.Get().Techs.Get("AnimalControl");

        // move traps to earlier tier
        ranching.AddUnlockedItemIDs("CreatureTrap", "FishTrap");
        animalControl.RemoveUnlockedItemIDs("CreatureTrap", "FishTrap");

        // move bait to later tier
        ranching.RemoveUnlockedItemIDs("FlyingCreatureBait");
        animalControl.AddUnlockedItemIDs("FlyingCreatureBait");
    }
}
