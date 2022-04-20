using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Player player;
    [Header("Target")]
    [SerializeField] bool targetIsPlayer;
    [SerializeField] bool targetIsEnemy;
    [Header("Purpose")]
    [SerializeField] bool isAnAttack;
    [SerializeField] bool isAHeal;
    [SerializeField] bool isASpeedBuff;
    [SerializeField] bool isADamageBuff;
    [Header("Details")]
    [SerializeField] float aOERadius;
    [SerializeField] float buffTimer;
    [SerializeField] float healthChange;
    [SerializeField] float speedChange;
    [SerializeField] float damageChange;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        CheckForTarget();
    }

    private void CheckForTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, aOERadius);
        foreach (Collider c in colliders)
        {
            if (targetIsPlayer == true)
            {
                if (c.GetComponent<Player>() == true)
                {
                    if(isAnAttack == true)
                    {
                        c.GetComponent<Health>().hp = c.GetComponent<Health>().hp - healthChange;
                    }

                    if (isAHeal == true)
                    {
                        c.GetComponent<Health>().hp = c.GetComponent<Health>().hp + healthChange;
                    }

                    if (isASpeedBuff == true)
                    {
                        c.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MovementSettings>().ForwardSpeed =
                            c.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MovementSettings>().ForwardSpeed + speedChange;
                        c.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MovementSettings>().BackwardSpeed =
                            c.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MovementSettings>().BackwardSpeed + speedChange;
                        c.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MovementSettings>().StrafeSpeed =
                            c.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MovementSettings>().StrafeSpeed + speedChange;
                        c.GetComponent<Player>().isBuffed = true;
                        c.GetComponent<Player>().buffTimer = buffTimer;
                    }

                    if (isADamageBuff == true)
                    {
                        c.GetComponentInChildren<DamageDealer>().damage = c.GetComponentInChildren<DamageDealer>().damage + damageChange;
                        c.GetComponentInChildren<BowShooting>().projectile.GetComponent<DamageDealer>().damage =
                             c.GetComponentInChildren<BowShooting>().projectile.GetComponent<DamageDealer>().damage + damageChange;
                        c.GetComponentInChildren<RangedAttack>().projectile.GetComponent<DamageDealer>().damage =
                            c.GetComponentInChildren<RangedAttack>().projectile.GetComponent<DamageDealer>().damage + damageChange;
                        c.GetComponentInChildren<DamageDealer>().isBuffed = true;
                        c.GetComponentInChildren<DamageDealer>().buffTimer = buffTimer;
                        c.GetComponentInChildren<BowShooting>().projectile.GetComponent<DamageDealer>().isBuffed = true;
                        c.GetComponentInChildren<BowShooting>().projectile.GetComponent<DamageDealer>().buffTimer = buffTimer;
                        c.GetComponentInChildren<RangedAttack>().projectile.GetComponent<DamageDealer>().isBuffed = true;
                        c.GetComponentInChildren<RangedAttack>().projectile.GetComponent<DamageDealer>().buffTimer = buffTimer;
                    }
                }
            }

            if (targetIsEnemy == true)
            {
                if (c.GetComponent<EnemyNavigation>() == true)
                {
                    if (isAnAttack == true)
                    {
                        c.GetComponent<Health>().hp = c.GetComponent<Health>().hp - healthChange;
                    }
                    if (isAHeal == true)
                    {
                        c.GetComponent<Health>().hp = c.GetComponent<Health>().hp + healthChange;
                    }
                    if (isASpeedBuff == true)
                    {
                        c.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = c.GetComponent<UnityEngine.AI.NavMeshAgent>().speed + speedChange;
                        c.GetComponent<EnemyNavigation>().isBuffed = true;
                        c.GetComponent<EnemyNavigation>().buffTimer = buffTimer;
                    }
                    if (isADamageBuff == true)
                    {
                        if (c.GetComponent <RangedEnemy>() == true)
                        {
                            c.GetComponent<RangedEnemy>().projectile.GetComponent<DamageDealer>().damage =
                                c.GetComponent<RangedEnemy>().projectile.GetComponent<DamageDealer>().damage + damageChange;
                            c.GetComponent<RangedEnemy>().projectile.GetComponent<DamageDealer>().isBuffed = true;
                            c.GetComponent<RangedEnemy>().projectile.GetComponent<DamageDealer>().buffTimer = buffTimer;
                        }
                        else
                        {
                            c.GetComponentInChildren<DamageDealer>().damage = c.GetComponentInChildren<DamageDealer>().damage + damageChange;
                            c.GetComponentInChildren<DamageDealer>().isBuffed = true;
                            c.GetComponentInChildren<DamageDealer>().buffTimer = buffTimer;
                        }
                    }
                }
            }
        }
    }
}