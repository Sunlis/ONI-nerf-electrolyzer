using HarmonyLib;
using System.Collections.Generic;
using Klei.AI;

class GlobalPatches
{

    public static Dictionary<string, int> MoraleChanges = new Dictionary<string, int>()
    {
        {"Edible0", 2 },
        {"Edible1", 4 },
        {"Edible2", 7 },
        {"Edible3", 10 },

        {"RoomMessHall", 1 },
        {"RoomGreatHall", 3 },
        {"RoomPark", 2 },
        {"RoomNatureReserve", 4 },
    };

    [HarmonyPatch(typeof(Db), nameof(Db.Initialize))]
    class Db_Initialize_Patch
    {
        static void Postfix()
        {
            CookingPatches.TweakFoodValues();

            // Tweak effect values as appropriate
            Debug.Log("Tweaking Effects");
            var effects = Db.Get().effects;
            for (int i = 0; i < effects.Count; i++)
            {
                var effect = effects[i];
                Debug.Log($"{effect.Id}: {effect.Name}");
                if (MoraleChanges.ContainsKey(effect.Id))
                {
                    if (effect.SelfModifiers.Count == 1 && effect.SelfModifiers[0].AttributeId == "QualityOfLife")
                    {
                        effect.SelfModifiers = new List<AttributeModifier>()
                        {
                            new AttributeModifier("QualityOfLife", MoraleChanges[effect.Id], effect.SelfModifiers[0].GetDescription())
                        };
                    }
                    else
                    {
                        Debug.LogWarning($"{effect.Id}: Expected to find exactly one AttributeModifier affecting QualityOfLife, but found {effect.SelfModifiers.Count} modifiers (and/or not matching QualityOfLife, a.k.a. Morale)");
                    }
                }
            }
        }
    }
}