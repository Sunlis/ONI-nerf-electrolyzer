using HarmonyLib;
using UnityEngine;

class AlgaeTerrariumPatches
{
    [HarmonyPatch(typeof(AlgaeHabitatConfig), nameof(AlgaeHabitatConfig.ConfigureBuildingTemplate))]
    class AlgaeHabitatConfig_ConfigureBuildingTemplate_Patch
    {
        public static void Postfix(GameObject go)
        {
            var waterTag = SimHashes.Water.CreateTag();
            var convertersUntyped = go.GetComponents(typeof(ElementConverter));
            foreach (ElementConverter converter in convertersUntyped)
            {
                if (converter.outputElements.Length == 1 && converter.outputElements[0].elementHash == SimHashes.DirtyWater)
                {
                    converter.outputElements[0].massGenerationRate = 0.0403334f;
                }
                else if (converter.consumedElements.Length == 2 && converter.consumedElements[1].tag == waterTag)
                {
                    converter.consumedElements[1].massConsumptionRate = 0.05f;
                }
            }
        }
    }
}