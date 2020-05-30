//using HarmonyLib;
//using GadgetCore.API;

//namespace Roguelands.MoreCombatChips.Patches
//{
//  [HarmonyPatch(typeof(ItemStandScript))]
//  [HarmonyPatch("Set")]
//  [HarmonyGadget("More Combat Chips")]
//  public static class Patch_ItemStandScript_Set
//  {
//    [HarmonyPrefix]
//    public static bool Prefix(int[] p)
//    {
//      MoreCombatChips.GetSingleton().Logger.Log($"Starting ItemStandScript Set: p[0] = {p[0]}, p[1] = {p[1]}");

//      return true;
//    }
//  }
//}