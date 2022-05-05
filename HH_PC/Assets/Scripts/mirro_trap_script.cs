using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirro_trap_script : MonoBehaviour
{
    [SerializeField] GameObject zombie,zombiePrefab;
    [SerializeField] float opacity;

    private Color sprColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (zombie.GetComponent<SpriteRenderer>().color.a >= 1)
        {
            Destroy(GetComponent<BoxCollider2D>());
            Instantiate(zombiePrefab, transform.position, Quaternion.identity);
            sprColor = zombie.GetComponent<SpriteRenderer>().color;
            sprColor.a = 0;
            zombie.GetComponent<SpriteRenderer>().color = sprColor;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sprColor = zombie.GetComponent<SpriteRenderer>().color;
            sprColor.a += opacity * Time.deltaTime;
            zombie.GetComponent<SpriteRenderer>().color = sprColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sprColor = zombie.GetComponent<SpriteRenderer>().color;
            sprColor.a = 0;
            zombie.GetComponent<SpriteRenderer>().color = sprColor;
        }
    }

}
