using HarmonyLib;
using UnityEngine;

class PlantDecorPatches
{
    // utility
    public static void ChangeDecorTo(GameObject go, EffectorValues decor)
    {
        var decorPlantComponent = go.GetComponent<PrickleGrass>();
        decorPlantComponent.positive_decor_effect = decor;
        var decorProvider = go.GetComponent<DecorProvider>();
        if (decorProvider != null)
        {
            decorProvider.SetValues(decor);
        }
    }

    // Jumping Joya
    [HarmonyPatch(typeof(CactusPlantConfig), nameof(CactusPlantConfig.CreatePrefab))]
    class JumpingJoya_CreatePrefab_Patch
    {
        public static void Postfix(GameObject __result)
        {
            ChangeDecorTo(__result, new EffectorValues(10, 3)); 
        }
    }

    // Mirth Leaf
    [HarmonyPatch(typeof(LeafyPlantConfig), nameof(LeafyPlantConfig.CreatePrefab))]
    class MirthLeaf_CreatePrefab_Patch
    {
        public static void Postfix(GameObject __result)
        {
            ChangeDecorTo(__result, new EffectorValues(15, 4));
        }
    }

    // Bluff Briar
    [HarmonyPatch(typeof(PrickleGrassConfig), nameof(PrickleGrassConfig.CreatePrefab))]
    class BluffBriar_CreatePrefab_Patch
    {
        public static void Postfix(GameObject __result)
        {
            ChangeDecorTo(__result, new EffectorValues(15, 4));
        }
    }

    // Mellow Mallow
    [HarmonyPatch(typeof(WineCupsConfig), nameof(WineCupsConfig.CreatePrefab))]
    class MellowMallow_CreatePrefab_Patch
    {
        public static void Postfix(GameObject __result)
        {
            ChangeDecorTo(__result, new EffectorValues(15, 4));
        }
    }

    // Bliss Burst
    [HarmonyPatch(typeof(CylindricaConfig), nameof(CylindricaConfig.CreatePrefab))]
    class BlissBurst_CreatePrefab_Patch
    {
        public static void Postfix(GameObject __result)
        {
            ChangeDecorTo(__result, new EffectorValues(15, 4));
        }
    }

    // Bliss Burst (can't find)
    // Mellow Mallow (can't find)
}