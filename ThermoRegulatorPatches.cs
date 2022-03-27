using HarmonyLib;
using UnityEngine;

class ThermoRegulatorPatches
{
    [HarmonyPatch(typeof(AirConditionerConfig), nameof(AirConditionerConfig.ConfigureBuildingTemplate))]
    class AirConditionerConfig_ConfigureBuildingTemplate_Patch
    {
        public static void Postfix(GameObject go)
        {
            var ac = go.GetComponent<AirConditioner>();
            ac.temperatureDelta = -38f;
        }
    }
}