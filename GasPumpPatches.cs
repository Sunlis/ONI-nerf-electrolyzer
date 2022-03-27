using HarmonyLib;

class GasPumpPatches
{
    [HarmonyPatch(typeof(GasPumpConfig), nameof(GasPumpConfig.CreateBuildingDef))]
    public class GasPumpConfig_CreateBuildingDef_Patch
    {
        public static void Postfix(BuildingDef __result)
        {
            __result.EnergyConsumptionWhenActive = 120.0f;
        }
    }

    [HarmonyPatch(typeof(GasMiniPumpConfig), nameof(GasMiniPumpConfig.CreateBuildingDef))]
    public class MiniGasPumpConfig_CreateBuildingDef_Patch
    {
        public static void Postfix(BuildingDef __result)
        {
            __result.EnergyConsumptionWhenActive = 30.0f;
        }
    }
}