using HarmonyLib;
using System;

class ArtDecorPatches
{
    [HarmonyPatch(typeof(Artable.Stage), MethodType.Constructor, new Type[] { typeof(string), typeof(string), typeof(string), typeof(int), typeof(bool), typeof(Artable.Status) })]
    class ArtableStage_Constructor_Patch
    {
        public static void Prefix(ref int decor_value)
        {
            decor_value *= 3;
        }
    }
}