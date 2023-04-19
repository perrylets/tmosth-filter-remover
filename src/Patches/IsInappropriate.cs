using HarmonyLib;

namespace Perry.FilterRemover.Patches
{
  [HarmonyPatch(typeof(NameEntryScreen), "IsInappropriate")]
  class IsInappropriate
  {

    static bool Prefix(ref bool __result)
    {

      __result = false;

      return false;

    }



  }

}
