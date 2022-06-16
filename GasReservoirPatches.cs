using HarmonyLib;
using UnityEngine;

class GasReservoirPatches
{

    [HarmonyPatch(typeof(GasReservoirConfig), nameof(GasReservoirConfig.ConfigureBuildingTemplate))]
    class GasReservoir_ConfigureBuildingTemplate_Patch
    {
        public static void Postfix(GameObject go)
        {
            var storage = go.GetComponent<Storage>();
            storage.capacityKg = 750f;
            var conduitConsumer = go.GetComponent<ConduitConsumer>();
            conduitConsumer.capacityKG = storage.capacityKg;
        }
    }
}
