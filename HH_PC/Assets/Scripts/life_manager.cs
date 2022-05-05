using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class life_manager : MonoBehaviour
{
    public bool alive;
    [SerializeField] Text life_text;
    public int lifes;
    [SerializeField] Animator animator;
    [SerializeField] Image panelMorir;
    [SerializeField] Image UI_healEffect;

    private AudioManager_Script audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager_Script>();
        animator.SetBool("alive", true);
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        life_text.text = ("x" + lifes);

        if (lifes <= 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
            animator.SetBool("alive", false);
            alive = false;
            StartCoroutine(panelAnim());

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && lifes > 0)
        {
            lifes--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && lifes > 0)
        {
            lifes--;
        }
        if (collision.gameObject.tag == "Botiquin" && lifes < 3)
        {
            lifes++;
            StartCoroutine(healAnim());
        }
        if(collision.gameObject.tag == "zombie")
        {
            lifes = 0;
        }
    }

    IEnumerator panelAnim()
    {
        yield return new WaitForSeconds(2);
        panelMorir.gameObject.SetActive(true);
    }

    IEnumerator healAnim()
    {
        audioManager.SelectSound(1, 0.5f);
        UI_healEffect.GetComponent<Animator>().SetBool("hasHealed",true);
        yield return new WaitForSeconds(.2f);
        UI_healEffect.GetComponent<Animator>().SetBool("hasHealed", false);
    }


}
