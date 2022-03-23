using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [SerializeField] Transform shootingPoint;
    [SerializeField] public GameObject projectile;
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
            GameObject projectiles = Instantiate(projectile, transform.position, transform.rotation);
            projectiles.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, speed));
        }
        if (Input.GetButtonUp("Fire1"))
        {
            return;
        }
    }
}