using HarmonyLib;
using UnityEngine;

class EthanolDistilleryPatches
{

    [HarmonyPatch(typeof(EthanolDistilleryConfig), nameof(EthanolDistilleryConfig.CreateBuildingDef))]
    class EthanolDistillery_CreateBuildingDef_Patch
    {
        public static void Postfix(BuildingDef __result)
        {
            __result.EnergyConsumptionWhenActive = 120f;
            __result.SelfHeatKilowattsWhenActive = 1.5f;
        }
    }

    [HarmonyPatch(typeof(EthanolDistilleryConfig), nameof(EthanolDistilleryConfig.ConfigureBuildingTemplate))]
    class EthanolDistillery_ConfigureBuildingTemplate_Patch
    { 
        public static void Postfix(GameObject go)
        { 
            ElementConverter elementConverter = go.GetComponent<ElementConverter>();
            elementConverter.outputElements = new ElementConverter.OutputElement[3]
            {
                new ElementConverter.OutputElement(0.7f, SimHashes.Ethanol, 323.15f, storeOutput: true),
                new ElementConverter.OutputElement(0.2f, SimHashes.ToxicSand, 323.15f, storeOutput: true),
                new ElementConverter.OutputElement(0.1f, SimHashes.CarbonDioxide, 343.15f)
            };
        }
    }
}