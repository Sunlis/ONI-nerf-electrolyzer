using HarmonyLib;
using System.Collections.Generic;
using Klei.AI;
using KMod;

class GlobalPatches : UserMod2
{
    public override void OnLoad(Harmony harmony)
    {
        CookingPatches.TweakFoodValues();
        base.OnLoad(harmony);
    }

    public static Dictionary<string, int> MoraleChanges = new Dictionary<string, int>()
    {
        {"Edible0", 2 },
        {"Edible1", 4 },
        {"Edible2", 7 },
        {"Edible3", 10 },

        {"RoomBedroom", 3 },
        {"RoomMessHall", 2 },
        {"RoomGreatHall", 3 },
        {"RoomPark", 2 },
        {"RoomNatureReserve", 4 },

        {"SodaFountain", 2 },
        {"Juicer", 3 },
        {"Danced", 3 },
        {"PlayedArcade", 4 },
        {"Sauna", 3 },
    };

    [HarmonyPatch(typeof(Db), nameof(Db.Initialize))]
    class Db_Initialize_Patch
    {
        static void Postfix()
        {
            // Tweak effect values as appropriate
            Debug.Log("Tweaking Effects");
            var effects = Db.Get().effects;
            for (int i = 0; i < effects.Count; i++)
            {
                var effect = effects[i];
                Debug.Log($"{effect.Id}: {effect.Name}");
                if (MoraleChanges.ContainsKey(effect.Id))
                {
                    bool found = false;
                    foreach (var modifier in effect.SelfModifiers)
                    {
                        if (modifier.AttributeId == "QualityOfLife")
                        {
                            modifier.SetValue(MoraleChanges[effect.Id]);
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Debug.Log($"Could not tweak effect \"{effect.Name}\" to have morale of +{MoraleChanges[effect.Id]}");
                    }
                }
            }

            CritterTrapsAndBaitPatches.TweakTrapTechs();
        }
    }
}