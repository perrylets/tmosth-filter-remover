using System;
using System.Reflection;
using MelonLoader;
using HarmonyLib;

namespace Perry.FilterRemover.Patches
{

  [HarmonyPatch(typeof(NameEntryScreen), START)]
  class Start
  {

    const string EXISTING_CHARACTERS = "existingCharacters";
    const string START = "Start";

    static void Postfix(NameEntryScreen __instance)
    {

      FieldInfo existingCharacters = typeof(NameEntryScreen).GetField(EXISTING_CHARACTERS, BindingFlags.NonPublic | BindingFlags.Instance);
      existingCharacters.SetValue(__instance, Array.Empty<String>());
      MelonLogger.Msg($"Existing characters: \"{string.Join('\n', existingCharacters.GetValue(__instance) as string[])}\" ");

    }

  }

}
