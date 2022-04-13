using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    public GameObject playerObject;
    public bool isAttacking;
    public float attackDistance;
    float health;
    Vector3 home;

    // Start is called before the first frame update
    void Start()
    {
        home = transform.position;
        health = GetComponent<Health>().hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject == true)
        {
            float followDistance = Vector3.Distance(transform.position, playerObject.transform.position);
            Vector3 Distance = transform.position - playerObject.transform.position;
            Vector3 DistanceNormalized = Distance.normalized;
            Vector3 targetPosition = playerObject.transform.position + (DistanceNormalized * attackDistance);
            if (followDistance > 20)
            {
                GetComponent<NavMeshAgent>().SetDestination(home);
                isAttacking = false;
            }
            else if (GetComponent<Health>().hp < health)
            {
                GetComponent<NavMeshAgent>().SetDestination(targetPosition);
                isAttacking = true;
            }
            else
            {
                GetComponent<NavMeshAgent>().SetDestination(targetPosition);
                isAttacking = true;
            }
        }
    }
}