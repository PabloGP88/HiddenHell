using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeTrap_Script : MonoBehaviour
{
    [SerializeField] Sprite[] sprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(trapActivated());
        }
    }

    IEnumerator trapActivated()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite[1];
        gameObject.tag = "Enemy";
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite[0];
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.tag = "trap";
    }

}
