using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    public GameObject player;
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
        if (player == true)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < 20)
            {
                GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            }
            else if (GetComponent<Health>().hp < health)
            {
                GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            }
            else
            {
                GetComponent<NavMeshAgent>().SetDestination(home);
            }
        }
    }
}
