//using HarmonyLib;
//using GadgetCore.API;

//namespace Roguelands.MoreCombatChips.Patches
//{
//  [HarmonyPatch(typeof(ItemStandScript))]
//  [HarmonyPatch("GetChipName")]
//  [HarmonyGadget("More Combat Chips")]
//  public static class Patch_ItemStandScript_GetChipName
//  {
//    [HarmonyPrefix]
//    public static bool Prefix(int id)
//    {
//      MoreCombatChips.GetSingleton().Logger.Log($"Starting GetChipName: id = {id}");

//      return true;
//    }
//  }
//}