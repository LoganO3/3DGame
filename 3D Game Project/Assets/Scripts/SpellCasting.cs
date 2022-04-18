using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{
    [SerializeField] Transform shootingPoint;
    [SerializeField] public GameObject projectile;
    [SerializeField] float speed;
    [SerializeField] float waitTimer = .25f;
    public GameObject[] projectiles;
    public int currentProjectile = 0;

    public bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        Fire();
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentProjectile == 0)
            {
                currentProjectile = 1;
                SwitchWeapon();
            }
            else if (currentProjectile == 1)
            {
                currentProjectile = 2;
                SwitchWeapon();
            }
            else if (currentProjectile == 2)
            {
                currentProjectile = 3;
                SwitchWeapon();
            }
            else if (currentProjectile == 3)
            {
                currentProjectile = 0;
                SwitchWeapon();
            }
        }
    }

    void SwitchWeapon()
    {
        projectile = projectiles[currentProjectile];
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1") && canShoot == true)
        {
            canShoot = false;
            GameObject activeProjectile = Instantiate(projectile, transform.position, transform.rotation);
            activeProjectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, speed));
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