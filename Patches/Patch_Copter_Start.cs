using GadgetCore.API;
using HarmonyLib;
using System.Collections;
using System.Reflection;
using UnityEngine;

namespace Roguelands.MoreCombatChips.Patches
{
  [HarmonyPatch(typeof(Copter))]
  [HarmonyPatch("Start")]
  [HarmonyGadget("More Combat Chips")]
  public static class Patch_Copter_Start
  {
    [HarmonyPrefix]
    public static bool Prefix(Copter __instance, ref Rigidbody ___r)
    {
      ___r = __instance.GetComponent<Rigidbody>();

      MethodInfo methodInfo = typeof(Copter).GetMethod("Move", BindingFlags.NonPublic | BindingFlags.Instance);
      __instance.StartCoroutine((IEnumerator)methodInfo.Invoke(__instance, new object[0]));

      return false;
    }
  }
}