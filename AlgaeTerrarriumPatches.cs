using HarmonyLib;
using UnityEngine;

class AlgaeTerrariumPatches
{
    [HarmonyPatch(typeof(AlgaeHabitatConfig), nameof(AlgaeHabitatConfig.ConfigureBuildingTemplate))]
    class AlgaeHabitatConfig_ConfigureBuildingTemplate_Patch
    {
        public static void Postfix(GameObject go)
        {
            var converters = go.GetComponents<ElementConverter>();
            if (converters != null || converters.Length != 2)
            {
                Debug.Log("Unable to patch algae terrarium");
                return;
            }
            var oxygenIdx = converters[0].outputElements[0].elementHash == SimHashes.Oxygen? 0: 1; // this one has the water consumer on the input side
            var pwaterIdx = 1 - oxygenIdx;
            converters[oxygenIdx].consumedElements[1].massConsumptionRate = 0.05f;   // Water:  300      -> 50      g/s
            converters[pwaterIdx].outputElements[0].massGenerationRate = 0.0403334f; // PWater: 290.3334 -> 40.3334 g/s
        }
    }
}