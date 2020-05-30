using GadgetCore.API;
using Roguelands.MoreCombatChips.Scripts;
using UnityEngine;

namespace Roguelands.MoreCombatChips.Projectiles
{
  internal class MessyMkIProjectileResource : BaseProjectileResource
  {
    public void AddResource()
    {
      gameObject = Object.Instantiate(GadgetCoreAPI.GetSpecialProjectileResource("silversh"));
      AddProjectileBehavior();
      GadgetCoreAPI.AddCustomResource("MoreCombatChips/MessyMkIProjectile", gameObject);
    }

    private void AddProjectileBehavior()
    {
      Object.Destroy(gameObject.GetComponent<Projectile>());
      gameObject.AddComponent<MessyMkIProjectileScript>();
    }
  }
}