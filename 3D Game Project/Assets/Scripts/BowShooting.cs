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
    Animator m_Animator;

    void Start()
    {
        m_Animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (drawLevel == 0)
        {
            speed = 0;
        }
        else if (drawLevel == 1)
        {
            speed = 5000;
        }
        else if (drawLevel == 2)
        {
            speed = 10000;
        }
        else if (drawLevel == 3)
        {
            speed = 15000;
        }
        else if (drawLevel == 4)
        {
            speed = 20000;
        }
        else if (drawLevel == 5)
        {
            speed = 25000;
        }
        else if (drawLevel == 6)
        {
            speed = 30000;
        }
        else if (drawLevel == 7)
        {
            speed = 35000;
        }
        else if (drawLevel == 8)
        {
            speed = 40000;
        }
        else if (drawLevel == 9)
        {
            speed = 45000;
        }
        else if (drawLevel == 10)
        {
            speed = 50000;
        }
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(DrawBack());
            m_Animator.SetBool("ShootingBow", true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject projectiles = Instantiate(projectile, transform.position, transform.rotation);
            projectiles.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, speed));
            drawLevel = 0;
            m_Animator.SetBool("ShootingBow", false);
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