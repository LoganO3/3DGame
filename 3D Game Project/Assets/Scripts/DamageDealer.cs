using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damage = 5;
    public float buffTimer;
    public bool isBuffed = false;
    float standardDamage;

    private void Start()
    {
        standardDamage = damage;  
    }

    private void Update()
    {
        if (isBuffed)
        {
            StartCoroutine(buff());
            isBuffed = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().hp = collision.gameObject.GetComponent<Health>().hp - damage;
        }
    }

    IEnumerator buff()
    {
        yield return new WaitForSeconds(buffTimer);
        damage = standardDamage;
    }
}
