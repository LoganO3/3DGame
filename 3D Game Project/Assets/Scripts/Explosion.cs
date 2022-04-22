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
    [Header("Details")]
    [SerializeField] float aOERadius;
    [SerializeField] float buffTimer;
    [SerializeField] float healthChange;

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
                    else { return; }
                    if (isAHeal == true)
                    {
                        c.GetComponent<Health>().hp = c.GetComponent<Health>().hp + healthChange;
                    }
                    else { return; }
                }
                else { return; }
            }
            else { return; }

            if (targetIsEnemy == true)
            {
                if (c.GetComponent<EnemyNavigation>() == true)
                {
                    if (isAnAttack == true)
                    {
                        c.GetComponent<Health>().hp = c.GetComponent<Health>().hp - healthChange;
                    }
                    else { return; }
                    if (isAHeal == true)
                    {
                        c.GetComponent<Health>().hp = c.GetComponent<Health>().hp + healthChange;
                    }
                    else { return; }
                }
                else { return; }
            }
            else { return; }
        }
    }
}