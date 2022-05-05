using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palancaPlayer_Script : MonoBehaviour
{

    public int[] palanca;
    [SerializeField] GameObject[] celdas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        verifyColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "palanca")
        {
            if (collision.gameObject.GetComponent<palanca_Script>().red)
            {
                palanca[0] = 1;
            }
            if (collision.gameObject.GetComponent<palanca_Script>().blue)
            {
                palanca[1] = 1;
            }
            if (collision.gameObject.GetComponent<palanca_Script>().purple)
            {
                palanca[2] = 1;
            }
            if (collision.gameObject.GetComponent<palanca_Script>().green)
            {
                palanca[3] = 1;
            }
        }
    }


    private void verifyColor()
    {
        if (palanca[0] == 1) Destroy(celdas[0]);
        if (palanca[1] == 1) Destroy(celdas[1]);
        if (palanca[2] == 1) Destroy(celdas[2]);
        if (palanca[3] == 1) Destroy(celdas[3]);
    }


}
