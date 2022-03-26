using HarmonyLib;
using UnityEngine;


public class ElectrolyzerPatches
{
    [HarmonyPatch(typeof(ElectrolyzerConfig), nameof(ElectrolyzerConfig.CreateBuildingDef))]
    public class ElectrolyzerConfig_CreateBuildingDef_Patch
    {
        public static void Postfix(BuildingDef __result)
        {
            __result.EnergyConsumptionWhenActive = 300.0f;
            __result.ExhaustKilowattsWhenActive = 0.5f;
            __result.SelfHeatKilowattsWhenActive = 2.0f;
        }
    }

    [HarmonyPatch(typeof(ElectrolyzerConfig), nameof(ElectrolyzerConfig.ConfigureBuildingTemplate))]
    public class ElectrolyzerConfig_ConfigureBuildingTemplate_Patch
    {
        public static void Postfix(GameObject go, ElectrolyzerConfig __instance)
        {
            var cellOffset = new CellOffset(0, 1);
            var ec = go.GetComponent<ElementConverter>();
            ec.consumedElements = new ElementConverter.ConsumedElement[1]
            {
                new ElementConverter.ConsumedElement(new Tag("Water"), 0.75f)
            };
            ec.outputElements = new ElementConverter.OutputElement[2]
            {
                new ElementConverter.OutputElement(0.666f, SimHashes.Oxygen, 323.15f, outputElementOffsetx: ((float) cellOffset.x), outputElementOffsety: ((float) cellOffset.y)),
                new ElementConverter.OutputElement(0.084f, SimHashes.Hydrogen, 323.15f, outputElementOffsetx: ((float) cellOffset.x), outputElementOffsety: ((float) cellOffset.y))
            };
        }
    }
}
