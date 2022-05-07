using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] GameObject lantern,blood_effect;
    [SerializeField] Animator animator;

    private GameObject player;
    private Rigidbody2D rb2d;
    private AudioManager_Script audioManager;
    private AudioSource audio;

    Vector2 movment;
        

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audioManager = FindObjectOfType<AudioManager_Script>();
        player = gameObject;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame1
    void Update()
    {

            movment.x = Input.GetAxisRaw("Horizontal");
            movment.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Hspeed", movment.x);
            animator.SetFloat("Vspeed", movment.y);
        
    }

    private void FixedUpdate()
    {
        if (gameObject.GetComponent<life_manager>().alive == true)
        {
            rb2d.MovePosition(rb2d.position + movment * moveSpeed * Time.fixedDeltaTime);
        }
        WalkSoundFX();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && gameObject.tag == "Player")
        {
            Vector2 pos_sangre = new Vector2(transform.position.x, transform.position.y + 0.1f);
            Instantiate(blood_effect, pos_sangre, Quaternion.identity);
            StartCoroutine(hasBeenDamaged());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && gameObject.tag == "Player" || collision.gameObject.tag == "zombie" && gameObject.tag == "Player")
        {
            Vector2 pos_sangre = new Vector2(transform.position.x, transform.position.y + 0.1f);
            Instantiate(blood_effect, pos_sangre, Quaternion.identity);
            StartCoroutine(hasBeenDamaged());
        }
    }

    IEnumerator hasBeenDamaged()
    {
        audioManager.SelectSound(0, 0.5f);
        moveSpeed += 1f;
        animator.SetBool("damaged", true);
        gameObject.tag = "PlayerHit";
        yield return new WaitForSeconds(2.5f);
        moveSpeed -= 1f;
        gameObject.tag = "Player";
        animator.SetBool("damaged", false);
    }

    private void WalkSoundFX()
    {
        if (gameObject.GetComponent<life_manager>().alive == true)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                if (!audio.isPlaying)
                {
                    audio.Play();
                }
            }
            else
            {
                audio.Stop();
            }
        }
        else { audio.Stop(); }
    }

}
