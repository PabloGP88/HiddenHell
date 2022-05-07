using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pivote_Script : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Vector2 mousePos;
    private Rigidbody2D rb2d;
    public GameObject player;
    [SerializeField] float y_pos;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<life_manager>().alive == false) Destroy(gameObject);
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y -y_pos, player.transform.position.z);
        }
    }


    private void FixedUpdate()
    {
        // if (player.GetComponent<life_manager>().alive == true) 
        mouseMovment();
    
    }

    void mouseMovment()
    {
        Vector2 lookDir = mousePos - rb2d.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 180f;
        rb2d.rotation = angle;
    }
}
