using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sillingManager_Script : MonoBehaviour
{

    [SerializeField] GameObject silling;
    [SerializeField] GameObject[] lights;


    private bool isPlayer;

    private void Start()
    {
        isPlayer = false;

        for (int i = 0; i < lights.Length; i++) lights[i].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayer = true;
            silling.SetActive(false);
            for (int i = 0; i < lights.Length; i++) { 
                lights[i].SetActive(true); 
                if (lights[i].GetComponent<EnemiesSpawn_Script>() != null)
                {
                    if (!lights[i].GetComponent<EnemiesSpawn_Script>().active)
                    {
                        lights[i].GetComponent<EnemiesSpawn_Script>().spawnEnemies();
                        lights[i].GetComponent<EnemiesSpawn_Script>().active = true;
                    }
                }
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isPlayer)
        {
            isPlayer = false;
            silling.SetActive(true);
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].SetActive(false);
                if (lights[i].GetComponent<EnemiesSpawn_Script>() != null)
                {
                    if (lights[i].GetComponent<EnemiesSpawn_Script>().active)
                    {
                        lights[i].GetComponent<EnemiesSpawn_Script>().clearEnemies();
                        lights[i].GetComponent<EnemiesSpawn_Script>().active = false;
                    }
                }
            }
        }

    }
}


