using HarmonyLib;

class ArborTreePatches
{
    //[HarmonyPatch(typeof(ForestTreeBranchConfig), nameof(ForestTreeBranchConfig.CreatePrefab))]
    class ArborTree_CreatePrefab_Patch
    {
        static void Prepare()
        {
            for(int i = 0; i < TUNING.CROPS.CROP_TYPES.Count; i++)
            {
                var current = TUNING.CROPS.CROP_TYPES[i];
                if (current.cropId == "WoodLog")
                {
                    TUNING.CROPS.CROP_TYPES[i] = new Crop.CropVal(
                        current.cropId,
                        current.cropDuration,
                        250,
                        current.renewable
                    );
                }
            }
        }
    }
}