using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            Debug.Log("Hit");
            collision.gameObject.GetComponent<Health>().hp = collision.gameObject.GetComponent<Health>().hp - damage;
        }
    }
}
