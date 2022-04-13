using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowShooting : MonoBehaviour
{
    [SerializeField] Transform shootingPoint;
    [SerializeField] public GameObject projectile;
    [SerializeField] float speed;
    [SerializeField] float waitTimer = .25f;

    // Start is called before the first frame update
    void Start()
    {
        
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
            return;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject projectiles = Instantiate(projectile, transform.position, transform.rotation);
            projectiles.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, speed));
        }
    }
}