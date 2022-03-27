using HarmonyLib;
using UnityEngine;


public class DesalinatorPatches
{
    [HarmonyPatch(typeof(DesalinatorConfig), nameof(DesalinatorConfig.CreateBuildingDef))]
    public class DesalinatorConfig_CreateBuildingDef_Patch
    {
        public static void Postfix(BuildingDef __result)
        {
            __result.EnergyConsumptionWhenActive = 120f;
            __result.SelfHeatKilowattsWhenActive = 4f;
        }
    }

    [HarmonyPatch(typeof(DesalinatorConfig), nameof(DesalinatorConfig.ConfigureBuildingTemplate))]
    public class DesalinatorConfig_ConfigureBuildingTemplate_Patch
    {
        public static void Postfix(GameObject go)
        {
            var emptyChore = go.GetComponent<DesalinatorWorkableEmpty>();
            emptyChore.workTime = 30f;
        }
    }
}
