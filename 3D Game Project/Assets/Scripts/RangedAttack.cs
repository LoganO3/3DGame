using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [SerializeField] Transform shootingPoint;
    [SerializeField] public GameObject projectile;
    [SerializeField] public float projectileFiringPeriod = 1f;

    public bool canShoot = true;
    float waitTimer = .25f;
    Player player;

    Coroutine firingCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        { 
                firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
            StartCoroutine(ResetFiring());
        }
    }

    IEnumerator ResetFiring()
    {
        yield return new WaitForSeconds(projectileFiringPeriod);
        canShoot = true;
        StopCoroutine(ResetFiring());
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            if (canShoot == true)
            {
                GameObject projectiles = Instantiate(projectile, shootingPoint.position, shootingPoint.rotation) as GameObject;
                projectiles.GetComponent<Rigidbody>().velocity = new Vector3(10, 10, 10);
                canShoot = false;
                yield return new WaitForSeconds(projectileFiringPeriod);
                canShoot = true;
            }
            else
            { yield return new WaitForSeconds(waitTimer); }
        }
    }
}