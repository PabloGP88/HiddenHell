using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLight_script : MonoBehaviour
{
    public int spawnID;

    private Vector2 pos;

    [SerializeField] float moveSpeed,speedSafe;
    [SerializeField] float posXmin, posXmax, posYmin, posYmax;

    bool playerInRange;

    private GameObject player, topLimit, bottomLimit;
    // Start is called before the first frame update

    private void Awake()
    {
        pos = transform.position;
    }
    void Start()
    {
        player = FindObjectOfType<player_script>().gameObject;
        topLimit = GameObject.Find("LimitTopRight" + spawnID.ToString());
        bottomLimit = GameObject.Find("LimitBottomLeft" + spawnID.ToString());
        posXmax = topLimit.transform.position.x;
        posXmin = bottomLimit.transform.position.x;
        posYmax = topLimit.transform.position.y;
        posYmin = bottomLimit.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = PlayerInRange();
        if (playerInRange)
        {
            Vector2 playerPos = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            transform.position = playerPos;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pos, moveSpeed*Time.deltaTime);
        }
    }
    private bool PlayerInRange()
    {
        if (player.transform.position.x < posXmin || player.transform.position.x > posXmax ||
            player.transform.position.y < posYmin || player.transform.position.y > posYmax)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "light")
        {
            moveSpeed *= 0;
        }
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = speedSafe;
    }


}
