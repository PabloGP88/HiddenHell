using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectiveBlade_script : MonoBehaviour
{
    [SerializeField] GameObject target, blade;
    [SerializeField] private float time;
    private Vector3 inicialPos;
    // Start is called before the first frame update
    void Start()
    {
        inicialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (blade.transform.position == transform.position && transform.position != target.transform.position)
        {
            transform.position = target.transform.position;
        }
        if (blade.transform.position == transform.position && transform.position != inicialPos)
        {
            transform.position = inicialPos;
        }
    }

}
