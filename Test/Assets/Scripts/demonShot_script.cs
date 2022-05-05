using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demonShot_script : MonoBehaviour
{

    public GameObject bulletShoot;
    [SerializeField] float H_fireForce, Y_fireForce,fireForce,time;
    bool canShoot;
    public bool inRange;

    GameObject body;

    // Start is called before the first frame update
    void Start()
    {
        body = FindObjectOfType<DemonShotRange_Script>().gameObject;
        inRange = false;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot && inRange) { StartCoroutine(shoot()); }
    }

    IEnumerator shoot()
    {
        body.GetComponent<Animator>().SetBool("shoot", true);
        GameObject bullet = Instantiate(bulletShoot, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(new Vector2 ((0+H_fireForce),(0+ + Y_fireForce))* fireForce, ForceMode2D.Impulse);
        canShoot = false;
        
        yield return new WaitForSeconds(time);
        canShoot = true;
        body.GetComponent<Animator>().SetBool("shoot", false);

    }


}
