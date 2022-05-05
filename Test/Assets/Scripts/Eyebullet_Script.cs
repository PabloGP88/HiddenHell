using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Eyebullet_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 150f * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
