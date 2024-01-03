using HarmonyLib;
using UnityEngine;


public class ElectrolyzerPatches
{
    [HarmonyPatch(typeof(ElectrolyzerConfig), nameof(ElectrolyzerConfig.CreateBuildingDef))]
    public class ElectrolyzerConfig_CreateBuildingDef_Patch
    {
        public static void Postfix(BuildingDef __result)
        {
            __result.EnergyConsumptionWhenActive = 320f;
        }
    }
}
