using HarmonyLib;
using UnityEngine;

class PetroleumGeneratorPatches
{
    [HarmonyPatch(typeof(PetroleumGeneratorConfig), nameof(PetroleumGeneratorConfig.CreateBuildingDef))]
    class PetroleumGeneratorConfig_CreateBuildingDef_Patch
    {
        public static void Postfix(BuildingDef __result)
        {
            __result.SelfHeatKilowattsWhenActive = 4.0f;
            __result.ExhaustKilowattsWhenActive = 1.0f;
        }
    }

    [HarmonyPatch(typeof(PetroleumGeneratorConfig), nameof(PetroleumGeneratorConfig.DoPostConfigureComplete))]
    class PetroleumGeneratorConfig_DoPostConfigureComplete_Patch
    {
        public static void Postfix(GameObject go)
        {
            var energyGenerator = go.GetComponent<EnergyGenerator>();
            // reduce polluted water output to compensate for ethanol distiller buff
            // incidentally, this also makes petroleum boilers no longer water-positive
            energyGenerator.formula = new EnergyGenerator.Formula()
            {
                inputs = new EnergyGenerator.InputItem[1]
                {
                    new EnergyGenerator.InputItem(GameTags.CombustibleLiquid, 2f, 20f)
                },
                outputs = new EnergyGenerator.OutputItem[2]
                {
                    new EnergyGenerator.OutputItem(SimHashes.CarbonDioxide, 0.5f, false, new CellOffset(0, 3), 383.15f),
                    new EnergyGenerator.OutputItem(SimHashes.DirtyWater, 0.6f, false, new CellOffset(1, 1), 313.15f)
                }
            };
        }
    }
}
