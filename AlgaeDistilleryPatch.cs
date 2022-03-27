using HarmonyLib;
using UnityEngine;

class AlgaeDistilleryPatches
{

    [HarmonyPatch(typeof(AlgaeDistilleryConfig), nameof(AlgaeDistilleryConfig.CreateBuildingDef))]
    class AlgaeDistillery_CreateBuildingDef_Patch
    {
        public static void Postfix(BuildingDef __result)
        {
            __result.ExhaustKilowattsWhenActive = 0.25f;
            __result.SelfHeatKilowattsWhenActive = 0.75f;
        }
    }

    [HarmonyPatch(typeof(AlgaeDistilleryConfig), nameof(AlgaeDistilleryConfig.ConfigureBuildingTemplate))]
    class AlgaeDistillery_ConfigureBuildingTemplate_Patch
    {
        public static void Postfix(GameObject go)
        {
            ElementConverter elementConverter = go.GetComponent<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[1]
            {
                new ElementConverter.ConsumedElement(SimHashes.SlimeMold.CreateTag(), 3f)
            };
            elementConverter.outputElements = new ElementConverter.OutputElement[2]
            {
                new ElementConverter.OutputElement(1f, SimHashes.Algae, 303.15f, storeOutput: true, outputElementOffsety: 1f),
                new ElementConverter.OutputElement(2f, SimHashes.DirtyWater, 303.15f, storeOutput: true)
            };
        }
    }
}