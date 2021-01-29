using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{
    public float camMoveSpeed = 1.0f;
    public static float limitMax = 4f;
    public static float limitMin = -4f;


    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
           
        transform.Translate(new Vector3(x * Time.deltaTime * camMoveSpeed, 0, 0),Space.World);
 
    }
}
