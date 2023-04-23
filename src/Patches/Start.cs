using System;
using System.Reflection;
using MelonLoader;
using HarmonyLib;
using TMPro;

namespace Perry.FilterRemover.Patches
{


  [HarmonyPatch(typeof(NameEntryScreen), START)]
  class Start
  {
    const string EXISTING_CHARACTERS = "existingCharacters";
    const string START = "Start";
    const string INPUT_FIELD = "_inputField";

    static void Postfix(NameEntryScreen __instance)
    {


      FieldInfo existingCharacters = __instance.GetType().GetField(EXISTING_CHARACTERS, BindingFlags.NonPublic | BindingFlags.Instance);
      existingCharacters.SetValue(__instance, Array.Empty<String>());
      MelonLogger.Msg($"Existing characters: \"{string.Join('\n', existingCharacters.GetValue(__instance) as string[])}\" ");
      FieldInfo inputFieldInfo = __instance.GetType().GetField(INPUT_FIELD, BindingFlags.NonPublic | BindingFlags.Instance);
      TMP_InputField? inputField = inputFieldInfo.GetValue(__instance) as TMP_InputField;
      if (inputField is null)
      {
        MelonLogger.Error("Input field is null");
        return;
      }
      inputField.characterLimit = 0;
      inputFieldInfo.SetValue(__instance, inputField);
      MelonLogger.Msg($"Name character limit: {(inputFieldInfo.GetValue(__instance) as TMP_InputField)?.characterLimit}");

    }

  }

}
