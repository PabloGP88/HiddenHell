using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonShotRange_Script : MonoBehaviour
{
    [SerializeField] GameObject[] firePoints;
    [SerializeField] GameObject dustEffect;
    [SerializeField] private float iniBox_X, iniBox_Y, Box_X, Box_Y;
    [SerializeField] private Sprite[] sprite;

    private bool playerIn;

    BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        iniBox_X = boxCollider.size.x;
        iniBox_Y = boxCollider.size.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            boxCollider.size = new Vector2(Box_X, Box_Y);
            Instantiate(dustEffect, transform.position, Quaternion.identity);
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite[1];
            for (int i = 0; i < firePoints.Length; i++)
            {
                firePoints[i].GetComponent<demonShot_script>().inRange = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite[0];
            boxCollider.size = new Vector2(iniBox_X, iniBox_Y);
            for (int i = 0; i < firePoints.Length; i++)
            {
                firePoints[i].GetComponent<demonShot_script>().inRange = false;
            }
        }
    }


}
