using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [SerializeField] Transform shootingPoint;
    [SerializeField] public GameObject projectile;
    [SerializeField] public float projectileFiringPeriod = 1f;
    [SerializeField] float speed;

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
                RaycastHit hit;
                Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                if (Physics.Raycast(ray, out hit, 400.0f))
                {
                    GameObject projectiles = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
                    projectiles.Rigidbody.velocity = (hit.point - transform.position).normalized * speed;
                }
            else
            { yield return new WaitForSeconds(waitTimer); }
        }

    }
}