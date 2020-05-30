//using HarmonyLib;
//using GadgetCore.API;
//using Roguelands.MoreCombatChips.Services;
//using Roguelands.MoreCombatChips.DataStructures;

//namespace Roguelands.MoreCombatChips.Patches
//{
//  [HarmonyPatch(typeof(ItemStandScript))]
//  [HarmonyPatch("GetChipCost")]
//  [HarmonyGadget("More Combat Chips")]
//  public static class Patch_ItemStandScript_GetChipCost
//  {
//    [HarmonyPrefix]
//    public static bool Prefix(int id, ref int __result)
//    {
//      MoreCombatChips.GetSingleton().Logger.Log($"Starting GetChipCost: ID is {id}");
//      int index = ChipManagementService.GetIndexFromList(id);
//      if (index != -1)
//      {
//        ModdedChip modChip = ChipManagementService.GetChipByIndex(index);
//        if (modChip.minCost >= 0 || modChip.maxCost >= 0)
//        {
//          __result = modChip.ComputeCost();
//          return false;
//        }
//      }
//      return true;
//    }
//  }
//}