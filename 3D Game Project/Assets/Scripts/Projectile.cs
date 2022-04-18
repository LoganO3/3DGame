using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]float waitTimer = 6f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }

    IEnumerator Wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTimer);
            Destroy(gameObject);
        }
    }
}
