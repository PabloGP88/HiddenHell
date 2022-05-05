using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llave_Script : MonoBehaviour
{

    private AudioManager_Script audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager_Script>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioManager.SelectSound(2, 0.5f);
        }
    }
}
