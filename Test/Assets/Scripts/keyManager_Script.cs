using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyManager_Script : MonoBehaviour
{
    public int keyAmount;
    [SerializeField] int keyMax;
    [SerializeField] Text keyCount;

    public bool megaKey;


    // Start is called before the first frame update
    void Start()
    {
        megaKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        keyCount.text = keyAmount.ToString() + "/" + keyMax.ToString();
        if (keyAmount == keyMax) megaKey = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "key")
        { keyAmount++; Destroy(collision.gameObject); }
    }

}
