using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botiquin_scripy : MonoBehaviour
{
    [SerializeField] GameObject healEffect;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                Instantiate(healEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
        }
    }
}
