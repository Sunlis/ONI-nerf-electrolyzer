using HarmonyLib;
using Klei.AI;

class IncubatorPatches
{
    [HarmonyPatch(typeof(IncubationMonitor.Instance), "UpdateIncubationState")]
    class IncubationMonitor_UpdateIncubationState_Patch
    {
        static void Postfix(IncubationMonitor.Instance __instance)
        {
            var effects = __instance.GetComponent<Effects>();
            // drop the Lullabied buff if the egg is removed from the incubator or the incubator is turned off
            if (effects.HasEffect("EggSong") && (!__instance.sm.incubatorIsActive.Get(__instance) || !__instance.sm.inIncubator.Get(__instance)))
            {
                effects.Remove("EggSong");
            }
        }
    }

    [HarmonyPatch(typeof(EggIncubatorConfig), nameof(EggIncubatorConfig.CreateBuildingDef))]
    class Incubator_BuildingDef_Patch
    {
        static void Postfix(BuildingDef __result)
        {
            __result.EnergyConsumptionWhenActive = 60f;
        }
    }
}