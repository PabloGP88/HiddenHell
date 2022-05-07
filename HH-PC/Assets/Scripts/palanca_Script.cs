using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palanca_Script : MonoBehaviour
{

    public bool red, blue, purple, green;

    Animator animator;
    BoxCollider2D box;

    [SerializeField] GameObject spawnEffect, spawn;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(box);
            animator.SetBool("active", true);
            Instantiate(spawnEffect, spawn.transform.position, Quaternion.identity);
        }
    }

}
