using System.Collections;
using UnityEngine;

namespace Roguelands.MoreCombatChips.Scripts
{
  public class MessyMkIScript : BaseTurretScript
  {
    private int damage;
    private Vector3 direction;
    private float attackAngle = 45f;
    private Vector3 attackDirection = Vector3.right;
    private float speed = 30f;
    private bool isShooting = false;
    private readonly int attackTimes = 50;
    private readonly float attackRate = 0.05f;
    private readonly float attackAngleIncrement = 15f;
    private readonly float minSpeed = 0.4f;
    private readonly float speedToStartShooting = 1.2f;

    [RPC]
    public virtual void Set(int damage, Vector3 direction)
    {
      MoreCombatChips.Log($"Set: {direction}");
      GetComponent<NetworkView>().RPC("SetSound", RPCMode.All);
      GetComponent<NetworkView>().RPC("SyncFields", RPCMode.AllBuffered, damage, direction);
    }

    [RPC]
    private void SyncFields(int damage, Vector3 direction)
    {
      this.damage = damage;
      this.direction = direction;
    }

    private void Update()
    {
      transform.Translate(direction * speed * Time.deltaTime);
      if (!isShooting && speed <= speedToStartShooting)
      {
        isShooting = true;
        StartCoroutine(Shoot());
      }
      speed = Mathf.Lerp(minSpeed, speed, 0.9f);
    }

    private IEnumerator Shoot()
    {
      // This method is being synced through SetShoot, so no need to sync.
      for (int i = 0; i < attackTimes; i++)
      {
        yield return new WaitForSeconds(attackRate);
        SetProjectile();
      }
      yield return new WaitForSeconds(1f);
      Die();

      yield break;
    }

    private void SetProjectile()
    {
      GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Au/turret"), volume * 0.25f);
      attackDirection = new Vector3(Mathf.Sin(Mathf.Deg2Rad * attackAngle), Mathf.Cos(Mathf.Deg2Rad * attackAngle), 0f);
      SpawnProjectile(attackDirection);
      SpawnProjectile(attackDirection * -1);
      SpawnProjectile(new Vector3(attackDirection.x, -attackDirection.y, attackDirection.z));
      SpawnProjectile(new Vector3(-attackDirection.x, attackDirection.y, attackDirection.z));
      UpdateAttackAngle();
    }

    private void SpawnProjectile(Vector3 moveTowards)
    {
      GameObject proj = (GameObject)Instantiate(Resources.Load("MoreCombatChips/MessyMkIProjectile"), transform.position, Quaternion.identity);
      proj.GetComponent<MessyMkIProjectileScript>().Set(damage, GameScript.MODS[10], moveTowards);
    }

    private void UpdateAttackAngle()
    {
      attackAngle += attackAngleIncrement;
      if (attackAngle >= 360f)
      {
        attackAngle -= 360f;
      }
    }
  }
}