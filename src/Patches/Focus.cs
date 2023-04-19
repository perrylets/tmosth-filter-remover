using System;
using System.Reflection;
using MelonLoader;
using HarmonyLib;

namespace Perry.FilterRemover.Patches
{

  [HarmonyPatch(typeof(NameEntryScreen), nameof(NameEntryScreen.Focus))]
  class Focus
  {

    const string EXISTING_CHARACTERS = "existingCharacters";

    static void Postfix(NameEntryScreen __instance)
    {

      MelonLogger.Msg(__instance);
      FieldInfo existingCharacters = typeof(NameEntryScreen).GetField(EXISTING_CHARACTERS, BindingFlags.NonPublic | BindingFlags.Instance);
      existingCharacters.SetValue(__instance, Array.Empty<String>());
      MelonLogger.Msg(string.Join('\n', existingCharacters.GetValue(__instance) as string[]));

    }

  }

}
