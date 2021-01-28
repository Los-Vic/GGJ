using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offsetPos;
    // Start is called before the first frame update
    void Start()
    {
        offsetPos = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offsetPos;
    }
}
