using GadgetCore.API;
using Roguelands.MoreCombatChips.Scripts;
using UnityEngine;

namespace Roguelands.MoreCombatChips.Projectiles
{
  public class MessyMkIResource : BaseProjectileResource
  {
    public void AddResource()
    {
      gameObject = Object.Instantiate(GadgetCoreAPI.GetProjectileResource("turret"));
      AddDroneBehavior();
      UpdateTexture();
      GadgetCoreAPI.AddCustomResource("MoreCombatChips/MessyMkI", gameObject);
    }

    private void AddDroneBehavior()
    {
      Object.Destroy(gameObject.GetComponent<TurretScript>());
      gameObject.AddComponent<MessyMkIScript>();
    }

    private void UpdateTexture()
    {
      foreach (MeshRenderer child in gameObject.transform.GetComponentsInChildren<MeshRenderer>())
      {
        switch (child.name)
        {
          case "Plane_001":
          case "eye":
            Object.Destroy(child.gameObject);
            break;

          case "Plane":
            child.material.SetTexture("_MainTex", GadgetCoreAPI.LoadTexture2D("SmallSample"));
            break;
        }
      }
    }
  }
}