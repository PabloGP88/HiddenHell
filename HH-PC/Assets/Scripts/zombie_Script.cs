using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_Script : MonoBehaviour
{

    GameObject player;

    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<player_script>().gameObject;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
