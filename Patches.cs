using HarmonyLib;

namespace ONI_Rebalancing_Mod
{
    public class Patches
    {
        [HarmonyPatch(typeof(Db))]
        [HarmonyPatch("Initialize")]
        public class Db_Initialize_Patch
        {
            public static void Prefix()
            {
                Debug.Log("Initializing ONI Rebalancing Mod...");
            }

            public static void Postfix()
            {
                Debug.Log("ONI Rebalancing Mod initialized!");
            }
        }
    }
}
