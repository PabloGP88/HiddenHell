using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_script : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (col.gameObject.GetComponent<lantern_Script>().timeLantern < col.gameObject.GetComponent<lantern_Script>().timeMaxLantern) { Destroy(gameObject); } 
        }
    }

}
