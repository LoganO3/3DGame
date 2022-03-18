using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage = 5;
    Health health;

    private void Start()
    {
        health = FindObjectOfType<Health>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            health.hp = health.hp - damage;
        }
    }
}
