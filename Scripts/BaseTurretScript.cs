using UnityEngine;

namespace Roguelands.MoreCombatChips.Scripts
{
  public abstract class BaseTurretScript : BaseScript
  {
    [RPC]
    protected virtual void SetSound()
    {
      GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Au/turret1"), volume);
    }

    protected virtual void Die()
    {
      Instantiate(Resources.Load("ex2"), transform.position, Quaternion.identity);
      Network.RemoveRPCs(GetComponent<NetworkView>().viewID);
      Network.Destroy(gameObject);
    }
  }
}