using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] GameObject player;

    // Update is called once per frame
    void Update()
    {
        healthText.text = player.GetComponent<Health>().hp.ToString();
    }
}
