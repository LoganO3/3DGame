using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [SerializeField] Transform shootingPoint;
    [SerializeField] public GameObject projectile;
    [SerializeField] float speed;
    [SerializeField] float waitTimer = .25f;

    public bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1") && canShoot == true)
        {
            canShoot = false;
            GameObject projectiles = Instantiate(projectile, transform.position, transform.rotation);
            projectiles.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, speed));
            StartCoroutine(Wait());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            return;
        }
    }

    IEnumerator Wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTimer);
            canShoot = true;
            StopCoroutine(Wait());
        }
    }
}