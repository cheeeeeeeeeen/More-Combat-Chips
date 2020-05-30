using UnityEngine;

namespace Roguelands.MoreCombatChips.Scripts
{
  public abstract class BaseScript : MonoBehaviour
  {
    protected readonly float volume = Menuu.soundLevel / 10f;
  }
}