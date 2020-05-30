//using HarmonyLib;
//using GadgetCore.API;
//using UnityEngine;
//using Roguelands.MoreCombatChips.Services;

//namespace Roguelands.MoreCombatChips.Patches
//{
//  [HarmonyPatch(typeof(ItemStandScript))]
//  [HarmonyPatch("GetChip")]
//  [HarmonyGadget("More Combat Chips")]
//  public static class Patch_ItemStandScript_GetChip
//  {
//    [HarmonyPrefix]
//    public static bool Prefix(ItemStandScript __instance, ref int __result)
//    {
//      if (__instance.isAdvanced)
//      {
//        int randNum = Random.Range(0, 100);
//        if (randNum < 1000)
//        {
//          __result = ChipManagementService.RandomlyGetIDFromAdvanced();
//          MoreCombatChips.GetSingleton().Logger.Log($"Generating Item Stand with Item ID {__result}");
//          return false;
//        }
//      }

//      return true;
//    }
//  }
//}