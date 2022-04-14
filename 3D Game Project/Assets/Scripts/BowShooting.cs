using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowShooting : MonoBehaviour
{
    [SerializeField] Transform shootingPoint;
    [SerializeField] public GameObject projectile;
    [SerializeField] float speed;
    [SerializeField] float waitTimer = .25f;
    [SerializeField] float drawLevel = 0;

    // Update is called once per frame
    void Update()
    {
        if (drawLevel == 0)
        {
            speed = 0;
        }
        else if (drawLevel == 1)
        {
            speed = 100;
        }
        else if (drawLevel == 2)
        {
            speed = 200;
        }
        else if (drawLevel == 3)
        {
            speed = 300;
        }
        else if (drawLevel == 4)
        {
            speed = 400;
        }
        else if (drawLevel == 5)
        {
            speed = 500;
        }
        else if (drawLevel == 6)
        {
            speed = 600;
        }
        else if (drawLevel == 7)
        {
            speed = 700;
        }
        else if (drawLevel == 8)
        {
            speed = 800;
        }
        else if (drawLevel == 9)
        {
            speed = 900;
        }
        else if (drawLevel == 10)
        {
            speed = 1000;
        }
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(DrawBack());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject projectiles = Instantiate(projectile, transform.position, transform.rotation);
            projectiles.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, speed));
            drawLevel = 0;
            StopAllCoroutines();
        }
    }

    IEnumerator DrawBack()
    {
        yield return new WaitForSeconds(waitTimer);
        drawLevel++;
        StartCoroutine(DrawBack());
    }
}