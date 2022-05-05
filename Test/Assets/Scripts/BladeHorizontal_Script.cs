using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeHorizontal_Script : MonoBehaviour
{
    [SerializeField] private GameObject target,objetcive;
    [SerializeField] private float speed,speedRotate;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, objetcive.transform.position, speed * Time.deltaTime);
        transform.Rotate(0, 0, speedRotate * Time.deltaTime);
    }
}

