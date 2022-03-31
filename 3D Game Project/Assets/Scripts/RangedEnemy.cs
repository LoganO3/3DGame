using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField] Transform shootingPoint;
    [SerializeField] public GameObject projectile;
    [SerializeField] float projectileSpeed;
    [SerializeField] float minTimeBetweenShots = .2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    public GameObject playerObject;
    public float shootingDistance;
    float speed;
    float shotCounter;
    int damping = 2;
    Vector3 home;

    // Start is called before the first frame update
    void Start()
    {
        home = transform.position;
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject == true)
        {
            var lookPos = playerObject.GetComponent<Transform>().position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            CountDownAndShoot();
            float followDistance = Vector3.Distance(transform.position, playerObject.transform.position);
            Vector3 Distance = transform.position - playerObject.transform.position;
            Vector3 DistanceNormalized = Distance.normalized;
            Vector3 targetPosition = playerObject.transform.position + (DistanceNormalized * shootingDistance);
            if (followDistance > 20)
            {
                GetComponent<NavMeshAgent>().SetDestination(home);
            }
            else if (GetComponent<NavMeshAgent>().destination == targetPosition)
            {
                return;
            }
            else
            {
                GetComponent<NavMeshAgent>().SetDestination(targetPosition);
            }
        }
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            var lookPos = playerObject.GetComponent<Transform>().position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject projectiles = Instantiate(projectile, transform.position, transform.rotation);
        projectiles.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, projectileSpeed));
    }
}