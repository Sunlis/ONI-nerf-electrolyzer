using HarmonyLib;
using Database;

class RoomTypesPatches
{
    // intercept the constructor arguments for just the great hall
    // it's not possible to edit Database.RoomTypes.GreatHall after the fact since the constraints are private set
    [HarmonyPatch(typeof(RoomType), MethodType.Constructor, new[] {
        typeof(string),
        typeof(string),
        typeof(string),
        typeof(string),
        typeof(RoomTypeCategory),
        typeof(RoomConstraints.Constraint),
        typeof(RoomConstraints.Constraint[]),
        typeof(RoomDetails.Detail[]),
        typeof(int),
        typeof(RoomType[]),
        typeof(bool),
        typeof(bool),
        typeof(string[]),
        typeof(int)
    })]
    class RoomTypes_Constructor_Patch
    {
        public static void Prefix(string id, ref RoomConstraints.Constraint[] additional_constraints)
        {
            if (id == nameof(RoomTypes.GreatHall))
            {
                additional_constraints = additional_constraints.AddToArray(RoomConstraints.LIGHT);
            }
        }
    }
}
