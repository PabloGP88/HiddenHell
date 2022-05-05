using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Script : MonoBehaviour
{

    [SerializeField] GameObject panel;

    public bool pause;

    // Start is called before the first frame update
    void Start()
    {
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkScape();
        if (pause)
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!pause)
        {
            panel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    void checkScape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = true;
        }
    }


}
