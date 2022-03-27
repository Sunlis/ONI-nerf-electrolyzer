using HarmonyLib;

class SpaceHeaterPatches
{
    [HarmonyPatch(typeof(SpaceHeaterConfig), nameof(SpaceHeaterConfig.CreateBuildingDef))]
    class SpaceHeater_CreateBuildingDef_Patch
    {
        public static void Postfix(BuildingDef __result)
        {
            __result.EnergyConsumptionWhenActive = 60f;
            __result.ExhaustKilowattsWhenActive = 20f;
            __result.SelfHeatKilowattsWhenActive = 80f;
            __result.OverheatTemperature = Temp.C(175f);
            // TODO: tempshift-plate effect
        }
    }
}