using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lantern_Script : MonoBehaviour
{
    [SerializeField] float  timeLanternRest, battery;
    [SerializeField] GameObject lantern;
    [SerializeField] Image verde1, verde2, amarillo1, amarillo2, rojo;

    public float timeLantern, timeMaxLantern;
    // Start is called before the first frame update
    void Start()
    {
        timeLantern = timeMaxLantern;
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        if (gameObject.GetComponent<life_manager>().alive == true)
        {
            timerLantern();
            UIBattery();
        }

    }

    void timerLantern()
    {
        timeLantern -= timeLanternRest * Time.deltaTime;
        if (timeLantern > timeMaxLantern)
        {
            timeLantern = timeMaxLantern;
        }
        if (timeLantern < 0)
        {
            lantern.SetActive(false);
        }
        if (timeLantern > 0)
        {
            lantern.SetActive(true);
        }
    }

    void UIBattery()
    {
        if (timeLantern < 144f)
        {
            verde1.enabled = false;
        } else if (timeLantern > 144f) verde1.enabled = true;

        if (timeLantern < 108f)
        {
            verde2.enabled = false;
        }
        else if (timeLantern > 108f) verde2.enabled = true;

        if (timeLantern < 72f)
        {
            amarillo1.enabled = false;
        }
        else if (timeLantern >  72f) amarillo1.enabled = true;

        if (timeLantern < 36f)
        {
            amarillo2.enabled = false;
        }
        else if (timeLantern > 36f) amarillo2.enabled = true;

        if (timeLantern < 0f)
        {
            rojo.enabled = false;
        }
        else if (timeLantern > 0f) rojo.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bateria" && timeLantern<timeMaxLantern)
        {
            timeLantern += battery;
        }
    }

    
}
