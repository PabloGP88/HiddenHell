using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy_Script : MonoBehaviour
{
    private GameObject player, topLimit, bottomLimit;
    private Animator animator;

    public int spawnID;

    [SerializeField] float moveSpeed,posXmin, posXmax, posYmin, posYmax;
    [SerializeField] private bool inRange;

    Vector2 origin;
    // Start is called before the first frame update

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<player_script>().gameObject;
        origin = transform.position;
    }
    void Start()
    {
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
        inRange = PlayerInRange();
        SetAnimations();
        if (inRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, origin, moveSpeed * Time.deltaTime);
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            animator.SetBool("down", true);
            animator.SetBool("up", false);
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

    private void SetAnimations()
    {
        if (player.transform.position.x > transform.position.x)
        {
            animator.SetBool("left", false);
            animator.SetBool("right", true);
        }
        else if (player.transform.position.x < transform.position.x)
        {
            animator.SetBool("left", true);
            animator.SetBool("right", false);
        }
        if (player.transform.position.y > transform.position.y)
        {
            animator.SetBool("down", false);
            animator.SetBool("up", true);
        }
        else if (player.transform.position.y < transform.position.y)
        {
            animator.SetBool("down", true);
            animator.SetBool("up", false);
        }
    }

}
