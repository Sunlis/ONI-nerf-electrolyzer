using HarmonyLib;
using UnityEngine;
using TUNING;

class SmartStoragePatches
{
    [HarmonyPatch(typeof(StorageLockerSmartConfig), nameof(StorageLockerSmartConfig.CreateBuildingDef))]
    public class SmartStorage_BuildingDef
    {
        public static void Postfix(BuildingDef __result)
        {
            __result.RequiresPowerInput = false;
            __result.EnergyConsumptionWhenActive = 0f;
            __result.ExhaustKilowattsWhenActive = 0f;
            __result.MaterialCategory = MATERIALS.ALL_METALS;
        }
    }
}