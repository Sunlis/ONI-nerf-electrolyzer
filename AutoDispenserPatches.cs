using HarmonyLib;

class AutomaticDispenserPatches
{
    [HarmonyPatch(typeof(ObjectDispenser.States), nameof(ObjectDispenser.States.InitializeStates))]
    class ObjectDispenser_InitializeStates_Patch
    {
        static void Postfix(ObjectDispenser.States __instance)
        {
            // only draw power when dispensing
            __instance.drop_item.Enter(smi => smi.SetActive(smi.GetComponent<Operational>().IsOperational));
            __instance.drop_item.Exit(smi => smi.SetActive(false));
        }
    }

    [HarmonyPatch(typeof(ObjectDispenser.Instance), MethodType.Constructor, new[] {typeof(ObjectDispenser), typeof(bool)})]
    class ObjectDispenserInstance_Constructor_Patch
    {
        static void Postfix(ObjectDispenser.Instance __instance)
        {
            __instance.sm.should_open.Set(false, __instance);
            __instance.SetActive(false);
        }
    }

    [HarmonyPatch(typeof(ObjectDispenser.Instance), "UpdateShouldOpen")]
    class ObjectDispenserInstance_UpdateShouldOpen_Patch
    {
        static bool Prefix(ObjectDispenser.Instance __instance)
        {
            var operational = __instance.GetComponent<Operational>();
            if (operational.IsOperational) // this dispenser is plugged in
            {
                __instance.sm.should_open.Set(__instance.IsOpened, __instance);
            }
            else
            {
                __instance.sm.should_open.Set(false, __instance);
            }
            return false; // totally override the original behavior
        }
    }

    [HarmonyPatch(typeof(ObjectDispenserConfig), nameof(ObjectDispenserConfig.CreateBuildingDef))]
    class ObjectDispenserConfig_BuildingDef_Patch
    {
        static void Postfix(BuildingDef __result)
        {
            __result.EnergyConsumptionWhenActive = 120f;
        }
    }
}