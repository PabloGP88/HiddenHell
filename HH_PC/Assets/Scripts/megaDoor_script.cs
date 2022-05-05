using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class megaDoor_script : MonoBehaviour
{

    [SerializeField] GameObject panel;
    [SerializeField] float timeWin;
    [SerializeField] BoxCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            if (player.GetComponent<keyManager_Script>().megaKey == true)
            {
                Destroy(col);
                GetComponent<Animator>().SetBool("Player", true);
                StartCoroutine(Win());
            }         
        }
    }

    IEnumerator Win()
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(timeWin);
        SceneManager.LoadScene("Win");
    }
}
