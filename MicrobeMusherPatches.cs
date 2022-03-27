using HarmonyLib;

class MicrobeMusherPatches
{
    [HarmonyPatch(typeof(MicrobeMusherConfig), nameof(MicrobeMusherConfig.CreateBuildingDef))]
    class MicrobeMusherConfig_CreateBuildingDef_Patch
    {
        public static void Postfix(BuildingDef __result)
        {
            __result.EnergyConsumptionWhenActive = 60f;
        }
    }
}